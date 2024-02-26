use master
go
drop database dbAlmoxarifado
create database dbAlmoxarifado
go
use dbAlmoxarifado
go
create table Produto(
   id int identity(1,1) primary key,
   nome  varchar(100) not null,
   estoque int null default(0),
   photourl varchar(255) null
)
SELECT * FROM Produto;
Update Produto set idcategoria = 1 where id = 3; 
Update Produto set idcategoria = 2 where id = 8; 

go
go
Delete from Produto where id = 4;
Delete from Produto where id = 5;
Delete from Produto where id = 6;
Delete from Produto where id = 7;
Insert Produto (nome, estoque,photourl) 
   values ('HP Turbo',20,null)

go
Insert Produto (nome, estoque,photourl) 
   values ('MONITOR GOT',40,null)

go
Insert Produto (nome, estoque,photourl) 
   values ('Caderno',20,null)
   go
Insert Produto (nome, estoque,photourl) 
   values ('mouse',100,null)
go
create table Categoria(
   id int identity(1,1) primary key,
   descricao varchar(max) not null,
)
Insert Categoria (descricao) 
   values ('Informática')
   Insert Categoria (descricao) 
   values ('Papelaria')
Select * from Produto
Select * from Categoria
alter table Produto add idcategoria int;
ALTER TABLE Produto
ADD CONSTRAINT idcategoria
FOREIGN KEY (idcategoria) REFERENCES Categoria(id);
create table Departamneto 
(
id int identity (1,1) primary key,
descricao varchar(100),  
ativo bit,
);
select * from Departamneto;
insert Departamneto(descricao, ativo) values('Financeiro', 1);