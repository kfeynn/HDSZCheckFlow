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
**		Desc: ��������ͷ ,����Code ��ѯ�˵�������������Ա
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

-- 1. ��ɫ�� �� ���ݱ� 
SELECT CheckRole.CheckRoleName,           -- ��ɫ����
	   CheckRole.CheckRoleCode ,          -- ��ɫ����
       CheckFlowInCompany_Body.CheckStep, -- �������
       CheckRole.IsRefer                  -- �Ƿ����
FROM CheckFlowInCompany_Body INNER JOIN                   -- ��˾���̱�
      CheckRole ON                                        -- ��ɫ��
      CheckFlowInCompany_Body.CheckRoleCode = CheckRole.CheckRoleCode
WHERE (CheckFlowInCompany_Body.CheckFlowInCompany_Head_pk = 15)
ORDER BY CheckFlowInCompany_Body.CheckStep


GO

GRANT EXEC ON p_GetStepPersonInfo TO PUBLIC

GO
