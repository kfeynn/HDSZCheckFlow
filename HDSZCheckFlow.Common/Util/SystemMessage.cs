// ================================================================================
// 		File: SystemMessage.cs
// 		Desc: ϵͳ��Ϣ�ࡣ
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
	/// SystemMessage ��ժҪ˵����
	/// </summary>
	public class SystemMessage
	{
		public SystemMessage()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}
		public static string OperationMessage(bool Flag,string StateID)
		{
			string Msg = "";

			if(Flag)
			{
				if(StateID != null && StateID != "")
				{
					Msg = "�޸ĳɹ�!";
				}
				else
				{
					Msg = "�����ɹ�!";
				}
			}
			else
			{
				if(StateID != null && StateID != "")
				{
					Msg = "�޸�ʧ��!";
				}
				else
				{
					Msg = "����ʧ��!";
				}
			}

			return Msg;
		}
	}
}
