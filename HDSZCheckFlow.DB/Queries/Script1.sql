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
**    c查询审批记录用
*******************************************************************************/

SELECT rec.*, ApplyType.ApplyTypeName, per.Name,
          (SELECT name
         FROM base_person per
         WHERE per.personcode = rec.displayspersoncode AND isdisplays = 1) 
      AS displaysName
FROM applySheetCheckRecord rec INNER JOIN
      ApplySheetHead ON 
      rec.ApplySheetHead_Pk = ApplySheetHead.ApplySheetHead_Pk INNER JOIN
      ApplyType ON 
      ApplySheetHead.ApplyTypeCode = ApplyType.ApplyTypeCode INNER JOIN
      Base_Person per ON rec.CheckPersonCode = per.personCode


GO

GRANT EXEC ON Stored_Procedure_Name TO PUBLIC

GO
