CREATE DATABASE SkiNet
USE SkiNet
GO

CREATE TABLE Products
(
	ProductId int IDENTITY(1,1) PRIMARY KEY,
	ProductName varchar(300),
)
GO

CREATE TABLE ProductType
(
	ProductTypeId int IDENTITY(1,1) PRIMARY KEY,
	ProductTypeName varchar(300)
)
GO

CREATE TABLE ProductBrand
(
	ProductBrandId int IDENTITY(1,1) PRIMARY KEY,
	ProductBrandName varchar(300)
)
GO

ALTER TABLE Products
ADD Description varchar(500)

ALTER TABLE Products
ADD Price decimal

ALTER TABLE Products
ADD PictureUrl varchar(300)

ALTER TABLE Products
ADD ProductTypeId int

ALTER TABLE Products
ADD FOREIGN KEY (ProductTypeId) REFERENCES ProductType(ProductTypeId)

ALTER TABLE Products
ADD ProductBrandId int

ALTER TABLE Products
ADD FOREIGN KEY (ProductBrandId) REFERENCES ProductBrand(ProductBrandId)

select * from Products
GO

select * from ProductType
GO

select * from ProductBrand
GO

alter table Products
drop column ProductDate
Go

insert into Products values ('Product One')

SELECT BulkColumn 
FROM OPENROWSET (
					BULK 'D:\Udemy\UdemyLearning\skinet\Infrastructure\Data\SeedData\products.json',SINGLE_CLOB
				) AS [Json];

SELECT * FROM OPENROWSET(
	BULK 'D:\Udemy\UdemyLearning\skinet\Infrastructure\Data\SeedData\types.json',
	SINGLE_CLOB) AS [Json]
	CROSS APPLY OPENJSON (BulkColumn,'$')
	WITH (
			ProductTypeName varchar(300) '$.Name'
		 ) AS [Types]

select *
FROM OPENROWSET(
	BULK 'D:\Udemy\UdemyLearning\skinet\Infrastructure\Data\SeedData\types.json',
	SINGLE_CLOB) as [json]
	CROSS APPLY OPENJSON (BulkColumn)
	WITH (
			ProductTypeId int '$.Id',
			ProductTypeName varchar(300) '$.Name'
		 ) AS [Types]

-- reading product types.json and inserting data into existing type table --
Declare @JSON varchar(max)
SELECT @JSON=BulkColumn
FROM OPENROWSET (BULK 'D:\Udemy\UdemyLearning\skinet\Infrastructure\Data\SeedData\types.json', SINGLE_CLOB) import
insert into ProductType
SELECT *
FROM OPENJSON (@JSON)
WITH 
(
	ProductTypeName varchar(300) '$.Name'
) 
Go

-- reading product types.json and inserting data into existing brand table --
Declare @JSON varchar(max)
SELECT @JSON=BulkColumn
FROM OPENROWSET (BULK 'D:\Udemy\UdemyLearning\skinet\Infrastructure\Data\SeedData\brands.json', SINGLE_CLOB) import
insert into ProductBrand
SELECT *
FROM OPENJSON (@JSON)
WITH 
(
	ProductBrandName varchar(300) '$.Name'
)
GO

-- reading products.json and inserting data into existing products table --
Declare @JSON varchar(max)
SELECT @JSON=BulkColumn
FROM OPENROWSET (BULK 'D:\Udemy\UdemyLearning\skinet\Infrastructure\Data\SeedData\products.json', SINGLE_CLOB) import
insert into Products
SELECT *
FROM OPENJSON (@JSON)
WITH                
(
	ProductName varchar(300) '$.Name',
	Description varchar(500) '$.Description',
	Price decimal '$.Price',
	PictureUrl varchar(300) '$.PictureUrl',
	ProductTypeId int '$.ProductTypeId',
	ProductBrandId int '$.ProductBrandId'
)
GO

delete from ProductType
select * from ProductType
select * from ProductBrand

select * from Products