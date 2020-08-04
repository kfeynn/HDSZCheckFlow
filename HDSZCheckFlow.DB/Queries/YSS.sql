IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'GetCostByClassDept')
	BEGIN
		PRINT 'Dropping Procedure GetCostByClassDept'
		DROP  Procedure  GetCostByClassDept
	END

GO

PRINT 'Creating Procedure GetCostByClassDept'
GO
CREATE Procedure GetCostByClassDept

	@iYear   int,                                 --��
	@iMonth  int,                                 --��
	@budGetDept varchar(100),                     --Ԥ�㲿�� (21,2201,2202 ) �� ,������Ҫͳ�Ƶļ���Ԥ�㲿�� , 
	@tableCode varchar(100)                       --runReport��Code
	
AS

/******************************************************************************
**		File: 
**		Name: GetCostByClassDept
**		Desc: ������Ԥ�㲿��,�ϼ�Ԥʵ�� ����
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

--�������������е��� ����

declare @sqlYusuanAndNcdept varchar(2000)           -- Ԥ��� + Nc�������ű�  ,��ѯ�ַ���
declare @sqlNcdeptAndNcCost varchar(2000)           -- Nc �������ű� + NCʵ���  ,��ѯ�ַ���

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

select iyear,imonth,outsubject  ,deptcode,[money] as outMoney  into #tempChangeOut from budget_change_Sheet where iyear= @iYear and  imonth=  @iMonth and  deptcode in (  @budGetDept )    --ת����Ŀ(������,���ż���,ע:����һ����������)
select iyear,imonth,insubject  , deptcode ,[money] as inMoney into  #tempChangeIn  from  budget_change_Sheet   where iyear= @iYear and  imonth=  @iMonth and  deptcode in (  @budGetDept ) --ת����Ŀ

/*   
-- ��all���ֵĵ������,out 

SELECT budget_change_Sheet.Iyear,                   --��
		budget_change_Sheet.Imonth,                 --��
      budget_change_Sheet.OutSubject,               --ת����Ŀ
      budget_change_Sheet.DeptCode,                 --����
       sum( budget_change_Sheet.Money) as outMoney  --ת�����
FROM budget_change_Sheet INNER JOIN                                       --������
      Base_Runreport ON LEFT(budget_change_Sheet.OutSubject, 4)           --���� ��
      = Base_Runreport.firstClassAccount AND 
      budget_change_Sheet.DeptCode = Base_Runreport.BudgetDept AND          
      Base_Runreport.tableCode = 'fuzhuDept'                               --��ѯ�����
WHERE (Base_Runreport.BudgetDept IN
          (SELECT BudgetDept
         FROM Base_Runreport
         WHERE (tableCode = 'fuzhuDept'))) AND (budget_change_Sheet.Iyear = 2008) AND 
      (budget_change_Sheet.Imonth = 6)
group by iyear, imonth,outsubject ,deptcode 

-- ��all���ֵĵ������,in 

SELECT budget_change_Sheet.Iyear,                   --��
		budget_change_Sheet.Imonth,                 --��
      budget_change_Sheet.InSubject,               --ת����Ŀ
      budget_change_Sheet.DeptCode,                 --����
       sum( budget_change_Sheet.Money) as InMoney  --ת�����
FROM budget_change_Sheet INNER JOIN                                       --������
      Base_Runreport ON LEFT(budget_change_Sheet.OutSubject, 4)           --���� ��
      = Base_Runreport.firstClassAccount AND 
      budget_change_Sheet.DeptCode = Base_Runreport.BudgetDept AND          
      Base_Runreport.tableCode = 'fuzhuDept'                               --��ѯ�����
WHERE (Base_Runreport.BudgetDept IN
          (SELECT BudgetDept
         FROM Base_Runreport
         WHERE (tableCode = 'fuzhuDept'))) AND (budget_change_Sheet.Iyear = 2008) AND 
      (budget_change_Sheet.Imonth = 6)
group by iyear, imonth,Insubject ,deptcode 

*/
-- ������� �����Էŵ���� 

