using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using System.Text;
using entiy=HDSZCheckFlow.Entiy;
using System.Text.RegularExpressions;
using System.Data.SqlClient;


namespace HDSZCheckFlow.UI.FixedAssets
{
	/// <summary>
	/// AssetStorageRemarks ��ժҪ˵����
	/// </summary>
	public class AssetStorageRemarks : System.Web.UI.Page
	{
		#region
		protected System.Web.UI.WebControls.TextBox txtApplyNo;
		protected System.Web.UI.WebControls.RadioButton rbtMark1;
		protected System.Web.UI.WebControls.RadioButton rbtMark2;
		protected System.Web.UI.WebControls.RadioButton rbtMark3;
		protected System.Web.UI.WebControls.TextBox txtProduct;
		protected System.Web.UI.WebControls.TextBox txtOrderNumber;
		protected System.Web.UI.WebControls.Button btnQuery;
		protected System.Web.UI.WebControls.Label lblPage;
		protected System.Web.UI.WebControls.Button btnFrist;
		protected System.Web.UI.WebControls.Button btnPageShi;
		protected System.Web.UI.WebControls.Button btnShang;
		protected System.Web.UI.WebControls.Button btnXia;
		protected System.Web.UI.WebControls.Button btnTuiShi;
		protected System.Web.UI.WebControls.Button btnMo;
		protected System.Web.UI.WebControls.Label lblTiao;
		protected System.Web.UI.WebControls.TextBox txtPage;
		protected System.Web.UI.WebControls.Button btnGo;
		protected System.Web.UI.WebControls.DataGrid dgApply;
		protected System.Web.UI.WebControls.CheckBox chbSelectAll;
		protected System.Web.UI.WebControls.Button btnUpdateShuju;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.TextBox TextBox1;
		protected System.Web.UI.WebControls.TextBox txtDateTo;
		protected System.Web.UI.WebControls.Button btnEnter;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.Panel Panel1;
		protected System.Web.UI.HtmlControls.HtmlGenericControl divPages;
		#endregion
		protected System.Web.UI.WebControls.CheckBox CheckBox3;
		protected System.Web.UI.WebControls.CheckBox CheckBox2;
		protected System.Web.UI.WebControls.RadioButton rbtChiceYes;
		protected System.Web.UI.WebControls.RadioButton rbtChiceNo;
		protected System.Web.UI.WebControls.RadioButton rbtChiceAll;
		HDSZCheckFlow.Entiy.PageViewState pageF = null;
		 
		/// <summary>
		/// Ҫ��ʾ�ı����������� 
		/// </summary>
	
		public string TblName
		{
			get { return ViewState["TblName"].ToString(); }
			set { ViewState["TblName"] = value; }
		}


		/// <summary>
		/// Ҫ��ʾ���ֶ��б�
		/// </summary>
		
		public string FldName
		{
			get { return ViewState["FldName"].ToString(); }
			set { ViewState["FldName"] = value; }
		}

		
		/// <summary>
		/// ÿҳ��ʾ�ļ�¼���� 
		/// </summary>
		public int PageSize
		{
			get { return  Convert.ToInt32( ViewState["PageSize"]); }
			set { ViewState["PageSize"] = value; }
		}


		/// <summary>
		/// Ҫ��ʾ��һҳ�ļ�¼
		/// </summary>
	
		public int Pages
		{
			get { return Convert.ToInt32( ViewState["Pages"]); }
			set { ViewState["Pages"] = value; }
		}
	

		/// <summary>
		/// �����ֶ��б������ 
		/// </summary>
		public string FldSort
		{
			get { return ViewState["FldSort"].ToString(); }
			set { ViewState["FldSort"] = value; }
		}


		/// <summary>
		/// ���򷽷���1Ϊ����0Ϊ����(����Ƕ��ֶ�����Sortָ�����һ�������ֶε�����˳��(���һ�������ֶβ���������)--���򴫲��磺' SortA Asc,SortB Desc,SortC ')  
		/// </summary>
		public int Sort
		{
			get { return Convert.ToInt32(ViewState["Sort"]); }
			set { ViewState["Sort"] = value; }
		}


