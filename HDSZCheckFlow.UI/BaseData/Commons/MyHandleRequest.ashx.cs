using System;
using System.Web;
using System.Data;
using System.Text;

namespace HDSZCheckFlow.UI.BaseData.Commons
{
	/// <summary>
	/// һ�㴦���������AJAX������ ��liyang 2014-08-08 ʵ�ּ۸��������������Ϣ������ʾ��
	/// </summary>
	public class MyHandleRequest: IHttpHandler 
	{
		public void ProcessRequest(HttpContext context)
		{
			string result = null;
			context.Response.ClearContent();
			context.Response.ContentType = "text/plain"; 
			
			//��ȡ����Ĳ���
			string invpk=context.Request.Params["inv_pk"];

			// ��ȡ�˴������Ļ�����Ϣ
			string sql = "select invName,invspec,invtype,measname,RealCurrTypeCode,RealOriginalcurPrice,RmbPrice,RealPriceDate  from Base_inventory where inv_pk = '" + invpk.Trim() + "'"; 

			DataSet ds = Bussiness.ComQuaryBLL.ExecutebyQuery(sql) ;

			if(ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0 )
			{
				DataTable dt = ds.Tables[0];
			    result = DataTableToJson(dt);//����Json��ʽ���͹�ǰ̨ʹ�á�
			}
			else    //û�ҵ�������Ϣ
			{
				result="0";//û����Ϣ�򷵻�0
			}	
			context.Response.Write(result);
			context.Response.End();
		} 

		public bool IsReusable
		{
			get { return true; } 
		}
 

		/// <summary>
		/// datatable ת��Ϊ json
		/// </summary>
		/// <param name="dt"></param>
		/// <returns></returns>
		public static string DataTableToJson(DataTable dt)
		{
			StringBuilder Json = new StringBuilder();
			Json.Append("[");
			if (dt != null)
			{
				if (dt.Rows.Count > 0)
				{
					for (int i = 0; i < dt.Rows.Count; i++)
					{
						Json.Append("{");
						for (int j = 0; j < dt.Columns.Count; j++)
						{
							Json.Append("\"" + dt.Columns[j].ColumnName.ToString() +
								"\":\"" + GetDeleteBR(dt.Rows[i][j].ToString()) + "\"");
							if (j < dt.Columns.Count - 1)
							{
								Json.Append(",");
								Json.Append("\r\n");
							}
						}
						Json.Append("}");
						if (i < dt.Rows.Count - 1)
						{
							Json.Append(",");
						}
					}
				}
			}
			Json.Append("]");
			return Json.ToString();
		}


		/// <summary> 
		/// ȥ�����з�        
		/// </summary>       
		/// <param name="str"></param>    
		/// <returns></returns>
		public static string GetDeleteBR(string strinput)
		{
			string p = "\\n|\r\n"; //���ݿ�ĵĻ�����\n
			string returnstr = System.Text.RegularExpressions.Regex.Replace(strinput, p, " ");
			return returnstr;
		}

	}
}
