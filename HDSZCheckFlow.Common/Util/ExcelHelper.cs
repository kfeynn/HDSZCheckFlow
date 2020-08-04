using System; 
using System.IO; 
using System.Data; 
using System.Web; 
using System.Web.UI; 
using System.Web.UI.WebControls; 
using System.Text; 
using System.Globalization; 
using System.Collections; 


namespace HDSZCheckFlow.Common.Util
{
	public class ExcelHelper 
	{ 
		#region Fields 
 
		string _fileName; 
		DataTable _dataSource;         
		string[] _titles = null; 
		string[] _fields = null; 
		int _maxRecords = 1000; 
 
		#endregion 
 
		#region Properties 
 
		/// <summary> 
		/// ��������� Excel ������¼�����������׳��쳣 
		/// </summary> 
		public int MaxRecords 
		{ 
			set { _maxRecords = value; } 
			get { return _maxRecords; } 
		} 
 
		/// <summary> 
		/// ������������ Excel �ļ��� 
		/// </summary> 
		public string FileName 
		{ 
			set { _fileName = value; } 
			get { return _fileName; } 
		} 
 
		#endregion 
 
		#region .ctor 
 
		/// <summary> 
		/// ���캯�� 
		/// </summary> 
		/// <param name="titles">Ҫ����� Excel ���б��������</param> 
		/// <param name="fields">Ҫ����� Excel ���ֶ���������</param> 
		/// <param name="dataSource">����Դ</param> 
		public ExcelHelper(string[] titles, string[] fields, DataTable dataSource): this(titles, dataSource)        
		{ 
			if (fields == null || fields.Length == 0) 
				throw new ArgumentNullException("fields"); 
 
			if (titles.Length != fields.Length) 
				throw new ArgumentException("titles.Length != fields.Length", "fields"); 
             
			_fields = fields;             
		} 
 
		/// <summary> 
		/// ���캯�� 
		/// </summary> 
		/// <param name="titles">Ҫ����� Excel ���б��������</param> 
		/// <param name="dataSource">����Դ</param> 
		public ExcelHelper(string[] titles, DataTable dataSource): this(dataSource) 
		{ 
			if (titles == null || titles.Length == 0) 
				throw new ArgumentNullException("titles"); 
			//if (titles.Length != dataSource.Columns.Count) 
			//    throw new ArgumentException("titles.Length != dataSource.Columns.Count", "dataSource"); 
 
			_titles = titles;             
		} 
 
		/// <summary> 
		/// ���캯�� 
		/// </summary> 
		/// <param name="dataSource">����Դ</param> 
		public ExcelHelper(DataTable dataSource) 
		{ 
			if (dataSource == null) 
				throw new ArgumentNullException("dataSource"); 
			// maybe more checks needed here (IEnumerable, IList, IListSource, ) ??? 
			// �����жϣ��ȼ򵥵�ʹ�� DataTable 
 
			_dataSource = dataSource; 
		} 
         
		public ExcelHelper() {} 
 
		#endregion 
         
		#region public Methods 
         
		/// <summary> 
		/// ������ Excel ����ʾ���� 
		/// </summary> 
		/// <param name="dg">DataGrid</param> 
		public void Export(DataGrid dg) 
		{ 
			if (dg == null) 
				throw new ArgumentNullException("dg"); 
			if (dg.AllowPaging || dg.PageCount > 1) 
				throw new ArgumentException("paged DataGrid can't be exported.", "dg"); 
 
			// ��ӱ�����ʽ 
			dg.HeaderStyle.Font.Bold = true; 
			dg.HeaderStyle.BackColor = System.Drawing.Color.LightGray; 
 
			RenderExcel(dg); 
		}

