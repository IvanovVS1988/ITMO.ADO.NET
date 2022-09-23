USE [master]
GO
CREATE DATABASE [FinalTask_Ado.net]
GO
USE [FinalTask_Ado.net]
GO

CREATE TABLE Customers( 
	[CustomerID] int IDENTITY(1,1) PRIMARY KEY NONCLUSTERED NOT NULL,
	[FirstName] varchar(20) NOT NULL,
	[LastName] varchar(20) NOT NULL,
	[Country] varchar(20)  NOT NULL,
	[City] varchar(20)  NOT NULL)
	ON [PRIMARY];
GO

CREATE TABLE Orders(
	[OrderID] int IDENTITY(1,1) PRIMARY KEY NONCLUSTERED NOT NULL,
	[CustomerID] int FOREIGN KEY REFERENCES Customers(CustomerID),
	[Product] varchar(20) NOT NULL,
	[Number] bigint NOT NULL,
	[Price] money  NOT NULL,
	[Discount] decimal(4,3) NOT NULL DEFAULT (0))
	ON [PRIMARY];
GO

INSERT INTO Customers ([FirstName], [LastName], [Country], [City])
	VALUES ('Vladimir', 'Ivanov', 'Russia', 'Saint-Petersburg'),
		('Sergei', 'Ivanov', 'Russia', 'Saint-Petersburg'),
		('Petr', 'Popov', 'Russia', 'Moscow'),
		('Vadim', 'Petrov', 'USA', 'New-York'),
		('Vadim', 'Ivanov', 'USA', 'New-York'),
		('Anna', 'Popova', 'USA', 'New-York'),
		('Julia', 'Petrova', 'USA', 'Chicago'),
		('Maria', 'Ivanova', 'USA', 'Chicago'),
		('Alexandr', 'Ivanov', 'Russia', 'Moscow'),
		('Alexandr', 'Petrov', 'Russia', 'Saint-Petersburg');
GO

INSERT INTO Orders ([CustomerID], [Product], [Number], [Price], [Discount])
	VALUES (1, 'Product CBRRL',  12.00,  548, 0.250),
		(2, 'Product TTEEX',   9.65,  981, 0.250),
		(3, 'Product ICKNK',  43.90,  445, 0.250),
		(4, 'Product HMLNI',  30.00,  763, 0.200),
		(5, 'Product HLGZA',  31.23,  753, 0.250),
		(6, 'Product QMVUN',  21.00,  706, 0.250),
		(7, 'Product WUXYK',  49.30, 1083, 0.250),
		(8, '(Product YYWRT',  24.00,  903, 0.250),
		(9, 'Product ASTMN',   2.50,  755, 0.250),
		(10, 'Product POXFU',   6.00,  891, 0.250),
		(1, 'Product AOZBW',  97.00,   95, 0.250),
		(2, 'Product OFBNT',  45.60,  640, 0.250),
		(3, 'Product VJZZH',  10.00, 1016, 0.250),
		(4, 'Product SMIOH',  43.90,  365, 0.250),
		(5, 'Product BIUDV',  16.25,  235, 0.100),
		(6, 'Product LUNZZ',  13.00,  791, 0.250),
		(7, 'Product HHYDP',  18.00,  828, 0.250),
		(8,'Product NUNAW',  32.00,  297, 0.200),
		(9, 'Product CKEDC',  62.50,  539, 0.250),
		(10, 'Product YHXGE',  31.00,  742, 0.250),
		(1, 'Product XKXDO',   9.20,  723, 0.250),
		(2, 'Product COAXA',  36.00,  714, 0.250),
		(3, 'Product QHFFP',  81.00,  313, 0.250),
		(4, 'Product APITJ',  53.00,  886, 0.250),
		(5, 'Product LYERX',  25.89,  612, 0.250),
		(6, 'Product YZIXQ',  18.40, 1103, 0.250),
		(7, 'Product HCQDE',  33.25,  740, 0.250),
		(8, 'Product MYMOI',  21.50, 1057, 0.250),
		(9, 'Product ZZZHR',  46.00,  580, 0.250),
		(10, 'Product AQOKR',   9.50,  508, 0.200),
		(1, 'Product LSOFL',  18.00,  793, 0.250),
		(2, 'Product OSFNS',  38.00,  344, 0.250),
		(3, 'Product VJIEO',  19.45,  601, 0.250),
		(4, 'Product WEUJZ',  15.00,  293, 0.200),
		(5, 'Product TOONT',  15.00,  817, 0.250),
		(6, 'Product VAIIV',  25.00,  301, 0.250),
		(7, 'Product XYZPE',  28.50,  603, 0.250),
		(8, 'Product WHBYK',  34.00, 1577, 0.250),
		(9, 'Product QSRXF',   7.00,  500, 0.250),
		(10,'Product EVFFA',  26.00,  125, 0.200),
		(1, 'Product XLXQF',  14.00,  184, 0.250),
		(2, 'Product GMKIJ',  19.00,  805, 0.250),
		(3, 'Product OVLQI',  19.50,  434, 0.250),
		(4, 'Product QAQRL',   7.45,  755, 0.250),
		(5, 'Product RJVNM',  14.00,  697, 0.250),
		(6, 'Product KSZOI',  15.50,  122, 0.050),
		(7, 'Product BLCAX',  39.00,  978, 0.250),
		(8, 'Product BKAZJ',  10.00,  297, 0.250),
		(9, 'Product PAFRH',  17.45, 1158, 0.250),
		(10, 'Product IMEHJ',  10.00,  328, 0.100),
		(1, 'Product XYWBZ',  21.05,  745, 0.200),
		(2, 'Product CPHFY',  21.00,  348, 0.250),
		(3, 'Product WVJFP',  40.00,  372, 0.250),
		(4, 'Product LYLNI',  14.00,  318, 0.250),
		(5, 'Product JLUDZ',   9.00,  580, 0.250),
		(6, 'Product XWOXC',  12.50, 1397, 0.250),
		(7, 'Product VKCMF',  38.00, 1263, 0.250),
		(8, 'Product BKGEA',  32.80,  722, 0.200),
		(9, 'Product MYNXN',  12.75,  138, 0.150),
		(10, 'Product JYGFE',  18.00,  981, 0.250),
		(1, 'Product RECZE',  19.00, 1057, 0.250),
		(2, 'Product LQMGN',  17.00,  239, 0.150),
		(3, 'Product EZZPR',   9.50,  485, 0.250),
		(4, 'Product FPYPN',  20.00,  520, 0.150),
		(5, 'Product NEVTJ',  18.00,  883, 0.250),
		(6, 'Product QOGNU',   4.50, 1125, 0.250),
		(7, 'Product QDOMO', 263.50,  623, 0.250),
		(8, 'Product GEEOO',  34.80,  806, 0.250),
		(9, 'Product SWNJY',  14.00,  506, 0.250),
		(10, 'Product KSBRM',  22.00,  453, 0.250),
		(1, 'Product BWRLG',   7.75, 1155, 0.250),
		(2, 'Product EPEIM',  21.35,  298, 0.250),
		(3, 'Product ACRVI',  13.25,  534, 0.250),
		(4, 'Product PWCJB',  23.25,  404, 0.250),
		(5, 'Product UKXRI',  55.00, 1496, 0.250),
		(6, 'Product VJXYN', 123.79,  746, 0.250),
		(7, 'Product TBTBL',  12.50,  799, 0.250);