create database db_bebida;

use db_bebida;

create table tbCategory(
	IdCat int primary key auto_increment,
    StrCategory varchar(50) not null
);

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

alter table tbBebida add constraint fk_idcat foreign key (IdCat) references tbCategory (IdCat);

alter table tbBebida add constraint fk_idingredient foreign key (IdIngredient) references tbIngredient (IdIngredient);