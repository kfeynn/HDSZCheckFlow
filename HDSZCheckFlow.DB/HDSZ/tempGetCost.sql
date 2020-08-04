IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'tempGetCost')
	BEGIN
		PRINT 'Dropping Procedure tempGetCost'
		DROP  Procedure  tempGetCost
	END

GO

PRINT 'Creating Procedure tempGetCost'
GO
CREATE Procedure tempGetCost
	/* Param List */
AS

/******************************************************************************
**		File: 
**		Name: tempGetCost
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

--预算表 + Nc基础部门表 
SELECT budget_account.Iyear, budget_account.Imonth, budget_account.SubjectCode, 
      budget_account.budgetMoney, budget_account.CheckMoney, 
      budget_account.PlanMoney, budget_account.deptCode, 
      Base_NC_Dept.NC_DeptCode, Base_NC_Dept.NC_DeptName, 
      Base_NC_Dept.budget_DeptCode into #temp1
FROM budget_account LEFT OUTER JOIN
      Base_NC_Dept ON budget_account.deptCode = Base_NC_Dept.budget_DeptCode


--Nc 基础部门表 + NC实算表 
SELECT GL_NC_Cost.localRealCost, Base_NC_Dept.NC_DeptCode, 
      GL_NC_Cost.NCDeptCode, Base_NC_Dept.NC_DeptName, 
      GL_NC_Cost.NCDeptName, Base_NC_Dept.budget_DeptCode, GL_NC_Cost.IYear, 
      GL_NC_Cost.IMonth, GL_NC_Cost.subjcode into #temp2 
FROM GL_NC_Cost LEFT OUTER JOIN
      Base_NC_Dept ON 
      GL_NC_Cost.NCDeptCode = Base_NC_Dept.NC_DeptCode 
WHERE (LEFT(GL_NC_Cost.subjcode, 4) IN
          (SELECT suncode
         FROM Base_CommonRelation))



select *    from #temp1   FULL  JOIN 
 #temp2   on     #temp1.Iyear= #temp2.Iyear and  #temp1.Imonth=#temp2.Imonth
and #temp1.SubjectCode=#temp2.subjcode  and  #temp1.deptCode=#temp2.budget_DeptCode

drop table #temp1,#temp2



SELECT GL_NC_Cost.localRealCost, Base_NC_Dept.NC_DeptCode, 
      GL_NC_Cost.NCDeptCode, Base_NC_Dept.NC_DeptName, 
      GL_NC_Cost.NCDeptName, Base_NC_Dept.budget_DeptCode, GL_NC_Cost.IYear, 
      GL_NC_Cost.IMonth, GL_NC_Cost.subjcode, 
      Base_Budget_Dept.budget_DeptName
FROM Base_Budget_Dept INNER JOIN
      Base_NC_Dept ON 
      Base_Budget_Dept.budget_DeptCode = Base_NC_Dept.budget_DeptCode RIGHT OUTER
       JOIN
      GL_NC_Cost ON Base_NC_Dept.NC_DeptCode = GL_NC_Cost.NCDeptCode
WHERE (LEFT(GL_NC_Cost.subjcode, 4) IN
          (SELECT suncode
         FROM Base_CommonRelation))


GO

GRANT EXEC ON tempGetCost TO PUBLIC

GO
