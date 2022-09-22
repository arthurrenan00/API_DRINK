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

insert into tbCategory (StrCategory) values ("Quente");
insert into tbIngredient (StrIngredient) values ("Água, Limão");
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

drop procedure spInsertBebida;

delimiter $$
create procedure spInsertBebida(vStrIngredient varchar(50), vStrCategory varchar(50),
vIdDrink int, vStrDrink varchar(50), vStrInstructions varchar(150), 
vStrDrinkThumb varchar(100))
begin
		if not exists (select StrIngredient from tbIngredient where StrIngredient = vStrIngredient limit 1) then
			insert into tbIngredient (StrIngredient) values (vStrIngredient);
		END If;
        
        if not exists (select StrCategory from tbCategory where StrCategory = vStrCategory limit 1) then
			insert into tbCategory (StrCategory) values (vStrCategory);
		END If;
    
    insert into tbBebida values (vIdDrink, (select IdCat from tbCategory where StrCategory = vStrCategory limit 1),
    (select IdIngredient from tbIngredient where StrIngredient = vStrIngredient limit 1), vStrDrink, vStrInstructions, vStrDrinkThumb);
end;
$$

call spInsertBebida("Laranja", "Frio", 6, "Suco de laranja", "Esprema a laranja em um copo de 200ml de água", "www.google.com");

update tbBebida set StrDrink="LIMAO", StrInstructions="Amasse :)", StrDrinkThumb="www.google.com" where IdDrink=8;
        