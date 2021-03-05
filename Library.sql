create database LibraryDatabase;

use LibraryDatabase;

create table Visitors (
	id int primary key identity,
	[name] nvarchar(50) check([name]<>N'') unique not null
)

create table Books (
	id int primary key identity,
	[name] nvarchar(50) check([name]<>N'') unique not null,
)

create table BooksVisitors (
	id int primary key identity,
	bookId int,
	constraint FK_LibraryDB_bookId foreign key(bookId) references Books(id),
	visitorId int,
	constraint FK_LibraryDB_visitorId foreign key(visitorId) references Visitors(id)
)

Select b.id, b.name from Books b
join BooksVisitors bv on b.id = bv.bookId
where bv.visitorId = 2;


create table Authors (
	id int primary key identity,
	[name] nvarchar(50) check([name]<>N'') unique not null
)

create table BooksAuthors (
	id int primary key identity,
	bookId int,
	constraint FK_BooksAuthors_bookId foreign key(bookId) references Books(id),
	authorId int,
	constraint FK_BooksAuthors_authorId foreign key(authorId) references Authors(id)
)

create table LibraryBooks (
	id int primary key identity,
	BooksAuthorsId int,
	constraint FK_LibraryBooks_BooksAuthorsId foreign key(BooksAuthorsId) references BooksAuthors(id),
	BooksVisitorsId int,
	constraint FK_LibraryBooks_BooksVisitorsId foreign key(BooksVisitorsId) references BooksVisitors(id)
)

insert into Books values ('Преступление и наказание');
insert into Books values ('Мастер и маргарита');
insert into Books values ('Процесс')
insert into Books values ('Превращение')
insert into Books values ('Зов Ктулху')
insert into Books values ('Шепчущий в ночи')

select * from Books

insert into Authors values ('Франц Кафка');
insert into Authors values ('Федор Достоевский');
insert into Authors values ('Михаил Булгаков');
insert into Authors values ('Фридрих Ницше');
insert into Authors values ('Говард Лавкрафт');

select * from Authors
select * from Books

insert into BooksAuthors values (1,2);
insert into BooksAuthors values (2,3);
insert into BooksAuthors values (3,1);
insert into BooksAuthors values (4,1);
insert into BooksAuthors values (3,4);

select a.name, b.name from BooksAuthors ba
join Books b on b.id = ba.bookId
join Authors a on a.id = ba.authorId;

insert into Visitors values ('Олег Монгол');
insert into Visitors values ('Влад Демон');
insert into Visitors values ('Кирилл Вжлинк');
insert into Visitors values ('Михаил Павлович');
insert into Visitors values ('Руслан Гительман');

select * from Books;
select * from Visitors

select b.name, v.name from BooksVisitors bv
join Books b on b.id = bv.bookId
join Visitors v on v.id = bv.visitorId

select * from Books 
where id != (select bookId from BooksVisitors);

insert into BooksVisitors values (2, 2);
insert into BooksVisitors values (1, 3);
insert into BooksVisitors values (3, 1);
insert into BooksVisitors values (5, 4);

select * from BooksVisitors

delete from BooksVisitors;