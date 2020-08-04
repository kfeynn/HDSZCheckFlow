using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.Text;
using System.Data;

namespace SendEmail
{
	/// <summary>
	/// TimerSendEmail ��ժҪ˵����
	/// </summary>
	public class TimerSendEmail : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox tbTime;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Label lblMsg;
		private System.Windows.Forms.NotifyIcon notifyIcon1;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Button button4;
		private System.ComponentModel.IContainer components;

		public TimerSendEmail()
		{
			//
			// Windows ���������֧���������
			//
			InitializeComponent();
			//
			// TODO: �� InitializeComponent ���ú�����κι��캯������
			//
		}

		/// <summary>
		/// ������������ʹ�õ���Դ��
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		/// <summary>
		/// Ӧ�ó��������ڵ㡣
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new TimerSendEmail());
		}

		#region Windows ������������ɵĴ���
		/// <summary>
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
		/// �˷��������ݡ�
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(TimerSendEmail));
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.button1 = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.tbTime = new System.Windows.Forms.TextBox();
			this.button2 = new System.Windows.Forms.Button();
			this.lblMsg = new System.Windows.Forms.Label();
			this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
			this.button3 = new System.Windows.Forms.Button();
			this.dataGrid1 = new System.Windows.Forms.DataGrid();
			this.button4 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			this.SuspendLayout();
			// 
			// timer1
			// 
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(128, 112);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(88, 23);
			this.button1.TabIndex = 1;
			this.button1.Text = "�����ֶ�����";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(32, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(536, 23);
			this.label1.TabIndex = 2;
			this.label1.Text = "�����ʼ���������(�ų���������)";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(40, 72);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(72, 16);
			this.label2.TabIndex = 3;
			this.label2.Text = "����ʱ�䣺";
			// 
			// tbTime
			// 
			this.tbTime.Location = new System.Drawing.Point(120, 64);
			this.tbTime.Name = "tbTime";
			this.tbTime.Size = new System.Drawing.Size(144, 21);
			this.tbTime.TabIndex = 4;
			this.tbTime.Text = "";
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(304, 64);
			this.button2.Name = "button2";
			this.button2.TabIndex = 5;
			this.button2.Text = "ȷ��";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// lblMsg
			// 
			this.lblMsg.Location = new System.Drawing.Point(408, 64);
			this.lblMsg.Name = "lblMsg";
			this.lblMsg.Size = new System.Drawing.Size(192, 72);
			this.lblMsg.TabIndex = 6;
			// 
			// notifyIcon1
			// 
			this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
			this.notifyIcon1.Text = "notifyIcon1";
			this.notifyIcon1.Visible = true;
			this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(40, 112);
			this.button3.Name = "button3";
			this.button3.TabIndex = 8;
			this.button3.Text = "��������";
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// dataGrid1
			// 
			this.dataGrid1.DataMember = "";
			this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid1.Location = new System.Drawing.Point(40, 152);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.Size = new System.Drawing.Size(464, 240);
			this.dataGrid1.TabIndex = 9;
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(240, 112);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(88, 24);
			this.button4.TabIndex = 10;
			this.button4.Text = "���Է��ʼ�";
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// TimerSendEmail
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(624, 413);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.dataGrid1);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.lblMsg);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.tbTime);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.button1);
			this.Name = "TimerSendEmail";
			this.Text = "TimerSendEmail";
			this.Resize += new System.EventHandler(this.TimerSendEmail_Resize);
			this.Load += new System.EventHandler(this.TimerSendEmail_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void TimerSendEmail_Load(object sender, System.EventArgs e)
		{
			GetSendTime() ;
			//һ���Ӳ鿴һ��
			timer1.Interval  =  60000;  
			timer1.Start();
		}

		private void GetSendTime()
		{
			//StreamReader sr = new StreamReader(@"D:\Finance\HDSZCheckFlow\SendEmail\Config.txt") ; 

			string ConfigUrl = System.Configuration.ConfigurationSettings.AppSettings["runTimeConfig"];

			StreamReader sr = new StreamReader(ConfigUrl) ; 
			this.tbTime.Text= sr.ReadToEnd();
			sr.Close();
			//this.tbTime.Text = System.Configuration.ConfigurationSettings.AppSettings["SendEmailTime"];
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			//�������õ�ʱ��
			string text = this.tbTime.Text; 
			//StreamWriter sw = File.CreateText(@"D:\Finance\HDSZCheckFlow\SendEmail\Config.txt"); 
			string ConfigUrl = System.Configuration.ConfigurationSettings.AppSettings["runTimeConfig"];
			StreamWriter sw = File.CreateText(ConfigUrl); 

			sw.WriteLine(text); 
			sw.Close(); 

			this.lblMsg.Text = "�������";
		}

		private void MinimizedToNormal()
		{
			this.Visible = true; 
			this.WindowState = FormWindowState.Normal; 
			this.notifyIcon1.Visible = false; 
		}

		private void NormalToMinimized()
		{
			if(this.WindowState == FormWindowState.Minimized) 
			{ 
				this.Hide(); 
				this.notifyIcon1.Visible=true; 
			} 
		}

		private void TimerSendEmail_Resize(object sender, System.EventArgs e)
		{
			NormalToMinimized();	
		}

		private void notifyIcon1_DoubleClick(object sender, System.EventArgs e)
		{
			this.MinimizedToNormal();
		}

		private void timer1_Tick(object sender, System.EventArgs e)
		{
			try
			{
				//ʱ��ؼ�����

				this.lblMsg.Text = DateTime.Now.ToShortTimeString();

				//�ų���������
				if( DateTime.Now.DayOfWeek != DayOfWeek.Saturday && DateTime.Now.DayOfWeek != DayOfWeek.Sunday )
				{
					string ThisTime=DateTime.Now.ToShortTimeString();//�õ����ڵ�ʱ��

					string SendEmailTime =  System.Configuration.ConfigurationSettings.AppSettings["SendEmailTime"];//��ȡ�����ļ����Լ����õ������ַ���

					//if(ThisTime.Equals (this.tbTime.Text))    //��С�����ܵ��� lbl ֵ 

					if(ThisTime.Equals (SendEmailTime))
					{
						//
						this.lblMsg.Text = "�����Զ�ִ�з��ͳ���";

						string conn =  System.Configuration.ConfigurationSettings.AppSettings["sqlconn"];//��ȡ�����ļ����Լ����õ������ַ���
						HDSZCheckFlow.Bussiness.SendEmailTimer.SendEmail(conn);


//						HDSZCheckFlow.Bussiness.SendEmailTimer.ATestEmail();




					}
				}



			}
			catch(Exception Ex)
			{
				
				
				this.lblMsg.Text = Ex.Message ;

			}
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			//�ֶ�ִ�����ѹ���
			//׼�������ַ���

			try
			{
			
				string conn =  System.Configuration.ConfigurationSettings.AppSettings["sqlconn"];//��ȡ�����ļ����Լ����õ������ַ���

				HDSZCheckFlow.Bussiness.SendEmailTimer.SendEmail(conn);

			}
			catch(Exception Ex)
			{
				
				
				this.lblMsg.Text = Ex.Message ;

			}
		}

		private void button3_Click(object sender, System.EventArgs e)
		{
			string conn =  System.Configuration.ConfigurationSettings.AppSettings["sqlconn"];//��ȡ�����ļ����Լ����õ������ַ���

			//������ʾ��ʲô����

			DataSet ds = HDSZCheckFlow.Bussiness.SendEmailTimer.TestConn(conn);


			if(ds!=null)
			{

				this.lblMsg.Text = ds.Tables[0].Rows[0]["username"].ToString();
			}

			DataSet dss = HDSZCheckFlow.Bussiness.SendEmailTimer.GetListTest(conn);
			if(ds!=null)
			{
				this.dataGrid1.DataSource = dss;
			}

		}

		private void button4_Click(object sender, System.EventArgs e)
		{
			try
			{
				string conn =  System.Configuration.ConfigurationSettings.AppSettings["sqlconn"];//��ȡ�����ļ����Լ����õ������ַ���
				//HDSZCheckFlow.Bussiness.SendEmailTimer.SendEmailForApplyBudget( conn);
				HDSZCheckFlow.Bussiness.SendEmailTimer.ATestEmail();
				this.lblMsg.Text = "�������";
			}
			catch(Exception ex)
			{
			     this.lblMsg.Text = ex.Message ;
			}
		}
	}
}
