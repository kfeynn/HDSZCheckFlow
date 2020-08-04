IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'p_GetBudgetByQuerter')
	BEGIN
		PRINT 'Dropping Procedure p_GetBudgetByQuerter'
		DROP  Procedure  p_GetBudgetByQuerter
	END

GO

PRINT 'Creating Procedure p_GetBudgetByQuerter'
GO
CREATE Procedure p_GetBudgetByQuerter
	@iyear int,
	@imonth int 
AS

/******************************************************************************
**		File: 
**		Name: p_GetBudgetByQuerter
**		Desc: 
			按季度查询预算信息,部门以及部门分类以及公司 横向排列,

**		Auth: zyq
**		Date: 2009-12-26
  
*******************************************************************************/

declare @querter int         --季度
declare @StartMonth int       
declare @EndMonth int
select  @querter = dbo.getQuarter(@imonth)

if @querter = 1 
	select @StartMonth=1,@EndMonth = 3
else if @querter = 2 
	select @StartMonth=4,@EndMonth = 6
else if @querter = 3 
	select @StartMonth=7,@EndMonth = 9
else if @querter = 4 
	select @StartMonth=10,@EndMonth = 12


--部门预算(分科目，部门分类，部门)
SELECT                              --类型排序（部门，部门分类，公司合计） 
	   budget_account.deptcode,                         --部门Code
	   Base_runreport.tablename ,                       --部门（报表）名称
	   Base_runreport.type,                             --类型
	   budget_account.Iyear,                            --年
	   dbo.getQuarter(@imonth) as Quarter ,                  --季度    
       SUM(budget_account.budgetMoney)/3 AS budgetMoney,--预算金额合计 季度平均
	   budget_account.SubjectCode,                      --科目
       Base_AccountSubject.Dispname ,                   --科目名称
	   Base_runreport.deptOrder                        --部门序号
	into #BudgetInfo 
FROM  budget_account INNER JOIN                                            --预算表
      Base_AccountSubject ON                                               --科目表
      budget_account.SubjectCode = Base_AccountSubject.subjectCode
	  left join Base_runreport on                                          --报表规则表
	  budget_account.deptcode = Base_runreport.budgetdept 
WHERE (budget_account.Iyear = @iyear)  
and Base_runreport.firstclassaccount = 'all' AND Base_runreport.type = 'Dept'   and 
(budget_account.Imonth between @StartMonth and @EndMonth)         --查询条件 ，年季
GROUP BY budget_account.deptcode , budget_account.Iyear,Base_runreport.tablename,
budget_account.SubjectCode,   --分组条件 ，年，季，科目
      Base_AccountSubject.Dispname ,Base_runreport.type,Base_runreport.deptOrder 

union all 

SELECT  
	   budget_account.deptcode,
	   Base_runreport.tablename ,
	   Base_runreport.type,
	   budget_account.Iyear,                            --年
	   dbo.getQuarter(@imonth) as Quarter ,                  --季度    
	   --budget_account.Imonth,                         --月 
       SUM(budget_account.budgetMoney)/3 AS budgetMoney,--预算金额合计 季度平均
	   budget_account.SubjectCode,                      --科目
       Base_AccountSubject.Dispname ,                    --科目名称
	   Base_runreport.deptOrder                        --部门序号

FROM  budget_account INNER JOIN                                            --预算表
      Base_AccountSubject ON                                               --科目表
      budget_account.SubjectCode = Base_AccountSubject.subjectCode
	  left join Base_runreport on                                          --报表规则表
	  budget_account.deptcode = Base_runreport.budgetdept 
WHERE (budget_account.Iyear = @iyear) AND Base_runreport.type = 'Dept'  
and Base_runreport.firstclassaccount = left(budget_account.subjectcode,4) and 
(budget_account.Imonth between @StartMonth and @EndMonth)         --查询条件 ，年月
GROUP BY budget_account.deptcode , 
budget_account.Iyear,Base_runreport.tablename,--budget_account.Imonth, 
budget_account.SubjectCode,   --分组条件 ，年，月，科目
      Base_AccountSubject.Dispname,Base_runreport.type,	   Base_runreport.deptOrder      


