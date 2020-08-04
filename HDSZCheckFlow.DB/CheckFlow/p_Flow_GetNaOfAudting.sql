IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'p_Flow_GetNaOfAudting')
	BEGIN
		PRINT 'Dropping Procedure p_Flow_GetNaOfAudting'
		DROP  Procedure  p_Flow_GetNaOfAudting
	END

GO

PRINT 'Creating Procedure p_Flow_GetNaOfAudting'
GO
CREATE Procedure p_Flow_GetNaOfAudting
	/* Param List */
	@UserCode varchar(50) 
AS

/******************************************************************************
**		File: 
**		Name: p_Flow_GetNaOfAudting
**		Desc:   查询未审批的个数
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

--  属于自己审批的单据信息
SELECT                     
      b .CheckRoleName AS CheckRoleName into #temp 
FROM ApplySheetHead a INNER JOIN
      CheckRole b ON a.CurrentCheckRole = b.CheckRoleCode INNER JOIN
      CheckPersonInRole c ON b.CheckRoleCode = c.CheckRoleCode INNER JOIN
      ApplyProcessType type ON 
      a.ApplyProcessCode = type.ApplyProcessTypeCode 
WHERE (c.PersonCode IN
          (SELECT UserName
         FROM xpGrid_User
         WHERE (displaysPerson = @UserCode) AND (IsDisplays = 1) OR
               (UserName = @UserCode))) AND a.IsCheckInCompany = 1 AND (type.IsFinishInCompany = 0) AND (type.IsDisallow = 0)
               
UNION ALL         -- 联合
-- 属于别人转让给自己的审批单据信息
SELECT                  
      b.CheckRoleName AS CheckRoleName
FROM ApplySheetHead a INNER JOIN
      CheckRole b ON a.CurrentCheckRole = b.CheckRoleCode INNER JOIN
      CheckFlowInDept ON a.CurrentCheckRole = CheckFlowInDept.CheckRoleCode AND 
      a.CheckSetp = CheckFlowInDept.CheckSetp and  a.ApplyDeptCode = CheckFlowInDept.DeptCode INNER JOIN
      Base_Person e ON CheckFlowInDept.CheckPersonCode = e.personCode INNER JOIN
      ApplyProcessType type ON 
      a.ApplyProcessCode = type.ApplyProcessTypeCode 
WHERE (a.IsCheckInCompany = 0) AND (e.personCode IN
          (SELECT UserName
         FROM xpGrid_User
         WHERE (displaysPerson = @UserCode) AND (IsDisplays = 1) OR
               (UserName = @UserCode))) AND (type.IsFinishInCompany = 0) AND (type.IsDisallow = 0)
select  count(*) as NumOfNaAudting  from #temp 
drop table #temp 




GO


GRANT EXEC ON p_Flow_GetNaOfAudting TO PUBLIC

GO
