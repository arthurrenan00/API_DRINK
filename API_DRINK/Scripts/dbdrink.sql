create database db_bebida;

use db_bebida;

create table tbCategory(
	IdCat int primary key auto_increment,
    StrCategory varchar(50) not null
);

insert into tbIngredient(StrIngredient) values ("Limão");

create table tbIngredient(
	IdIngredient int primary key auto_increment,
    StrIngredient varchar(50) not null
);


create table tbBebida (
	IdDrink int primary key,
    IdCat int,
    IdIngredient int,
    StrDrink varchar(50) not null,
    StrInstructions varchar(150) not null,
    StrDrinkThumb varchar(100)
);

insert into tbBebida values(2, 1, 1, "Chá de limão", "misture o limão na água e esquente", "www.google.com"); 

alter table tbBebida add constraint fk_idcat foreign key (IdCat) references tbCategory (IdCat);

alter table tbBebida add constraint fk_idingredient foreign key (IdIngredient) references tbIngredient (IdIngredient);

create view vm_Bebida as select tbBebida.IdDrink, tbBebida.StrDrink, tbCategory.StrCategory, 
tbIngredient.StrIngredient, tbBebida.StrInstructions, tbBebida.StrDrinkThumb 
from tbBebida inner join tbCategory on tbCategory.IdCat = tbBebida.IdCat
inner join tbIngredient on tbIngredient.IdIngredient = tbBebida.IdIngredient;


select * from vm_Bebida;