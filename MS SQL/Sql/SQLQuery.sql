

CREATE TABLE StoreImages3008 (
    Id INT PRIMARY KEY IDENTITY(1,1),
    ImageData VARBINARY(MAX),
	ImageLocation NVARCHAR(MAX),
	IsActive bit Default 1,
	IsDeleted bit Default 0
);

---Drop table StoreImages3008

Select * from StoreImages3008


truncate table StoreImages3008





--------- Another Table --------
--Select * from FileUpload070723