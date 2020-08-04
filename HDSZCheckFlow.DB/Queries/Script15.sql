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


SELECT applySheetCheckRecord.CheckComment, applySheetCheckRecord.IsPass, 
      ApplySheetHead.ApplySheetNo, ApplySheetHead.ApplyDate, 
      ApplySheetHead.ApplySheetHead_Pk, Base_Person_Check.personCode, 
      Base_Person_Check.Name AS CheckName, applySheetCheckRecord.IsDisplays, 
      applySheetCheckRecord.DisplaysPersonCode, 
      Base_Person_Displays.Name AS displayName, applySheetCheckRecord.Checkdate, 
      CASE isdisplays WHEN 1 THEN rtrim(Base_Person_Check.Name) 
      + ' ´ú ' + Base_Person_Displays.Name ELSE rtrim(Base_Person_Check.Name) 
      END AS FullCheckName, applySheetCheckRecord.CheckRole, 
      CheckRole.CheckRoleName
FROM Base_Person Base_Person_Check RIGHT OUTER JOIN
      CheckRole INNER JOIN
      applySheetCheckRecord ON 
      CheckRole.CheckRoleCode = applySheetCheckRecord.CheckRole ON 
      Base_Person_Check.personCode = applySheetCheckRecord.CheckPersonCode LEFT OUTER
       JOIN
      Base_Person Base_Person_Displays ON 
      applySheetCheckRecord.DisplaysPersonCode = Base_Person_Displays.personCode LEFT
       OUTER JOIN
      ApplySheetHead ON 
      applySheetCheckRecord.ApplySheetHead_Pk = ApplySheetHead.ApplySheetHead_Pk
GO

GRANT EXEC ON Stored_Procedure_Name TO PUBLIC

GO
