using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimApi.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimApi.Data;


[Table("Category", Schema = "dbo")]
public class Category : BaseModel
{
    public string Name { get; set; }  
    public int Order { get; set; }

    //Collection navigation property
    public ICollection<Product> Products { get; set; }

    public bool IsValid { get; set; }
}

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.Property(x => x.Id).IsRequired(true).UseIdentityColumn();
        builder.Property(x => x.CreatedAt).IsRequired(false);
        builder.Property(x => x.CreatedBy).IsRequired(false).HasMaxLength(30);
        builder.Property(x => x.UpdatedAt).IsRequired(false);
        builder.Property(x => x.UpdatedBy).IsRequired(false).HasMaxLength(30);

        builder.Property(x => x.Name).IsRequired(true).HasMaxLength(30);
        builder.Property(x => x.Order).IsRequired(true);
        builder.Property(x => x.IsValid).IsRequired(true).HasDefaultValue(true);

        builder.HasIndex(x=> x.Name).IsUnique(true);


        // Category-Product ilişkisi tanımlaması
        builder.HasMany(x => x.Products)
               .WithOne(x => x.Category)
               .HasForeignKey(x => x.CategoryId)
               .IsRequired(true); 
    }
}