		/// <summary>
		/// ��ѯ����,����where  
		/// </summary>
		public string StrCondition
		{
			get { return ViewState["StrCondition"].ToString(); }
			set { ViewState["StrCondition"] = value; }
		}


		/// <summary>
		/// ���������  
		/// </summary>
		public string id
		{
			get { return  ViewState["id"].ToString(); }
			set { ViewState["id"] = value; }
		}
		

		/// <summary>
		/// �Ƿ���Ӳ�ѯ�ֶε� DISTINCT Ĭ��0�����/1���  
		/// </summary>
		
		public int Dist
		{
			get { return Convert.ToInt32(ViewState["Dist"]); }
			set { ViewState["Dist"] = value; }

		}


		/// <summary>
		/// ��ѯ�����ҳ�����ҳ�� 
		/// </summary>
		public int PageCount
		{
			get { return Convert.ToInt32( ViewState["PageCount"]); }
			set { ViewState["PageCount"] = value; }

		}

		
		/// <summary>
		/// ��ѯ���ļ�¼��  
		/// </summary>
		public int Counts
		{
			get { return Convert.ToInt32( ViewState["Counts"]); }
			set { ViewState["Counts"] = value; }

		}
		
		
		/// <summary>
		/// ������������� 
		/// </summary>
		public int Rownum
		{
			get { return Convert.ToInt32( ViewState["Rownum"]); }
			set { ViewState["Rownum"] = value; }

		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
			if(!Page.IsPostBack)
			{
				this.getPageViewLoad(1,"",0,0);
				
			}
		}