union all 


--部门预算(分科目，部门分类，部门)
SELECT 
	   '8100' deptcode,
	   Base_runreport.tablename ,
	   Base_runreport.type,
	   budget_account.Iyear,                            --年
	   dbo.getQuarter(@imonth) as Quarter ,                   --季度    
       SUM(budget_account.budgetMoney)/3 AS budgetMoney,--预算金额合计 季度平均
	   budget_account.SubjectCode,                      --科目
       Base_AccountSubject.Dispname ,                    --科目名称
	   Base_runreport.deptOrder                        --部门序号

FROM  budget_account INNER JOIN                                            --预算表
      Base_AccountSubject ON                                               --科目表
      budget_account.SubjectCode = Base_AccountSubject.subjectCode
	  left join Base_runreport on                                          --报表规则表
	  budget_account.deptcode = Base_runreport.budgetdept 
WHERE (budget_account.Iyear = @iyear)  
and Base_runreport.firstclassaccount = 'all' AND Base_runreport.type = 'ClassDept'   and 
(budget_account.Imonth between @StartMonth and @EndMonth)         --查询条件 ，年月
GROUP BY  budget_account.Iyear,Base_runreport.tablename,--budget_account.Imonth, 
		  budget_account.SubjectCode,   --分组条件 ，年，月，科目
          Base_AccountSubject.Dispname ,Base_runreport.type,Base_runreport.deptOrder    

union all 

SELECT   
       '8100' as deptcode,
	   Base_runreport.tablename ,
	   Base_runreport.type,
	   budget_account.Iyear,                            --年
	   dbo.getQuarter(@imonth) as Quarter ,                  --季度    
	   --budget_account.Imonth,                         --月 
       SUM(budget_account.budgetMoney)/3 AS budgetMoney,--预算金额合计 季度平均
	   budget_account.SubjectCode,                      --科目
       Base_AccountSubject.Dispname,                     --科目名称
	   Base_runreport.deptOrder                        --部门序号

FROM  budget_account INNER JOIN                                            --预算表
      Base_AccountSubject ON                                               --科目表
      budget_account.SubjectCode = Base_AccountSubject.subjectCode
	  left join Base_runreport on                                          --报表规则表
	  budget_account.deptcode = Base_runreport.budgetdept 
WHERE (budget_account.Iyear = @iyear) AND Base_runreport.type = 'ClassDept'  
and Base_runreport.firstclassaccount = left(budget_account.subjectcode,4) and 
(budget_account.Imonth between @StartMonth and @EndMonth)         --查询条件 ，年月
GROUP BY  
		budget_account.Iyear,Base_runreport.tablename,--budget_account.Imonth, 
		budget_account.SubjectCode,   --分组条件 ，年，月，科目
        Base_AccountSubject.Dispname,Base_runreport.type,	   Base_runreport.deptOrder                        --部门序号


union all 

-- 公司预算合计（分科目）

SELECT  	  
       '9100' as deptcode,
	   '总公司' as tablename ,
       'ACompany' as type,
        budget_account.Iyear,                           --年
	   dbo.getQuarter(@imonth) as Quarter ,                  --季度    
	   --budget_account.Imonth,                         --月 
       SUM(budget_account.budgetMoney)/3 AS budgetMoney,--预算金额合计 季度平均
	   budget_account.SubjectCode,                      --科目
       Base_AccountSubject.Dispname ,                    --科目名称
	   100 as deptOrder                        --部门序号

FROM  budget_account INNER JOIN                                            --预算表
      Base_AccountSubject ON                                               --科目表
      budget_account.SubjectCode = Base_AccountSubject.subjectCode
WHERE (budget_account.Iyear = @iyear)  and 
(budget_account.Imonth between @StartMonth and @EndMonth)         --查询条件 ，年月
GROUP BY  budget_account.Iyear,--budget_account.Imonth, 
budget_account.SubjectCode,   --分组条件 ，年，月，科目
Base_AccountSubject.Dispname                   --部门序号



