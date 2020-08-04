IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'GetCostByClassDept')
	BEGIN
		PRINT 'Dropping Procedure GetCostByClassDept'
		DROP  Procedure  GetCostByClassDept
	END

GO

PRINT 'Creating Procedure GetCostByClassDept'
GO






CREATE      Procedure GetCostByClassDept

	@iYear   int,                                 --年
	@iMonth  int,                                 --月
--	@budGetDept varchar(100),                     --预算部门 (21,2201,2202 ) 等 ,代表需要统计的几个预算部门 , 
	@tableCode varchar(100)                       --runReport的Code
	
AS

/******************************************************************************
**		File: 
**		Name: GetCostByClassDept
**		Desc: 分三类预算部门,合计预实算 报表
**
**		Auth: zyq
**		Date: 2008-07-22
*******************************************************************************
**		Change History
*******************************************************************************
**		Date:		Author:				Description:
**		--------		--------				-------------------------------
                 2009-10-14          zyq                          添加人件费
*******************************************************************************/


--调整金额，调整表，有调出 调入

---*******************************************************************统计调整金额Start****************************************************************---

-- 非all部分的调整金额,out 

SELECT budget_change_Sheet.Iyear,                    --年
		budget_change_Sheet.Imonth,                  --月
      budget_change_Sheet.OutSubject,                --转出项目
      budget_change_Sheet.DeptCode,                  --部门
       sum( budget_change_Sheet.Money) as outMoney , --转出金额
		'0' as inMoney                               --转入金额
	into #NoAllOut
FROM budget_change_Sheet INNER JOIN                                       --调整表
      Base_Runreport ON LEFT(budget_change_Sheet.OutSubject, 4)           --报表 表
      = Base_Runreport.firstClassAccount AND 
      budget_change_Sheet.DeptCode = Base_Runreport.BudgetDept AND          
      Base_Runreport.tableCode = @tableCode                               --查询表类别
WHERE (Base_Runreport.BudgetDept IN
          (SELECT BudgetDept
         FROM Base_Runreport
         WHERE (tableCode = @tableCode))) AND (budget_change_Sheet.Iyear = @iYear) AND 
      (budget_change_Sheet.Imonth = @iMonth)
group by iyear, imonth,outsubject ,deptcode 

-- 非all部分的调整金额,in 

SELECT budget_change_Sheet.Iyear,                   --年
		budget_change_Sheet.Imonth,                 --月
      budget_change_Sheet.InSubject,               --转入项目
      budget_change_Sheet.DeptCode,                 --部门
		'0' as OutMoney,                           --转出金额
       sum( budget_change_Sheet.Money) as InMoney  --转出金额

	into #NoAllIn 
FROM budget_change_Sheet INNER JOIN                                       --调整表
      Base_Runreport ON LEFT(budget_change_Sheet.OutSubject, 4)           --报表 表
      = Base_Runreport.firstClassAccount AND 
      budget_change_Sheet.DeptCode = Base_Runreport.BudgetDept AND          
      Base_Runreport.tableCode = @tableCode                               --查询表类别
WHERE (Base_Runreport.BudgetDept IN
          (SELECT BudgetDept
         FROM Base_Runreport
         WHERE (tableCode = @tableCode))) AND (budget_change_Sheet.Iyear = @iYear) AND 
      (budget_change_Sheet.Imonth = @iMonth)
group by iyear, imonth,Insubject ,deptcode 


-- 调整金额 ，可以放到最后 

-- all 部分得调整金额 out 
SELECT budget_change_Sheet.Iyear,                     --年
		budget_change_Sheet.Imonth,                   --月
      budget_change_Sheet.OutSubject ,                 --转出项目
      budget_change_Sheet.DeptCode,                   --部门
      sum (budget_change_Sheet.Money) as outMoney,     --转出金额（合计）
		'0' as inMoney                                 --转入金额
	into  #AllOut
