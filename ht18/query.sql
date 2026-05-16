CREATE TABLE Categories (
	Id INT IDENTITY(1, 1),
	CategoryName VARCHAR(80),

	PRIMARY KEY (Id)
	);

CREATE TABLE Books (
	Id INT IDENTITY(1, 1),
	Title VARCHAR(80) NOT NULL,
	Price INT,
	CategoryId INT,
	IsDeleted BIT DEFAULT 0,

	PRIMARY KEY (Id),
	FOREIGN KEY (CategoryId) REFERENCES Categories (Id) ON DELETE CASCADE
	);


SELECT Title, Price
FROM Books
WHERE Price > 300
ORDER BY Price DESC;

INSERT INTO Categories (CategoryName)
VALUES ('Programming');

INSERT INTO Books (Title, Price, CategoryId)
VALUES ('Clean Code', 600, 1);

UPDATE Books
SET Price = 750
WHERE Id = 1;

SELECT Books.Title, Categories.CategoryName
FROM Books
INNER JOIN Categories ON Books.CategoryId = Categories.Id;

SELECT CategoryId, COUNT(*) AS TotalBooks
FROM Books
GROUP BY CategoryId;

UPDATE Books
SET IsDeleted = 1
WHERE Id = 5;