		#region Web ������������ɵĴ���
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: �õ����� ASP.NET Web ���������������ġ�
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
		/// �˷��������ݡ�
		/// </summary>
		private void InitializeComponent()
		{    
			this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
			this.btnFrist.Click += new System.EventHandler(this.btnFrist_Click);
			this.btnPageShi.Click += new System.EventHandler(this.btnPageShi_Click);
			this.btnShang.Click += new System.EventHandler(this.btnShang_Click);
			this.btnXia.Click += new System.EventHandler(this.btnXia_Click);
			this.btnTuiShi.Click += new System.EventHandler(this.btnTuiShi_Click);
			this.btnMo.Click += new System.EventHandler(this.btnMo_Click);
			this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
			this.dgApply.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgApply_ItemCommand);
			this.dgApply.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgApply_ItemDataBound);
			this.chbSelectAll.CheckedChanged += new System.EventHandler(this.chbSelectAll_CheckedChanged);
			this.btnUpdateShuju.Click += new System.EventHandler(this.btnUpdateShuju_Click);
			this.btnEnter.Click += new System.EventHandler(this.btnEnter_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		/// <summary>
		///	��������
		/// </summary>
		private void getPageViewstate(string tblName,string fldName,int pageSize,int page,string fldSort ,int sort,string strCondition,string iD,int dist,int pageCount,int counts)
		{
			pageF = new HDSZCheckFlow.Entiy.PageViewState();
			pageF.TblName = tblName;
			pageF.FldName = fldName;
			pageF.PageSize = pageSize;
			pageF.Page = page;
			pageF.FldSort = fldSort;
			pageF.Sort = sort;
			pageF.StrCondition = strCondition;
			pageF.ID = iD;
			pageF.Dist = dist;
			pageF.PageCount = pageCount;
			pageF.Counts = counts;
			this.saveState(tblName, fldName, pageSize, page, fldSort , sort, strCondition, iD, dist, pageCount, counts);
			
		}

		/// <summary>
		/// ��������
		/// </summary>
		private void saveState(string tblName,string fldName,int pageSize,int page,string fldSort ,int sort,string strCondition,string iD,int dist,int pageCount,int counts)
		{
			this.TblName =tblName;
			this.FldName = fldName;
			this.PageSize = pageSize;
			this.Pages = page;
			this.FldSort = fldSort;
			this.Sort = sort;
			this.StrCondition = strCondition;
			this.id = iD;
			this.Dist = dist;
			this.PageCount = pageCount;
			this.Counts = counts;
		}


		/// <summary>
		/// 
		/// ��ҳ
		/// </summary>
		private void getPageViewLoadMain(int page1 ,string strCondition1,int pageCount1,int counts1)
		{
			//Ҫ��ʾ�ı�����������  
			string tblName ="[Asset_FinallyPriceCheck] as a inner JOIN [Asset_FinallyPriceCheck_Body] as b ON  a.[id]=b.[FinallyPriceCheck_Id] inner join [v_FinallyPriceCheckList] as c on a.[id] = c.[id] ";
			//��ʾ�ֶ�
			string fldName = @"a.id as aid ,b.Id ,a.[ApplySheetHead_Pk],a.[PriceCheckSheetNo],a.ApplyDeptClassCode,a.ApplyDeptCode,a.ApplyPersonCode,a.MakeDate,a.BargainNo,a.ItemName,b.[FinallyPriceCheck_Id],b.SubjectName,b.[Asset_ApplySheet_Body_Id],b.Offer,b.Article,b.Remark,b.Number,b.originalcurrPrice,b.currTypeCode,b.FinallyPrice,b.IsInStore,b.InStoreSigner,b.InStoreDatetime";
			//ҳ��ʾ����
			int pageSize = 5;
			//�����ֶ��б������  
			string FldSort  ="MakeDate";
			//���򷽷���1Ϊ����0Ϊ����(����Ƕ��ֶ�����Sortָ�����һ�������ֶε�����˳��(���һ�������ֶβ���������)--���򴫲��磺' SortA Asc,SortB Desc,SortC ')  
			int Sort = 1;
			//��������� //Ӧ��Ϊ���������
			string ID = "ID";
			//�Ƿ���Ӳ�ѯ�ֶε� DISTINCT Ĭ��0�����/1��� 
			int Dist = 0;
			//pageCount    int = 1 output,            ----��ѯ�����ҳ�����ҳ��  out
			this.getPageViewstate(  tblName, fldName, pageSize, page1, FldSort , Sort, strCondition1, ID, Dist, pageCount1, counts1);
			//������Ԥ�����õ���Ŀ
			
			try
			{
				DataSet dsProc_DataPagination = HDSZCheckFlow.Bussiness.AssetAdvanceRemarksBLL.GetPageDataPagination( pageF);
				this.dgApply.DataSource = dsProc_DataPagination.Tables[0];
				this.dgApply.DataBind();
				this.PageCount = pageF.PageCount;
				this.Counts = pageF.Counts;
				if(page1 > PageCount)
				{
					this.Pages = PageCount;
				}
				else if(page1 <= 0)
				{
					this.Pages = 1;
				}
				this.lblPage.Text = "�� "+this.Pages.ToString()+" ҳ �� "+this.PageCount.ToString()+" ҳ  �ܼ�¼�� "+this.Counts.ToString()+ "  ��";
				
			}			
			catch(Exception ex)			
			{		
				
				Common.Log.Logger.Log("AssetArrivalRemarks.aspx",ex.ToString());		
			}	
		}
			



		/// <summary>
		/// ��ʼ������
		/// </summary>
		private void getPageViewLoad(int page,string strCondition,int pageCount,int counts)
		{
			try
			{
				this.Panel1.Visible=false;	
				this.getPageViewLoadMain(page , strCondition, pageCount, counts);
			}			
			catch(Exception ex)			
			{			
				Common.Log.Logger.Log("AssetArrivalRemarks.aspx",ex.ToString());		
			}		
			 	

		}

	

		/// <summary>
		/// ��֯��ѯ����
		/// </summary>
		/// <returns></returns>
		private string getStrCondition()
		{
			//txtApplyNo ��   ��  ��
			//txtProduct  �� Ŀ �� ��
			//txtOrderNumber  ��   ͬ  ��
			//rbtMark1 ��
			//rbtMark2 ��
			//rbtMark3 ȫ Ĭ��Ϊȫ 
			
			#region  �����ѯ����
			
			StringBuilder filter=new StringBuilder();
			
			if(this.CheckBox2.Checked)
			{
				//���ŵĲ�ѯ����
				if(!"".Equals(this.txtApplyNo.Text))
				{ 
				
					filter.Append(" and ");
					//���� this.txtApplyNo.Text ,���ŷָ�    ǰ������� ������
					string querySheetNoStr = "";
					string []tempStr = this.txtApplyNo.Text.Split(new char[] {','});
					foreach(string aaStr in tempStr)
					{
						if(querySheetNoStr.Length > 0 )
						{
							querySheetNoStr = querySheetNoStr + "," + "'" + aaStr + "'" ;
						}
						else
						{
							querySheetNoStr =  "'" + aaStr + "'" ; 
						}
					}

					filter.Append(" PriceCheckSheetNo in  " +" (" + querySheetNoStr + ")" );
				}
				//��Ŀ���Ʋ�ѯ���� 
				if(!"".Equals(this.txtProduct.Text))
				{
				
					filter.Append(" and ");
				

					//���� this.txtProduct.Text ,���ŷָ�    ǰ������� ������
					string queryProductStr = "";
					string []testStr = this.txtProduct.Text.Split(new char[] {','});
					foreach(string aaaStr in testStr)
					{
						if(queryProductStr.Length > 0 )
						{
							queryProductStr = queryProductStr + "," + "'" + aaaStr + "'" ;
						}
						else
						{
							queryProductStr =  "'" + aaaStr + "'" ; 
						}
					}

					filter.Append(" ItemName in  " +"(" + queryProductStr + ")" );
				}
			
				//�Ƿ����� IsArrived

				if(!this.rbtChiceAll.Checked)
				{
				
					filter.Append(" and ");
				
					if(this.rbtChiceYes.Checked )
					{
						filter.Append("IsArrived  = 1 " );
					}
					else
					{
						filter.Append(" (IsArrived = 0 or IsArrived is null) " );
					}
				}
			
				//��ͬ�� ����BargainNo
				if(!"".Equals(this.txtOrderNumber.Text))
				{
				
					filter.Append(" and ");
				

					//���� this.txtOrderNumber.Text 
					string queryProductStr = this.txtOrderNumber.Text.Trim().ToString();

					filter.Append(" (BargainNo like  '%" + queryProductStr + "%')" );
				
				}

			}
			else
			{
				//���ŵĲ�ѯ����
				if(!"".Equals(this.txtApplyNo.Text))
				{ 
				
					filter.Append(" and ");
					//���� this.txtApplyNo.Text ,���ŷָ�    ǰ������� ������
					string querySheetNoStr = "";
					string []tempStr = this.txtApplyNo.Text.Split(new char[] {','});
					foreach(string aaStr in tempStr)
					{
						if(querySheetNoStr.Length > 0 )
						{
							querySheetNoStr = querySheetNoStr + "," + "'" + aaStr + "'" ;
						}
						else
						{
							querySheetNoStr =  "'" + aaStr + "'" ; 
						}
					}

					filter.Append(" PriceCheckSheetNo in  " +" (" + querySheetNoStr + ")" );
				}
				//��Ŀ���Ʋ�ѯ���� 
				if(!"".Equals(this.txtProduct.Text))
				{
				
					filter.Append(" and ");
				

					//���� this.txtProduct.Text ,���ŷָ�    ǰ������� ������
					string queryProductStr = "";
					string []testStr = this.txtProduct.Text.Split(new char[] {','});
					foreach(string aaaStr in testStr)
					{
						if(queryProductStr.Length > 0 )
						{
							queryProductStr = queryProductStr + "," + "'" + aaaStr + "'" ;
						}
						else
						{
							queryProductStr =  "'" + aaaStr + "'" ; 
						}
					}

					filter.Append(" ItemName in  " +"(" + queryProductStr + ")" );
				}
			
				//�Ƿ񵽻� IsArrived

				if(!this.rbtMark3.Checked)
				{
				
					filter.Append(" and ");
				
					if(this.rbtMark1.Checked )
					{
						filter.Append("IsInStore  = 1 " );
					}
					else
					{
						filter.Append(" (IsInStore = 0 or IsInStore is null) " );
					}
				}
			
				//��ͬ�� ����BargainNo
				if(!"".Equals(this.txtOrderNumber.Text))
				{
				
					filter.Append(" and ");
				

					//���� this.txtOrderNumber.Text 
					string queryProductStr = this.txtOrderNumber.Text.Trim().ToString();

					filter.Append(" (BargainNo like  '%" + queryProductStr + "%')" );
				
				}

			}
			string returnValue=filter.ToString();

			
			return returnValue;

			
			#endregion  
			
			
		}

		/// <summary>
		/// ��ѯ
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnQuery_Click(object sender, System.EventArgs e)
		{

			this.getPageViewLoad(1,getStrCondition(),0,0);
		}

		/// <summary>
		/// ��ע���
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnEnter_Click(object sender, System.EventArgs e)
		{
			this.lblMessage.Text = "";
			string EarnestSigner = this.TextBox1.Text.Trim();
			string txtDateTo =this.txtDateTo.Text.Trim();
			int IsInStore = this.CheckBox3.Checked == true ? 1 : 0;
			//�Ƿ�����
			int IsArrived = HDSZCheckFlow.Bussiness.AssetAdvanceRemarksBLL.SelectIsArrivedByOS(this.Rownum);
			if(IsArrived > 0)
			{
				//����Ѿ����������޸�
				int IsPayForP = HDSZCheckFlow.Bussiness.AssetAdvanceRemarksBLL.SelectBycmdStrIsPayForP( this.Rownum);
				if(IsPayForP < 1)
				{
					int UpAssetAdvance = HDSZCheckFlow.Bussiness.AssetAdvanceRemarksBLL.UadateAssetStorageRemarks(IsInStore,EarnestSigner,txtDateTo,this.Rownum);
					if(UpAssetAdvance > 0)
					{
						this.lblMessage.Text = "��ע���ɹ���";
						this.getPageViewLoad(this.Pages,getStrCondition(),0,0);
					}
					else
					{
						this.lblMessage.Text = "��ע���ʧ�ܣ�";
						this.Label4.Text = "��ע���ʧ��!";
					}
				}
				else
				{
					this.lblMessage.Text = "��ע��Ϣ�Ѿ����";
					this.Label4.Text = "��ע��Ϣ�Ѿ�����";
				}
				
			}
			else
			{
				this.lblMessage.Text = "δ���գ�";
				this.Label4.Text = "δ���գ�";
			}
			
		}

		private static  Color color;

		/// <summary>
		/// GridVIEW���������	
		/// </summary>
		/// <param name="source"></param>
		/// <param name="e"></param>
		private void dgApply_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			try
			{				
				if(e.CommandName.Equals("ReMark")) //���������ť			
				{			
					for(int i=0;i<this.dgApply.Items.Count ;i++)		
					{		
						if(this.dgApply.Items[i].BackColor==Color.Yellow)	
						{	
							this.dgApply.Items[i].BackColor= color;
						}	
					}		
					color=e.Item.BackColor;		
					e.Item.BackColor=Color.Yellow;		
					
					// ..initial Panel		
					
					this.Panel1.Visible=true;		
				
					//�۸�þ����ݱ���id
					this.Rownum = Convert.ToInt32(e.CommandArgument);

					this.CheckBox3.Checked = ((Label)e.Item.FindControl("lblyfk")).Text == "��" ? true : false  ; 
					this.txtDateTo.Text = DateTime.Now.ToString("yyyy-MM-dd mm:dd:ss");
					if(!"&nbsp;".Equals( e.Item.Cells[7].Text.Trim()) )
					{
						
						this.TextBox1.Text = e.Item.Cells[7].Text.Trim();
					}
					else
					{
						
						int UserCode = Convert.ToInt32( User.Identity.Name);

						this.TextBox1.Text = HDSZCheckFlow.Bussiness.AssetAdvanceRemarksBLL.getUserName(UserCode);
				   
					}
					
					if(!"&nbsp;".Equals( e.Item.Cells[8].Text.Trim()))
					{
						this.txtDateTo.Text = e.Item.Cells[8].Text.Trim();
					}
					

				
				}		
			}			
			catch(Exception ex)			
			{			
				Common.Log.Logger.Log("AssetArrivalRemarks.aspx/dgApply_ItemCommand",ex.ToString());		
			}			

		}

