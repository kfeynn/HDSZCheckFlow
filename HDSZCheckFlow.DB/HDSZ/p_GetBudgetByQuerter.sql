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
			�����Ȳ�ѯԤ����Ϣ,�����Լ����ŷ����Լ���˾ ��������,

**		Auth: zyq
**		Date: 2009-12-26
  
*******************************************************************************/

declare @querter int         --����
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


--����Ԥ��(�ֿ�Ŀ�����ŷ��࣬����)
SELECT                              --�������򣨲��ţ����ŷ��࣬��˾�ϼƣ� 
	   budget_account.deptcode,                         --����Code
	   Base_runreport.tablename ,                       --���ţ���������
	   Base_runreport.type,                             --����
	   budget_account.Iyear,                            --��
	   dbo.getQuarter(@imonth) as Quarter ,                  --����    
       SUM(budget_account.budgetMoney)/3 AS budgetMoney,--Ԥ����ϼ� ����ƽ��
	   budget_account.SubjectCode,                      --��Ŀ
       Base_AccountSubject.Dispname ,                   --��Ŀ����
	   Base_runreport.deptOrder                        --�������
	into #BudgetInfo 
FROM  budget_account INNER JOIN                                            --Ԥ���
      Base_AccountSubject ON                                               --��Ŀ��
      budget_account.SubjectCode = Base_AccountSubject.subjectCode
	  left join Base_runreport on                                          --��������
	  budget_account.deptcode = Base_runreport.budgetdept 
WHERE (budget_account.Iyear = @iyear)  
and Base_runreport.firstclassaccount = 'all' AND Base_runreport.type = 'Dept'   and 
(budget_account.Imonth between @StartMonth and @EndMonth)         --��ѯ���� ���꼾
GROUP BY budget_account.deptcode , budget_account.Iyear,Base_runreport.tablename,
budget_account.SubjectCode,   --�������� ���꣬������Ŀ
      Base_AccountSubject.Dispname ,Base_runreport.type,Base_runreport.deptOrder 

union all 

SELECT  
	   budget_account.deptcode,
	   Base_runreport.tablename ,
	   Base_runreport.type,
	   budget_account.Iyear,                            --��
	   dbo.getQuarter(@imonth) as Quarter ,                  --����    
	   --budget_account.Imonth,                         --�� 
       SUM(budget_account.budgetMoney)/3 AS budgetMoney,--Ԥ����ϼ� ����ƽ��
	   budget_account.SubjectCode,                      --��Ŀ
       Base_AccountSubject.Dispname ,                    --��Ŀ����
	   Base_runreport.deptOrder                        --�������

FROM  budget_account INNER JOIN                                            --Ԥ���
      Base_AccountSubject ON                                               --��Ŀ��
      budget_account.SubjectCode = Base_AccountSubject.subjectCode
	  left join Base_runreport on                                          --��������
	  budget_account.deptcode = Base_runreport.budgetdept 
WHERE (budget_account.Iyear = @iyear) AND Base_runreport.type = 'Dept'  
and Base_runreport.firstclassaccount = left(budget_account.subjectcode,4) and 
(budget_account.Imonth between @StartMonth and @EndMonth)         --��ѯ���� ������
GROUP BY budget_account.deptcode , 
budget_account.Iyear,Base_runreport.tablename,--budget_account.Imonth, 
budget_account.SubjectCode,   --�������� ���꣬�£���Ŀ
      Base_AccountSubject.Dispname,Base_runreport.type,	   Base_runreport.deptOrder      


union all 


--����Ԥ��(�ֿ�Ŀ�����ŷ��࣬����)
SELECT 
	   '8100' deptcode,
	   Base_runreport.tablename ,
	   Base_runreport.type,
	   budget_account.Iyear,                            --��
	   dbo.getQuarter(@imonth) as Quarter ,                   --����    
       SUM(budget_account.budgetMoney)/3 AS budgetMoney,--Ԥ����ϼ� ����ƽ��
	   budget_account.SubjectCode,                      --��Ŀ
       Base_AccountSubject.Dispname ,                    --��Ŀ����
	   Base_runreport.deptOrder                        --�������

FROM  budget_account INNER JOIN                                            --Ԥ���
      Base_AccountSubject ON                                               --��Ŀ��
      budget_account.SubjectCode = Base_AccountSubject.subjectCode
	  left join Base_runreport on                                          --��������
	  budget_account.deptcode = Base_runreport.budgetdept 
WHERE (budget_account.Iyear = @iyear)  
and Base_runreport.firstclassaccount = 'all' AND Base_runreport.type = 'ClassDept'   and 
(budget_account.Imonth between @StartMonth and @EndMonth)         --��ѯ���� ������
GROUP BY  budget_account.Iyear,Base_runreport.tablename,--budget_account.Imonth, 
		  budget_account.SubjectCode,   --�������� ���꣬�£���Ŀ
          Base_AccountSubject.Dispname ,Base_runreport.type,Base_runreport.deptOrder    

union all 

SELECT   
       '8100' as deptcode,
	   Base_runreport.tablename ,
	   Base_runreport.type,
	   budget_account.Iyear,                            --��
	   dbo.getQuarter(@imonth) as Quarter ,                  --����    
	   --budget_account.Imonth,                         --�� 
       SUM(budget_account.budgetMoney)/3 AS budgetMoney,--Ԥ����ϼ� ����ƽ��
	   budget_account.SubjectCode,                      --��Ŀ
       Base_AccountSubject.Dispname,                     --��Ŀ����
	   Base_runreport.deptOrder                        --�������

