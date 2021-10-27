Create Database WishList

Use WishList

Create Table Usuarios(
Id_Usuario Int Primary Key Identity,
Email Varchar(150) Not Null Unique ,
Senha Varchar(15) Not Null Unique 
);
Go

Create Table Desejos(
Id_Desejo Int Primary Key Identity,
Descricao_Desejo Varchar(200) Unique Not Null,
Id_Usuario Int Foreign Key References Usuarios(Id_Usuario)
);
Go