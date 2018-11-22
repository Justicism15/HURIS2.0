use HURIS3
go

IF EXISTS (SELECT * FROM sys.procedures WHERE name = 'usp_UserLogin')
	DROP procedure usp_UserLogin
GO
CREATE procedure usp_UserLogin
(
	@UserAccess VARCHAR(100),
	@UserPassword VARCHAR(32)

)
WITH ENCRYPTION
AS
BEGIN TRANSACTION
SET NOCOUNT OFF

	SELECT * FROM SystemUsers WHERE UserName = @UserAccess AND UserPassword = @UserPassword; 
	--SELECT SCOPE_IDENTITY()

IF @@ERROR <> 0 
	BEGIN
		ROLLBACK TRANSACTION
		RAISERROR ('Error',16,1)
		END
	COMMIT TRANSACTION
GO

IF EXISTS (SELECT * FROM sys.procedures WHERE name = 'usp_EmployeeSearch')
	DROP PROCEDURE [usp_EmployeeSearch]
GO
CREATE PROCEDURE [usp_EmployeeSearch]
(
	@Keywords NVARCHAR(180)
)
WITH ENCRYPTION 
AS
SET NOCOUNT OFF
	Select *
	FROM Employees 
	where (FirstName like '%' + @Keywords + '%' OR LastName like '%' + @Keywords + '%') 
			OR (CONCAT (FirstName, ' ' , LastName ) Like '%' + @Keywords + '%') 
			OR (CONCAT (LastName, ', ' , FirstName ) Like '%' + @Keywords + '%')
			OR (CONCAT (LastName, ',' , FirstName ) Like '%' + @Keywords + '%')  
GO



IF EXISTS (SELECT * FROM sys.procedures WHERE name = 'usp_EmployeeRegistration')
	DROP procedure usp_EmployeeRegistration
GO
CREATE procedure usp_EmployeeRegistration
(
	@fname VARCHAR(100),
	@lname VARCHAR(100),
	@mname VARCHAR(100),
	@gender VARCHAR(12),
	@dob DATE,
	@suffix VARCHAR(1) = NULL,
	@empcode VARCHAR(12),
	@phone VARCHAR(100)
)
WITH ENCRYPTION
AS
BEGIN TRANSACTION
SET NOCOUNT OFF

	INSERT INTO Employees
	(
		FirstName,LastName,MiddleName,Suffix,Gender,Birthdate,EmpCode,PhoneNo
	)
	VALUES
	(
		@fname, @lname, @mname, @suffix, @gender, @dob, @empcode, @phone
	)
	--SELECT SCOPE_IDENTITY()

IF @@ERROR <> 0 
	BEGIN
		ROLLBACK TRANSACTION
		RAISERROR ('Error',16,1)
		END
	COMMIT TRANSACTION
GO



IF EXISTS (SELECT * FROM sys.procedures WHERE name = 'usp_EmpRelativeRegistration')
	DROP procedure usp_EmpRelativeRegistration
GO
CREATE procedure usp_EmpRelativeRegistration
(
	@fname VARCHAR(100),
	@lname VARCHAR(100),
	@mname VARCHAR(100),
	@relationship VARCHAR(100),
	@address VARCHAR(500),
	@email VARCHAR(100),
	@contact VARCHAR(500),
	@empID INT
)
WITH ENCRYPTION
AS
BEGIN TRANSACTION
SET NOCOUNT OFF

	INSERT INTO EmployeeRelatives
	(
		FirstName,LastName,MiddleName,Relationship, HomeAddress, Email, ContactNo, EmpID
	)
	VALUES
	(
		@fname, @lname, @mname, @relationship, @address,@email,@contact, @empID
	)
	--SELECT SCOPE_IDENTITY()

IF @@ERROR <> 0 
	BEGIN
		ROLLBACK TRANSACTION
		RAISERROR ('Error',16,1)
		END
	COMMIT TRANSACTION
GO


IF EXISTS (SELECT * FROM sys.procedures WHERE name = 'usp_ViewEmployeeRelatives')
	DROP procedure usp_ViewEmployeeRelatives
GO
CREATE procedure usp_ViewEmployeeRelatives
(
	@EmpID INT
)
WITH ENCRYPTION
AS
BEGIN TRANSACTION
SET NOCOUNT OFF

	SELECT EmpId,FirstName, MiddleName, LastName, ContactNo, Email, Relationship FROM EmployeeRelatives where EmpID = @EmpID;
	--SELECT SCOPE_IDENTITY()

