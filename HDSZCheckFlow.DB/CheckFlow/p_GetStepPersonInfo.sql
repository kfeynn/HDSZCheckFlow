IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'p_GetStepPersonInfo')
	BEGIN
		PRINT 'Dropping Procedure p_GetStepPersonInfo'
		DROP  Procedure  p_GetStepPersonInfo
	END

GO

PRINT 'Creating Procedure p_GetStepPersonInfo'
GO
CREATE Procedure p_GetStepPersonInfo
	/* Param List */
	@CheckFlowInCompanyHeadpk int,
	@deptCode varchar(50)
AS

/******************************************************************************
**		File: 
**		Name: p_GetStepPersonInfo
**		Desc: 根据流程头 ,部门Code 查询此单的所有审批人员
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

-- 1. 角色表 和 单据表 
SELECT CheckRole.CheckRoleName,           -- 角色名称
	   CheckRole.CheckRoleCode ,          -- 角色代码
       CheckFlowInCompany_Body.CheckStep, -- 步骤号码
       CheckRole.IsRefer                  -- 是否参照
FROM CheckFlowInCompany_Body INNER JOIN                   -- 公司流程表
      CheckRole ON                                        -- 角色表
      CheckFlowInCompany_Body.CheckRoleCode = CheckRole.CheckRoleCode
WHERE (CheckFlowInCompany_Body.CheckFlowInCompany_Head_pk = 15)
ORDER BY CheckFlowInCompany_Body.CheckStep


GO

GRANT EXEC ON p_GetStepPersonInfo TO PUBLIC

GO
