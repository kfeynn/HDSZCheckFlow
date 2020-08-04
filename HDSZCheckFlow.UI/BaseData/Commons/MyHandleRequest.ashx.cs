using System;
using System.Web;
using System.Data;
using System.Text;

namespace HDSZCheckFlow.UI.BaseData.Commons
{
	/// <summary>
	/// 一般处理程序，用于AJAX请求处理 （liyang 2014-08-08 实现价格管理功能里物料信息联动显示）
	/// </summary>
	public class MyHandleRequest: IHttpHandler 
	{
		public void ProcessRequest(HttpContext context)
		{
			string result = null;
			context.Response.ClearContent();
			context.Response.ContentType = "text/plain"; 
			
			//获取请求的参数
			string invpk=context.Request.Params["inv_pk"];

			// 获取此存货编码的基本信息
			string sql = "select invName,invspec,invtype,measname,RealCurrTypeCode,RealOriginalcurPrice,RmbPrice,RealPriceDate  from Base_inventory where inv_pk = '" + invpk.Trim() + "'"; 

			DataSet ds = Bussiness.ComQuaryBLL.ExecutebyQuery(sql) ;

			if(ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0 )
			{
				DataTable dt = ds.Tables[0];
			    result = DataTableToJson(dt);//构造Json格式类型供前台使用。
			}
			else    //没找到基本信息
			{
				result="0";//没有信息则返回0
			}	
			context.Response.Write(result);
			context.Response.End();
		} 

		public bool IsReusable
		{
			get { return true; } 
		}
 

		/// <summary>
		/// datatable 转换为 json
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
		/// 去掉换行符        
		/// </summary>       
		/// <param name="str"></param>    
		/// <returns></returns>
		public static string GetDeleteBR(string strinput)
		{
			string p = "\\n|\r\n"; //数据库的的换行是\n
			string returnstr = System.Text.RegularExpressions.Regex.Replace(strinput, p, " ");
			return returnstr;
		}

	}
}
