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
**		Desc: ��ѯ��˾Ԥʵ�����         
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
--�������������е��� ���루����Ŀ���֣������ֲ��ţ�

select iyear,imonth,outsubject  ,'0' as inMoney, sum([money]) as outMoney  into #tempChangeOut from budget_change_Sheet where iyear= @iYear and  imonth=  @iMonth group by  iyear,imonth,outsubject   --ת����Ŀ
select iyear,imonth,insubject   , sum([money]) as inMoney ,'0' as outMoney into  #tempChangeIn  from  budget_change_Sheet   where iyear= @iYear and  imonth=  @iMonth group by iyear,imonth,insubject         --ת����Ŀ

select *  into #tempChange from  #tempChangeOut 
	union all 
select * from  #tempChangeIn

select iyear ,imonth,outsubject as subject ,(isnull( inmoney,0) -isnull( outmoney ,0) ) as changeMoney into #ChangeMoney1
from  #tempChange 

select iyear,imonth,subject,sum(changemoney) as changemoney into #ChangeMoney from #ChangeMoney1
group by iyear,imonth,subject 

drop table #tempChangeOut,#tempChangeIn,#tempChange, #ChangeMoney1

--Ԥ��� + Nc�������ű� 

SELECT budget_account.Iyear,                            --��
	   budget_account.Imonth,                           --��
	   budget_account.SubjectCode,                      --��Ŀ
       SUM(budget_account.budgetMoney) AS budgetMoney,  --Ԥ����ϼ�
       SUM(budget_account.PlanMoney) AS PlanMoney,      --������ϼ�
       Base_AccountSubject.Dispname                     --��Ŀ����
       into #budgetInfoAndNcDept
FROM  budget_account INNER JOIN                                            --Ԥ���
      Base_AccountSubject ON                                               --��Ŀ��
      budget_account.SubjectCode = Base_AccountSubject.subjectCode
WHERE (budget_account.Iyear = @iYear) AND (budget_account.Imonth = @iMonth)         --��ѯ���� ������
GROUP BY budget_account.Iyear, budget_account.Imonth, budget_account.SubjectCode,   --�������� ���꣬�£���Ŀ
      Base_AccountSubject.Dispname
      
---//////////////////////////////////////////Ԥ��� + Nc�������ű� + �������////////////////////////////////////////////////////////---