        public void Export(GridView dg)
        {
            if (dg == null)
                throw new ArgumentNullException("dg");
            if (dg.AllowPaging || dg.PageCount > 1)
                throw new ArgumentException("paged DataGrid can't be exported.", "dg");

            // ��ӱ�����ʽ 
            dg.HeaderStyle.Font.Bold = true;
            dg.HeaderStyle.BackColor = System.Drawing.Color.LightGray;

            RenderExcel(dg);
        }


 
		/// <summary> 
		/// ������ Excel ����ʾ���� 
		/// </summary> 
		public void Export() 
		{ 
			if (_dataSource == null) 
				throw new Exception("����Դ��δ��ʼ��"); 
 
			if (_fields == null && _titles != null && _titles.Length != _dataSource.Columns.Count)  
				throw new Exception("_titles.Length != _dataSource.Columns.Count"); 
//			if (_fields == null && _titles!=null && _titles.Length != _dataSource.Columns.Count) 
//				throw new Exception("_titles.Length != _dataSource.Columns.Count"); 
  
			if (_dataSource.Rows.Count > _maxRecords) 
				throw new Exception("�������������������ơ������� MaxRecords �����Զ��嵼��������¼����"); 
 
			DataGrid dg = new DataGrid(); 
			dg.DataSource = _dataSource; 
 
			if (_titles == null) 
			{ 
				dg.AutoGenerateColumns = true; 
			}  
			else 
			{ 
				dg.AutoGenerateColumns = false; 
				int cnt = _titles.Length; 
 
				System.Web.UI.WebControls.BoundColumn col; 
 
				if (_fields == null) 
				{ 
					for (int i=0; i<cnt; i++) 
					{ 
						col = new System.Web.UI.WebControls.BoundColumn(); 
						col.HeaderText = _titles[i]; 
						col.DataField = _dataSource.Columns[i].ColumnName; 
						dg.Columns.Add(col); 
					} 
				} 
				else 
				{ 
					for (int i=0; i<cnt; i++) 
					{ 
						col = new System.Web.UI.WebControls.BoundColumn(); 
						col.HeaderText = _titles[i]; 
						col.DataField = _fields[i]; 
						dg.Columns.Add(col); 
					} 
				} 
			} 
 
			// ��ӱ�����ʽ 
			dg.HeaderStyle.Font.Bold = true; 
			dg.HeaderStyle.BackColor = System.Drawing.Color.LightGray; 
			dg.ItemDataBound += new DataGridItemEventHandler(DataGridItemDataBound); 
 
			dg.DataBind(); 
			RenderExcel(dg); 
		} 
 
		#endregion 
 
		#region private Methods 
         
		private void RenderExcel(Control c) 
		{ 
			// ȷ����һ���Ϸ�������ļ��� 
			if (_fileName == null || _fileName == string.Empty || !(_fileName.ToLower().EndsWith(".xls"))) 
				_fileName = GetRandomFileName(); 
 
			HttpResponse response = HttpContext.Current.Response; 
             
			response.Charset = "GB2312"; 
			response.ContentEncoding = Encoding.GetEncoding("GB2312"); 
			response.ContentType = "application/ms-excel/msword"; 
			response.AppendHeader("Content-Disposition", "attachment;filename=" +  
				HttpUtility.UrlEncode(_fileName)); 
 
			CultureInfo cult = new CultureInfo("zh-CN", true); 
			StringWriter sw = new StringWriter(cult);             
			HtmlTextWriter writer = new HtmlTextWriter(sw); 
 
			writer.WriteLine("<meta http-equiv=\"Content-Type\" content=\"text/html;charset=GB2312\">"); 
 
			DataGrid dg = c as DataGrid; 
             
			if (dg != null) 
			{ 
				dg.RenderControl(writer); 
			} 

			c.Dispose(); 
 
			response.Write(sw.ToString()); 
			response.End(); 
		} 
 
 
		/// <summary> 
		/// �õ�һ��������ļ��� 
		/// </summary> 
		/// <returns></returns> 
		private string GetRandomFileName() 
		{ 
			Random rnd = new Random((int) (DateTime.Now.Ticks)); 
			string s = rnd.Next(Int32.MaxValue).ToString(); 
			return DateTime.Now.ToShortDateString() + "_" + s + ".xls"; 
		} 
 
