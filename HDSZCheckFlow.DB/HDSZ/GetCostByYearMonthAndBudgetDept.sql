IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'GetCostByYearMonthAndBudgetDept')
	BEGIN
		PRINT 'Dropping Procedure GetCostByYearMonthAndBudgetDept'
		DROP  Procedure  GetCostByYearMonthAndBudgetDept
	END

GO

PRINT 'Creating Procedure GetCostByYearMonthAndBudgetDept'
GO
CREATE Procedure GetCostByYearMonthAndBudgetDept
	@iYear   int,                                 --年
	@iMonth  int,                                 --月
	@budGetDept varchar(100),                      --预算部门
	@subject varchar(50)                          --科目,All代表所有, 4105 ,5502 等,代表一级科目 (前4位数字)
AS

/******************************************************************************
**		File: 
**		Name: GetCostByYearMonthAndBudgetDept
**		Desc: 根据 年,月,预算部门 查询预实算情况
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
**		Date: 2008-07-17
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



select iyear,imonth,outsubject  ,deptcode,[money] as outMoney  into #tempChangeOut from budget_change_Sheet where iyear= @iYear and  imonth=  @iMonth and  deptcode in (  @budGetDept ) --转出项目
select iyear,imonth,insubject  , deptcode ,[money] as inMoney into  #tempChangeIn  from  budget_change_Sheet   where iyear= @iYear and  imonth=  @iMonth and  deptcode in (  @budGetDept )        --转入项目

select  iyear,imonth , deptcode, outsubject,sum(outmoney) as outMoney  into #outItem from #tempChangeOut  group by outsubject ,iyear,imonth,deptcode  --按年月outsubject,group金额
select  iyear,imonth , deptcode, insubject ,sum(inmoney) as inMoney into #inItem from  #tempChangein   group by insubject ,iyear,imonth,deptcode                             --按年月insubject ,group金额


--预算表 + Nc基础部门表 
set @sqlYusuanAndNcdept = 'SELECT budget_account.Iyear, budget_account.Imonth, budget_account.SubjectCode, 
      budget_account.budgetMoney, budget_account.CheckMoney, 
      budget_account.PlanMoney, budget_account.deptCode, 
      Base_NC_Dept.NC_DeptCode, Base_NC_Dept.NC_DeptName, 
      Base_NC_Dept.budget_DeptCode, Base_Budget_Dept.budget_DeptName, 
      Base_AccountSubject.Dispname,
      ( isnull((select inMoney from #inItem  where #inItem.iyear=budget_account.iyear and  #inItem.Imonth=budget_account.Imonth and  #inItem.insubject=budget_account.SubjectCode  and  #inItem.deptcode=budget_account.deptcode),0) - 
      isnull((select outMoney from #outItem  where #outItem.iyear=budget_account.iyear and  #outItem.Imonth=budget_account.Imonth and  #outItem.outsubject=budget_account.SubjectCode  and  #outItem.deptcode=budget_account.deptcode),0)            
        ) as changeMoney    --调整金额
       into temp1           --exec 只能生成表，而不可保存临时表
FROM budget_account INNER JOIN
      Base_Budget_Dept ON 
      budget_account.deptCode = Base_Budget_Dept.budget_DeptCode INNER JOIN
      Base_AccountSubject ON 
      budget_account.SubjectCode = Base_AccountSubject.subjectCode LEFT OUTER JOIN
      Base_NC_Dept ON budget_account.deptCode = Base_NC_Dept.budget_DeptCode
where budget_account.Iyear= '+  cast(@iYear as char(4))  + ' and budget_account.Imonth =' +  cast(@iMonth as char(4))  + ' and  budget_account.deptcode in ( '+   cast( @budGetDept as char(100) )  + ')'

if @subject <> 'ALL'    -- 如果需要查询的科目不为所有 ，则根据要求筛选科目 
	begin
	
		set @sqlYusuanAndNcdept = @sqlYusuanAndNcdept + ' and left(budget_account.SubjectCode,4)  =  ' + cast(@subject as char(8))  
		
	end

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
         
if @subject <> 'ALL'    -- 如果需要查询的科目不为所有 ，则根据要求筛选科目 
	begin
	
		set @sqlNcdeptAndNcCost = @sqlNcdeptAndNcCost + ' and left(GL_NC_Cost.subjcode,4)  =  ' + cast(@subject as char(8))  
		
	end

exec (@sqlNcdeptAndNcCost)  --执行 sql 语句


select 
isnull(temp1.Iyear,temp2.IYear) as IYear,                                 --年，为空则采用nc中的年
isnull(temp1.Imonth,temp2.Imonth) as Imonth,						        --月，为空则采用nc中的月
isnull(temp1.budget_DeptName,temp2.budget_DeptName) as budget_DeptName,   --预算部门，为空则采用nc中的  
isnull(temp1.NC_DeptName,temp2.NC_DeptName) as NC_DeptName,               --nc部门，为空则用nc的
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
		deptCode,    --部门
		SubjectCode, --科目
		( select isnull(sum(budgetMoney),0)/3 from budget_account o  where  
			o.imonth>=@baseMonth+1  and o.imonth<=@baseMonth+3 and o.iyear=budget_account.iyear and o.deptCode=budget_account.deptCode and o.SubjectCode
			=budget_account.SubjectCode) as oneQ, -- 一季度预算信息
		( select  isnull(sum(budgetMoney),0)/3 from budget_account o  where  
			o.imonth>=@baseMonth+4  and o.imonth<=@baseMonth+6 and o.deptCode=budget_account.deptCode and o.SubjectCode
			=budget_account.SubjectCode) as twoQ, -- 二季度
		( select isnull(sum(budgetMoney),0)/6 from budget_account o  where  
			o.imonth>=@baseMonth+1  and o.imonth<=@baseMonth+6 and o.iyear=budget_account.iyear and o.deptCode=budget_account.deptCode and o.SubjectCode
			=budget_account.SubjectCode) as oneH  -- 上半年预算信息
into #QuarterInfo 
FROM budget_account 
WHERE  (deptCode =@budGetDept ) 
group by deptCode,SubjectCode ,Iyear



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

GRANT EXEC ON GetCostByYearMonthAndBudgetDept TO PUBLIC

GO