		/// <summary>
		/// ��ҳ
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnFrist_Click(object sender, System.EventArgs e)
		{
			
			this.getPageViewLoad( 1, getStrCondition() , 0, 0); 
			
		}

		/// <summary>
		/// ����ʮҳ��  �ڵ�ǰҳ���ϼӺ���ʮ �󻹴���1 ����ʾ����ʮ��ҳ��  �����С��0 ����ʾ��һҳ
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnPageShi_Click(object sender, System.EventArgs e)
		{

			if(Convert.ToInt32(this.Pages) - 10 >= 0)
			{
				int btnA = Convert.ToInt32(this.Pages) - 10;
				this.getPageViewLoad( btnA, getStrCondition() , 0, 0); 
			}
			else
			{
				this.getPageViewLoad( 1, getStrCondition() , 0, 0); 
			}
		}
		
		/// <summary>
		/// ��ҳ��Ϊһ
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnShang_Click(object sender, System.EventArgs e)
		{
			if(Convert.ToInt32( this.Pages) - 1 >= 0)
			{
				int btnA =Convert.ToInt32( this.Pages) - 1;
				this.getPageViewLoad( btnA, getStrCondition() , 0, 0); 
			}
			else
			{
				this.getPageViewLoad( 1, getStrCondition() , 0, 0); 
			}
		}

