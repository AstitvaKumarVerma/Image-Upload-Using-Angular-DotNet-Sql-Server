CREATE TABLE StoreImages3008 (
    Id INT PRIMARY KEY IDENTITY(1,1),
    ImageData VARBINARY(MAX),
	ImageLocation NVARCHAR(MAX),
	IsActive bit Default 1,
	IsDeleted bit Default 0
);



Select * from StoreImages3008

