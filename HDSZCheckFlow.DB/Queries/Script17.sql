IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Stored_Procedure_Name')
	BEGIN
		PRINT 'Dropping Procedure Stored_Procedure_Name'
		DROP  Procedure  Stored_Procedure_Name
	END

GO

PRINT 'Creating Procedure Stored_Procedure_Name'
GO
CREATE Procedure Stored_Procedure_Name
	/* Param List */
AS

/******************************************************************************
**		File: 
**		Name: Stored_Procedure_Name
**		Desc: 
**
**		This template can be customized:
**              
**		Return values:
** 
**		Called by:   
**              
**		Parameters:
**		Input							Output
**     ----------							-----------
**
**		Auth: 
**		Date: 
*******************************************************************************
**		Change History
*******************************************************************************
**		Date:		Author:				Description:
**		--------		--------				-------------------------------------------
**    
*******************************************************************************/


SELECT Base_AccountSubject.subjectCode, Base_AccountSubject.subjectName
FROM Base_AccountSubject INNER JOIN
      Base_CommonRelation ON 
      Base_AccountSubject.subjectCode = Base_CommonRelation.sunCode
WHERE (Base_AccountSubject.IsEnd = 'y') AND (Base_AccountSubject.DR = 0) AND 
      (LEFT(Base_AccountSubject.subjectCode, 4) = '5502') AND 
      (Base_CommonRelation.type = 'secendstep') AND 
      (Base_CommonRelation.fatherCode = '16')












GO

GRANT EXEC ON Stored_Procedure_Name TO PUBLIC

GO
