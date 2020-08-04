IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'GetCostByClassDept')
	BEGIN
		PRINT 'Dropping Procedure GetCostByClassDept'
		DROP  Procedure  GetCostByClassDept
	END

GO

PRINT 'Creating Procedure GetCostByClassDept'
GO






CREATE      Procedure GetCostByClassDept

	@iYear   int,                                 --��
	@iMonth  int,                                 --��
--	@budGetDept varchar(100),                     --Ԥ�㲿�� (21,2201,2202 ) �� ,������Ҫͳ�Ƶļ���Ԥ�㲿�� , 
	@tableCode varchar(100)                       --runReport��Code
	
AS

/******************************************************************************
**		File: 
**		Name: GetCostByClassDept
**		Desc: ������Ԥ�㲿��,�ϼ�Ԥʵ�� ����
**
**		Auth: zyq
**		Date: 2008-07-22
*******************************************************************************
**		Change History
*******************************************************************************
**		Date:		Author:				Description:
**		--------		--------				-------------------------------
                 2009-10-14          zyq                          ����˼���
*******************************************************************************/


--�������������е��� ����

---*******************************************************************ͳ�Ƶ������Start****************************************************************---

-- ��all���ֵĵ������,out 

SELECT budget_change_Sheet.Iyear,                    --��
		budget_change_Sheet.Imonth,                  --��
      budget_change_Sheet.OutSubject,                --ת����Ŀ
      budget_change_Sheet.DeptCode,                  --����
       sum( budget_change_Sheet.Money) as outMoney , --ת�����
		'0' as inMoney                               --ת����
	into #NoAllOut
FROM budget_change_Sheet INNER JOIN                                       --������
      Base_Runreport ON LEFT(budget_change_Sheet.OutSubject, 4)           --���� ��
      = Base_Runreport.firstClassAccount AND 
      budget_change_Sheet.DeptCode = Base_Runreport.BudgetDept AND          
      Base_Runreport.tableCode = @tableCode                               --��ѯ�����
WHERE (Base_Runreport.BudgetDept IN
          (SELECT BudgetDept
         FROM Base_Runreport
         WHERE (tableCode = @tableCode))) AND (budget_change_Sheet.Iyear = @iYear) AND 
      (budget_change_Sheet.Imonth = @iMonth)
group by iyear, imonth,outsubject ,deptcode 

-- ��all���ֵĵ������,in 

SELECT budget_change_Sheet.Iyear,                   --��
		budget_change_Sheet.Imonth,                 --��
      budget_change_Sheet.InSubject,               --ת����Ŀ
      budget_change_Sheet.DeptCode,                 --����
		'0' as OutMoney,                           --ת�����
       sum( budget_change_Sheet.Money) as InMoney  --ת�����

	into #NoAllIn 
FROM budget_change_Sheet INNER JOIN                                       --������
      Base_Runreport ON LEFT(budget_change_Sheet.OutSubject, 4)           --���� ��
      = Base_Runreport.firstClassAccount AND 
      budget_change_Sheet.DeptCode = Base_Runreport.BudgetDept AND          
      Base_Runreport.tableCode = @tableCode                               --��ѯ�����
WHERE (Base_Runreport.BudgetDept IN
          (SELECT BudgetDept
         FROM Base_Runreport
         WHERE (tableCode = @tableCode))) AND (budget_change_Sheet.Iyear = @iYear) AND 
      (budget_change_Sheet.Imonth = @iMonth)
group by iyear, imonth,Insubject ,deptcode 


-- ������� �����Էŵ���� 

-- all ���ֵõ������ out 
SELECT budget_change_Sheet.Iyear,                     --��
		budget_change_Sheet.Imonth,                   --��
      budget_change_Sheet.OutSubject ,                 --ת����Ŀ
      budget_change_Sheet.DeptCode,                   --����
      sum (budget_change_Sheet.Money) as outMoney,     --ת�����ϼƣ�
		'0' as inMoney                                 --ת����
	into  #AllOut
