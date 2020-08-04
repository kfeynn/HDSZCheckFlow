IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'GetCostByClassDept')
	BEGIN
		PRINT 'Dropping Procedure GetCostByClassDept'
		DROP  Procedure  GetCostByClassDept
	END

GO

PRINT 'Creating Procedure GetCostByClassDept'
GO
CREATE Procedure GetCostByClassDept

	@iYear   int,                                 --年
	@iMonth  int,                                 --月
	@budGetDept varchar(100),                     --预算部门 (21,2201,2202 ) 等 ,代表需要统计的几个预算部门 , 
	@tableCode varchar(100)                       --runReport的Code
	
AS

/******************************************************************************
**		File: 
**		Name: GetCostByClassDept
**		Desc: 分三类预算部门,合计预实算 报表
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
**		Auth: zyq
**		Date: 2008-07-22
*******************************************************************************
**		Change History
*******************************************************************************
**		Date:		Author:				Description:
**		--------		--------				-------------------------------------------
**    
*******************************************************************************/

--调整金额，调整表，有调出 调入

declare @sqlYusuanAndNcdept varchar(2000)           -- 预算表 + Nc基础部门表  ,查询字符串
declare @sqlNcdeptAndNcCost varchar(2000)           -- Nc 基础部门表 + NC实算表  ,查询字符串

SELECT budget_account.deptCode, budget_account.Iyear, budget_account.Imonth, 
      SUM(budget_account.budgetMoney) AS budgetMoney, 
      SUM(budget_account.PlanMoney) AS PlanMoney, budget_account.SubjectCode, 
      Base_AccountSubject.Dispname, Base_Budget_Dept.budget_DeptName, 
      Base_NC_Dept.NC_DeptName
FROM budget_account INNER JOIN
      Base_Budget_Dept ON 
      budget_account.deptCode = Base_Budget_Dept.budget_DeptCode INNER JOIN
      Base_AccountSubject ON 
      budget_account.SubjectCode = Base_AccountSubject.subjectCode LEFT OUTER JOIN
      Base_NC_Dept ON 
      budget_account.deptCode = Base_NC_Dept.budget_DeptCode INNER JOIN
      Base_Runreport ON LEFT(budget_account.SubjectCode, 4) 
      = Base_Runreport.firstClassAccount AND 
      budget_account.deptCode = Base_Runreport.BudgetDept
WHERE (Base_Runreport.tableCode = 'fuzhudept') AND (budget_account.Iyear = 2008) AND 
      (budget_account.Imonth = 6) AND (Base_Runreport.BudgetDept IN
          (SELECT BudgetDept
         FROM Base_Runreport
         WHERE (tableCode = 'fuzhudept')))
GROUP BY budget_account.deptCode, budget_account.Iyear, budget_account.Imonth, 
      Base_AccountSubject.Dispname, budget_account.SubjectCode, 
      Base_Budget_Dept.budget_DeptName, Base_NC_Dept.NC_DeptName

select iyear,imonth,outsubject  ,deptcode,[money] as outMoney  into #tempChangeOut from budget_change_Sheet where iyear= @iYear and  imonth=  @iMonth and  deptcode in (  @budGetDept )    --转出项目(按年月,部门集合,注:可有一个或多个部门)
select iyear,imonth,insubject  , deptcode ,[money] as inMoney into  #tempChangeIn  from  budget_change_Sheet   where iyear= @iYear and  imonth=  @iMonth and  deptcode in (  @budGetDept ) --转入项目

/*   
-- 非all部分的调整金额,out 

SELECT budget_change_Sheet.Iyear,                   --年
		budget_change_Sheet.Imonth,                 --月
      budget_change_Sheet.OutSubject,               --转出项目
      budget_change_Sheet.DeptCode,                 --部门
       sum( budget_change_Sheet.Money) as outMoney  --转出金额
FROM budget_change_Sheet INNER JOIN                                       --调整表
      Base_Runreport ON LEFT(budget_change_Sheet.OutSubject, 4)           --报表 表
      = Base_Runreport.firstClassAccount AND 
      budget_change_Sheet.DeptCode = Base_Runreport.BudgetDept AND          
      Base_Runreport.tableCode = 'fuzhuDept'                               --查询表类别
WHERE (Base_Runreport.BudgetDept IN
          (SELECT BudgetDept
         FROM Base_Runreport
         WHERE (tableCode = 'fuzhuDept'))) AND (budget_change_Sheet.Iyear = 2008) AND 
      (budget_change_Sheet.Imonth = 6)
group by iyear, imonth,outsubject ,deptcode 

-- 非all部分的调整金额,in 

SELECT budget_change_Sheet.Iyear,                   --年
		budget_change_Sheet.Imonth,                 --月
      budget_change_Sheet.InSubject,               --转入项目
      budget_change_Sheet.DeptCode,                 --部门
       sum( budget_change_Sheet.Money) as InMoney  --转出金额
FROM budget_change_Sheet INNER JOIN                                       --调整表
      Base_Runreport ON LEFT(budget_change_Sheet.OutSubject, 4)           --报表 表
      = Base_Runreport.firstClassAccount AND 
      budget_change_Sheet.DeptCode = Base_Runreport.BudgetDept AND          
      Base_Runreport.tableCode = 'fuzhuDept'                               --查询表类别
WHERE (Base_Runreport.BudgetDept IN
          (SELECT BudgetDept
         FROM Base_Runreport
         WHERE (tableCode = 'fuzhuDept'))) AND (budget_change_Sheet.Iyear = 2008) AND 
      (budget_change_Sheet.Imonth = 6)
group by iyear, imonth,Insubject ,deptcode 

*/
-- 调整金额 ，可以放到最后 

