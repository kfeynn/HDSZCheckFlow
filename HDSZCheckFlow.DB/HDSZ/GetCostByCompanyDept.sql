IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'GetCostByCompanyDept')
	BEGIN
		PRINT 'Dropping Procedure GetCostByCompanyDept'
		DROP  Procedure  GetCostByCompanyDept
	END

GO

PRINT 'Creating Procedure GetCostByCompanyDept'
GO

CREATE  Procedure GetCostByCompanyDept
	@iYear   int,
	@iMonth  int
AS

/******************************************************************************
**		File: 
**		Name: GetCostByCompanyDept
**		Desc: 查询公司预实算情况         
**		
**		Input							Output
**     ----------							-----------
**		Auth: zyq
**		Date: 2008-07-25
*******************************************************************************
**		Change History
*******************************************************************************
**		Date:		Author:				Description:
**		--------		--------	-------------------------------------------
**    
*******************************************************************************/

--------
--调整金额，调整表，有调出 调入（按科目区分，不区分部门）

select iyear,imonth,outsubject  ,'0' as inMoney, sum([money]) as outMoney  into #tempChangeOut from budget_change_Sheet where iyear= @iYear and  imonth=  @iMonth group by  iyear,imonth,outsubject   --转出项目
select iyear,imonth,insubject   , sum([money]) as inMoney ,'0' as outMoney into  #tempChangeIn  from  budget_change_Sheet   where iyear= @iYear and  imonth=  @iMonth group by iyear,imonth,insubject         --转入项目

select *  into #tempChange from  #tempChangeOut 
	union all 
select * from  #tempChangeIn

select iyear ,imonth,outsubject as subject ,(isnull( inmoney,0) -isnull( outmoney ,0) ) as changeMoney into #ChangeMoney1
from  #tempChange 

select iyear,imonth,subject,sum(changemoney) as changemoney into #ChangeMoney from #ChangeMoney1
group by iyear,imonth,subject 

drop table #tempChangeOut,#tempChangeIn,#tempChange, #ChangeMoney1

--预算表 + Nc基础部门表 

SELECT budget_account.Iyear,                            --年
	   budget_account.Imonth,                           --月
	   budget_account.SubjectCode,                      --科目
       SUM(budget_account.budgetMoney) AS budgetMoney,  --预算金额合计
       SUM(budget_account.PlanMoney) AS PlanMoney,      --推算金额合计
       Base_AccountSubject.Dispname                     --科目名称
       into #budgetInfoAndNcDept
FROM  budget_account INNER JOIN                                            --预算表
      Base_AccountSubject ON                                               --科目表
      budget_account.SubjectCode = Base_AccountSubject.subjectCode
WHERE (budget_account.Iyear = @iYear) AND (budget_account.Imonth = @iMonth)         --查询条件 ，年月
GROUP BY budget_account.Iyear, budget_account.Imonth, budget_account.SubjectCode,   --分组条件 ，年，月，科目
      Base_AccountSubject.Dispname
      
---//////////////////////////////////////////预算表 + Nc基础部门表 + 调整金额////////////////////////////////////////////////////////---