		/// <summary>
		/// ��һҳ
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnXia_Click(object sender, System.EventArgs e)
		{
			if(Convert.ToInt32(this.Pages) + 1 <= this.PageCount )
			{
				this.Pages = Convert.ToInt32(this.Pages) + 1;
				this.getPageViewLoad( Convert.ToInt32(this.Pages), getStrCondition() , 0, 0); 
			}
			else
			{
				this.getPageViewLoad(this.PageCount, getStrCondition() , 0, 0); 
			}
		}

		/// <summary>
		/// ǰ��ʮҳ  ��� ʮҳ���ҳ��������ҳ�� ������ʾ���һҳ
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnTuiShi_Click(object sender, System.EventArgs e)
		{
			if(Convert.ToInt32(this.Pages) + 10 <= this.Counts)
			{
				int btnA = Convert.ToInt32(this.Pages) + 10;
				this.getPageViewLoad( btnA, getStrCondition() , 0, 0); 
			}
			else
			{
				this.getPageViewLoad( this.PageCount, getStrCondition() , 0, 0); 
			}
		}

		/// <summary>
		/// ĩҳ
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnMo_Click(object sender, System.EventArgs e)
		{
			this.getPageViewLoad( this.PageCount, getStrCondition() , 0, 0); 
		}

		/// <summary>
		/// ��ת��ָ��ҳ��
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnGo_Click(object sender, System.EventArgs e)
		{
			
			string   str   =   this.txtPage.Text.Trim(); 
			//ֻ����������
			if(Regex.Match(str, @"^[0-9]*[1-9][0-9]*$").Success) 
			{ 
				//ҳ��Ϊ�յĻ� ҳ�����ֲ���
				if(this.txtPage.Text.Trim().ToString() !=null )
				{
					this.getPageViewLoad(Convert.ToInt32(str), getStrCondition() , 0, 0); 
				}
				else
				{
					this.getPageViewLoad(Convert.ToInt32( this.Pages ), getStrCondition() , 0, 0); 
				}
				this.Label4.Text ="";
							
			} 
			else 
			{ 

				this.Label4.Text = "������ֻ��������������";
				this.txtPage.Text = "";
			} 

			
		}
		