-- all 部分得调整金额 out 
SELECT budget_change_Sheet.Iyear,                     --年
		budget_change_Sheet.Imonth,                   --月
      budget_change_Sheet.OutSubject,                 --转出项目
      budget_change_Sheet.DeptCode,                   --部门
      sum (budget_change_Sheet.Money) as outMoney     --转出金额（合计）
FROM budget_change_Sheet INNER JOIN                                              --预算调整表
      Base_Runreport ON                                                          --报表 表 （过滤统计部门以及科目）
      budget_change_Sheet.DeptCode = Base_Runreport.BudgetDept AND 
      Base_Runreport.tableCode = 'fuzhuDept'                                     --查询表类别
WHERE (Base_Runreport.BudgetDept IN
          (SELECT BudgetDept
         FROM Base_Runreport
         WHERE (tableCode = 'fuzhuDept'))) AND (budget_change_Sheet.Iyear = 2008) AND 
      (budget_change_Sheet.Imonth = 6) AND (Base_Runreport.firstClassAccount = 'all')
    group by iyear, imonth,outsubject ,deptcode 

-- all 部分得调整金额 in
SELECT budget_change_Sheet.Iyear,                     --年
		budget_change_Sheet.Imonth,                   --月
      budget_change_Sheet.inSubject,                 --转出项目
      budget_change_Sheet.DeptCode,                   --部门
      sum (budget_change_Sheet.Money) as inMoney     --转出金额（合计）
FROM budget_change_Sheet INNER JOIN                                              --预算调整表
      Base_Runreport ON                                                          --报表 表 （过滤统计部门以及科目）
      budget_change_Sheet.DeptCode = Base_Runreport.BudgetDept AND 
      Base_Runreport.tableCode = 'fuzhuDept'                                     --查询表类别
WHERE (Base_Runreport.BudgetDept IN
          (SELECT BudgetDept
         FROM Base_Runreport
         WHERE (tableCode = 'fuzhuDept'))) AND (budget_change_Sheet.Iyear = 2008) AND 
      (budget_change_Sheet.Imonth = 6) AND (Base_Runreport.firstClassAccount = 'all')
    group by iyear, imonth,insubject ,deptcode 



select  iyear,imonth ,  outsubject,sum(outmoney) as outMoney  into #outItem from #tempChangeOut  group by outsubject ,iyear,imonth  --按年月科目outsubject,group金额
select  iyear,imonth ,  insubject ,sum(inmoney) as inMoney into #inItem from  #tempChangein   group by insubject ,iyear,imonth      --按年月科目insubject ,group金额


-- 根据部门  筛选科目 ( 有的部门,需要统计全部科目,有的部门只需要统计部分科目) 


--预算表 + Nc基础部门表 + Base_runReport
SELECT budget_account.deptCode,           --部门
		budget_account.Iyear,             --年份
		budget_account.Imonth,            --月份
      sum(budget_account.budgetMoney) as budgetMoney,       --预算金额
      sum( budget_account.PlanMoney) as PlanMoney,          --推算金额
       budget_account.SubjectCode,        --科目号码
      Base_AccountSubject.Dispname        --科目名称
FROM budget_account INNER JOIN                         --预算表
      Base_AccountSubject ON                           --基础NC科目表
      budget_account.SubjectCode = Base_AccountSubject.subjectCode INNER JOIN
      Base_Runreport ON LEFT(budget_account.SubjectCode, 4)   -- 基础报表 表
      = Base_Runreport.firstClassAccount AND 
      budget_account.deptCode = Base_Runreport.BudgetDept
WHERE (Base_Runreport.tableCode = @tableCode) AND (budget_account.Iyear = @iYear) AND 
      (budget_account.Imonth = @iMonth) AND (Base_Runreport.BudgetDept in (SELECT BudgetDept FROM Base_Runreport WHERE (tableCode = @tableCode )) )