select   #budgetInfoAndNcDept.*,               --预算表合计中的所有字段
	(isnull(#budgetInfoAndNcDept.PlanMoney,0) + isnull(#ChangeMoney.ChangeMoney,0)) as newPlanMoney,   --加上调整金额后的 推算金额
	#ChangeMoney.ChangeMoney                --调整金额
	into #Budget 
from #budgetInfoAndNcDept  left join #ChangeMoney 
		on   #budgetInfoAndNcDept.iyear = #ChangeMoney.iyear                 --关联条件 ，年
		and  #budgetInfoAndNcDept.imonth = #ChangeMoney.imonth               --关联条件 ，月
		and  #budgetInfoAndNcDept.subjectcode = #ChangeMoney.subject         --关联条件 ，科目


drop table #budgetInfoAndNcDept,#ChangeMoney
---///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////---

--Nc 基础部门表 + NC实算表 

SELECT SUM(GL_NC_Cost.localRealCost) AS localRealCost,   --实际发生金额
		 GL_NC_Cost.IYear,                               --年
		 GL_NC_Cost.IMonth,                              --月
         GL_NC_Cost.subjcode,                            --科目
         Base_AccountSubject.Dispname                    --科目名称
         into #RealCost 
FROM Base_AccountSubject INNER JOIN                                         --科目表
      GL_NC_Cost ON Base_AccountSubject.subjectCode = GL_NC_Cost.subjcode   --实算表
WHERE (GL_NC_Cost.IYear = @iYear) AND (GL_NC_Cost.IMonth = @iMonth) AND                       --查询条件 ，年月
      (LEFT(GL_NC_Cost.subjcode, 4) IN                                                        --查询条件 ，科目头4位，在Base_CommonRelation 表
          (SELECT suncode
         FROM Base_CommonRelation))
GROUP BY GL_NC_Cost.IYear, GL_NC_Cost.IMonth, GL_NC_Cost.subjcode,             --分组条件，年，月，科目
      Base_AccountSubject.Dispname





--/////////////////////////////////////////////////////整理预算 与 实际发生的 金额//////////////////////////////////////////////////////////////////////

select 
isnull(#Budget.Iyear,#RealCost.IYear) as IYear,                                  --年，为空则采用nc中的年
isnull(#Budget.Imonth,#RealCost.Imonth) as Imonth,						         --月，为空则采用nc中的月
#Budget.budgetMoney,(#Budget.newPlanMoney ) as PlanMoney,#RealCost.localRealCost,                    --预算金额，推算金额，实际发证金额,调整金额
--#Budget.changeMoney,													         --调整金额
--isnull(#Budget.deptCode,#RealCost.NC_DeptCode) as BudgetdeptCode,              --预算部门
isnull(#Budget.Dispname,#RealCost.Dispname) as Dispname,                         --科目	
isnull(#Budget.SubjectCode,#RealCost.subjcode) as SubjectCode                    --科目编号
into #ThisBudget 
  from #Budget   FULL  JOIN 
 #RealCost   on     #Budget.Iyear= #RealCost.Iyear and  #Budget.Imonth=#RealCost.Imonth
 and #Budget.SubjectCode=#RealCost.subjcode  

drop table #Budget,#RealCost  

--////////////////////////////////////////////////整理预算 与 实际发生的 金额End //////////////////////////////////////////////////////////////////////




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
		SubjectCode, --科目
		( select isnull(sum(budgetMoney),0)/3 from budget_account o  where  
			o.imonth>=@baseMonth+1  and o.imonth<=@baseMonth+3 and o.iyear=budget_account.iyear and  o.SubjectCode
			=budget_account.SubjectCode) as oneQ, -- 一季度预算信息
		( select  isnull(sum(budgetMoney),0)/3 from budget_account o  where  
			o.imonth>=@baseMonth+4  and o.imonth<=@baseMonth+6  and o.iyear=budget_account.iyear  and o.SubjectCode
			=budget_account.SubjectCode) as twoQ, -- 二季度
		( select isnull(sum(budgetMoney),0)/6 from budget_account o  where  
			o.imonth>=@baseMonth+1  and o.imonth<=@baseMonth+6 and o.iyear=budget_account.iyear   and o.SubjectCode
			=budget_account.SubjectCode) as oneH  -- 上半年预算信息
into #QuarterInfo 
FROM budget_account 
WHERE  budget_account.iyear=@iYear 
group by SubjectCode ,Iyear


-- 应再与上面的 表联合查询把， 1q .2q. 1 h , 3q,4q, 2h 情况 加入 
select '0' as unionType,'0' as order1, #ThisBudget.*,Base_accontInBudgetSubject.CommonCode, Base_CommonCode.ShowOrder,Base_CommonCode.codename ,#QuarterInfo.oneQ,#QuarterInfo.twoQ,
#QuarterInfo.oneH
 into #table2  from   #ThisBudget left join Base_accontInBudgetSubject on  #ThisBudget.SubjectCode = Base_accontInBudgetSubject.subjectCode left JOIN Base_CommonCode 
 on   Base_CommonCode.Code = Base_accontInBudgetSubject.CommonCode  left join #QuarterInfo on #QuarterInfo.subjectcode = #ThisBudget.SubjectCode 
order by  Base_CommonCode.ShowOrder 


--求和的标 ，分类好的标 ，union 一下形成第四个表 ， --  加  1q .2q. 1 h , 3q,4q, 2h 情况



select *  from #table2 
 union all 
select '1' as unionType,'0' as order1, iyear,imonth ,sum(budgetmoney) as budgetmoney,
sum(planmoney) as planmoney, sum (localrealcost) as localrealcost ,codename + '合计' as  Dispname,'' as subjectcode,commoncode,ShowOrder,codename,sum(oneQ) as oneQ,sum(twoQ) as twoQ,
sum(oneH) as oneH  
from #table2   group by  
commoncode,ShowOrder,codename ,iyear,imonth 
union all
  select '2' as unionType,'1' as order1, iyear,imonth ,sum(budgetmoney) as budgetmoney,
sum(planmoney) as planmoney, sum (localrealcost) as localrealcost , '总  计：' as  Dispname,'' as subjectcode,'' as commoncode,'' as ShowOrder,'' as codename,sum(oneQ) as oneQ,sum(twoQ) as twoQ,
sum(oneH) as oneH  
from #table2   group by  iyear,imonth --commoncode,ShowOrder,codename ,
order by order1 asc , ShowOrder asc,subjectcode desc 


drop table #QuarterInfo,#table2,#ThisBudget

GO


GRANT EXEC ON GetCostByCompanyDept TO PUBLIC

GO