FROM budget_change_Sheet INNER JOIN                                              --Ԥ�������
      Base_Runreport ON                                                          --���� �� ������ͳ�Ʋ����Լ���Ŀ��
      budget_change_Sheet.DeptCode = Base_Runreport.BudgetDept AND 
      Base_Runreport.tableCode =@tableCode                                     --��ѯ�����
WHERE (Base_Runreport.BudgetDept IN
          (SELECT BudgetDept
         FROM Base_Runreport
         WHERE (tableCode = @tableCode))) AND (budget_change_Sheet.Iyear = @iYear) AND 
      (budget_change_Sheet.Imonth = @iMonth) AND (Base_Runreport.firstClassAccount = 'all')
    group by iyear, imonth,outsubject ,deptcode 

-- all ���ֵõ������ in
SELECT budget_change_Sheet.Iyear,                      --��
		budget_change_Sheet.Imonth,            --��
      budget_change_Sheet.inSubject,                   --ת����Ŀ
      budget_change_Sheet.DeptCode,                    --����
	 '0' as OutMoney,                              --ת����
      sum (budget_change_Sheet.Money) as inMoney       --ת�����ϼƣ�
	into #AllIn
FROM budget_change_Sheet INNER JOIN                                              --Ԥ�������
      Base_Runreport ON                                                          --���� �� ������ͳ�Ʋ����Լ���Ŀ��
      budget_change_Sheet.DeptCode = Base_Runreport.BudgetDept AND 
      Base_Runreport.tableCode = @tableCode                                     --��ѯ�����
WHERE (Base_Runreport.BudgetDept IN
          (SELECT BudgetDept
         FROM Base_Runreport
         WHERE (tableCode = @tableCode))) AND (budget_change_Sheet.Iyear = @iYear) AND 
      (budget_change_Sheet.Imonth = @iMonth) AND (Base_Runreport.firstClassAccount = 'all')
    group by iyear, imonth,insubject ,deptcode 

select * into #ChangeMoney 
from #NoAllOut union all
select * from #NoAllIn  union all
select * from #AllOut  union all 
select *  from #AllIn 

select  iyear,imonth,Outsubject as subject  ,deptcode ,(isnull(sum(inMoney),0) - isnull(sum(outMoney),0) )  as ChangeMoney 
into #ChangeMoneyAll 
from #ChangeMoney 
group by iyear,imonth,Outsubject ,deptcode 


drop table #NoAllOut,#NoAllIn,#AllOut,#AllIn ,#ChangeMoney 
--******************************************************************ͳ�Ƶ������End**************************************************************************--



--------------------------------------------------------Ԥ��� + Nc�������ű�Start----------------------------------------------------------------------
-- ���ݲ���  ɸѡ��Ŀ ( �еĲ���,��Ҫͳ��ȫ����Ŀ,�еĲ���ֻ��Ҫͳ�Ʋ��ֿ�Ŀ) 


--Ԥ��� + Nc�������ű� + Base_runReport    ��All���ֵ�Ԥ����Ϣ

SELECT budget_account.deptCode,           --����
	budget_account.Iyear,             --���
	budget_account.Imonth,            --�·�
      sum(budget_account.budgetMoney) as budgetMoney,       --Ԥ����
      sum( budget_account.PlanMoney) as PlanMoney,          --������
       budget_account.SubjectCode,        --��Ŀ����
      Base_AccountSubject.Dispname,        --��Ŀ����
      Base_Budget_Dept.budget_DeptName,   --nc��������
      Base_NC_Dept.NC_DeptName
     into #NoAllBudgetInfo
FROM budget_account  INNER JOIN
      Base_Budget_Dept ON 
      budget_account.deptCode = Base_Budget_Dept.budget_DeptCode  INNER JOIN                         --Ԥ���
      Base_AccountSubject ON                           --����NC��Ŀ��
      budget_account.SubjectCode = Base_AccountSubject.subjectCode  
      LEFT OUTER JOIN
      Base_NC_Dept ON 
      budget_account.deptCode = Base_NC_Dept.budget_DeptCode  INNER JOIN
      Base_Runreport ON LEFT(budget_account.SubjectCode, 4)   -- �������� ��
      = Base_Runreport.firstClassAccount AND 
      budget_account.deptCode = Base_Runreport.BudgetDept
