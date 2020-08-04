IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'p_Flow_CheckFlowInDeptValid')
	BEGIN
		PRINT 'Dropping Procedure p_Flow_CheckFlowInDeptValid'
		DROP  Procedure  p_Flow_CheckFlowInDeptValid
	END

GO

PRINT 'Creating Procedure p_Flow_CheckFlowInDeptValid'
GO
CREATE Procedure p_Flow_CheckFlowInDeptValid
	@deptCode varchar(50),
	@result int output
AS

/******************************************************************************
**		File: 
**		Name: p_Flow_CheckFlowInDeptValid
**		Desc: 
**
			检测流程是否合法

			有效                                       0 

			查看是否有流程最高级的标识,				   1

			审批级从小到大无重复                       2
			
			流程最高级的标识只能有一个				   3


*******************************************************************************
**		Change History
*******************************************************************************
**		Date:		Author:				Description:
**		--------		--------				-------------------------------------------
**    
*******************************************************************************/

DECLARE @NumOfStep int
set @NumOfStep=0

select @NumOfStep=count (0) from CheckFlowInDept  where  DeptCode=@deptCode and IsLastStep=1 

if @NumOfStep=0
	begin 
		set @result=1
	end
else if @NumOfStep>1
	begin	
		set @result=3
	end
else
	begin 
		select CheckSetp ,count(0) as IsNum into #temp from CheckFlowInDept where  DeptCode=@deptCode   group by CheckSetp 
		select @NumOfStep=count(0) from   #temp where IsNum>1
		if @NumOfStep>0 
			begin 
				set @result=2
			end 
		else
			begin
				set @result=0
			end
	end

GO

GRANT EXEC ON p_Flow_CheckFlowInDeptValid TO PUBLIC

GO
