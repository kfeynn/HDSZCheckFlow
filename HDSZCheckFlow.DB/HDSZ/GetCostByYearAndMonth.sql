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

--�������������е��� ����


select iyear,imonth,outsubject  ,deptcode,[money] as outMoney  into #tempChangeOut from budget_change_Sheet        --ת����Ŀ
select iyear,imonth,insubject  , deptcode ,[money] as inMoney into  #tempChangeIn  from  budget_change_Sheet         --ת����Ŀ

select  iyear,imonth , deptcode, outsubject,sum(outmoney) as outMoney  into #outItem from #tempChangeOut  group by outsubject ,iyear,imonth,deptcode  --������outsubject,group���
select  iyear,imonth , deptcode, insubject ,sum(inmoney) as inMoney into #inItem from  #tempChangein   group by insubject ,iyear,imonth,deptcode                             --������insubject ,group���


--Ԥ��� + Nc�������ű� 
SELECT budget_account.Iyear, budget_account.Imonth, budget_account.SubjectCode, 
      budget_account.budgetMoney, budget_account.CheckMoney, 
      budget_account.PlanMoney, budget_account.deptCode, 
      Base_NC_Dept.NC_DeptCode, Base_NC_Dept.NC_DeptName, 
      Base_NC_Dept.budget_DeptCode, Base_Budget_Dept.budget_DeptName, 
      Base_AccountSubject.Dispname,
      ( isnull((select inMoney from #inItem  where #inItem.iyear=budget_account.iyear and  #inItem.Imonth=budget_account.Imonth and  #inItem.insubject=budget_account.SubjectCode  and  #inItem.deptcode=budget_account.deptcode),0) -
      isnull((select outMoney from #outItem  where #outItem.iyear=budget_account.iyear and  #outItem.Imonth=budget_account.Imonth and  #outItem.outsubject=budget_account.SubjectCode  and  #outItem.deptcode=budget_account.deptcode),0)            
        ) as changeMoney    --�������
       into #temp1
FROM budget_account INNER JOIN
      Base_Budget_Dept ON 
      budget_account.deptCode = Base_Budget_Dept.budget_DeptCode INNER JOIN
      Base_AccountSubject ON 
      budget_account.SubjectCode = Base_AccountSubject.subjectCode LEFT OUTER JOIN
      Base_NC_Dept ON budget_account.deptCode = Base_NC_Dept.budget_DeptCode
where budget_account.Iyear=@iYear and budget_account.Imonth = @iMonth

drop table  #tempChangeOut,#tempChangeIn ,#outItem,#inItem   --ɾ��������ʱ��
--Nc �������ű� + NCʵ��� 
         
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
isnull(#temp1.Iyear,#temp2.IYear) as IYear,                                 --�꣬Ϊ�������nc�е���
isnull(#temp1.Imonth,#temp2.Imonth) as Imonth,						        --�£�Ϊ�������nc�е���
isnull(#temp1.budget_DeptName,#temp2.budget_DeptName) as budget_DeptName,   --Ԥ�㲿�ţ�Ϊ�������nc�е�  
isnull(#temp1.NC_DeptName,#temp2.NC_DeptName) as NC_DeptName,               --nc���ţ�Ϊ������nc��
#temp1.budgetMoney,#temp1.PlanMoney,#temp2.localRealCost,                    --Ԥ��������ʵ�ʷ�֤���,�������
#temp1.changeMoney,
isnull(#temp1.Dispname,#temp2.Dispname) as Dispname                         --��Ŀ	

  from #temp1   FULL  JOIN 
 #temp2   on     #temp1.Iyear= #temp2.Iyear and  #temp1.Imonth=#temp2.Imonth
 and #temp1.SubjectCode=#temp2.subjcode  and  #temp1.deptCode=#temp2.budget_DeptCode

drop table #temp1,#temp2




GO


GRANT EXEC ON GetCostByYearAndMonth TO PUBLIC

GO
