use master
go
drop database dbAlmoxarifado
create database dbAlmoxarifado
go
use dbAlmoxarifado
go

Create table Funcionario(
 id int identity(1,1) primary key,
 nome varchar(100) not null,
 carga varchar(100) not null,
 datanascimento datetime,
 salario decimal,
 endereco varchar(100) not null,
 cidade varchar(100) not null,
 uf varchar(100) not null,
 idDepartamento int not null
)
select * from Funcionario 
select * from Departamento WHERE descricao = 'peste';
alter table Funcionario drop column uf;
insert into Funcionario(nome, carga,salario, endereco, cidade, idDepartamento) values ('Vinicius','Contador',2.000, 'Rua Castelo Branco', 'Estância', 1);
insert into Funcionario(nome, carga,salario, endereco, cidade, idDepartamento) values ('Julia','Contadora',1.000, 'Rua Castelo Preto', 'Estância', 1);
insert into Funcionario(nome, carga,salario, endereco, cidade, idDepartamento) values ('José','Técnico',2.000, 'Rua Lua', 'Aracaju', 3);
insert into Funcionario(nome, carga,salario, endereco, cidade, idDepartamento) values ('Maria','Receptora',2.000, 'Rua Lua', 'Aracaju', 2);
insert into Funcionario(nome, carga,salario, endereco, cidade, idDepartamento) values ('Rafael','Técnico',2.000, 'Rua Lua', 'Aracaju', 3);



Create table Departamento(
  id int identity(1,1) primary key,
  descricao varchar(100) not null,
  situacao varchar(100) 
)
select * from Departamento;
insert into Departamento(descricao, situacao) values ('Contagem do Estoque','ativo');
insert into Departamento(descricao, situacao) values ('Recebimento de Carga','ativo');
insert into Departamento(descricao, situacao) values ('Informática','desativado');
insert into Departamento(descricao, situacao) values ('peste','desativado');


ALTER TABLE Funcionario 
ADD CONSTRAINT IDDepartamento
FOREIGN KEY (idDepartamento) REFERENCES Departamento(id);

Create table CategoriaMotivo
(
id int identity(1,1) primary key,
descricao varchar(100) not null,

)
Create Table Motivo
(
MotID int identity (1,1) primary key,
MotDescricao varchar(200),
)
ALTER TABLE Motivo 
ADD CONSTRAINT IDCategoriadoMotivo
FOREIGN KEY (MotID) REFERENCES CategoriaMotivo(id);

create table Produto(
   id int identity(1,1) primary key,
   nome  varchar(100) not null,
   estoque int null default(0),
   photourl varchar(max) null
) 
Create table Requisicao
(
ReqID int identity (1,1) primary key,
ReqData date,
iddepartamento int,
idfuncionario int,
idmotivo int,
iditens int
)


ALTER TABLE Requisicao 
ADD CONSTRAINT idfuncionario
FOREIGN KEY (idfuncionario) REFERENCES Funcionario(id);

ALTER TABLE Requisicao 
ADD CONSTRAINT idmotivo
FOREIGN KEY (idmotivo) REFERENCES Motivo(MotID);


Create table itens
(
iditens int identity (1,1) primary key,
idrequisicao int,
codigoProduto int,
preco decimal,
quantidade int
)

ALTER TABLE itens 
ADD CONSTRAINT iditens
FOREIGN KEY (iditens) REFERENCES Requisicao(ReqID);

ALTER TABLE itens 
ADD CONSTRAINT idproduto
FOREIGN KEY (codigoProduto) REFERENCES Produto(id);

go
Insert Produto (nome, estoque,photourl) values ('HP Turbo',20,null)
go
Insert Produto (nome, estoque,photourl) values ('MONITOR GOT',40,null)
/*insert select