-- all ���ֵõ������ out 
SELECT budget_change_Sheet.Iyear,                     --��
		budget_change_Sheet.Imonth,                   --��
      budget_change_Sheet.OutSubject,                 --ת����Ŀ
      budget_change_Sheet.DeptCode,                   --����
      sum (budget_change_Sheet.Money) as outMoney     --ת�����ϼƣ�
FROM budget_change_Sheet INNER JOIN                                              --Ԥ�������
      Base_Runreport ON                                                          --���� �� ������ͳ�Ʋ����Լ���Ŀ��
      budget_change_Sheet.DeptCode = Base_Runreport.BudgetDept AND 
      Base_Runreport.tableCode = 'fuzhuDept'                                     --��ѯ�����
WHERE (Base_Runreport.BudgetDept IN
          (SELECT BudgetDept
         FROM Base_Runreport
         WHERE (tableCode = 'fuzhuDept'))) AND (budget_change_Sheet.Iyear = 2008) AND 
      (budget_change_Sheet.Imonth = 6) AND (Base_Runreport.firstClassAccount = 'all')
    group by iyear, imonth,outsubject ,deptcode 

-- all ���ֵõ������ in
SELECT budget_change_Sheet.Iyear,                     --��
		budget_change_Sheet.Imonth,                   --��
      budget_change_Sheet.inSubject,                 --ת����Ŀ
      budget_change_Sheet.DeptCode,                   --����
      sum (budget_change_Sheet.Money) as inMoney     --ת�����ϼƣ�
FROM budget_change_Sheet INNER JOIN                                              --Ԥ�������
      Base_Runreport ON                                                          --���� �� ������ͳ�Ʋ����Լ���Ŀ��
      budget_change_Sheet.DeptCode = Base_Runreport.BudgetDept AND 
      Base_Runreport.tableCode = 'fuzhuDept'                                     --��ѯ�����
WHERE (Base_Runreport.BudgetDept IN
          (SELECT BudgetDept
         FROM Base_Runreport
         WHERE (tableCode = 'fuzhuDept'))) AND (budget_change_Sheet.Iyear = 2008) AND 
      (budget_change_Sheet.Imonth = 6) AND (Base_Runreport.firstClassAccount = 'all')
    group by iyear, imonth,insubject ,deptcode 



select  iyear,imonth ,  outsubject,sum(outmoney) as outMoney  into #outItem from #tempChangeOut  group by outsubject ,iyear,imonth  --�����¿�Ŀoutsubject,group���
select  iyear,imonth ,  insubject ,sum(inmoney) as inMoney into #inItem from  #tempChangein   group by insubject ,iyear,imonth      --�����¿�Ŀinsubject ,group���


-- ���ݲ���  ɸѡ��Ŀ ( �еĲ���,��Ҫͳ��ȫ����Ŀ,�еĲ���ֻ��Ҫͳ�Ʋ��ֿ�Ŀ) 


--Ԥ��� + Nc�������ű� + Base_runReport
SELECT budget_account.deptCode,           --����
		budget_account.Iyear,             --���
		budget_account.Imonth,            --�·�
      sum(budget_account.budgetMoney) as budgetMoney,       --Ԥ����
      sum( budget_account.PlanMoney) as PlanMoney,          --������
       budget_account.SubjectCode,        --��Ŀ����
      Base_AccountSubject.Dispname        --��Ŀ����
FROM budget_account INNER JOIN                         --Ԥ���
      Base_AccountSubject ON                           --����NC��Ŀ��
      budget_account.SubjectCode = Base_AccountSubject.subjectCode INNER JOIN
      Base_Runreport ON LEFT(budget_account.SubjectCode, 4)   -- �������� ��
      = Base_Runreport.firstClassAccount AND 
      budget_account.deptCode = Base_Runreport.BudgetDept
WHERE (Base_Runreport.tableCode = @tableCode) AND (budget_account.Iyear = @iYear) AND 
      (budget_account.Imonth = @iMonth) AND (Base_Runreport.BudgetDept in (SELECT BudgetDept FROM Base_Runreport WHERE (tableCode = @tableCode )) )
