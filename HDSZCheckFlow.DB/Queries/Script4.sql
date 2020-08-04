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

SELECT h.ApplySheetHead_Pk, h.ApplyTypeCode, h.ApplyDate, h.ApplyDeptClassCode, 
      h.ApplyDeptCode, h_b.SubmitType
FROM ApplySheetHead h INNER JOIN
      ApplySheetHead_Budget h_b ON h.ApplySheetHead_Pk = h_b.ApplySheetHead_Pk

SELECT h.ApplySheetHead_Pk, h.ApplyTypeCode, h.ApplyDate, h.ApplyDeptClassCode, 
      h.ApplyDeptCode, h_b.SubmitType
FROM ApplySheetHead h INNER JOIN
      ApplySheetHead_Budget h_b ON h.ApplySheetHead_Pk = h_b.ApplySheetHead_Pk
GO

GRANT EXEC ON Stored_Procedure_Name TO PUBLIC

GO