IF @@ERROR <> 0 
	BEGIN
		ROLLBACK TRANSACTION
		RAISERROR ('Error',16,1)
		END
	COMMIT TRANSACTION
GO



IF EXISTS (SELECT * FROM sys.procedures WHERE name = 'usp_UserRegistration')
	DROP procedure usp_UserRegistration
GO
CREATE procedure usp_UserRegistration
(
	@useraccess VARCHAR(100),
	@userpassword VARCHAR(32),
	@empNumber VARCHAR(12),
	@empType VARCHAR(100)

)
WITH ENCRYPTION
AS
BEGIN TRANSACTION
SET NOCOUNT OFF

	INSERT INTO SystemUsers
	(
		UserName, UserPassword, EmployeeNumber, UserType
	)
	VALUES
	(
		@useraccess, @userpassword, @empNumber, @empType
	)
	--SELECT SCOPE_IDENTITY()

IF @@ERROR <> 0 
	BEGIN
		ROLLBACK TRANSACTION
		RAISERROR ('Error',16,1)
		END
	COMMIT TRANSACTION
GO



IF EXISTS (SELECT * FROM sys.procedures WHERE name = 'usp_UserSearch')
	DROP PROCEDURE usp_UserSearch
GO
CREATE PROCEDURE usp_UserSearch
(
	@Keywords NVARCHAR(180)
)
WITH ENCRYPTION 
AS
SET NOCOUNT OFF
	Select *
	FROM SystemUsers
	where (EmployeeNumber like '%' + @Keywords + '%' OR EmployeeNumber like '%' + @Keywords + '%');
GO


IF EXISTS (SELECT * FROM sys.procedures WHERE name = 'usp_UserRecords')
	DROP PROCEDURE usp_UserRecords
GO
CREATE PROCEDURE usp_UserRecords
(
	@UserID INT
)
WITH ENCRYPTION 
AS	
SET NOCOUNT OFF
	SELECT * FROM SystemUsers where UserID = @UserID;
GO


IF EXISTS (SELECT * FROM sys.procedures WHERE name = 'usp_UserDetailsUpdate')
	DROP procedure usp_UserDetailsUpdate
GO
CREATE procedure usp_UserDetailsUpdate
(
	@useraccess VARCHAR(100),
	@UserID INT,
	@userpassword VARCHAR(32),
	@EmployeeNumber VARCHAR(12),
	@UserType VARCHAR(100)

)
WITH ENCRYPTION
AS
BEGIN TRANSACTION
SET NOCOUNT OFF

	UPDATE SystemUsers SET UserName = @useraccess, UserPassword = @userpassword, EmployeeNumber =@EmployeeNumber,
	UserType = @UserType where UserID = @UserID;
	--SELECT SCOPE_IDENTITY()

IF @@ERROR <> 0 
	BEGIN
		ROLLBACK TRANSACTION
		RAISERROR ('Error',16,1)
		END
	COMMIT TRANSACTION
GO



IF EXISTS (SELECT * FROM sys.procedures WHERE name = 'usp_GetEmployeeID')
	DROP procedure usp_GetEmployeeID
GO
CREATE procedure usp_GetEmployeeID
(
	@empCode NVARCHAR(100)
)
WITH ENCRYPTION
AS
BEGIN TRANSACTION
SET NOCOUNT OFF

	SELECT EmpID From Employees WHERE EmpCode = @empCode;

IF @@ERROR <> 0 
	BEGIN
		ROLLBACK TRANSACTION
		RAISERROR ('Error',16,1)
		END
	COMMIT TRANSACTION
GO

IF EXISTS (SELECT * FROM sys.procedures WHERE name = 'usp_EmployeeIndividualRecord')
	DROP procedure usp_EmployeeIndividualRecord
GO
CREATE procedure usp_EmployeeIndividualRecord
(
	@EmpID Int

)
WITH ENCRYPTION
AS
BEGIN TRANSACTION
SET NOCOUNT OFF

	SELECT * From Employees where EmpID = @EmpID;

IF @@ERROR <> 0 
	BEGIN
		ROLLBACK TRANSACTION
		RAISERROR ('Error',16,1)
		END
	COMMIT TRANSACTION
GO