WHERE (Base_Runreport.tableCode = @tableCode) AND (budget_account.Iyear = @iYear) AND 
      (budget_account.Imonth = @iMonth) AND (Base_Runreport.BudgetDept in 
(SELECT BudgetDept FROM Base_Runreport WHERE (tableCode = @tableCode ))) 
group by  budget_account.deptCode, budget_account.Iyear, budget_account.Imonth,  --���� �꣬�£����ţ���Ŀ ���ϼ�
      Base_AccountSubject.Dispname, budget_account.SubjectCode, 
      Base_Budget_Dept.budget_DeptName, Base_NC_Dept.NC_DeptName                   




--Ԥ��� + Nc�������ű� + Base_runReport    All���ֵ�Ԥ����Ϣ

SELECT budget_account.deptCode, budget_account.Iyear, budget_account.Imonth, 
      SUM(budget_account.budgetMoney) AS budgetMoney, 
      SUM(budget_account.PlanMoney) AS PlanMoney, budget_account.SubjectCode, 
      Base_AccountSubject.Dispname ,
      Base_Budget_Dept.budget_DeptName,   --nc��������
      Base_NC_Dept.NC_DeptName
	into #AllBudgetInfo
FROM budget_account  INNER JOIN
      Base_Budget_Dept ON 
      budget_account.deptCode = Base_Budget_Dept.budget_DeptCode LEFT OUTER JOIN
      Base_NC_Dept ON 
      budget_account.deptCode = Base_NC_Dept.budget_DeptCode    INNER JOIN
      Base_AccountSubject ON 
      budget_account.SubjectCode = Base_AccountSubject.subjectCode INNER JOIN
      Base_Runreport ON 
      budget_account.deptCode = Base_Runreport.BudgetDept
WHERE (Base_Runreport.tableCode = @tableCode) AND (budget_account.Iyear = @iYear) AND 
      (budget_account.Imonth = @iMonth) AND (Base_Runreport.BudgetDept IN
          (SELECT BudgetDept
         FROM Base_Runreport
         WHERE (tableCode = @tableCode))) AND (Base_Runreport.firstClassAccount = 'all')
GROUP BY budget_account.deptCode, budget_account.Iyear, budget_account.Imonth, 
      Base_AccountSubject.Dispname, budget_account.SubjectCode,
       Base_Budget_Dept.budget_DeptName, Base_NC_Dept.NC_DeptName        
 
 -- �ϲ�ͳ������������
select * into #BudgetInfo from #NoAllBudgetInfo   union  all 
select * from  #AllBudgetInfo

select deptCode ,iyear,imonth,sum(budgetMoney) as budgetMoney ,
sum(PlanMoney) as PlanMoney ,subjectcode ,dispname,budget_DeptName,NC_DeptName
into  #budgetInfoAndNcDept
 from #BudgetInfo 
group by   deptCode ,iyear,imonth,subjectcode ,dispname ,budget_DeptName,NC_DeptName

drop table  #NoAllBudgetInfo,#AllBudgetInfo,#BudgetInfo

--------------------------------------------------------Ԥ��� + Nc�������ű�End----------------------------------------------------------------------


---//////////////////////////////////////////Ԥ��� + Nc�������ű� + �������////////////////////////////////////////////////////////---

