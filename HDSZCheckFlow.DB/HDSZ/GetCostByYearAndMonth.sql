IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'GetCostByYearAndMonth')
	BEGIN
		PRINT 'Dropping Procedure GetCostByYearAndMonth'
		DROP  Procedure  GetCostByYearAndMonth
	END

GO

PRINT 'Creating Procedure GetCostByYearAndMonth'
GO
CREATE Procedure GetCostByYearAndMonth
	@iYear   int,
	@iMonth  int
AS

/******************************************************************************
**		File: 
**		Name: GetCostByYearAndMonth
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

--调整金额，调整表，有调出 调入


select iyear,imonth,outsubject  ,deptcode,[money] as outMoney  into #tempChangeOut from budget_change_Sheet        --转出项目
select iyear,imonth,insubject  , deptcode ,[money] as inMoney into  #tempChangeIn  from  budget_change_Sheet         --转入项目

select  iyear,imonth , deptcode, outsubject,sum(outmoney) as outMoney  into #outItem from #tempChangeOut  group by outsubject ,iyear,imonth,deptcode  --按年月outsubject,group金额
select  iyear,imonth , deptcode, insubject ,sum(inmoney) as inMoney into #inItem from  #tempChangein   group by insubject ,iyear,imonth,deptcode                             --按年月insubject ,group金额


--预算表 + Nc基础部门表 
SELECT budget_account.Iyear, budget_account.Imonth, budget_account.SubjectCode, 
      budget_account.budgetMoney, budget_account.CheckMoney, 
      budget_account.PlanMoney, budget_account.deptCode, 
      Base_NC_Dept.NC_DeptCode, Base_NC_Dept.NC_DeptName, 
      Base_NC_Dept.budget_DeptCode, Base_Budget_Dept.budget_DeptName, 
      Base_AccountSubject.Dispname,
      ( isnull((select inMoney from #inItem  where #inItem.iyear=budget_account.iyear and  #inItem.Imonth=budget_account.Imonth and  #inItem.insubject=budget_account.SubjectCode  and  #inItem.deptcode=budget_account.deptcode),0) -
      isnull((select outMoney from #outItem  where #outItem.iyear=budget_account.iyear and  #outItem.Imonth=budget_account.Imonth and  #outItem.outsubject=budget_account.SubjectCode  and  #outItem.deptcode=budget_account.deptcode),0)            
        ) as changeMoney    --调整金额
       into #temp1
FROM budget_account INNER JOIN
      Base_Budget_Dept ON 
      budget_account.deptCode = Base_Budget_Dept.budget_DeptCode INNER JOIN
      Base_AccountSubject ON 
      budget_account.SubjectCode = Base_AccountSubject.subjectCode LEFT OUTER JOIN
      Base_NC_Dept ON budget_account.deptCode = Base_NC_Dept.budget_DeptCode
where budget_account.Iyear=@iYear and budget_account.Imonth = @iMonth

drop table  #tempChangeOut,#tempChangeIn ,#outItem,#inItem   --删除调整临时表
--Nc 基础部门表 + NC实算表 
         
SELECT GL_NC_Cost.localRealCost, Base_NC_Dept.NC_DeptCode, 
      GL_NC_Cost.NCDeptCode, Base_NC_Dept.NC_DeptName, 
      GL_NC_Cost.NCDeptName, Base_NC_Dept.budget_DeptCode, GL_NC_Cost.IYear, 
      GL_NC_Cost.IMonth, GL_NC_Cost.subjcode, Base_Budget_Dept.budget_DeptName, 
      Base_AccountSubject.Dispname into #temp2
FROM Base_AccountSubject INNER JOIN
      GL_NC_Cost ON 
      Base_AccountSubject.subjectCode = GL_NC_Cost.subjcode LEFT OUTER JOIN
      Base_Budget_Dept INNER JOIN
      Base_NC_Dept ON 
      Base_Budget_Dept.budget_DeptCode = Base_NC_Dept.budget_DeptCode ON 
      GL_NC_Cost.NCDeptCode = Base_NC_Dept.NC_DeptCode
WHERE  GL_NC_Cost.IYear = @iYear and  GL_NC_Cost.IMonth = @iMonth and  (LEFT(GL_NC_Cost.subjcode, 4) IN
          (SELECT suncode
         FROM Base_CommonRelation))


select 
isnull(#temp1.Iyear,#temp2.IYear) as IYear,                                 --年，为空则采用nc中的年
isnull(#temp1.Imonth,#temp2.Imonth) as Imonth,						        --月，为空则采用nc中的月
isnull(#temp1.budget_DeptName,#temp2.budget_DeptName) as budget_DeptName,   --预算部门，为空则采用nc中的  
isnull(#temp1.NC_DeptName,#temp2.NC_DeptName) as NC_DeptName,               --nc部门，为空则用nc的
#temp1.budgetMoney,#temp1.PlanMoney,#temp2.localRealCost,                    --预算金额，推算金额，实际发证金额,调整金额
#temp1.changeMoney,
isnull(#temp1.Dispname,#temp2.Dispname) as Dispname                         --科目	

  from #temp1   FULL  JOIN 
 #temp2   on     #temp1.Iyear= #temp2.Iyear and  #temp1.Imonth=#temp2.Imonth
 and #temp1.SubjectCode=#temp2.subjcode  and  #temp1.deptCode=#temp2.budget_DeptCode

drop table #temp1,#temp2




GO


GRANT EXEC ON GetCostByYearAndMonth TO PUBLIC

GO