select   #budgetInfoAndNcDept.*,               --Ԥ���ϼ��е������ֶ�
	(isnull(#budgetInfoAndNcDept.PlanMoney,0) + isnull(#ChangeMoney.ChangeMoney,0)) as newPlanMoney,   --���ϵ�������� ������
	#ChangeMoney.ChangeMoney                --�������
	into #Budget 
from #budgetInfoAndNcDept  left join #ChangeMoney 
		on   #budgetInfoAndNcDept.iyear = #ChangeMoney.iyear                 --�������� ����
		and  #budgetInfoAndNcDept.imonth = #ChangeMoney.imonth               --�������� ����
		and  #budgetInfoAndNcDept.subjectcode = #ChangeMoney.subject         --�������� ����Ŀ


drop table #budgetInfoAndNcDept,#ChangeMoney
---///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////---

--Nc �������ű� + NCʵ��� 

SELECT SUM(GL_NC_Cost.localRealCost) AS localRealCost,   --ʵ�ʷ������
		 GL_NC_Cost.IYear,                               --��
		 GL_NC_Cost.IMonth,                              --��
         GL_NC_Cost.subjcode,                            --��Ŀ
         Base_AccountSubject.Dispname                    --��Ŀ����
         into #RealCost 
FROM Base_AccountSubject INNER JOIN                                         --��Ŀ��
      GL_NC_Cost ON Base_AccountSubject.subjectCode = GL_NC_Cost.subjcode   --ʵ���
WHERE (GL_NC_Cost.IYear = @iYear) AND (GL_NC_Cost.IMonth = @iMonth) AND                       --��ѯ���� ������
      (LEFT(GL_NC_Cost.subjcode, 4) IN                                                        --��ѯ���� ����Ŀͷ4λ����Base_CommonRelation ��
          (SELECT suncode
         FROM Base_CommonRelation))
GROUP BY GL_NC_Cost.IYear, GL_NC_Cost.IMonth, GL_NC_Cost.subjcode,             --�����������꣬�£���Ŀ
      Base_AccountSubject.Dispname





--/////////////////////////////////////////////////////����Ԥ�� �� ʵ�ʷ����� ���//////////////////////////////////////////////////////////////////////

select 
isnull(#Budget.Iyear,#RealCost.IYear) as IYear,                                  --�꣬Ϊ�������nc�е���
isnull(#Budget.Imonth,#RealCost.Imonth) as Imonth,						         --�£�Ϊ�������nc�е���
#Budget.budgetMoney,(#Budget.newPlanMoney ) as PlanMoney,#RealCost.localRealCost,                    --Ԥ��������ʵ�ʷ�֤���,�������
--#Budget.changeMoney,													         --�������
--isnull(#Budget.deptCode,#RealCost.NC_DeptCode) as BudgetdeptCode,              --Ԥ�㲿��
isnull(#Budget.Dispname,#RealCost.Dispname) as Dispname,                         --��Ŀ	
isnull(#Budget.SubjectCode,#RealCost.subjcode) as SubjectCode                    --��Ŀ���
into #ThisBudget 
  from #Budget   FULL  JOIN 
 #RealCost   on     #Budget.Iyear= #RealCost.Iyear and  #Budget.Imonth=#RealCost.Imonth
 and #Budget.SubjectCode=#RealCost.subjcode  

drop table #Budget,#RealCost  

--////////////////////////////////////////////////����Ԥ�� �� ʵ�ʷ����� ���End //////////////////////////////////////////////////////////////////////




-- ���ݵ�ǰ�·� ����ѯ�� Ԥ����� ���ֶ�Ϊ �� ��Ŀ���꣬�� �� 1q .2q. 1 h , 3q,4q, 2h ���
--

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
		SubjectCode, --��Ŀ
		( select isnull(sum(budgetMoney),0)/3 from budget_account o  where  
			o.imonth>=@baseMonth+1  and o.imonth<=@baseMonth+3 and o.iyear=budget_account.iyear and  o.SubjectCode
			=budget_account.SubjectCode) as oneQ, -- һ����Ԥ����Ϣ
		( select  isnull(sum(budgetMoney),0)/3 from budget_account o  where  
			o.imonth>=@baseMonth+4  and o.imonth<=@baseMonth+6  and o.iyear=budget_account.iyear  and o.SubjectCode
			=budget_account.SubjectCode) as twoQ, -- ������
		( select isnull(sum(budgetMoney),0)/6 from budget_account o  where  
			o.imonth>=@baseMonth+1  and o.imonth<=@baseMonth+6 and o.iyear=budget_account.iyear   and o.SubjectCode
			=budget_account.SubjectCode) as oneH  -- �ϰ���Ԥ����Ϣ
into #QuarterInfo 
FROM budget_account 
WHERE  budget_account.iyear=@iYear 
group by SubjectCode ,Iyear


-- Ӧ��������� �����ϲ�ѯ�ѣ� 1q .2q. 1 h , 3q,4q, 2h ��� ���� 
select '0' as unionType,'0' as order1, #ThisBudget.*,Base_accontInBudgetSubject.CommonCode, Base_CommonCode.ShowOrder,Base_CommonCode.codename ,#QuarterInfo.oneQ,#QuarterInfo.twoQ,
#QuarterInfo.oneH
 into #table2  from   #ThisBudget left join Base_accontInBudgetSubject on  #ThisBudget.SubjectCode = Base_accontInBudgetSubject.subjectCode left JOIN Base_CommonCode 
 on   Base_CommonCode.Code = Base_accontInBudgetSubject.CommonCode  left join #QuarterInfo on #QuarterInfo.subjectcode = #ThisBudget.SubjectCode 
order by  Base_CommonCode.ShowOrder 


--��͵ı� ������õı� ��union һ���γɵ��ĸ��� �� --  ��  1q .2q. 1 h , 3q,4q, 2h ���



select *  from #table2 
 union all 
select '1' as unionType,'0' as order1, iyear,imonth ,sum(budgetmoney) as budgetmoney,
sum(planmoney) as planmoney, sum (localrealcost) as localrealcost ,codename + '�ϼ�' as  Dispname,'' as subjectcode,commoncode,ShowOrder,codename,sum(oneQ) as oneQ,sum(twoQ) as twoQ,
sum(oneH) as oneH  
from #table2   group by  
commoncode,ShowOrder,codename ,iyear,imonth 
union all
  select '2' as unionType,'1' as order1, iyear,imonth ,sum(budgetmoney) as budgetmoney,
sum(planmoney) as planmoney, sum (localrealcost) as localrealcost , '��  �ƣ�' as  Dispname,'' as subjectcode,'' as commoncode,'' as ShowOrder,'' as codename,sum(oneQ) as oneQ,sum(twoQ) as twoQ,
sum(oneH) as oneH  
from #table2   group by  iyear,imonth --commoncode,ShowOrder,codename ,
order by order1 asc , ShowOrder asc,subjectcode desc 


drop table #QuarterInfo,#table2,#ThisBudget

GO


GRANT EXEC ON GetCostByCompanyDept TO PUBLIC

GO