FROM budget_change_Sheet INNER JOIN                                              --预算调整表
      Base_Runreport ON                                                          --报表 表 （过滤统计部门以及科目）
      budget_change_Sheet.DeptCode = Base_Runreport.BudgetDept AND 
      Base_Runreport.tableCode =@tableCode                                     --查询表类别
WHERE (Base_Runreport.BudgetDept IN
          (SELECT BudgetDept
         FROM Base_Runreport
         WHERE (tableCode = @tableCode))) AND (budget_change_Sheet.Iyear = @iYear) AND 
      (budget_change_Sheet.Imonth = @iMonth) AND (Base_Runreport.firstClassAccount = 'all')
    group by iyear, imonth,outsubject ,deptcode 

-- all 部分得调整金额 in
SELECT budget_change_Sheet.Iyear,                      --年
		budget_change_Sheet.Imonth,            --月
      budget_change_Sheet.inSubject,                   --转出项目
      budget_change_Sheet.DeptCode,                    --部门
	 '0' as OutMoney,                              --转入金额
      sum (budget_change_Sheet.Money) as inMoney       --转出金额（合计）
	into #AllIn
FROM budget_change_Sheet INNER JOIN                                              --预算调整表
      Base_Runreport ON                                                          --报表 表 （过滤统计部门以及科目）
      budget_change_Sheet.DeptCode = Base_Runreport.BudgetDept AND 
      Base_Runreport.tableCode = @tableCode                                     --查询表类别
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
--******************************************************************统计调整金额End**************************************************************************--



--------------------------------------------------------预算表 + Nc基础部门表Start----------------------------------------------------------------------
-- 根据部门  筛选科目 ( 有的部门,需要统计全部科目,有的部门只需要统计部分科目) 


--预算表 + Nc基础部门表 + Base_runReport    非All部分的预算信息

SELECT budget_account.deptCode,           --部门
	budget_account.Iyear,             --年份
	budget_account.Imonth,            --月份
      sum(budget_account.budgetMoney) as budgetMoney,       --预算金额
      sum( budget_account.PlanMoney) as PlanMoney,          --推算金额
       budget_account.SubjectCode,        --科目号码
      Base_AccountSubject.Dispname,        --科目名称
      Base_Budget_Dept.budget_DeptName,   --nc部门名称
      Base_NC_Dept.NC_DeptName
     into #NoAllBudgetInfo
FROM budget_account  INNER JOIN
      Base_Budget_Dept ON 
      budget_account.deptCode = Base_Budget_Dept.budget_DeptCode  INNER JOIN                         --预算表
      Base_AccountSubject ON                           --基础NC科目表
      budget_account.SubjectCode = Base_AccountSubject.subjectCode  
      LEFT OUTER JOIN
      Base_NC_Dept ON 
      budget_account.deptCode = Base_NC_Dept.budget_DeptCode  INNER JOIN
      Base_Runreport ON LEFT(budget_account.SubjectCode, 4)   -- 基础报表 表
      = Base_Runreport.firstClassAccount AND 
      budget_account.deptCode = Base_Runreport.BudgetDept
WHERE (Base_Runreport.tableCode = @tableCode) AND (budget_account.Iyear = @iYear) AND 
      (budget_account.Imonth = @iMonth) AND (Base_Runreport.BudgetDept in 
(SELECT BudgetDept FROM Base_Runreport WHERE (tableCode = @tableCode ))) 
group by  budget_account.deptCode, budget_account.Iyear, budget_account.Imonth,  --按照 年，月，部门，科目 做合计
      Base_AccountSubject.Dispname, budget_account.SubjectCode, 
      Base_Budget_Dept.budget_DeptName, Base_NC_Dept.NC_DeptName                   




--预算表 + Nc基础部门表 + Base_runReport    All部分的预算信息

SELECT budget_account.deptCode, budget_account.Iyear, budget_account.Imonth, 
      SUM(budget_account.budgetMoney) AS budgetMoney, 
      SUM(budget_account.PlanMoney) AS PlanMoney, budget_account.SubjectCode, 
      Base_AccountSubject.Dispname ,
      Base_Budget_Dept.budget_DeptName,   --nc部门名称
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
 
 -- 合并统计以上两部分
