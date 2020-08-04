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


--比较季度推算是否超预算


--@Type=0  	显所有明细
--@Type=1	显示超预算科目明细
--@Type=2	显示选中部门所有明细
--@Type=3	显示选中部门超预算科目明细
--@Type=4	显示部门汇总
--@Type=5	显示公司汇总



SELECT @Quarter  AS 季度, d.budget_DeptName AS 部门名称, d.budget_Deptcode as 部门编码,
      b.SubjectCode AS 科目编码, s.Dispname AS 科目名称, SUM(b.budgetMoney) 
      AS 季度预算, SUM(b.PlanMoney) AS 季度推算, SUM(b.budgetMoney) 
      - SUM(b.PlanMoney) AS [(预-推)差异]
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

select * from  #CompareBugetToPan where [(预-推)差异]<0



if @Type=2 


select * from  #CompareBugetToPan where 部门编码=@deptcode




if @Type=3


select * from  #CompareBugetToPan where 部门编码=@deptcode and [(预-推)差异]<0


if @Type=4



SELECT 季度, 部门名称, 部门编码,
      sum(季度预算) as 季度预算,  sum(季度推算) as 季度推算, sum([(预-推)差异]) as [(预-推)差异]
from  #CompareBugetToPan
group by 季度, 部门名称, 部门编码
order by 部门编码


if @Type=5


SELECT 季度,    sum(季度预算) as 季度预算,  sum(季度推算) as 季度推算, sum([(预-推)差异]) as [(预-推)差异]
from  #CompareBugetToPan
group by 季度





GO
