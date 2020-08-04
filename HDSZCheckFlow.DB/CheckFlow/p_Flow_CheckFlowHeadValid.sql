IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'p_Flow_CheckFlowHeadValid')
	BEGIN
		PRINT 'Dropping Procedure p_Flow_CheckFlowHeadValid'
		DROP  Procedure  p_Flow_CheckFlowHeadValid
	END

GO

PRINT 'Creating Procedure p_Flow_CheckFlowHeadValid'
GO
CREATE Procedure p_Flow_CheckFlowHeadValid
	@headPk int,
	@result int output
AS

/******************************************************************************
**		File: 
**		Name: p_Flow_CheckFlowHeadValid
			
			检测流程是否合法

			有效                                       0 

			流程名关联了相关流程信息                   1

			查看是否有流程最高级的标识,				   2

			审批级从小到大无重复                       3
			
			流程最高级的标识只能有一个				   4


*******************************************************************************
**		Date:		Author:				Description:
**		--------		--------				-------------------------------------------
**    
*******************************************************************************/
DECLARE @NumOfStep int
set @NumOfStep=0

SELECT CheckStep, COUNT(0) AS IsNum into #temp
FROM CheckFlowInCompany_Body 
WHERE (CheckFlowInCompany_Head_pk = @headPk) 
GROUP BY CheckStep

select @NumOfStep=count(0) from #temp  

if @NumOfStep=0
	BEGIN
		set @result=1 
	End
else
	begin 
		select @NumOfStep=count(0) from #temp where IsNum>1
		if @NumOfStep>0
			begin
				set @result=3
			end
		else
			begin
				SELECT IsLastStep, COUNT(0) AS IsNum into #temp1
					FROM CheckFlowInCompany_Body 
					WHERE (CheckFlowInCompany_Head_pk = @headPk) AND (IsLastStep = 1)
					GROUP BY IsLastStep 
					
				select @NumOfStep=count(0) from #temp1 
				if @NumOfStep=0
					begin
						set @result=2
					end
				else
					begin 
						select @NumOfStep=count(0) from #temp1 where IsNum>1
						if @NumOfStep>0
							begin
								set @result=4							
							end
						else
							begin 
								set @result=0
							end 
					end
					
				
			end
	end



GO


GRANT EXEC ON p_Flow_CheckFlowHeadValid TO PUBLIC

GO