select * into #BudgetInfo from #NoAllBudgetInfo   union  all 
select * from  #AllBudgetInfo

select deptCode ,iyear,imonth,sum(budgetMoney) as budgetMoney ,
sum(PlanMoney) as PlanMoney ,subjectcode ,dispname,budget_DeptName,NC_DeptName
into  #budgetInfoAndNcDept
 from #BudgetInfo 
group by   deptCode ,iyear,imonth,subjectcode ,dispname ,budget_DeptName,NC_DeptName

drop table  #NoAllBudgetInfo,#AllBudgetInfo,#BudgetInfo

--------------------------------------------------------预算表 + Nc基础部门表End----------------------------------------------------------------------


---//////////////////////////////////////////预算表 + Nc基础部门表 + 调整金额////////////////////////////////////////////////////////---

select   #budgetInfoAndNcDept.*,               --预算表合计中的所有字段
	(isnull(#budgetInfoAndNcDept.PlanMoney,0) + isnull(#ChangeMoneyAll.ChangeMoney,0)) as newPlanMoney,   --加上调整金额后的 推算金额
	#ChangeMoneyAll.ChangeMoney                --调整金额
	into #BudgetBefore 
from #budgetInfoAndNcDept  left join #ChangeMoneyAll 
		on   #budgetInfoAndNcDept.iyear = #ChangeMoneyAll.iyear                 --关联条件 ，年
		and  #budgetInfoAndNcDept.imonth = #ChangeMoneyAll.imonth               --关联条件 ，月
		and  #budgetInfoAndNcDept.subjectcode = #ChangeMoneyAll.subject         --关联条件 ，科目
		and  #budgetInfoAndNcDept.deptcode = #ChangeMoneyAll.deptcode           --关联条件 ，部门

select iyear,imonth,sum(budgetMoney) as budgetMoney,sum(PlanMoney) as PlanMoney,subjectcode,dispname,sum(newPlanMoney) as newPlanMoney, sum(ChangeMoney) as ChangeMoney  
into #Budget
from #BudgetBefore
group by iyear,imonth,subjectcode,dispname

drop table #budgetInfoAndNcDept,#ChangeMoneyAll,#BudgetBefore
---///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////---


-----------------------------------------------------Nc 基础部门表 + NC实算表Strat-------------------------------------------------------------------

--Nc 基础部门表 + NC实算表  非 All  部分

SELECT GL_NC_Cost.localRealCost,          --实际发生金额
		Base_NC_Dept.NC_DeptCode,         --NC部门代码
        GL_NC_Cost.NCDeptCode,            --NC部门代码
        Base_NC_Dept.NC_DeptName,         --NC部门名称
        GL_NC_Cost.NCDeptName,            --NC部门名称
        Base_NC_Dept.budget_DeptCode,     --预算部门代码
        GL_NC_Cost.IYear,                 --年份
        GL_NC_Cost.IMonth,                --月份
        GL_NC_Cost.subjcode,              --科目
        Base_AccountSubject.Dispname,     --科目名称
        Base_Budget_Dept.budget_DeptName  --预算部门名称
	into #NoAllRealCost
FROM Base_AccountSubject INNER JOIN                                                --NC科目表
      GL_NC_Cost ON                                                                --NC实际金额发生表
      Base_AccountSubject.subjectCode = GL_NC_Cost.subjcode 
      INNER JOIN Base_Runreport                                                    --报表 表
      ON GL_NC_Cost.NCDeptCode = Base_Runreport.BudgetDept 
      AND LEFT(GL_NC_Cost.subjcode, 4) = Base_Runreport.firstClassAccount          --关联条件为firstClassAccount里记录的头四位值
      LEFT OUTER JOIN Base_Budget_Dept INNER JOIN
      Base_NC_Dept ON                                                              --NC部门表
      Base_Budget_Dept.budget_DeptCode = Base_NC_Dept.budget_DeptCode ON 
      GL_NC_Cost.NCDeptCode = Base_NC_Dept.NC_DeptCode
WHERE (GL_NC_Cost.IYear = @iYear) AND (GL_NC_Cost.IMonth = @iMonth) 
	and GL_NC_Cost.subjcode not in ('410501','410504','410512','410510','550212','550204','550225','550201','550104','550101','550112','550109')
AND 
      (LEFT(GL_NC_Cost.subjcode, 4) IN
          (SELECT suncode
         FROM Base_CommonRelation)) AND (Base_Runreport.tableCode = @tableCode)    
         
         
--Nc 基础部门表 + NC实算表  非 All  部分


SELECT GL_NC_Cost.localRealCost,          --实际发生金额
		Base_NC_Dept.NC_DeptCode,         --NC部门代码
        GL_NC_Cost.NCDeptCode,            --NC部门代码
        Base_NC_Dept.NC_DeptName,         --NC部门名称
        GL_NC_Cost.NCDeptName,            --NC部门名称
        Base_NC_Dept.budget_DeptCode,     --预算部门代码
        GL_NC_Cost.IYear,                 --年份
        GL_NC_Cost.IMonth,                --月份
        GL_NC_Cost.subjcode,              --科目
        Base_AccountSubject.Dispname,     --科目名称
        Base_Budget_Dept.budget_DeptName  --预算部门名称
	into #AllRealCost
FROM Base_AccountSubject INNER JOIN                                                --NC科目表
      GL_NC_Cost ON                                                                --NC实际金额发生表
      Base_AccountSubject.subjectCode = GL_NC_Cost.subjcode 
      INNER JOIN Base_Runreport                                                    --报表 表
      ON GL_NC_Cost.NCDeptCode = Base_Runreport.BudgetDept 
      AND  Base_Runreport.firstClassAccount = 'all'                                --关联条件为All
      LEFT OUTER JOIN Base_Budget_Dept INNER JOIN
      Base_NC_Dept ON                                                              --NC部门表
      Base_Budget_Dept.budget_DeptCode = Base_NC_Dept.budget_DeptCode ON 
      GL_NC_Cost.NCDeptCode = Base_NC_Dept.NC_DeptCode
WHERE (GL_NC_Cost.IYear = @iYear) AND (GL_NC_Cost.IMonth = @iMonth) 
	and GL_NC_Cost.subjcode not in ('410501','410504','410512','410510','550225','550109','550212','550204','550201','550104','550101','550112')
AND 
      (LEFT(GL_NC_Cost.subjcode, 4) IN
          (SELECT suncode
         FROM Base_CommonRelation)) AND (Base_Runreport.tableCode = @tableCode)


--从Hr中取得人件费----------



SELECT nian,yue,Base_Runreport.firstclassaccount as zj,
Base_Runreport.budgetdept as budget_deptcode,
sum(bmgz)  as  工资,
sum(jbf) as 加班费,
sum(ylbx+yllbx+sybx+gsbx+syybx) as 保险,
sum(fl+txbz+jtbz) as 补助
into #HrRJF 
FROM Hr_GZB_RJF Hr 
inner join Base_Runreport on Hr.b0fycb = Base_Runreport.tablecode and Base_Runreport.type = 'FYCB' and Base_Runreport.classtype='Budget'

WHERE (Hr.Nian = @iYear) AND (Hr.Yue = @iMonth) and b0fycb in 
 (select tablecode from Base_Runreport where budgetdept in ( select budgetdept from Base_Runreport where tablecode = @tableCode)  )
group by nian ,yue ,firstclassaccount,Base_Runreport.budgetdept
--,b0fycb,fycb 


select 工资 as localrealcost,nian as iyear ,yue as imonth,budget_deptcode,case zj when '直' then '410501' else '550201' end  as subjcode,zj + ' 工资' as dispname 
into #HrRenjian1
from #HrRJF 
union all
select 加班费,nian,yue,budget_deptcode,case zj when '直' then '410510' else '550225' end  as subjcode,zj +' 加班费' as dispname from #HrRJF 
union all
select 保险,nian,yue,budget_deptcode,case zj when '直' then '410512' else '550201' end   as subjcode,zj +' 保险' as dispname from #HrRJF 
union all 
select 补助,nian,yue,budget_deptcode,case zj when '直' then '410504' else '550201' end   as subjcode,zj +' 福利' as dispname from #HrRJF 

-- 合并 All部分的
select Hr.*  into #HrRenjian2 from #HrRenjian1 Hr  inner  join Base_Runreport 
on Hr.budget_deptcode = Base_Runreport.budgetdept and  Base_Runreport.firstclassaccount = 'all'
where Base_Runreport.tablecode = @tableCode  and Base_Runreport.type in ('Dept','ClassDept') and Base_Runreport.ClassType = 'Budget'

union all
-- 4105 直接费用
select Hr.* from #HrRenjian1 Hr  inner  join Base_Runreport 
on Hr.budget_deptcode = Base_Runreport.budgetdept 
 AND LEFT(Hr.subjcode, 4) = Base_Runreport.firstClassAccount
where Base_Runreport.tablecode = @tableCode and  Base_Runreport.firstclassaccount = '4105'
 and Base_Runreport.type in ('Dept','ClassDept') and Base_Runreport.ClassType = 'Budget'

union all 
-- 5502 间接费用
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


select * into #RealCostBefore from #NoAllRealCost  union  all                            --关联 实际发生金额表的数据(All 与 NoAll)
select * from #AllRealCost
--select * from #RealCost           

select sum(localrealcost) as localrealcost,iyear,imonth,subjcode ,dispname 
 into #RealCost from  #RealCostBefore  
group by subjcode ,dispname ,iyear,imonth
 union all
select * from #HrRenjian                                


drop table #NoAllRealCost,#AllRealCost,#RealCostBefore,#HrRenjian

------------------------------------------------------Nc 基础部门表 + NC实算表End---------------------------------------------------------------------

--/////////////////////////////////////////////////////整理预算 与 实际发生的 金额//////////////////////////////////////////////////////////////////////

select 
isnull(#Budget.Iyear,#RealCost.IYear) as IYear,                                  --年，为空则采用nc中的年
isnull(#Budget.Imonth,#RealCost.Imonth) as Imonth,						         --月，为空则采用nc中的月
#Budget.budgetMoney,(#Budget.newPlanMoney ) as PlanMoney,#RealCost.localRealCost,                    --预算金额，推算金额，实际发证金额,调整金额
--#Budget.changeMoney,													         --调整金额
--isnull(#Budget.deptCode,#RealCost.NC_DeptCode) as BudgetdeptCode,              --预算部门
isnull(#Budget.Dispname,#RealCost.Dispname) as Dispname,                         --科目	
isnull(#Budget.SubjectCode,#RealCost.subjcode) as SubjectCode                    --科目编号
into #ThisMonthBudget 
  from #Budget   FULL  JOIN 
 #RealCost   on     #Budget.Iyear= #RealCost.Iyear and  #Budget.Imonth=#RealCost.Imonth
 and #Budget.SubjectCode=#RealCost.subjcode  


drop table #Budget,#RealCost  

--////////////////////////////////////////////////整理预算 与 实际发生的 金额End //////////////////////////////////////////////////////////////////////

--1.整理当月预实推
--2.归类，加字段。预算归类字段，

 
--3.判断月份， <= 6 ,   1q,2q,1h.       >6 .  3q,4q,2h.
--

-- 根据当前月份 ，查询出 预算情况 。字段为 ： 科目，年，月 ， 1q .2q. 1 h , 3q,4q, 2h 情况


declare @baseMonth int 

if @iMonth<= 6   -- 取 1q,2q预算信息 。 平均值用 1q计算
	begin
		set @baseMonth=0     --上半年
	end
else if @iMonth<= 12   -- 取 1q,2q预算信息 。 平均值用 2q计算
	begin
		set @baseMonth=6 	 --下半年
	end
	
SELECT  Iyear,       --年
		deptCode,    --部门
		SubjectCode, --科目
		( select isnull(sum(budgetMoney),0)/3 from budget_account o  where  
			o.imonth>=@baseMonth+1  and o.imonth<=@baseMonth+3 and o.iyear=budget_account.iyear and o.deptCode=budget_account.deptCode and o.SubjectCode
			=budget_account.SubjectCode) as oneQ, -- 一季度预算信息
		( select  isnull(sum(budgetMoney),0)/3 from budget_account o  where  
			o.imonth>=@baseMonth+4  and o.imonth<=@baseMonth+6  and o.iyear=budget_account.iyear and o.deptCode=budget_account.deptCode and o.SubjectCode
			=budget_account.SubjectCode) as twoQ, -- 二季度
		( select isnull(sum(budgetMoney),0)/6 from budget_account o  where  
			o.imonth>=@baseMonth+1  and o.imonth<=@baseMonth+6 and o.iyear=budget_account.iyear and o.deptCode=budget_account.deptCode and o.SubjectCode
			=budget_account.SubjectCode) as oneH  -- 上半年预算信息
into #QuarterInfoBefore 
FROM budget_account 
WHERE  (deptCode in (select budgetdept from base_runreport where tablecode=@tablecode))  and budget_account.iyear=@iYear 
group by deptCode,SubjectCode ,Iyear


select subjectcode,sum(oneQ) as oneQ,sum(twoQ) as twoQ,sum(oneH) as oneH into #QuarterInfo from #QuarterInfoBefore group by  subjectcode 


--聚合 #ThisMonthBudget  ，排除年月等信息 。集合到科目级别
select sum(PlanMoney) as PlanMoney ,sum(localRealCost) as localRealCost ,dispname,subjectcode into #ThisBudget from #ThisMonthBudget group by dispname,subjectcode



-- 应再与上面的 表联合查询把， 1q .2q. 1 h , 3q,4q, 2h 情况 加入 
select '0' as unionType,'0' as order1, #ThisBudget.*,Base_accontInBudgetSubject.CommonCode, Base_CommonCode.ShowOrder,Base_CommonCode.codename ,#QuarterInfo.oneQ,#QuarterInfo.twoQ,
#QuarterInfo.oneH
 into #table2  from   #ThisBudget left join Base_accontInBudgetSubject on  #ThisBudget.SubjectCode = Base_accontInBudgetSubject.subjectCode left JOIN Base_CommonCode 
 on   Base_CommonCode.Code = Base_accontInBudgetSubject.CommonCode  left join #QuarterInfo on #QuarterInfo.subjectcode = #ThisBudget.SubjectCode 
order by  Base_CommonCode.ShowOrder 


--求和的标 ，分类好的标 ，union 一下形成第四个表 ， --  加  1q .2q. 1 h , 3q,4q, 2h 情况

select *  from #table2 
 union all 
select '1' as unionType,'0' as order1,
sum(planmoney) as planmoney, sum (localrealcost) as localrealcost ,codename + '合计' as  Dispname,'' as subjectcode,commoncode,ShowOrder,codename,sum(oneQ) as oneQ,sum(twoQ) as twoQ,
sum(oneH) as oneH  
from #table2   group by  
commoncode,ShowOrder,codename 
 union all 
 select '2' as unionType, '1' as order1,
sum(planmoney) as planmoney, sum (localrealcost) as localrealcost , '总   计' as  Dispname,'' as subjectcode,'' as commoncode,'' as ShowOrder,'' as codename,sum(oneQ) as oneQ,sum(twoQ) as twoQ,
sum(oneH) as oneH  
from #table2   --group by  commoncode,ShowOrder,codename 

order by  order1 asc , ShowOrder asc, subjectcode desc 


drop table #QuarterInfo,#table2,#ThisMonthBudget,#ThisBudget,#QuarterInfoBefore

-- 查询科目的 ‘约束’！！！  前面已经加上。
GO









GRANT EXEC ON GetCostByClassDept TO PUBLIC

GO
