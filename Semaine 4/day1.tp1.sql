use master;
GO
drop database skirental;
GO
create database skirental;
GO

use skirental;

create table customers(
	id  numeric(6),
	name varchar(30) not null,
	firstname varchar(30),
	adress varchar(120),
	zip varchar(5) not null,
	city  varchar(80) not null default 'NANTES',
	constraint pk_customers_id  primary key(id),
	constraint ck_customers_zip check(zip between '01000' and '95999')
);

GO
create table cards(
	id numeric(6),
	customer numeric(6) not null,
	createdAt datetime not null default getDate(),
	payedAt datetime,
	"state" char(2) not null default 'EC' constraint ck_cards_state check("state" in('EC','RE','SO')),
	constraint fk_cards_customers foreign key(customer) references customers(id) on delete cascade,
	constraint pk_cards_id  primary key(id),
	constraint ck_cards_payedAt check((createdAt<payedAt and "state"='SO') or ("state"<>'SO' and payedAt = null)),
);
GO

create table cardlines(
	"card" numeric(6),
	line  numeric(3),
	refart char(8) not null,
	dtout datetime not null default getDate(),
	dtin datetime,
	constraint pk_cardlines primary key("card",line),
	constraint fk_cardlines_card foreign key("card") references cards(id) on delete cascade,
	constraint ck_cardlines_dtin check(dtout<dtin)
);
GO

create table prices(
	id char(5),
	label varchar(30),
	dayprice numeric(5,2) not null constraint ck_prices_dayprice check(0<=dayprice),
	constraint pk_prices primary key(id),
	constraint unique_prices_label unique(label)
);
GO

create table qualities(
	id char(5),
	label varchar(30) not null,
	constraint pk_quality primary key(id), 
	constraint unique_quality_label unique(label)
);
GO

create table categories(
	id char(5) primary key,
	label varchar(30) not null,
	constraint unique_category_label unique(label)
);
GO


create table pricelist(
	quality char(5) not null,
	category char(5) not null,
	price char(5) not null,
	constraint pk_pricelist primary key(quality,category),
	constraint fk_pricelist_quality foreign key(quality) references qualities(id),
	constraint fk_pricelist_category foreign key(category) references categories(id),
	constraint fk_pricelist_prices foreign key(price) references prices(id)
);
GO

create table articles(
	refart char(8),
	designation varchar(80) not null,
	quality char(5) not null,
	category char(5) not null,
	constraint pk_articles primary key(refart),
	constraint fk_pricelist foreign key (quality,category) references pricelist(quality,category)
);
GO
