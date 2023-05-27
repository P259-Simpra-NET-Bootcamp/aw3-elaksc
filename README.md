[![Review Assignment Due Date](https://classroom.github.com/assets/deadline-readme-button-24ddc0f5d75046c5622901739e7c5dd533143b0c8e959d652212380cedb1ea36.svg)](https://classroom.github.com/a/gaQlcHTs)
# aw3-template

simapi projesindeki Category ve Product modelleri 1-M relation olacak sekilde yeniden modelleyiniz.
Iki model icin iligli controllerlari yeniden duzenleyiniz. 
Iki modeli iceren bir migration dosyasi hazirlayip ekleyiniz. 
odev icersinde sadece 2 modeli gonderiniz. 

--------
--------

## SimpraApi-W3

This project is that includes the relationships between the Product and Category tables.

### Relationship Description
A Category can have multiple Products (One-to-Many relationship).
A Product can belong to only one Category (Many-to-One relationship).

### Installation

Clone this repository to your local machine or download and extract the zip file.

```bash
git clone https://github.com/P259-Simpra-NET-Bootcamp/aw3-elaksc.git
```
Navigate to the project folder.

```bash
cd aw2-elaksc
```
Compile and run the project.

```bash
dotnet run
```


### One-to-Many Relationship
The One-to-Many relationship allows multiple Products to be associated with a Category. In this project, the Products are linked to a Category through the Category Id field in the Category table.

Example:

Category: Electronics
Products: Phone, Computer, TV
You can add multiple Products to a Category and access the Category to which each Product is associated.




## Contributing
If you have any issues, errors, or suggestions, please open an issue or contribute by submitting a pull request.

- Fork this project and create a local copy.
- Create a separate branch for new features or fixes.
- Make your changes and test your code.
- Commit your changes and push to your branch.
- Propose your changes to the main project by opening a pull request.