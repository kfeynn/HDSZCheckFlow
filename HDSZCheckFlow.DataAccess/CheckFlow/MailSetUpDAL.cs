using System;
using System.Data;
using HDSZCheckFlow.Entiy;

namespace HDSZCheckFlow.DataAccess.CheckFlow
{
	/// <summary>
	/// MailSetUpDAL ��ժҪ˵����
	/// </summary>
	public class MailSetUpDAL
	{
		public MailSetUpDAL()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}
		

		
		/// <summary>
		/// ��ȡ�����û����ʼ�������Ϣ
		/// </summary>
		/// <returns></returns>
		public  static BaseEmail selectDuget(int PersonID)
		{
			BaseEmail baseemail = new BaseEmail();
			try
			{
				//����xpGrid_User���еõ�	PersonCode ͨ�� User.Identity.Name ID
				
				DBAccess dbAccess=new SQLAccess();
				string cmdStrUser = "select UserName from xpGrid_User where UserID = @UserID";
				DBParameterCollection Params1=new DBParameterCollection();
				Params1.Add(Parameter.GetDBParameter("@UserID",PersonID));
			
				string PersonCode = (string)dbAccess.ExecuteScalar(cmdStrUser,CommandType.Text,Params1);
				

				//ͨ��PersonCoDE ����ѯ�ʼ�������Ϣ �����ʼ�ʵ�����
				string cmdStr="select PersonCode, Email, NickName, Name, IsAccept from dbo.Base_Email where  PersonCode= @PersonCode ";
				DBParameterCollection Params=new DBParameterCollection();
				Params.Add(Parameter.GetDBParameter("@PersonCode",PersonCode));
				DataSet ds=dbAccess.ExecuteDataset(cmdStr,CommandType.Text,Params);
					
				if(ds!=null && ds.Tables.Count>0)
				{
					
						for(int i=0;i<ds.Tables[0].Rows.Count ;i++)
						{
							baseemail.PersonCode = ds.Tables[0].Rows[i]["PersonCode"].ToString();
							baseemail.NickName = ds.Tables[0].Rows[i]["NickName"].ToString();
							baseemail.Name = ds.Tables[0].Rows[i]["Name"].ToString();
							baseemail.IsAccept = int.Parse(ds.Tables[0].Rows[i]["IsAccept"].ToString());
							baseemail.Email = ds.Tables[0].Rows[i]["Email"].ToString();
						}
					
				}
				else
				{
					return null;
				}

			}
			catch(Exception ex)
			{
				
				Common.Log.Logger.Log("DataAccess.CheckFlow.MailSetUpDAL->",ex.Message );
				return null;
			}
			return baseemail;
		}

		/// <summary>
		/// �޸�Email������Ϣ
		/// </summary>
		/// <param name="email"></param>
		/// <returns></returns>
		public static int UpdateEmail(BaseEmail email){
			int i = 0;
			try
			{
				DBAccess dbAccess=new SQLAccess();
				string strBaseEmailUpdate = "update dbo.Base_Email set  Email = @Email, NickName = @NickName, [Name] = @Name, IsAccept = @IsAccept where PersonCode = @PersonCode";
				DBParameterCollection Params1=new DBParameterCollection();
				Params1.Add(Parameter.GetDBParameter("@Email",email.Email));
				Params1.Add(Parameter.GetDBParameter("@NickName",email.NickName));
				Params1.Add(Parameter.GetDBParameter("@Name",email.Name));
				Params1.Add(Parameter.GetDBParameter("@IsAccept",email.IsAccept));
				Params1.Add(Parameter.GetDBParameter("@PersonCode",Convert.ToInt32(email.PersonCode)));
				i = dbAccess.ExecuteNonQuery(strBaseEmailUpdate,CommandType.Text,Params1);

			}
			catch(Exception ex)
			{
				Common.Log.Logger.Log("DataAccess.CheckFlow.MailSetUpDAL->",ex.Message );
				return i;
			}
			return i;
		}


	}
	
}