		/// <summary>
		/// ѡ�е����ݽ��и���
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnUpdateShuju_Click(object sender, System.EventArgs e)
		{
			foreach(DataGridItem itm in this.dgApply.Items )
			{
				
				CheckBox chkCode=itm.FindControl("CheckBox1") as CheckBox;
				if( chkCode.Checked )
				{
					int Chi = (itm.FindControl("lblyfk") as Label).Text.Trim().ToString() == "��" ? 1 : 1;
					int UserCode = Convert.ToInt32( User.Identity.Name);
					string Code = HDSZCheckFlow.Bussiness.AssetAdvanceRemarksBLL.getUserName(UserCode);
					string txtDateTo  = DateTime.Now.ToString("yyyy-MM-dd");
					int  ID=int.Parse(dgApply.DataKeys[itm.ItemIndex].ToString()); 

					//�Ƿ�����
					int IsArrived = HDSZCheckFlow.Bussiness.AssetAdvanceRemarksBLL.SelectIsArrivedByOS(ID);
					if(IsArrived > 0)
					{
						//����Ѿ����������޸�
						int IsPayForP = HDSZCheckFlow.Bussiness.AssetAdvanceRemarksBLL.SelectBycmdStrIsPayForP( this.Rownum);
						if(IsPayForP < 1)
						{
							int UpAssetAdvance =   HDSZCheckFlow.Bussiness.AssetAdvanceRemarksBLL.UadateAssetStorageRemarks(Chi,Code,txtDateTo,ID);

							if(UpAssetAdvance < 1)
							{
								this.Label4.Text = "�޸�ʧ�ܣ�";
							}
						}
						else
						{
							this.Label4.Text = "�����Ѿ�������Ϣ�����飡";
						}
						
					}
					else
					{
						this.Label4.Text = "����δ�����豸�����飡";
						break;
					}
				}
				
			}
			
			this.getPageViewLoad( this.Pages, getStrCondition() , 0, 0); 
		}