FROM  budget_account INNER JOIN                                            --Ԥ���
      Base_AccountSubject ON                                               --��Ŀ��
      budget_account.SubjectCode = Base_AccountSubject.subjectCode
	  left join Base_runreport on                                          --��������
	  budget_account.deptcode = Base_runreport.budgetdept 
WHERE (budget_account.Iyear = @iyear) AND Base_runreport.type = 'ClassDept'  
and Base_runreport.firstclassaccount = left(budget_account.subjectcode,4) and 
(budget_account.Imonth between @StartMonth and @EndMonth)         --��ѯ���� ������
GROUP BY  
		budget_account.Iyear,Base_runreport.tablename,--budget_account.Imonth, 
		budget_account.SubjectCode,   --�������� ���꣬�£���Ŀ
        Base_AccountSubject.Dispname,Base_runreport.type,	   Base_runreport.deptOrder                        --�������


union all 

-- ��˾Ԥ��ϼƣ��ֿ�Ŀ��

SELECT  	  
       '9100' as deptcode,
	   '�ܹ�˾' as tablename ,
       'ACompany' as type,
        budget_account.Iyear,                           --��
	   dbo.getQuarter(@imonth) as Quarter ,                  --����    
	   --budget_account.Imonth,                         --�� 
       SUM(budget_account.budgetMoney)/3 AS budgetMoney,--Ԥ����ϼ� ����ƽ��
	   budget_account.SubjectCode,                      --��Ŀ
       Base_AccountSubject.Dispname ,                    --��Ŀ����
	   100 as deptOrder                        --�������

FROM  budget_account INNER JOIN                                            --Ԥ���
      Base_AccountSubject ON                                               --��Ŀ��
      budget_account.SubjectCode = Base_AccountSubject.subjectCode
WHERE (budget_account.Iyear = @iyear)  and 
(budget_account.Imonth between @StartMonth and @EndMonth)         --��ѯ���� ������
GROUP BY  budget_account.Iyear,--budget_account.Imonth, 
budget_account.SubjectCode,   --�������� ���꣬�£���Ŀ
Base_AccountSubject.Dispname                   --�������



order by deptcode ,tablename, budget_account.subjectcode  

---------------------------------����Ԥ��ֵEnd----------------------------------------------

--  �Զ����Ŀ�ϲ�


--�Զ����Ŀ��Ӧ�����Ŀ��
select  Base_CommonRelation.*,Base_CommonCode.codename 
into #MadeAccount
from  Base_CommonRelation,Base_CommonCode 
where Base_CommonRelation.type = 'MadeToAccountSubject'
and  Base_CommonCode.codetype = 'MadeAccountSubject'
and Base_CommonRelation.fathercode = Base_CommonCode.code 


--ʵ�ʷ����������Զ����Ŀ�������Զ���Ŀ�Ŀת��Ϊ�Զ����Ŀ��

select 
  
#budgetinfo.iyear,  
#budgetinfo.quarter,
#budgetinfo.deptcode,
#budgetinfo.tablename,
#budgetinfo.type,
#budgetinfo.budgetMoney,
isnull(#MadeAccount.fathercode ,#budgetinfo.subjectcode) as subjectcode , -- ��Ŀ�������Զ����Ŀ��
isnull(#MadeAccount.codename,#budgetinfo.dispname ) as  dispname,      --��Ŀ����
#budgetinfo.deptOrder
into #Budget2 
from #budgetinfo left join #MadeAccount 
on  #budgetinfo.subjectcode=#MadeAccount.suncode 


--�ϲ���Ŀ
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
----------------------------------�Զ�������ĿEnd----------------------------------------

-- ��Ŀ��������
-- ��Base_accontInBudgetSubject �ж���Ĺ������л���

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
-- ���ͷ���ϼ�  ���˼��ѣ�ͳ�ξ��ѵȣ�

select 
1 as uniontype,
iyear,
quarter,
deptcode,
tablename,
type ,
sum(budgetmoney ) as budgetmoney,
'' as subjectcode,
codename + '�ϼƣ�' as dispname,
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
-- �ܺϼ�  ���˼��� + ͳ�ξ��ѡ�������

select 
2 as uniontype,
iyear,
quarter,
deptcode,
tablename,
type ,
sum(budgetmoney ) as budgetmoney,
'' as subjectcode,
'�ܼƣ�' as dispname,
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
deptOrder     --���������


 
--order by deptcode,showorder,subjectcode 


--------------------------��Ŀ�������� End-----------------------------------------


--select * from #BudgetEnd order by deptcode ,showorder,uniontype,subjectcode 


-- �����ź�����ʾ

declare @s varchar(8000)
set @s = 'select codename as �������,dispname as ��Ŀ����'
select @s=@s+','+tablename+'=sum(case tablename when '''+tablename+''' then budgetmoney else 0 end ) '
from (select  subjectcode,dispname,codename,tablename,deptOrder  from #BudgetEnd ) budget group by tablename,deptOrder order by deptOrder  

print @s 

exec (@s + 'from #BudgetEnd group by  subjectcode,dispname,iyear,quarter,codename,showorder,uniontype order by showorder,uniontype,subjectcode   ')


drop table #budgetinfo ,#MadeAccount,#Budget2,#Budget,#Table,#BudgetEnd




GRANT EXEC ON p_GetBudgetByQuerter TO PUBLIC

GO