order by deptcode ,tablename, budget_account.subjectcode  

---------------------------------基础预算值End----------------------------------------------

--  自定义科目合并


--自定义科目对应财务科目表
select  Base_CommonRelation.*,Base_CommonCode.codename 
into #MadeAccount
from  Base_CommonRelation,Base_CommonCode 
where Base_CommonRelation.type = 'MadeToAccountSubject'
and  Base_CommonCode.codetype = 'MadeAccountSubject'
and Base_CommonRelation.fathercode = Base_CommonCode.code 


--实际发生金额关联自定义科目，（有自定义的科目转换为自定义科目）

select 
  
#budgetinfo.iyear,  
#budgetinfo.quarter,
#budgetinfo.deptcode,
#budgetinfo.tablename,
#budgetinfo.type,
#budgetinfo.budgetMoney,
isnull(#MadeAccount.fathercode ,#budgetinfo.subjectcode) as subjectcode , -- 科目（包含自定义科目）
isnull(#MadeAccount.codename,#budgetinfo.dispname ) as  dispname,      --科目名称
#budgetinfo.deptOrder
into #Budget2 
from #budgetinfo left join #MadeAccount 
on  #budgetinfo.subjectcode=#MadeAccount.suncode 


--合并科目
select 
iyear,  
quarter,
deptcode,
tablename,
type,
sum(budgetMoney) as budgetMoney,
subjectcode,
dispname,
deptOrder

    
into #Budget
from #Budget2   group by iyear,quarter,deptcode,tablename,type,subjectcode,dispname,deptOrder


--select * from #Budget
----------------------------------自定义财务科目End----------------------------------------

-- 科目分类排序
-- 按Base_accontInBudgetSubject 中定义的规则排列汇总

select 
#Budget.* ,
ba.commoncode,
bc.codename,
bc.showorder 
into #Table 
from 
#Budget left join Base_accontInBudgetSubject  ba on  
#Budget.subjectcode = ba.subjectcode 
left join Base_CommonCode  bc  on 
ba.commoncode = bc.code and bc.codetype = 'CostBudgetType'

--order by showorder ,#Budget.subjectcode 



select  
0 as uniontype,
* 

into #BudgetEnd
from #Table 

union all
-- 类型分类合计  （人件费，统治经费等）

select 
1 as uniontype,
iyear,
quarter,
deptcode,
tablename,
type ,
sum(budgetmoney ) as budgetmoney,
'' as subjectcode,
codename + '合计：' as dispname,
deptOrder,
commoncode,
codename,
showorder
from #Table group by 
iyear,
quarter,
deptcode,
tablename,
type,
commoncode,
codename,
showorder,
deptOrder

union all
-- 总合计  （人件费 + 统治经费。。。）

select 
2 as uniontype,
iyear,
quarter,
deptcode,
tablename,
type ,
sum(budgetmoney ) as budgetmoney,
'' as subjectcode,
'总计：' as dispname,
deptOrder,
'' as commoncode,
'' as codename,
100 as showorder
from #Table group by 
iyear,
quarter,
deptcode,
tablename,
type,
deptOrder     --部门排序号


 
--order by deptcode,showorder,subjectcode 


--------------------------科目分类排序 End-----------------------------------------


--select * from #BudgetEnd order by deptcode ,showorder,uniontype,subjectcode 


-- 将部门横向显示

declare @s varchar(8000)
set @s = 'select codename as 费用类别,dispname as 科目名称'
select @s=@s+','+tablename+'=sum(case tablename when '''+tablename+''' then budgetmoney else 0 end ) '
from (select  subjectcode,dispname,codename,tablename,deptOrder  from #BudgetEnd ) budget group by tablename,deptOrder order by deptOrder  

print @s 

exec (@s + 'from #BudgetEnd group by  subjectcode,dispname,iyear,quarter,codename,showorder,uniontype order by showorder,uniontype,subjectcode   ')


drop table #budgetinfo ,#MadeAccount,#Budget2,#Budget,#Table,#BudgetEnd




GRANT EXEC ON p_GetBudgetByQuerter TO PUBLIC

GO