group by budget_account.deptCode,budget_account.Iyear,                    --���� �꣬�£����ţ���Ŀ ���ϼ�
budget_account.Imonth,Base_AccountSubject.Dispname,budget_account.SubjectCode



--Ԥ��� + Nc�������ű� 
set @sqlYusuanAndNcdept = ' SELECT budget_account.Iyear, budget_account.Imonth, budget_account.SubjectCode, 
     sum( budget_account.budgetMoney),
      sum(budget_account.PlanMoney),           
      Base_AccountSubject.Dispname,
      ( isnull((select inMoney from #inItem  where #inItem.iyear=budget_account.iyear and  #inItem.Imonth=budget_account.Imonth 
and  #inItem.insubject=budget_account.SubjectCode  ),0) - 
      isnull((select outMoney from #outItem  where #outItem.iyear=budget_account.iyear and  #outItem.Imonth=budget_account.Imonth 
and  #outItem.outsubject=budget_account.SubjectCode  ),0)            
        ) as changeMoney    --�������
       into temp1           --exec ֻ�����ɱ������ɱ�����ʱ��
FROM budget_account INNER JOIN
      Base_AccountSubject ON 
      budget_account.SubjectCode = Base_AccountSubject.subjectCode 
where budget_account.Iyear= '+  cast(@iYear as char(4))  + ' and budget_account.Imonth =' +  cast(@iMonth as char(4))  + ' and  budget_account.deptcode in ( '+   cast( @budGetDept as char(100) )  + ')
 group by  budget_account.Iyear, budget_account.Imonth, budget_account.SubjectCode ,Base_AccountSubject.Dispname '




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
         
   

exec (@sqlNcdeptAndNcCost)  --ִ�� sql ���


select 
isnull(temp1.Iyear,temp2.IYear) as IYear,                                  --�꣬Ϊ�������nc�е���
isnull(temp1.Imonth,temp2.Imonth) as Imonth,						       --�£�Ϊ�������nc�е���
isnull(temp1.budget_DeptName,temp2.budget_DeptName) as budget_DeptName,    --Ԥ�㲿�ţ�Ϊ�������nc�е�  
isnull(temp1.NC_DeptName,temp2.NC_DeptName) as NC_DeptName,                --nc���ţ�Ϊ������nc��
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
		Imonth,      --��
		deptCode,    --����
		SubjectCode, --��Ŀ
		( select  budgetMoney from budget_account o  where  
o.imonth=@baseMonth+1 and o.iyear=budget_account.iyear and o.deptCode=budget_account.deptCode and o.SubjectCode
=budget_account.SubjectCode) as onemonth, -- һ��Ԥ����Ϣ
( select  budgetMoney from budget_account o  where  
o.imonth=@baseMonth+2 and o.iyear=budget_account.iyear and o.deptCode=budget_account.deptCode and o.SubjectCode
=budget_account.SubjectCode) as twomonth, -- ����
( select  budgetMoney from budget_account o  where  
o.imonth=@baseMonth+3 and o.iyear=budget_account.iyear and o.deptCode=budget_account.deptCode and o.SubjectCode
=budget_account.SubjectCode) as threemonth, -- ����
( select  budgetMoney from budget_account o  where  
o.imonth=@baseMonth+4 and o.iyear=budget_account.iyear and o.deptCode=budget_account.deptCode and o.SubjectCode
=budget_account.SubjectCode) as firthmonth, -- ����
( select  budgetMoney from budget_account o  where  
o.imonth=@baseMonth+5 and o.iyear=budget_account.iyear and o.deptCode=budget_account.deptCode and o.SubjectCode
=budget_account.SubjectCode) as firemonth, -- ����
( select  budgetMoney from budget_account o  where  
o.imonth=@baseMonth+6 and o.iyear=budget_account.iyear and o.deptCode=budget_account.deptCode and o.SubjectCode
=budget_account.SubjectCode) as sixmonth  --���� 
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

GRANT EXEC ON GetCostByClassDept TO PUBLIC

GO