		private void DataGridItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e) 
		{ 
			if(e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) 
			{ 
				e.Item.Attributes.Add("style", "vnd.ms-excel.numberformat:@"); 
				//e.Item.Cells[3].Attributes.Add("style", "vnd.ms-excel.numberformat:��#,###.00"); 
			} 
		} 
 
		#endregion 


        /// <summary>
        /// DataGrid ����Excel����ʾ����
        /// </summary>
        /// <param name="fileName">�������ļ���</param>
        /// <param name="ctl">����ʵ��</param>
        public void GoToExcel2(string fileName, System.Web.UI.WebControls.GridView ctl)
        {
            HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment;filename=" + fileName + "");
            HttpContext.Current.Response.Charset = "GB2312";
            HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");//System.Text.Encoding.Default;   ////
            HttpContext.Current.Response.ContentType = "application/ms-excel";
            ctl.Page.EnableViewState = false;
            //System.Globalization.CultureInfo myCItrad = new System.Globalization.CultureInfo("ZH-CN",true);
            System.IO.StringWriter tw = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);
            ctl.RenderControl(hw);
            HttpContext.Current.Response.Write("<meta http-equiv=Content-Type content=text/html;charset=GB2312>");

            HttpContext.Current.Response.Write(tw.ToString());
            HttpContext.Current.Response.End();
        }

		
		/// <summary>
		/// ��DATAGRID���������ӱ��
		/// </summary>
		/// <param name="ctl"></param>
		public   void   DataGridToExcel( System.Web.UI.Control   ctl)       
		{   
			try
			{
				HttpContext.Current.Response.Write("<html><head><meta http-equiv=Content-Type content=\"text/html; charset=gb2312\">");
				HttpContext.Current.Response.AppendHeader("Content-Disposition","attachment;filename=Excel.xls");   
				HttpContext.Current.Response.Charset   ="GB2312";   
				HttpContext.Current.Response.ContentEncoding   =System.Text.Encoding.Default;   
				HttpContext.Current.Response.ContentType   ="application/ms-excel";//image/JPEG;text/HTML;image/GIF;vnd.ms-excel/msword   
				ctl.Page.EnableViewState   =false;   
				System.IO.StringWriter     tw   =   new   System.IO.StringWriter()   ;   
				System.Web.UI.HtmlTextWriter   hw   =   new   System.Web.UI.HtmlTextWriter   (tw);   
				ctl.RenderControl(hw);   
				HttpContext.Current.Response.Write(tw.ToString());   


				HttpContext.Current.Response.Write("</body></html>");


				HttpContext.Current.Response.End();  
			}

			catch
			{
				throw new Exception("�����޷�����!");

			}
		}
		/// <summary>
		/// DataGrid ����Excel����ʾ����
		/// </summary>
		/// <param name="fileName"></param>
		/// <param name="ctl"></param>
		public void GoToExcel(string fileName,System.Web.UI.WebControls.DataGrid ctl)
		{
			HttpContext.Current.Response.AppendHeader("Content-Disposition","attachment;filename=" + fileName +"");   
			HttpContext.Current.Response.Charset   ="GB2312";   
			HttpContext.Current.Response.ContentEncoding   =System.Text.Encoding.Default;   //System.Text.Encoding.GetEncoding("GB2312");//
			HttpContext.Current.Response.ContentType   ="application/ms-excel";
			ctl.Page.EnableViewState   =false;   
			//System.Globalization.CultureInfo myCItrad = new System.Globalization.CultureInfo("ZH-CN",true);
			System.IO.StringWriter     tw   =   new   System.IO.StringWriter()   ;   
			System.Web.UI.HtmlTextWriter   hw   =   new   System.Web.UI.HtmlTextWriter   (tw);   
			ctl.RenderControl(hw);   
			HttpContext.Current.Response.Write(tw.ToString());   
			HttpContext.Current.Response.End();  
		}

