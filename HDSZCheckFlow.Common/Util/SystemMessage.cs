// ================================================================================
// 		File: SystemMessage.cs
// 		Desc: 系统消息类。
//  
// 		Called by:   
//               
// 		Auth: Andy Lee
// 		Date: 2007-04-30
// ================================================================================
// 		Change History
// ================================================================================
// 		Date:		Author:				Description:
// 		--------	--------			-------------------
//    
// ================================================================================
// Copyright (C) 2007 FCKJ Corporation
// ================================================================================
using System;

namespace HDSZCheckFlow.Common.Util
{
	/// <summary>
	/// SystemMessage 的摘要说明。
	/// </summary>
	public class SystemMessage
	{
		public SystemMessage()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		public static string OperationMessage(bool Flag,string StateID)
		{
			string Msg = "";

			if(Flag)
			{
				if(StateID != null && StateID != "")
				{
					Msg = "修改成功!";
				}
				else
				{
					Msg = "新增成功!";
				}
			}
			else
			{
				if(StateID != null && StateID != "")
				{
					Msg = "修改失败!";
				}
				else
				{
					Msg = "新增失败!";
				}
			}

			return Msg;
		}
	}
}