		/// <summary>
		/// ȫѡʵ�� �ı�GRIDVIEW Checked 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void chbSelectAll_CheckedChanged(object sender, System.EventArgs e)
		{
			//ȫѡ
			if(this.chbSelectAll.Checked )
			{
				foreach(DataGridItem itm in this.dgApply.Items )
				{
					CheckBox chkCode=itm.FindControl("CheckBox1") as CheckBox;
					chkCode.Checked=true;
				}
			}
			else
			{
				foreach(DataGridItem itm in this.dgApply.Items )
				{
					CheckBox chkCode=itm.FindControl("CheckBox1") as CheckBox;
					chkCode.Checked=false;

					
				}
			}
		}

		private void dgApply_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{

			if(!"&nbsp;".Equals( e.Item.Cells[5].Text.Trim())&&(e.Item.ItemType!=ListItemType.Footer)&&(e.Item.ItemType!=ListItemType.Header)&&(e.Item.ItemType!=ListItemType.Pager))
			{
				string Asset_ApplySheet_Body_Id = e.Item.Cells[5].Text.Trim().ToString();
				string SubjectName = HDSZCheckFlow.Bussiness.AssetAdvanceRemarksBLL.SelectAsset_ApplySheet_Body_Id(Asset_ApplySheet_Body_Id);
				e.Item.Cells[5].Text = SubjectName;
			}
			//�󶨸�����ť��ʾ��Ϣ
			if (!"&nbsp;".Equals( e.Item.Cells[6].Text.Trim())&&(e.Item.ItemType!=ListItemType.Footer)&&(e.Item.ItemType!=ListItemType.Header)&&(e.Item.ItemType!=ListItemType.Pager)) 
			{ 
				if(!"&nbsp;".Equals( e.Item.Cells[6].Text.Trim()))
				{
					string ApplySheetHead_Pk =  e.Item.Cells[6].Text.Trim();
					string Name = HDSZCheckFlow.Bussiness.AssetAdvanceRemarksBLL.SelectNameByApplySheetHead_Pk(ApplySheetHead_Pk);
					e.Item.Cells[6].Text = Name;
				}
				
			}
		}

		
	}
}