//		/// <summary>
//		/// DataGrid ����Excel����ʾ����
//		/// </summary>
//		/// <param name="fileName"></param>
//		/// <param name="ctl"></param>
//		public void GoToExcelFromDataSet(string fileName,DataSet  ds)
//		{
//			    
//			DataTable   dt=ds.Tables[0];     
//			StringWriter   sw=new   StringWriter();     
//			System.Web.UI.HtmlTextWriter   hw   =   new   System.Web.UI.HtmlTextWriter   (sw); 
////			sw.WriteLine("�Զ����,����,����");     
////			foreach(DataRow   dr   in   dt.Rows)     
////			{     
////				sw.WriteLine(dr["ID"]+","+dr["vName"]+","+dr["iAge"]);     
////			}     
//
//			foreach(DataRow dr in dt.Rows)
//			{
//				for(int i=0;i<dr.ItemArray.Length ;i++)
//				{
//					sw.Write(dr[i].ToString() + " ," );
//				}
//				sw.WriteLine ("");
//			}
//			sw.Close();
//			HttpContext.Current.Response.AddHeader("Content-Disposition","attachment;filename=test.csv");
//			HttpContext.Current.Response.ContentType="application/ms-excel";
//			HttpContext.Current.Response.ContentEncoding=System.Text.Encoding.GetEncoding("GB2312");
//			HttpContext.Current.Response.Write(hw);
//			HttpContext.Current.Response.End();
//
//		}

		/// <summary>
		/// DataGrid ����Excel����ʾ����
		/// </summary>
		/// <param name="fileName">�������ļ���</param>
		/// <param name="ctl">����ʵ��</param>
		public void GoToExcelFromDataSet(string fileName, DataSet ds)
		{

			DataTable dt = ds.Tables[0];
			StringWriter sw = new StringWriter();
			System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(sw);
			//			sw.WriteLine("�Զ����,����,����");     
			//			foreach(DataRow   dr   in   dt.Rows)     
			//			{     
			//				sw.WriteLine(dr["ID"]+","+dr["vName"]+","+dr["iAge"]);     
			//			}     
			for (int j = 0; j < dt.Columns.Count; j++)
			{
				sw.Write(dt.Columns[j].ColumnName + " ,");
			}
			sw.WriteLine("");

			foreach (DataRow dr in dt.Rows)
			{
				for (int i = 0; i < dr.ItemArray.Length; i++)
				{
					sw.Write(dr[i].ToString() + " ,");
				}
				sw.WriteLine("");
			}
			sw.Close();
			HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=" + fileName);
			HttpContext.Current.Response.ContentType = "application/ms-excel";
			HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
			//HttpContext.Current.Response.Write(hw);
			HttpContext.Current.Response.Write(sw);
			HttpContext.Current.Response.End();

		}


		/// <summary>
		///  DataGrid ����Pdf ����ʾ����
		/// </summary>
		/// <param name="fileName"></param>
		/// <param name="ctl"></param>
		public void GoToPDF(string fileName,System.Web.UI.WebControls.DataGrid ctl)
		{
			HttpContext.Current.Response.AppendHeader("Content-Disposition","attachment;filename=" + fileName +"");   
			HttpContext.Current.Response.Charset   ="GB2312";   
			HttpContext.Current.Response.ContentEncoding   =System.Text.Encoding.Default;   //System.Text.Encoding.GetEncoding("GB2312");//
			HttpContext.Current.Response.ContentType = "application/pdf"; 
			ctl.Page.EnableViewState   =false;   
			System.Globalization.CultureInfo myCItrad = new System.Globalization.CultureInfo("ZH-CN",true);
			System.IO.StringWriter     tw   =   new   System.IO.StringWriter()   ;   
			System.Web.UI.HtmlTextWriter   hw   =   new   System.Web.UI.HtmlTextWriter   (tw);   
			ctl.RenderControl(hw);   
			HttpContext.Current.Response.Write(tw.ToString());   
			HttpContext.Current.Response.End();  
		}






	} 
}
