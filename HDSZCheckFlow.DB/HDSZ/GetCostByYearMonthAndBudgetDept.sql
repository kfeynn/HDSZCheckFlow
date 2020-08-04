IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'GetCostByYearMonthAndBudgetDept')
	BEGIN
		PRINT 'Dropping Procedure GetCostByYearMonthAndBudgetDept'
		DROP  Procedure  GetCostByYearMonthAndBudgetDept
	END

GO

PRINT 'Creating Procedure GetCostByYearMonthAndBudgetDept'
GO
CREATE Procedure GetCostByYearMonthAndBudgetDept
	@iYear   int,                                 --��
	@iMonth  int,                                 --��
	@budGetDept varchar(100),                      --Ԥ�㲿��
	@subject varchar(50)                          --��Ŀ,All��������, 4105 ,5502 ��,����һ����Ŀ (ǰ4λ����)
AS

/******************************************************************************
**		File: 
**		Name: GetCostByYearMonthAndBudgetDept
**		Desc: ���� ��,��,Ԥ�㲿�� ��ѯԤʵ�����
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

--�������������е��� ����

declare @sqlYusuanAndNcdept varchar(2000)           -- Ԥ��� + Nc�������ű�  ,��ѯ�ַ���
declare @sqlNcdeptAndNcCost varchar(2000)           -- Nc �������ű� + NCʵ���  ,��ѯ�ַ���



select iyear,imonth,outsubject  ,deptcode,[money] as outMoney  into #tempChangeOut from budget_change_Sheet where iyear= @iYear and  imonth=  @iMonth and  deptcode in (  @budGetDept ) --ת����Ŀ
select iyear,imonth,insubject  , deptcode ,[money] as inMoney into  #tempChangeIn  from  budget_change_Sheet   where iyear= @iYear and  imonth=  @iMonth and  deptcode in (  @budGetDept )        --ת����Ŀ

select  iyear,imonth , deptcode, outsubject,sum(outmoney) as outMoney  into #outItem from #tempChangeOut  group by outsubject ,iyear,imonth,deptcode  --������outsubject,group���
select  iyear,imonth , deptcode, insubject ,sum(inmoney) as inMoney into #inItem from  #tempChangein   group by insubject ,iyear,imonth,deptcode                             --������insubject ,group���


--Ԥ��� + Nc�������ű� 
set @sqlYusuanAndNcdept = 'SELECT budget_account.Iyear, budget_account.Imonth, budget_account.SubjectCode, 
      budget_account.budgetMoney, budget_account.CheckMoney, 
      budget_account.PlanMoney, budget_account.deptCode, 
      Base_NC_Dept.NC_DeptCode, Base_NC_Dept.NC_DeptName, 
      Base_NC_Dept.budget_DeptCode, Base_Budget_Dept.budget_DeptName, 
      Base_AccountSubject.Dispname,
      ( isnull((select inMoney from #inItem  where #inItem.iyear=budget_account.iyear and  #inItem.Imonth=budget_account.Imonth and  #inItem.insubject=budget_account.SubjectCode  and  #inItem.deptcode=budget_account.deptcode),0) - 
      isnull((select outMoney from #outItem  where #outItem.iyear=budget_account.iyear and  #outItem.Imonth=budget_account.Imonth and  #outItem.outsubject=budget_account.SubjectCode  and  #outItem.deptcode=budget_account.deptcode),0)            
        ) as changeMoney    --�������
       into temp1           --exec ֻ�����ɱ������ɱ�����ʱ��
FROM budget_account INNER JOIN
      Base_Budget_Dept ON 
      budget_account.deptCode = Base_Budget_Dept.budget_DeptCode INNER JOIN
      Base_AccountSubject ON 
      budget_account.SubjectCode = Base_AccountSubject.subjectCode LEFT OUTER JOIN
      Base_NC_Dept ON budget_account.deptCode = Base_NC_Dept.budget_DeptCode
where budget_account.Iyear= '+  cast(@iYear as char(4))  + ' and budget_account.Imonth =' +  cast(@iMonth as char(4))  + ' and  budget_account.deptcode in ( '+   cast( @budGetDept as char(100) )  + ')'

if @subject <> 'ALL'    -- �����Ҫ��ѯ�Ŀ�Ŀ��Ϊ���� �������Ҫ��ɸѡ��Ŀ 
	begin
	
		set @sqlYusuanAndNcdept = @sqlYusuanAndNcdept + ' and left(budget_account.SubjectCode,4)  =  ' + cast(@subject as char(8))  
		
	end

 EXEC(@sqlYusuanAndNcdept)    --ִ�� sql ���

drop table  #tempChangeOut,#tempChangeIn ,#outItem,#inItem   --ɾ��������ʱ��
--Nc �������ű� + NCʵ��� 
         
--׼��sql ���
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
         
if @subject <> 'ALL'    -- �����Ҫ��ѯ�Ŀ�Ŀ��Ϊ���� �������Ҫ��ɸѡ��Ŀ 
	begin
	
		set @sqlNcdeptAndNcCost = @sqlNcdeptAndNcCost + ' and left(GL_NC_Cost.subjcode,4)  =  ' + cast(@subject as char(8))  
		
	end

exec (@sqlNcdeptAndNcCost)  --ִ�� sql ���


select 
isnull(temp1.Iyear,temp2.IYear) as IYear,                                 --�꣬Ϊ�������nc�е���
isnull(temp1.Imonth,temp2.Imonth) as Imonth,						        --�£�Ϊ�������nc�е���
isnull(temp1.budget_DeptName,temp2.budget_DeptName) as budget_DeptName,   --Ԥ�㲿�ţ�Ϊ�������nc�е�  
isnull(temp1.NC_DeptName,temp2.NC_DeptName) as NC_DeptName,               --nc���ţ�Ϊ������nc��
temp1.budgetMoney,(temp1.PlanMoney + temp1.changeMoney ) as PlanMoney,temp2.localRealCost,                    --Ԥ��������ʵ�ʷ�֤���,�������
--temp1.changeMoney,													   --�������
--isnull(temp1.deptCode,temp2.NC_DeptCode) as BudgetdeptCode,              --Ԥ�㲿��
isnull(temp1.Dispname,temp2.Dispname) as Dispname,                         --��Ŀ	
isnull(temp1.SubjectCode,temp2.subjcode) as SubjectCode                    --��Ŀ���
into #ThisMonthBudget 
  from temp1   FULL  JOIN 
 temp2   on     temp1.Iyear= temp2.Iyear and  temp1.Imonth=temp2.Imonth
 and temp1.SubjectCode=temp2.subjcode  and  temp1.deptCode=temp2.budget_DeptCode

drop table temp1,temp2


--1.������Ԥʵ��
--2.���࣬���ֶΡ�Ԥ������ֶΣ�

 
--3.�ж��·ݣ� <= 6 ,   1q,2q,1h.       >6 .  3q,4q,2h.
--

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
		deptCode,    --����
		SubjectCode, --��Ŀ
		( select isnull(sum(budgetMoney),0)/3 from budget_account o  where  
			o.imonth>=@baseMonth+1  and o.imonth<=@baseMonth+3 and o.iyear=budget_account.iyear and o.deptCode=budget_account.deptCode and o.SubjectCode
			=budget_account.SubjectCode) as oneQ, -- һ����Ԥ����Ϣ
		( select  isnull(sum(budgetMoney),0)/3 from budget_account o  where  
			o.imonth>=@baseMonth+4  and o.imonth<=@baseMonth+6 and o.deptCode=budget_account.deptCode and o.SubjectCode
			=budget_account.SubjectCode) as twoQ, -- ������
		( select isnull(sum(budgetMoney),0)/6 from budget_account o  where  
			o.imonth>=@baseMonth+1  and o.imonth<=@baseMonth+6 and o.iyear=budget_account.iyear and o.deptCode=budget_account.deptCode and o.SubjectCode
			=budget_account.SubjectCode) as oneH  -- �ϰ���Ԥ����Ϣ
into #QuarterInfo 
FROM budget_account 
WHERE  (deptCode =@budGetDept ) 
group by deptCode,SubjectCode ,Iyear



-- Ӧ��������� �����ϲ�ѯ�ѣ� 1q .2q. 1 h , 3q,4q, 2h ��� ���� 
select '0' as unionType, #ThisMonthBudget.*,Base_accontInBudgetSubject.CommonCode, Base_CommonCode.ShowOrder,Base_CommonCode.codename ,#QuarterInfo.oneQ,#QuarterInfo.twoQ,
#QuarterInfo.oneH
 into #table2  from   #ThisMonthBudget left join Base_accontInBudgetSubject on  #ThisMonthBudget.SubjectCode = Base_accontInBudgetSubject.subjectCode left JOIN Base_CommonCode 
 on   Base_CommonCode.Code = Base_accontInBudgetSubject.CommonCode  left join #QuarterInfo on #QuarterInfo.subjectcode = #ThisMonthBudget.SubjectCode 
order by  Base_CommonCode.ShowOrder 

--��͵ı� ������õı� ��union һ���γɵ��ĸ��� �� --  ��  1q .2q. 1 h , 3q,4q, 2h ���

select *  from #table2 
 union all 
select '1' as unionType, iyear,imonth,budget_deptname,nc_deptname,sum(budgetmoney) as budgetmoney,
sum(planmoney) as planmoney, sum (localrealcost) as localrealcost ,codename + '�ϼ�' as  Dispname,'' as subjectcode,commoncode,ShowOrder,codename,sum(oneQ) as oneQ,sum(twoQ) as twoQ,
sum(oneH) as oneH  
from #table2   group by  iyear,imonth,budget_deptname,nc_deptname,
commoncode,ShowOrder,codename 
order by ShowOrder asc,subjectcode desc 


drop table #QuarterInfo,#table2,#ThisMonthBudget

--@subject varchar(50)                          --��Ŀ,All��������, 4105 ,5502 ��,����һ����Ŀ (ǰ4λ����) 
-- ��ѯ��Ŀ�� ��Լ����������  ǰ���Ѿ����ϡ� 
 



GO

GRANT EXEC ON GetCostByYearMonthAndBudgetDept TO PUBLIC

GO
