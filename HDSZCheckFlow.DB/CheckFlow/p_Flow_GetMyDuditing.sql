IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'p_Flow_GetMyDuditing')
	BEGIN
		PRINT 'Dropping Procedure p_Flow_GetMyDuditing'
		DROP  Procedure  p_Flow_GetMyDuditing
	END

GO

PRINT 'Creating Procedure p_Flow_GetMyDuditing'
GO
CREATE Procedure p_Flow_GetMyDuditing
	@PersonCode varchar(50) 
AS

/******************************************************************************
**		File: 
**		Name: p_Flow_GetMyDuditing
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

SELECT ApplySheetHead.ApplySheetHead_Pk, CheckFlowInDept.CheckPersonCode  into #temp 
FROM ApplySheetHead INNER JOIN
      CheckFlowInDept ON 
      ApplySheetHead.ApplyDeptCode = CheckFlowInDept.DeptCode AND 
      ApplySheetHead.CheckSetp = CheckFlowInDept.CheckSetp INNER JOIN
      ApplyProcessType type ON 
      ApplySheetHead.ApplyProcessCode = type.ApplyProcessTypeCode 
WHERE (ApplySheetHead.IsCheckInCompany = 0) AND (type.IsFinishInCompany = 0)
union all 
SELECT  h.ApplySheetHead_Pk,pir.PersonCode 
FROM ApplySheetHead h INNER JOIN 
      CheckPersonInRole pir ON h.CurrentCheckRole = pir.CheckRoleCode INNER JOIN
      ApplyProcessType type ON 
      h.ApplyProcessCode = type.ApplyProcessTypeCode 
WHERE (h.IsCheckInCompany = 1) AND (type.IsFinishInCompany = 0)



--Î´Íê!





GO

GRANT EXEC ON p_Flow_GetMyDuditing TO PUBLIC

GO
