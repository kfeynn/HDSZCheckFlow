IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'P_Budget_CompareBugetToPan')
	BEGIN
		PRINT 'Dropping Procedure P_Budget_CompareBugetToPan'
		DROP  Procedure  P_Budget_CompareBugetToPan
	END

GO

PRINT 'Creating Procedure P_Budget_CompareBugetToPan'
GO 






CREATE    proc P_Budget_CompareBugetToPan

@IYear int=2008,@Quarter int=4 ,@Type int=4,@deptcode varchar(20)=''

as


--�Ƚϼ��������Ƿ�Ԥ��


--@Type=0  	��������ϸ
--@Type=1	��ʾ��Ԥ���Ŀ��ϸ
--@Type=2	��ʾѡ�в���������ϸ
--@Type=3	��ʾѡ�в��ų�Ԥ���Ŀ��ϸ
--@Type=4	��ʾ���Ż���
--@Type=5	��ʾ��˾����



SELECT @Quarter  AS ����, d.budget_DeptName AS ��������, d.budget_Deptcode as ���ű���,
      b.SubjectCode AS ��Ŀ����, s.Dispname AS ��Ŀ����, SUM(b.budgetMoney) 
      AS ����Ԥ��, SUM(b.PlanMoney) AS ��������, SUM(b.budgetMoney) 
      - SUM(b.PlanMoney) AS [(Ԥ-��)����]
into #CompareBugetToPan

FROM dbo.budget_account b INNER JOIN
      dbo.Base_AccountSubject s ON b.SubjectCode = s.subjectCode INNER JOIN
      dbo.Base_Budget_Dept d ON b.deptCode = d.budget_DeptCode
WHERE (b.Iyear = @IYear) AND (dbo.getQuarter(b.Imonth) = @Quarter )
GROUP BY b.SubjectCode, s.Dispname, d.budget_Deptcode,d.budget_DeptName
ORDER BY d.budget_DeptName, b.SubjectCode


if @Type=0 

select * from  #CompareBugetToPan


if @Type=1

select * from  #CompareBugetToPan where [(Ԥ-��)����]<0



if @Type=2 


select * from  #CompareBugetToPan where ���ű���=@deptcode




if @Type=3


select * from  #CompareBugetToPan where ���ű���=@deptcode and [(Ԥ-��)����]<0


if @Type=4



SELECT ����, ��������, ���ű���,
      sum(����Ԥ��) as ����Ԥ��,  sum(��������) as ��������, sum([(Ԥ-��)����]) as [(Ԥ-��)����]
from  #CompareBugetToPan
group by ����, ��������, ���ű���
order by ���ű���


if @Type=5


SELECT ����,    sum(����Ԥ��) as ����Ԥ��,  sum(��������) as ��������, sum([(Ԥ-��)����]) as [(Ԥ-��)����]
from  #CompareBugetToPan
group by ����





GO