select   #budgetInfoAndNcDept.*,               --Ԥ���ϼ��е������ֶ�
	(isnull(#budgetInfoAndNcDept.PlanMoney,0) + isnull(#ChangeMoneyAll.ChangeMoney,0)) as newPlanMoney,   --���ϵ�������� ������
	#ChangeMoneyAll.ChangeMoney                --�������
	into #BudgetBefore 
from #budgetInfoAndNcDept  left join #ChangeMoneyAll 
		on   #budgetInfoAndNcDept.iyear = #ChangeMoneyAll.iyear                 --�������� ����
		and  #budgetInfoAndNcDept.imonth = #ChangeMoneyAll.imonth               --�������� ����
		and  #budgetInfoAndNcDept.subjectcode = #ChangeMoneyAll.subject         --�������� ����Ŀ
		and  #budgetInfoAndNcDept.deptcode = #ChangeMoneyAll.deptcode           --�������� ������

select iyear,imonth,sum(budgetMoney) as budgetMoney,sum(PlanMoney) as PlanMoney,subjectcode,dispname,sum(newPlanMoney) as newPlanMoney, sum(ChangeMoney) as ChangeMoney  
into #Budget
from #BudgetBefore
group by iyear,imonth,subjectcode,dispname

drop table #budgetInfoAndNcDept,#ChangeMoneyAll,#BudgetBefore
---///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////---


-----------------------------------------------------Nc �������ű� + NCʵ���Strat-------------------------------------------------------------------

--Nc �������ű� + NCʵ���  �� All  ����

SELECT GL_NC_Cost.localRealCost,          --ʵ�ʷ������
		Base_NC_Dept.NC_DeptCode,         --NC���Ŵ���
        GL_NC_Cost.NCDeptCode,            --NC���Ŵ���
        Base_NC_Dept.NC_DeptName,         --NC��������
        GL_NC_Cost.NCDeptName,            --NC��������
        Base_NC_Dept.budget_DeptCode,     --Ԥ�㲿�Ŵ���
        GL_NC_Cost.IYear,                 --���
        GL_NC_Cost.IMonth,                --�·�
        GL_NC_Cost.subjcode,              --��Ŀ
        Base_AccountSubject.Dispname,     --��Ŀ����
        Base_Budget_Dept.budget_DeptName  --Ԥ�㲿������
	into #NoAllRealCost
FROM Base_AccountSubject INNER JOIN                                                --NC��Ŀ��
      GL_NC_Cost ON                                                                --NCʵ�ʽ�����
      Base_AccountSubject.subjectCode = GL_NC_Cost.subjcode 
      INNER JOIN Base_Runreport                                                    --���� ��
      ON GL_NC_Cost.NCDeptCode = Base_Runreport.BudgetDept 
      AND LEFT(GL_NC_Cost.subjcode, 4) = Base_Runreport.firstClassAccount          --��������ΪfirstClassAccount���¼��ͷ��λֵ
      LEFT OUTER JOIN Base_Budget_Dept INNER JOIN
      Base_NC_Dept ON                                                              --NC���ű�
      Base_Budget_Dept.budget_DeptCode = Base_NC_Dept.budget_DeptCode ON 
      GL_NC_Cost.NCDeptCode = Base_NC_Dept.NC_DeptCode
WHERE (GL_NC_Cost.IYear = @iYear) AND (GL_NC_Cost.IMonth = @iMonth) 
	and GL_NC_Cost.subjcode not in ('410501','410504','410512','410510','550212','550204','550225','550201','550104','550101','550112','550109')
AND 
      (LEFT(GL_NC_Cost.subjcode, 4) IN
          (SELECT suncode
         FROM Base_CommonRelation)) AND (Base_Runreport.tableCode = @tableCode)    
         
         
--Nc �������ű� + NCʵ���  �� All  ����


SELECT GL_NC_Cost.localRealCost,          --ʵ�ʷ������
		Base_NC_Dept.NC_DeptCode,         --NC���Ŵ���
        GL_NC_Cost.NCDeptCode,            --NC���Ŵ���
        Base_NC_Dept.NC_DeptName,         --NC��������
        GL_NC_Cost.NCDeptName,            --NC��������
        Base_NC_Dept.budget_DeptCode,     --Ԥ�㲿�Ŵ���
        GL_NC_Cost.IYear,                 --���
        GL_NC_Cost.IMonth,                --�·�
        GL_NC_Cost.subjcode,              --��Ŀ
        Base_AccountSubject.Dispname,     --��Ŀ����
        Base_Budget_Dept.budget_DeptName  --Ԥ�㲿������
	into #AllRealCost
FROM Base_AccountSubject INNER JOIN                                                --NC��Ŀ��
      GL_NC_Cost ON                                                                --NCʵ�ʽ�����
      Base_AccountSubject.subjectCode = GL_NC_Cost.subjcode 
      INNER JOIN Base_Runreport                                                    --���� ��
      ON GL_NC_Cost.NCDeptCode = Base_Runreport.BudgetDept 
      AND  Base_Runreport.firstClassAccount = 'all'                                --��������ΪAll
      LEFT OUTER JOIN Base_Budget_Dept INNER JOIN
      Base_NC_Dept ON                                                              --NC���ű�
      Base_Budget_Dept.budget_DeptCode = Base_NC_Dept.budget_DeptCode ON 
      GL_NC_Cost.NCDeptCode = Base_NC_Dept.NC_DeptCode
WHERE (GL_NC_Cost.IYear = @iYear) AND (GL_NC_Cost.IMonth = @iMonth) 
	and GL_NC_Cost.subjcode not in ('410501','410504','410512','410510','550225','550109','550212','550204','550201','550104','550101','550112')
AND 
      (LEFT(GL_NC_Cost.subjcode, 4) IN
          (SELECT suncode
         FROM Base_CommonRelation)) AND (Base_Runreport.tableCode = @tableCode)


--��Hr��ȡ���˼���----------



SELECT nian,yue,Base_Runreport.firstclassaccount as zj,
Base_Runreport.budgetdept as budget_deptcode,
sum(bmgz)  as  ����,
sum(jbf) as �Ӱ��,
sum(ylbx+yllbx+sybx+gsbx+syybx) as ����,
sum(fl+txbz+jtbz) as ����
into #HrRJF 
FROM Hr_GZB_RJF Hr 
inner join Base_Runreport on Hr.b0fycb = Base_Runreport.tablecode and Base_Runreport.type = 'FYCB' and Base_Runreport.classtype='Budget'

WHERE (Hr.Nian = @iYear) AND (Hr.Yue = @iMonth) and b0fycb in 
 (select tablecode from Base_Runreport where budgetdept in ( select budgetdept from Base_Runreport where tablecode = @tableCode)  )
group by nian ,yue ,firstclassaccount,Base_Runreport.budgetdept
--,b0fycb,fycb 


select ���� as localrealcost,nian as iyear ,yue as imonth,budget_deptcode,case zj when 'ֱ' then '410501' else '550201' end  as subjcode,zj + ' ����' as dispname 
into #HrRenjian1
from #HrRJF 
union all
select �Ӱ��,nian,yue,budget_deptcode,case zj when 'ֱ' then '410510' else '550225' end  as subjcode,zj +' �Ӱ��' as dispname from #HrRJF 
union all
select ����,nian,yue,budget_deptcode,case zj when 'ֱ' then '410512' else '550201' end   as subjcode,zj +' ����' as dispname from #HrRJF 
union all 
select ����,nian,yue,budget_deptcode,case zj when 'ֱ' then '410504' else '550201' end   as subjcode,zj +' ����' as dispname from #HrRJF 

-- �ϲ� All���ֵ�
select Hr.*  into #HrRenjian2 from #HrRenjian1 Hr  inner  join Base_Runreport 
on Hr.budget_deptcode = Base_Runreport.budgetdept and  Base_Runreport.firstclassaccount = 'all'
where Base_Runreport.tablecode = @tableCode  and Base_Runreport.type in ('Dept','ClassDept') and Base_Runreport.ClassType = 'Budget'

union all
-- 4105 ֱ�ӷ���
select Hr.* from #HrRenjian1 Hr  inner  join Base_Runreport 
on Hr.budget_deptcode = Base_Runreport.budgetdept 
 AND LEFT(Hr.subjcode, 4) = Base_Runreport.firstClassAccount
where Base_Runreport.tablecode = @tableCode and  Base_Runreport.firstclassaccount = '4105'
 and Base_Runreport.type in ('Dept','ClassDept') and Base_Runreport.ClassType = 'Budget'

union all 
-- 5502 ��ӷ���
select Hr.* from #HrRenjian1 Hr  inner  join Base_Runreport 
on Hr.budget_deptcode = Base_Runreport.budgetdept 
 AND LEFT(Hr.subjcode, 4) = '5502'
where Base_Runreport.tablecode = @tableCode and (  Base_Runreport.firstclassaccount ='5502' ) 
 and Base_Runreport.type in ('Dept','ClassDept') and Base_Runreport.ClassType = 'Budget'



select sum(localrealcost) as localrealcost,iyear,imonth,subjcode,dispname 
into #HrRenjian
  from #HrRenjian2 
group by iyear,imonth,subjcode,dispname 


drop table #HrRJF ,#HrRenjian1,#HrRenjian2

----------------------------


----------------------------


select * into #RealCostBefore from #NoAllRealCost  union  all                            --���� ʵ�ʷ������������(All �� NoAll)
select * from #AllRealCost
--select * from #RealCost           

select sum(localrealcost) as localrealcost,iyear,imonth,subjcode ,dispname 
 into #RealCost from  #RealCostBefore  
group by subjcode ,dispname ,iyear,imonth
 union all
select * from #HrRenjian                                


drop table #NoAllRealCost,#AllRealCost,#RealCostBefore,#HrRenjian

------------------------------------------------------Nc �������ű� + NCʵ���End---------------------------------------------------------------------

--/////////////////////////////////////////////////////����Ԥ�� �� ʵ�ʷ����� ���//////////////////////////////////////////////////////////////////////

select 
isnull(#Budget.Iyear,#RealCost.IYear) as IYear,                                  --�꣬Ϊ�������nc�е���
isnull(#Budget.Imonth,#RealCost.Imonth) as Imonth,						         --�£�Ϊ�������nc�е���
#Budget.budgetMoney,(#Budget.newPlanMoney ) as PlanMoney,#RealCost.localRealCost,                    --Ԥ��������ʵ�ʷ�֤���,�������
--#Budget.changeMoney,													         --�������
--isnull(#Budget.deptCode,#RealCost.NC_DeptCode) as BudgetdeptCode,              --Ԥ�㲿��
isnull(#Budget.Dispname,#RealCost.Dispname) as Dispname,                         --��Ŀ	
isnull(#Budget.SubjectCode,#RealCost.subjcode) as SubjectCode                    --��Ŀ���
into #ThisMonthBudget 
  from #Budget   FULL  JOIN 
 #RealCost   on     #Budget.Iyear= #RealCost.Iyear and  #Budget.Imonth=#RealCost.Imonth
 and #Budget.SubjectCode=#RealCost.subjcode  


drop table #Budget,#RealCost  

--////////////////////////////////////////////////����Ԥ�� �� ʵ�ʷ����� ���End //////////////////////////////////////////////////////////////////////

--1.������Ԥʵ��
--2.���࣬���ֶΡ�Ԥ������ֶΣ�

 
--3.�ж��·ݣ� <= 6 ,   1q,2q,1h.       >6 .  3q,4q,2h.
--

-- ���ݵ�ǰ�·� ����ѯ�� Ԥ����� ���ֶ�Ϊ �� ��Ŀ���꣬�� �� 1q .2q. 1 h , 3q,4q, 2h ���


declare @baseMonth int 

if @iMonth<= 6   -- ȡ 1q,2qԤ����Ϣ �� ƽ��ֵ�� 1q����
	begin
		set @baseMonth=0     --�ϰ���
	end
else if @iMonth<= 12   -- ȡ 1q,2qԤ����Ϣ �� ƽ��ֵ�� 2q����
	begin
		set @baseMonth=6 	 --�°���
	end
	
SELECT  Iyear,       --��
		deptCode,    --����
		SubjectCode, --��Ŀ
		( select isnull(sum(budgetMoney),0)/3 from budget_account o  where  
			o.imonth>=@baseMonth+1  and o.imonth<=@baseMonth+3 and o.iyear=budget_account.iyear and o.deptCode=budget_account.deptCode and o.SubjectCode
			=budget_account.SubjectCode) as oneQ, -- һ����Ԥ����Ϣ
		( select  isnull(sum(budgetMoney),0)/3 from budget_account o  where  
			o.imonth>=@baseMonth+4  and o.imonth<=@baseMonth+6  and o.iyear=budget_account.iyear and o.deptCode=budget_account.deptCode and o.SubjectCode
			=budget_account.SubjectCode) as twoQ, -- ������
		( select isnull(sum(budgetMoney),0)/6 from budget_account o  where  
			o.imonth>=@baseMonth+1  and o.imonth<=@baseMonth+6 and o.iyear=budget_account.iyear and o.deptCode=budget_account.deptCode and o.SubjectCode
			=budget_account.SubjectCode) as oneH  -- �ϰ���Ԥ����Ϣ
into #QuarterInfoBefore 
FROM budget_account 
WHERE  (deptCode in (select budgetdept from base_runreport where tablecode=@tablecode))  and budget_account.iyear=@iYear 
group by deptCode,SubjectCode ,Iyear


select subjectcode,sum(oneQ) as oneQ,sum(twoQ) as twoQ,sum(oneH) as oneH into #QuarterInfo from #QuarterInfoBefore group by  subjectcode 


--�ۺ� #ThisMonthBudget  ���ų����µ���Ϣ �����ϵ���Ŀ����
select sum(PlanMoney) as PlanMoney ,sum(localRealCost) as localRealCost ,dispname,subjectcode into #ThisBudget from #ThisMonthBudget group by dispname,subjectcode



-- Ӧ��������� �����ϲ�ѯ�ѣ� 1q .2q. 1 h , 3q,4q, 2h ��� ���� 
select '0' as unionType,'0' as order1, #ThisBudget.*,Base_accontInBudgetSubject.CommonCode, Base_CommonCode.ShowOrder,Base_CommonCode.codename ,#QuarterInfo.oneQ,#QuarterInfo.twoQ,
#QuarterInfo.oneH
 into #table2  from   #ThisBudget left join Base_accontInBudgetSubject on  #ThisBudget.SubjectCode = Base_accontInBudgetSubject.subjectCode left JOIN Base_CommonCode 
 on   Base_CommonCode.Code = Base_accontInBudgetSubject.CommonCode  left join #QuarterInfo on #QuarterInfo.subjectcode = #ThisBudget.SubjectCode 
order by  Base_CommonCode.ShowOrder 


--��͵ı� ������õı� ��union һ���γɵ��ĸ��� �� --  ��  1q .2q. 1 h , 3q,4q, 2h ���

select *  from #table2 
 union all 
select '1' as unionType,'0' as order1,
sum(planmoney) as planmoney, sum (localrealcost) as localrealcost ,codename + '�ϼ�' as  Dispname,'' as subjectcode,commoncode,ShowOrder,codename,sum(oneQ) as oneQ,sum(twoQ) as twoQ,
sum(oneH) as oneH  
from #table2   group by  
commoncode,ShowOrder,codename 
 union all 
 select '2' as unionType, '1' as order1,
sum(planmoney) as planmoney, sum (localrealcost) as localrealcost , '��   ��' as  Dispname,'' as subjectcode,'' as commoncode,'' as ShowOrder,'' as codename,sum(oneQ) as oneQ,sum(twoQ) as twoQ,
sum(oneH) as oneH  
from #table2   --group by  commoncode,ShowOrder,codename 

order by  order1 asc , ShowOrder asc, subjectcode desc 


drop table #QuarterInfo,#table2,#ThisMonthBudget,#ThisBudget,#QuarterInfoBefore

-- ��ѯ��Ŀ�� ��Լ����������  ǰ���Ѿ����ϡ�
GO









GRANT EXEC ON GetCostByClassDept TO PUBLIC

GO
