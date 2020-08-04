//namespace HDSZCheckFlow.UI.OrderManage.OrderInfo
//{
//
//
//	public class OneOrderInfo :

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

namespace HDSZCheckFlow.UI.OrderManage.OrderInfo
{
	/// <summary>
	/// AuditingForOneApply ��ժҪ˵����
	/// </summary>
	public class OneOrderInfo : System.Web.UI.Page
	{
		#region   ����

		protected System.Web.UI.WebControls.Label lblApplyDate;
		protected System.Web.UI.WebControls.Label lblMoney;
		protected System.Web.UI.WebControls.Label  lblMessage;
		protected System.Web.UI.WebControls.Label lblDeliveryDate;
		protected System.Web.UI.WebControls.Label lblOrderNo;
		protected System.Web.UI.WebControls.Label lblPerson;
		protected System.Web.UI.WebControls.DataGrid dgOrder;
		protected System.Web.UI.WebControls.Button btnPrint;
		#endregion 
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			string OrderId=Request.QueryString["OrderId"].ToString();  //��Ҫ�����ĵ���ID

			if(!Page.IsPostBack)
			{
				try
				{
					BindBaseInfoOfOrder(int.Parse(OrderId));
					BindApplyBodyInfo(int.Parse(OrderId));
				}
				catch(Exception ex)
				{
					Common.Log.Logger.Log("CheckFlow.ApplySheetBodyInfo2",ex.Message );
				}
			}
		}

		private void BindBaseInfoOfOrder(int OrderId)
		{
			try
			{
				//������ͷ��Ϣ
				#region 
				Entiy.OrderSheet orderSheet = Entiy.OrderSheet.Find(OrderId);
				if(orderSheet != null )
				{
					this.lblOrderNo.Text  = orderSheet.OrderNo ; 
					this.lblApplyDate .Text  = orderSheet.OrderDate.ToString(); 
					Entiy.BasePerson person = Entiy.BasePerson.Find(orderSheet.MakerCode);
					if(person != null )
					{
						this.lblPerson.Text  = person.Name;
					}
				}
				#endregion 
			}
			catch(Exception ex)
			{
				Common.Log.Logger.Log("BindBaseInfoOfOrder",ex.Message );
			}
		}

		private void BindApplyBodyInfo(int OrderId)
		{
			//�ﶨ��������������¼
			DataSet ds=Bussiness.OrderManageBLL.GetOrderBodyByOrderId(OrderId);

			decimal money = 0 ; 

			for (int i=0;i<ds.Tables[0].Rows.Count ;i++)
			{
				money += Convert.ToDecimal( ds.Tables[0].Rows[i]["money"].ToString());
			}
			this.lblMoney.Text = money.ToString("#,###.##");

			if(ds!=null)
			{
				this.dgOrder.DataSource=ds;
			}
			else
			{
				this.dgOrder.DataSource=null;
			}
			this.dgOrder.DataBind();
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
			this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnPrint_Click(object sender, System.EventArgs e)
		{
			//����ˮ�������ӡ
			string OrderId=Request.QueryString["OrderId"].ToString();  //��Ҫ�����ĵ���ID

			//��url�������ܣ���ֹ͵��,Common.Security.Cryptography.Encode
			Response.Write("<script language='javascript'>window.open('../PrintOrder/PrintPurchaseOrder.aspx?OrderId=" + Common.Security.Cryptography.Encode(OrderId) + " ');</script>");

		}
	
	}
}