group by budget_account.deptCode,budget_account.Iyear,                    --按照 年，月，部门，科目 做合计
budget_account.Imonth,Base_AccountSubject.Dispname,budget_account.SubjectCode



--预算表 + Nc基础部门表 
set @sqlYusuanAndNcdept = ' SELECT budget_account.Iyear, budget_account.Imonth, budget_account.SubjectCode, 
     sum( budget_account.budgetMoney),
      sum(budget_account.PlanMoney),           
      Base_AccountSubject.Dispname,
      ( isnull((select inMoney from #inItem  where #inItem.iyear=budget_account.iyear and  #inItem.Imonth=budget_account.Imonth 
and  #inItem.insubject=budget_account.SubjectCode  ),0) - 
      isnull((select outMoney from #outItem  where #outItem.iyear=budget_account.iyear and  #outItem.Imonth=budget_account.Imonth 
and  #outItem.outsubject=budget_account.SubjectCode  ),0)            
        ) as changeMoney    --调整金额
       into temp1           --exec 只能生成表，而不可保存临时表
FROM budget_account INNER JOIN
      Base_AccountSubject ON 
      budget_account.SubjectCode = Base_AccountSubject.subjectCode 
where budget_account.Iyear= '+  cast(@iYear as char(4))  + ' and budget_account.Imonth =' +  cast(@iMonth as char(4))  + ' and  budget_account.deptcode in ( '+   cast( @budGetDept as char(100) )  + ')
 group by  budget_account.Iyear, budget_account.Imonth, budget_account.SubjectCode ,Base_AccountSubject.Dispname '




 EXEC(@sqlYusuanAndNcdept)    --执行 sql 语句

drop table  #tempChangeOut,#tempChangeIn ,#outItem,#inItem   --删除调整临时表
--Nc 基础部门表 + NC实算表 
         
--准备sql 语句
set @sqlNcdeptAndNcCost = 'SELECT GL_NC_Cost.localRealCost, Base_NC_Dept.NC_DeptCode, 
      GL_NC_Cost.NCDeptCode, Base_NC_Dept.NC_DeptName, 
      GL_NC_Cost.NCDeptName, Base_NC_Dept.budget_DeptCode, GL_NC_Cost.IYear, 
      GL_NC_Cost.IMonth, GL_NC_Cost.subjcode, Base_Budget_Dept.budget_DeptName, 
      Base_AccountSubject.Dispname into temp2
FROM Base_AccountSubject INNER JOIN
      GL_NC_Cost ON 
      Base_AccountSubject.subjectCode = GL_NC_Cost.subjcode LEFT OUTER JOIN
      Base_Budget_Dept INNER JOIN
      Base_NC_Dept ON 
      Base_Budget_Dept.budget_DeptCode = Base_NC_Dept.budget_DeptCode ON 
      GL_NC_Cost.NCDeptCode = Base_NC_Dept.NC_DeptCode
WHERE  GL_NC_Cost.IYear =' +  cast(@iYear as char(4)) + 'and  GL_NC_Cost.IMonth ='+  cast(@iMonth as char(4))  + '  and  GL_NC_Cost.NCDeptCode   
in ( ' +  cast( @budGetDept as char(100) )  + ')  and  (LEFT(GL_NC_Cost.subjcode, 4) IN
          (SELECT suncode
         FROM Base_CommonRelation)) '
         
   

exec (@sqlNcdeptAndNcCost)  --执行 sql 语句


select 
isnull(temp1.Iyear,temp2.IYear) as IYear,                                  --年，为空则采用nc中的年
isnull(temp1.Imonth,temp2.Imonth) as Imonth,						       --月，为空则采用nc中的月
isnull(temp1.budget_DeptName,temp2.budget_DeptName) as budget_DeptName,    --预算部门，为空则采用nc中的  
isnull(temp1.NC_DeptName,temp2.NC_DeptName) as NC_DeptName,                --nc部门，为空则用nc的
temp1.budgetMoney,(temp1.PlanMoney + temp1.changeMoney ) as PlanMoney,temp2.localRealCost,                    --预算金额，推算金额，实际发证金额,调整金额
--temp1.changeMoney,													   --调整金额
--isnull(temp1.deptCode,temp2.NC_DeptCode) as BudgetdeptCode,              --预算部门
isnull(temp1.Dispname,temp2.Dispname) as Dispname,                         --科目	
isnull(temp1.SubjectCode,temp2.subjcode) as SubjectCode                    --科目编号
into #ThisMonthBudget 
  from temp1   FULL  JOIN 
 temp2   on     temp1.Iyear= temp2.Iyear and  temp1.Imonth=temp2.Imonth
 and temp1.SubjectCode=temp2.subjcode  and  temp1.deptCode=temp2.budget_DeptCode

drop table temp1,temp2


--1.整理当月预实推
--2.归类，加字段。预算归类字段，

 
--3.判断月份， <= 6 ,   1q,2q,1h.       >6 .  3q,4q,2h.
--

-- 根据当前月份 ，查询出 预算情况 。字段为 ： 科目，年，月 ， 1q .2q. 1 h , 3q,4q, 2h 情况
--

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
		Imonth,      --月
		deptCode,    --部门
		SubjectCode, --科目
		( select  budgetMoney from budget_account o  where  
o.imonth=@baseMonth+1 and o.iyear=budget_account.iyear and o.deptCode=budget_account.deptCode and o.SubjectCode
=budget_account.SubjectCode) as onemonth, -- 一月预算信息
( select  budgetMoney from budget_account o  where  
o.imonth=@baseMonth+2 and o.iyear=budget_account.iyear and o.deptCode=budget_account.deptCode and o.SubjectCode
=budget_account.SubjectCode) as twomonth, -- 二月
( select  budgetMoney from budget_account o  where  
o.imonth=@baseMonth+3 and o.iyear=budget_account.iyear and o.deptCode=budget_account.deptCode and o.SubjectCode
=budget_account.SubjectCode) as threemonth, -- 三月
( select  budgetMoney from budget_account o  where  
o.imonth=@baseMonth+4 and o.iyear=budget_account.iyear and o.deptCode=budget_account.deptCode and o.SubjectCode
=budget_account.SubjectCode) as firthmonth, -- 四月
( select  budgetMoney from budget_account o  where  
o.imonth=@baseMonth+5 and o.iyear=budget_account.iyear and o.deptCode=budget_account.deptCode and o.SubjectCode
=budget_account.SubjectCode) as firemonth, -- 五月
( select  budgetMoney from budget_account o  where  
o.imonth=@baseMonth+6 and o.iyear=budget_account.iyear and o.deptCode=budget_account.deptCode and o.SubjectCode
=budget_account.SubjectCode) as sixmonth  --六月 
into #QuarterBudget 
FROM budget_account 
WHERE (deptCode = 21) 

select deptcode, subjectcode,
(isnull(onemonth,0) + isnull(twomonth,0) + isnull(threemonth,0) )/3 as oneQ,
(isnull(firthmonth,0) +isnull( firemonth,0)  +isnull( sixmonth,0) ) /3 as twoQ ,
(isnull(onemonth,0) + isnull(twomonth,0) + isnull(threemonth,0) +isnull(firthmonth,0) +isnull( firemonth,0)  +isnull( sixmonth,0)) /6 as oneH
into #QuarterInfo 
 from #QuarterBudget

drop table  #QuarterBudget



-- 应再与上面的 表联合查询把， 1q .2q. 1 h , 3q,4q, 2h 情况 加入 
select '0' as unionType, #ThisMonthBudget.*,Base_accontInBudgetSubject.CommonCode, Base_CommonCode.ShowOrder,Base_CommonCode.codename ,#QuarterInfo.oneQ,#QuarterInfo.twoQ,
#QuarterInfo.oneH
 into #table2  from   #ThisMonthBudget left join Base_accontInBudgetSubject on  #ThisMonthBudget.SubjectCode = Base_accontInBudgetSubject.subjectCode left JOIN Base_CommonCode 
 on   Base_CommonCode.Code = Base_accontInBudgetSubject.CommonCode  left join #QuarterInfo on #QuarterInfo.subjectcode = #ThisMonthBudget.SubjectCode 
order by  Base_CommonCode.ShowOrder 

--求和的标 ，分类好的标 ，union 一下形成第四个表 ， --  加  1q .2q. 1 h , 3q,4q, 2h 情况

select *  from #table2 
 union all 
select '1' as unionType, iyear,imonth,budget_deptname,nc_deptname,sum(budgetmoney) as budgetmoney,
sum(planmoney) as planmoney, sum (localrealcost) as localrealcost ,codename + '合计' as  Dispname,'' as subjectcode,commoncode,ShowOrder,codename,sum(oneQ) as oneQ,sum(twoQ) as twoQ,
sum(oneH) as oneH  
from #table2   group by  iyear,imonth,budget_deptname,nc_deptname,
commoncode,ShowOrder,codename 
order by ShowOrder asc,subjectcode desc 


drop table #QuarterInfo,#table2,#ThisMonthBudget

--@subject varchar(50)                          --科目,All代表所有, 4105 ,5502 等,代表一级科目 (前4位数字) 
-- 查询科目的 ‘约束’！！！  前面已经加上。 
 







GO

GRANT EXEC ON GetCostByClassDept TO PUBLIC

GO
