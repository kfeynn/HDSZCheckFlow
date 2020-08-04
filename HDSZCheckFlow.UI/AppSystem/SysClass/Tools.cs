///2008-06-23  zyq Add
using System;
using System.Web;
using System.Collections;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.ComponentModel;
using System.Diagnostics;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Configuration;
using System.Web.Security;
using System.Security.Cryptography;
//using WFNetCtrl;
using System.Drawing.Imaging;
using System.Drawing;
using System.Net;
//using System.Web.Services;

namespace HDSZCheckFlow.UI.AppSystem.SysClass
{
	/// <summary>
	/// Tools ��ժҪ˵����
	/// </summary>
	public class Tools:Page
	{
		public Tools()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}

		
		#region �������˵���alert�Ի���
		/// <summary>
		/// �������˵���alert�Ի���
		/// </summary>
		/// <param name="str_Message">��ʾ��Ϣ,���ӣ�"������������!"</param>
		/// <param name="page">Page��</param>
		public void Alert(string str_Message,Page page)
		{
			page.RegisterStartupScript("", "<script>alert('" + str_Message + "');</script>");
		}
		#endregion

		#region MessageBox ��ʾ������Ϣ
		/// <summary>
		/// MessageBox ��ʾ������Ϣ
		/// </summary>
		public static void MessageBoxAlert(string message)
		{
			message = message.Replace("\\", "\\\\");
			message = message.Replace("\n", "\\n");
			message = message.Replace("\r", "");
			System.Web.HttpContext.Current.Response.Write("<script language=\"JavaScript\" type=\"text/JavaScript\">alert(\"" + message + "\")</script>");
		}



		/// <summary>
		/// �Զ��ر�,����ת
		/// </summary>
		/// <param name="_content">��ʾ����</param>
		/// <param name="turnPage">�����Ǿ��Ե�URL</param>
		/// <returns></returns>
		public static string MessageBoxTurnPageAndAutoClose(string _content,string turnPage)
		{		
			
			string str ="";
			str += "<script language='javascript'>";
			str += "errorTurnPageBoxString = errorTurnPageBoxString.replace('[$turnPage$]','"+ turnPage +"');";
			str += "errorTurnPageBoxString = errorTurnPageBoxString.replace('[$turnPage$]','"+ turnPage +"');";
			str += "errorTurnPageBoxString = errorTurnPageBoxString.replace('[$turnPage$]','"+ turnPage +"');";
			str += "document.write(errorTurnPageBoxString);";
			str += "autoCloseAndTrunPageDiv(\"��ʾ��Ϣ\",\""+ _content +"\",\"error\",'"+ turnPage +"',5);";
			str += "</script>";
			return str;
		}

		/// <summary>
		/// ��ʾ,�رպ���ת
		/// </summary>
		/// <param name="_content">��ʾ����</param>
		/// <param name="turnPage">�����Ǿ��Ե�URL</param>
		/// <returns></returns>
		public static string MessageBoxTurnPage(string _content,string turnPage)
		{		
			string str ="";
			str += "<script language='javascript'>";
			//str += "document.write(errorTurnPageBoxString);";
			str += "errorTurnPageBoxString = errorTurnPageBoxString.replace('[$turnPage$]','"+ turnPage +"');";
			str += "errorTurnPageBoxString = errorTurnPageBoxString.replace('[$turnPage$]','"+ turnPage +"');";
			str += "document.write(errorTurnPageBoxString);";
			str += "showBox(\"��ʾ��Ϣ\",\""+ _content +"\",\"error\");";
			str += "</script>";
			return str;
		}





		/// <summary>
		/// ����
		/// </summary>
		/// <param name="_content"></param>
		/// <returns></returns>
		public static string  MessageBox(string _content)
		{			
			string str ="";
			str += "<script language='javascript'>";
			str += "document.write(errorBoxString);";
			str += "showBox('��ʾ��Ϣ',\""+ _content +"\",'error');";
			str += "</script>";						
			return str;
		}

		/// <summary>
		/// �����Զ��ر�
		/// </summary>
		/// <param name="_content"></param>
		/// <returns></returns>
		public static string MessageBoxAutoClose(string _content)
		{				
			string str ="";
			str += "<script language='javascript'>";
			str += "document.write(errorBoxString);";
			str += "autoCloseDiv(\"��ʾ��Ϣ\",\""+ _content +"\",\"error\",5);";
			str += "</script>";
			return str;
		}
	

		public static string ShowDivMsgBox(string _content)
		{			
			return "autoCloseDiv(\"��ʾ��Ϣ\",\""+_content+"\",\"error\",5);";
		}

		public static string ShowDivMsgBoxAutoClose(string _content)
		{			
			return "autoCloseDiv(\"��ʾ��Ϣ\",\"&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"+_content+"\",\"msg\",5);";
		}
		#endregion

		#region �������˵���alert�Ի���
		/// <summary>
		/// �������˵���alert�Ի���
		/// </summary>
		/// <param name="str_Ctl_Name">��ý���ؼ�Idֵ,���磺txt_Name</param>
		/// <param name="str_Message">��ʾ��Ϣ,���ӣ�"������������!"</param>
		/// <param name="page">Page��</param>
		public void Alert(string str_Ctl_Name, string str_Message, Page page)
		{
			page.RegisterStartupScript("","<script>alert('"+str_Message+"');document.forms(0)."+str_Ctl_Name+".focus(); document.forms(0)."+str_Ctl_Name+".select();</script>");
		}
		#endregion

		#region �������˵���confirm�Ի���
		/// <summary>
		/// �������˵���confirm�Ի���,�ú����и��׶�,����ŵ���Ӧ�¼������,Ŀǰû�����ƽ������
		/// </summary>
		/// <param name="str_Message">��ʾ��Ϣ,���ӣ�"���Ƿ�ȷ��ɾ��!"</param>
		/// <param name="btn">����Botton��ťIdֵ,���磺btn_Flow</param>
		/// <param name="page">Page��</param>
		public void Confirm(string str_Message,string btn,Page page)
		{
			page.RegisterStartupScript ("","<script> if (confirm('"+str_Message+"')==true){document.forms(0)."+btn+".click();}</script>");
		}



		/// <summary>
		///  �������˵���confirm�Ի���,ѯ���û�׼��ת����Ӧ����������"ȷ��"��"ȡ��"ʱ�Ĳ���
		/// </summary>
		/// <param name="str_Message">��ʾ��Ϣ�����磺"�ɹ���������,����\"ȷ��\"��ť��д����,����\"ȡ��\"�޸�����"</param>
		/// <param name="btn_Redirect_Flow">"ȷ��"��ťidֵ</param>
		/// <param name="btn_Redirect_Self">"ȡ��"��ťidֵ</param>
		/// <param name="page">Page��</param>       
		public void Confirm(string str_Message,string btn_Redirect_Flow,string btn_Redirect_Self,Page page)
		{
			page.RegisterStartupScript("","<script> if (confirm('"+str_Message+"')==true){document.forms(0)."+btn_Redirect_Flow+".click();}else{document.forms(0)."+btn_Redirect_Self+".click();}</script>");
		}

		#endregion

		#region ˢ��ĳ����
		/// <summary>
		/// ˢ��ĳ����
		/// </summary>
		/// <param name="Frame">������</param>
		/// <param name="url">����</param>
		/// <param name="page">page����</param>
		public void ReloadFrame(string Frame,string url,Page page)
		{
			page.RegisterStartupScript("","<script language=\"javascript\">parent.frames('"+Frame+"').document.location.href='"+url+"';</script>");
		}
		#endregion

		#region �������������ȡԶ���û���ʵIP��ַ�� 
		public string GetClientIP(Page page) 
		{

			//����͸�����������

			string userIP = page.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

			if (userIP == null || userIP == "")
			{

				//û�д��������,����д����������ȡ���Ǵ����������IP

				userIP = page.Request.ServerVariables["REMOTE_ADDR"];

			}

			return userIP;
		
		}
		public string GetClientIP(HttpRequest _Request) 
		{

			//����͸�����������

			string userIP = _Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

			if (userIP == null || userIP == "")
			{

				//û�д��������,����д����������ȡ���Ǵ����������IP

				userIP = _Request.ServerVariables["REMOTE_ADDR"];

			}

			return userIP;
		
		}
		#endregion
        
		#region ��ȡ���ؼ������IP��ַ
		// Put user code to initialize the page here
		/// <summary>
		///�������ܣ���ȡ���ؼ������IP��ַ
		///�����������
		///���������string cIPAddresses�����ؼ������IP��ַ
		/// </summary>
		public string GetServerIP() 
		{
			string cLocalComputerName = null;
			cLocalComputerName = Dns.GetHostName();//���ؼ������DNS������

			string cIPAddresses = "";//���ؼ������IP��ַ
			try 
			{
				System.Text.ASCIIEncoding ASCII = new System.Text.ASCIIEncoding();
  
				IPHostEntry heLocalComputer = Dns.Resolve(cLocalComputerName);

				foreach (IPAddress curAdd in heLocalComputer.AddressList) 
				{
					Byte[] bytes = curAdd.GetAddressBytes();
					for (int i = 0; i < bytes.Length; i++) 
					{
						cIPAddresses += bytes[i].ToString() + ".";
					}                          
				}
				cIPAddresses = cIPAddresses.Substring(0, cIPAddresses.Length - 1);
			}
			catch (Exception e) 
			{
				string cErrMsg = e.ToString();
				cIPAddresses = "";
			}
			return "http://"+cIPAddresses;
		}
		#endregion

		#region ���14ʱ��+������λ��ʱ�������

		public string GetRandom(int int_Count)
		{
			string str_RV="1";
			for (int i=0;i<int_Count-2;i++)
			{
				str_RV=str_RV+"0";
			}
			Random r=new Random();
			str_RV=r.Next(Convert.ToInt32 (str_RV)).ToString();
			int int_Count1=int_Count-str_RV.Length;
			if (int_Count1>0)
			{
				for (int i=0;i<int_Count1;i++)
				{
					str_RV=str_RV+"0";
				}
			}
			return str_RV;
		}
		#endregion

		#region  ���뺺��,�õ�ƴ��
		/// <summary>
		/// ���ƴ��
		/// </summary>
		/// <param name="str_Spell">����</param>
		/// <returns></returns>
		public string GetSpellByChinese(string str_Spell)
		{

			Hashtable t=hb();

			byte[] b=System.Text.Encoding.Default.GetBytes(str_Spell);
			int p;
			StringBuilder ret=new StringBuilder();
			for(int i=0;i< b.Length;i++)
			{
				p=(int)b[i];
				if(p>160)
				{
					p=p*256+b[++i]-65536;
					ret.Append(g(t,p));
				}
				else
				{
					ret.Append((char)p);
				}
			}
			t.Clear();
			return ret.ToString();
		}
		private string g(Hashtable ht,int num)
		{
			if(num < -20319||num > -10247)
				return "";
			while(!ht.ContainsKey(num))
				num--;
			return ht[num].ToString();
		}

		private Hashtable hb() 
		{
			Hashtable ht=new Hashtable(); 
			ht.Add(-20319,"a"); 
			ht.Add(-20317,"ai");ht.Add(-20304,"an"); ht.Add(-20295,"ang"); 
			ht.Add(-20292,"ao");ht.Add(-20283,"ba"); ht.Add(-20265,"bai"); 
			ht.Add(-20257,"ban");ht.Add(-20242,"bang"); ht.Add(-20230,"bao"); 
			ht.Add(-20051,"bei"); ht.Add(-20036,"ben"); ht.Add(-20032,"beng"); 
			ht.Add(-20026,"bi"); ht.Add(-20002,"bian"); ht.Add(-19990,"biao"); 
			ht.Add(-19986,"bie"); ht.Add(-19982,"bin"); ht.Add(-19976,"bing"); 
			ht.Add(-19805,"bo"); ht.Add(-19784,"bu"); ht.Add(-19775,"ca"); 
			ht.Add(-19774,"cai"); ht.Add(-19763,"can"); ht.Add(-19756,"cang"); 
			ht.Add(-19751,"cao"); ht.Add(-19746,"ce"); ht.Add(-19741,"ceng"); 
			ht.Add(-19739,"cha"); ht.Add(-19728,"chai"); ht.Add(-19725,"chan"); 
			ht.Add(-19715,"chang"); ht.Add(-19540,"chao"); ht.Add(-19531,"che"); 
			ht.Add(-19525,"chen"); ht.Add(-19515,"cheng"); ht.Add(-19500,"chi"); 
			ht.Add(-19484,"chong"); ht.Add(-19479,"chou"); ht.Add(-19467,"chu"); 
			ht.Add(-19289,"chuai"); ht.Add(-19288,"chuan"); ht.Add(-19281,"chuang"); 
			ht.Add(-19275,"chui"); ht.Add(-19270,"chun"); ht.Add(-19263,"chuo"); 
			ht.Add(-19261,"ci"); ht.Add(-19249,"cong"); ht.Add(-19243,"cou"); 
			ht.Add(-19242,"cu"); ht.Add(-19238,"cuan"); ht.Add(-19235,"cui"); 
			ht.Add(-19227,"cun"); ht.Add(-19224,"cuo"); ht.Add(-19218,"da"); 
			ht.Add(-19212,"dai"); ht.Add(-19038,"dan"); ht.Add(-19023,"dang"); 
			ht.Add(-19018,"dao"); ht.Add(-19006,"de"); ht.Add(-19003,"deng"); 
			ht.Add(-18996,"di"); ht.Add(-18977,"dian"); ht.Add(-18961,"diao"); 
			ht.Add(-18952,"die"); ht.Add(-18783,"ding"); ht.Add(-18774,"diu"); 
			ht.Add(-18773,"dong"); ht.Add(-18763,"dou"); ht.Add(-18756,"du"); 
			ht.Add(-18741,"duan"); ht.Add(-18735,"dui"); ht.Add(-18731,"dun"); 
			ht.Add(-18722,"duo"); ht.Add(-18710,"e"); ht.Add(-18697,"en"); 
			ht.Add(-18696,"er"); ht.Add(-18526,"fa"); ht.Add(-18518,"fan"); 
			ht.Add(-18501,"fang"); ht.Add(-18490,"fei"); ht.Add(-18478,"fen"); 
			ht.Add(-18463,"feng"); ht.Add(-18448,"fo"); ht.Add(-18447,"fou"); 
			ht.Add(-18446,"fu"); ht.Add(-18239,"ga"); ht.Add(-18237,"gai"); 
			ht.Add(-18231,"gan"); ht.Add(-18220,"gang"); ht.Add(-18211,"gao"); 
			ht.Add(-18201,"ge"); ht.Add(-18184,"gei"); ht.Add(-18183,"gen"); 
			ht.Add(-18181,"geng"); ht.Add(-18012,"gong"); ht.Add(-17997,"gou"); 
			ht.Add(-17988,"gu"); ht.Add(-17970,"gua"); ht.Add(-17964,"guai"); 
			ht.Add(-17961,"guan"); ht.Add(-17950,"guang"); ht.Add(-17947,"gui"); 
			ht.Add(-17931,"gun"); ht.Add(-17928,"guo"); ht.Add(-17922,"ha"); 
			ht.Add(-17759,"hai"); ht.Add(-17752,"han"); ht.Add(-17733,"hang"); 
			ht.Add(-17730,"hao"); ht.Add(-17721,"he"); ht.Add(-17703,"hei"); 
			ht.Add(-17701,"hen"); ht.Add(-17697,"heng"); ht.Add(-17692,"hong"); 
			ht.Add(-17683,"hou"); ht.Add(-17676,"hu"); ht.Add(-17496,"hua"); 
			ht.Add(-17487,"huai"); ht.Add(-17482,"huan"); ht.Add(-17468,"huang"); 
			ht.Add(-17454,"hui"); ht.Add(-17433,"hun"); ht.Add(-17427,"huo"); 
			ht.Add(-17417,"ji"); ht.Add(-17202,"jia"); ht.Add(-17185,"jian"); 
			ht.Add(-16983,"jiang"); ht.Add(-16970,"jiao"); ht.Add(-16942,"jie"); 
			ht.Add(-16915,"jin"); ht.Add(-16733,"jing"); ht.Add(-16708,"jiong"); 
			ht.Add(-16706,"jiu"); ht.Add(-16689,"ju"); ht.Add(-16664,"juan"); 
			ht.Add(-16657,"jue"); ht.Add(-16647,"jun"); ht.Add(-16474,"ka"); 
			ht.Add(-16470,"kai"); ht.Add(-16465,"kan"); ht.Add(-16459,"kang"); 
			ht.Add(-16452,"kao"); ht.Add(-16448,"ke"); ht.Add(-16433,"ken"); 
			ht.Add(-16429,"keng"); ht.Add(-16427,"kong"); ht.Add(-16423,"kou"); 
			ht.Add(-16419,"ku"); ht.Add(-16412,"kua"); ht.Add(-16407,"kuai"); 
			ht.Add(-16403,"kuan"); ht.Add(-16401,"kuang"); ht.Add(-16393,"kui"); 
			ht.Add(-16220,"kun"); ht.Add(-16216,"kuo"); ht.Add(-16212,"la"); 
			ht.Add(-16205,"lai"); ht.Add(-16202,"lan"); ht.Add(-16187,"lang"); 
			ht.Add(-16180,"lao"); ht.Add(-16171,"le"); ht.Add(-16169,"lei"); 
			ht.Add(-16158,"leng"); ht.Add(-16155,"li"); ht.Add(-15959,"lia"); 
			ht.Add(-15958,"lian"); ht.Add(-15944,"liang"); ht.Add(-15933,"liao"); 
			ht.Add(-15920,"lie"); ht.Add(-15915,"lin"); ht.Add(-15903,"ling"); 
			ht.Add(-15889,"liu"); ht.Add(-15878,"int"); ht.Add(-15707,"lou");
			ht.Add(-15701,"lu");ht.Add(-15681,"lv");ht.Add(-15667,"luan");
			ht.Add(-15661,"lue");ht.Add(-15659,"lun");ht.Add(-15652,"luo");
			ht.Add(-15640,"ma");ht.Add(-15631,"mai");ht.Add(-15625,"man");
			ht.Add(-15454,"mang");ht.Add(-15448,"mao");ht.Add(-15436,"me");
			ht.Add(-15435,"mei");ht.Add(-15419,"men");ht.Add(-15416,"meng");
			ht.Add(-15408,"mi");ht.Add(-15394,"mian");ht.Add(-15385,"miao");
			ht.Add(-15377,"mie");ht.Add(-15375,"min");ht.Add(-15369,"ming");
			ht.Add(-15363,"miu");ht.Add(-15362,"mo");ht.Add(-15183,"mou");
			ht.Add(-15180,"mu");ht.Add(-15165,"na");ht.Add(-15158,"nai");
			ht.Add(-15153,"nan");ht.Add(-15150,"nang");ht.Add(-15149,"nao");
			ht.Add(-15144,"ne");ht.Add(-15143,"nei");ht.Add(-15141,"nen");
			ht.Add(-15140,"neng");ht.Add(-15139,"ni");ht.Add(-15128,"nian");
			ht.Add(-15121,"niang");ht.Add(-15119,"niao");ht.Add(-15117,"nie");
			ht.Add(-15110,"nin");ht.Add(-15109,"ning");ht.Add(-14941,"niu");
			ht.Add(-14937,"nong");ht.Add(-14933,"nu");ht.Add(-14930,"nv");
			ht.Add(-14929,"nuan");ht.Add(-14928,"nue");ht.Add(-14926,"nuo");
			ht.Add(-14922,"o");ht.Add(-14921,"ou");ht.Add(-14914,"pa");
			ht.Add(-14908,"pai");ht.Add(-14902,"pan");ht.Add(-14894,"pang");
			ht.Add(-14889,"pao");ht.Add(-14882,"pei");ht.Add(-14873,"pen");
			ht.Add(-14871,"peng");ht.Add(-14857,"pi");ht.Add(-14678,"pian");
			ht.Add(-14674,"piao");ht.Add(-14670,"pie");ht.Add(-14668,"pin");
			ht.Add(-14663,"ping");ht.Add(-14654,"po");ht.Add(-14645,"pu");
			ht.Add(-14630,"qi");ht.Add(-14594,"qia");ht.Add(-14429,"qian");
			ht.Add(-14407,"qiang");ht.Add(-14399,"qiao");ht.Add(-14384,"qie");
			ht.Add(-14379,"qin");ht.Add(-14368,"qing");ht.Add(-14355,"qiong");
			ht.Add(-14353,"qiu");ht.Add(-14345,"qu");ht.Add(-14170,"quan");
			ht.Add(-14159,"que");ht.Add(-14151,"qun");ht.Add(-14149,"ran");
			ht.Add(-14145,"rang");ht.Add(-14140,"rao");ht.Add(-14137,"re");
			ht.Add(-14135,"ren");ht.Add(-14125,"reng");ht.Add(-14123,"ri");
			ht.Add(-14122,"rong");ht.Add(-14112,"rou");ht.Add(-14109,"ru");
			ht.Add(-14099,"ruan");ht.Add(-14097,"rui");ht.Add(-14094,"run");
			ht.Add(-14092,"ruo");ht.Add(-14090,"sa");ht.Add(-14087,"sai");
			ht.Add(-14083,"san");ht.Add(-13917,"sang");ht.Add(-13914,"sao");
			ht.Add(-13910,"se");ht.Add(-13907,"sen");ht.Add(-13906,"seng");
			ht.Add(-13905,"sha");ht.Add(-13896,"shai");ht.Add(-13894,"shan");
			ht.Add(-13878,"shang");ht.Add(-13870,"shao");ht.Add(-13859,"she");
			ht.Add(-13847,"shen");ht.Add(-13831,"sheng");ht.Add(-13658,"shi");
			ht.Add(-13611,"shou");ht.Add(-13601,"shu");ht.Add(-13406,"shua");
			ht.Add(-13404,"shuai");ht.Add(-13400,"shuan");ht.Add(-13398,"shuang");
			ht.Add(-13395,"shui");ht.Add(-13391,"shun");ht.Add(-13387,"shuo");
			ht.Add(-13383,"si");ht.Add(-13367,"song");ht.Add(-13359,"sou");
			ht.Add(-13356,"su");ht.Add(-13343,"suan");ht.Add(-13340,"sui");
			ht.Add(-13329,"sun");ht.Add(-13326,"suo");ht.Add(-13318,"ta");
			ht.Add(-13147,"tai");ht.Add(-13138,"tan");ht.Add(-13120,"tang");
			ht.Add(-13107,"tao");ht.Add(-13096,"te");ht.Add(-13095,"teng");
			ht.Add(-13091,"ti");ht.Add(-13076,"tian");ht.Add(-13068,"tiao");
			ht.Add(-13063,"tie");ht.Add(-13060,"ting");ht.Add(-12888,"tong");
			ht.Add(-12875,"tou");ht.Add(-12871,"tu");ht.Add(-12860,"tuan");
			ht.Add(-12858,"tui");ht.Add(-12852,"tun");ht.Add(-12849,"tuo");
			ht.Add(-12838,"wa");ht.Add(-12831,"wai");ht.Add(-12829,"wan");
			ht.Add(-12812,"wang");ht.Add(-12802,"wei");ht.Add(-12607,"wen");
			ht.Add(-12597,"weng");ht.Add(-12594,"wo");ht.Add(-12585,"wu");
			ht.Add(-12556,"xi");ht.Add(-12359,"xia");ht.Add(-12346,"xian");
			ht.Add(-12320,"xiang");ht.Add(-12300,"xiao");ht.Add(-12120,"xie");
			ht.Add(-12099,"xin");ht.Add(-12089,"xing");ht.Add(-12074,"xiong");
			ht.Add(-12067,"xiu");ht.Add(-12058,"xu");ht.Add(-12039,"xuan");
			ht.Add(-11867,"xue");ht.Add(-11861,"xun");ht.Add(-11847,"ya");
			ht.Add(-11831,"yan");ht.Add(-11798,"yang");ht.Add(-11781,"yao");
			ht.Add(-11604,"ye");ht.Add(-11589,"yi");ht.Add(-11536,"yin");
			ht.Add(-11358,"ying");ht.Add(-11340,"yo");ht.Add(-11339,"yong");
			ht.Add(-11324,"you");ht.Add(-11303,"yu");ht.Add(-11097,"yuan");
			ht.Add(-11077,"yue");ht.Add(-11067,"yun");ht.Add(-11055,"za");
			ht.Add(-11052,"zai");ht.Add(-11045,"zan");ht.Add(-11041,"zang");
			ht.Add(-11038,"zao");ht.Add(-11024,"ze");ht.Add(-11020,"zei");
			ht.Add(-11019,"zen");ht.Add(-11018,"zeng");ht.Add(-11014,"zha");
			ht.Add(-10838,"zhai");ht.Add(-10832,"zhan");ht.Add(-10815,"zhang");
			ht.Add(-10800,"zhao");ht.Add(-10790,"zhe");ht.Add(-10780,"zhen");
			ht.Add(-10764,"zheng");ht.Add(-10587,"zhi");ht.Add(-10544,"zhong");
			ht.Add(-10533,"zhou");ht.Add(-10519,"zhu");ht.Add(-10331,"zhua");
			ht.Add(-10329,"zhuai");ht.Add(-10328,"zhuan");ht.Add(-10322,"zhuang");
			ht.Add(-10315,"zhui");ht.Add(-10309,"zhun");ht.Add(-10307,"zhuo");
			ht.Add(-10296,"zi");ht.Add(-10281,"zong");ht.Add(-10274,"zou");
			ht.Add(-10270,"zu");ht.Add(-10262,"zuan");ht.Add(-10260,"zui");
			ht.Add(-10256,"zun");ht.Add(-10254,"zuo");ht.Add(-10247,"zz");
			return ht;
		}

		#endregion

		#region ���CheckBoxLis,RadioButtonList,ListBox�ؼ�����ѡ��ֵ���Զ��Ÿ�,��ʽ��"2,3,4"
		/// <summary>
		/// ���CheckBoxLis,RadioButtonList,ListBox�ؼ�����ѡ��ֵ���Զ��Ÿ�,��ʽ��"2,3,4"
		/// </summary>
		/// <param name="listctrl">CheckBoxLis,RadioButtonList,ListBox�ؼ�</param>
		/// <param name="type">���ͣ�������Value����Textֵ</param>
		/// <returns></returns>
		public string GetCtrlSelValue(Control listctrl)
		{
			string str_Value = "";

			//������CheckBoxList������
			if (listctrl is CheckBoxList)
			{
				for (int i = 0; i < ((CheckBoxList)listctrl).Items.Count; i++)
				{
					if (((CheckBoxList)listctrl).Items[i].Selected == true)
					{
						str_Value = str_Value + ((CheckBoxList)listctrl).Items[i].Value + ",";
					}
				}
				if (str_Value != "")
				{
					str_Value = str_Value.Substring(0, str_Value.Length - 1);
				}
			}
			//������RadioButtonList������
			if (listctrl is RadioButtonList)
			{
				for (int i = 0; i < ((RadioButtonList)listctrl).Items.Count; i++)
				{
					if (((RadioButtonList)listctrl).Items[i].Selected == true)
					{
						str_Value = ((RadioButtonList)listctrl).Items[i].Value;
					}
				}

			}
			//������ListBox������
			if (listctrl is ListBox)
			{

				for (int i = 0; i < ((ListBox)listctrl).Items.Count; i++)
				{
					if (((ListBox)listctrl).Items[i].Selected == true)
					{
						str_Value = str_Value + ((ListBox)listctrl).Items[i].Value + ",";
					}
				}
				if (str_Value != "")
				{
					str_Value = str_Value.Substring(0, str_Value.Length - 1);
				}
			}
			return str_Value;
		}
		#endregion

		#region ����CheckBoxLis,RadioButtonList,ListBox�ؼ�����ѡ��ֵ���Զ��Ÿ�,��ʽ��"2,3,4"
		/// <summary>
		/// ����CheckBoxLis,RadioButtonList,ListBox�ؼ�����ѡ��ֵ
		/// </summary>
		/// <param name="strValueField"></param>
		/// <param name="id"></param>
		/// <param name="name"></param>
		/// <param name="lst"></param>
		/// <param name="listctrl"></param>
		public void SetCtrl(string strValueField, string id, string name, IList lst, Control listctrl)
		{
			BindCtrl(id, name, lst, listctrl);

			//������DropDownList������
			if (listctrl is DropDownList)
			{
				((DropDownList)listctrl).Items[0].Selected = false;
				for (int i = 0; i < ((DropDownList)listctrl).Items.Count; i++)
				{
					if ("," + strValueField + "," == "," + ((DropDownList)listctrl).Items[i].Value + ",")
					{
						((DropDownList)listctrl).Items[i].Selected = true;
						break;
					}
				}
			}
			//������CheckBoxList������
			if (listctrl is CheckBoxList)
			{
				for (int i = 0; i < ((CheckBoxList)listctrl).Items.Count; i++)
				{
					if (("," + strValueField + ",").IndexOf("," + ((CheckBoxList)listctrl).Items[i].Value + ",") != -1)
					{
						((CheckBoxList)listctrl).Items[i].Selected = true;
					}
				}
			}
			//������RadioButtonList������
			if (listctrl is RadioButtonList)
			{
				((RadioButtonList)listctrl).Items[0].Selected = false;
				for (int i = 0; i < ((RadioButtonList)listctrl).Items.Count; i++)
				{
					if ("," + strValueField + "," == "," + ((RadioButtonList)listctrl).Items[i].Value + ",")
					{
						((RadioButtonList)listctrl).Items[i].Selected = true;
						break;
					}
				}
			}
			//������c������
			if (listctrl is ListBox)
			{
				for (int i = 0; i < ((ListBox)listctrl).Items.Count; i++)
				{
					if (("," + strValueField + ",").IndexOf("," + ((ListBox)listctrl).Items[i].Value + ",") != -1)
					{
						((ListBox)listctrl).Items[i].Selected = true;
					}
				}
			}
		}
		public void SetCtrl(string strValueField, string val, string txt, Control listctrl)
		{
			string[] arr_Val = val.Split(',');
			string[] arr_Txt = txt.Split(',');

			//������DropDownList������
			if (listctrl is DropDownList)
			{
				for (int i = 0; i < arr_Val.Length; i++)
				{
					if (strValueField == arr_Val[i].ToString())
					{
						ListItem it = new ListItem(arr_Txt[i], arr_Val[i]);
						((DropDownList)listctrl).Items.Insert(0, it);
					}
					else
					{
						ListItem it = new ListItem(arr_Txt[i], arr_Val[i]);
						((DropDownList)listctrl).Items.Add(it);
					}
				}
			}
			//������CheckBoxList������
			if (listctrl is CheckBoxList)
			{
				for (int i = 0; i < arr_Val.Length; i++)
				{
					if (strValueField == arr_Val.ToString())
					{
						ListItem it = new ListItem(arr_Txt[i], arr_Val[i]);
						it.Selected = true;
						((CheckBoxList)listctrl).Items.Add(it);
					}
				}
			}

			//������RadioButtonList������
			if (listctrl is RadioButtonList)
			{
				for (int i = 0; i < arr_Val.Length; i++)
				{
					if (strValueField == arr_Val.ToString())
					{
						ListItem it = new ListItem(arr_Txt[i], arr_Val[i]);
						it.Selected = true;
						((RadioButtonList)listctrl).Items.Add(it);
					}
				}
			}
			//������ListBox������
			if (listctrl is ListBox)
			{
				for (int i = 0; i < arr_Val.Length; i++)
				{
					if (strValueField == arr_Val.ToString())
					{
						ListItem it = new ListItem(arr_Txt[i], arr_Val[i]);
						it.Selected = true;
						((ListBox)listctrl).Items.Add(it);
					}
				}
			}


		}

		/// <summary>
		/// ��DropDownList�ȿؼ�
		/// </summary>
		/// <param name="id">�ؼ�Valueֵ�ֶ�</param>
		/// <param name="name">�ؼ�Textֵ�ֶ�</param>
		/// <param name="lst">IList����Դ</param>
		/// <param name="listctrl">�ؼ�Id</param>
		public void BindCtrl(string id, string name, IList lst, Control listctrl)
		{
			//������DropDownList������
			if (listctrl is DropDownList)
			{
				((DropDownList)listctrl).DataValueField = id;
				((DropDownList)listctrl).DataTextField = name;
				((DropDownList)listctrl).DataSource = lst;
				((DropDownList)listctrl).DataBind();
			}
			if (listctrl is CheckBoxList)
			{
				((CheckBoxList)listctrl).DataValueField = id;
				((CheckBoxList)listctrl).DataTextField = name;
				((CheckBoxList)listctrl).DataSource = lst;
				((CheckBoxList)listctrl).DataBind();
			}
		}

		public void BindCtrl(string DefaultValue, string DefaultText, string id, string name, IList lst, Control listctrl)
		{
			//������DropDownList������
			if (listctrl is DropDownList)
			{
				((DropDownList)listctrl).DataValueField = id;
				((DropDownList)listctrl).DataTextField = name;
				((DropDownList)listctrl).DataSource = lst;
				((DropDownList)listctrl).DataBind();
				ListItem it = new ListItem(DefaultText, DefaultValue);
				it.Selected = true;
				((DropDownList)listctrl).Items.Insert(0, it);
			}

		}
		public void BindCtrl(IList lst, Control ctl_Listctl)
		{
			if (ctl_Listctl is Repeater)
			{
				((Repeater)ctl_Listctl).DataSource = lst;
				((Repeater)ctl_Listctl).DataBind();
			}
			if (ctl_Listctl is DataList)
			{
				((DataList)ctl_Listctl).DataSource = lst;
				((DataList)ctl_Listctl).DataBind();
			}
			if (ctl_Listctl is DataGrid)
			{
				((DataGrid)ctl_Listctl).DataSource = lst;
				((DataGrid)ctl_Listctl).DataBind();
			}
		}
		#endregion

		#region �ж�EMail�ĺϷ���-���Email(��","��";"����)
		/// <summary>
		/// ����һ���ַ���,�ж��ǲ��ǺϷ���Email,����Ƕ��Email����","����";"����
		/// </summary>
		/// <param name="Mail_More">string,Email�ַ��� </param>
		/// <returns>bool</returns>
		public static bool IsMailMore(string Mail_More)
		{
			bool Validate_result = true;
			char[] Partition = new char[] { ',', ';' };
			string[] Invite_Mail = Mail_More.Split(Partition);
			for (int i = 0; i < Invite_Mail.Length; i++)
			{
				if (Invite_Mail[i].Length > 0)
				{

					Validate_result = Regex.IsMatch(Invite_Mail[i].Trim(), @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");


					if (Validate_result == false)
					{
						return false;
					}
				}

			}
			return true;

		}
		#endregion

		#region �ж�EMail�ĺϷ���-����Email

		/// <summary>
		/// ����һ���ַ���,�ж��ǲ��ǺϷ���Email,����ֻ����֤һ��EMail
		/// </summary>
		/// <param name="Mail_One">string,Email�ַ���</param>
		/// <returns>bool</returns>
		public static bool IsMailOne(string Mail_One)
		{
			bool Validate_result = true;

			Validate_result = Regex.IsMatch(Mail_One.Trim(), @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");

			if (!Validate_result)
			{

				return false;
			}
			else
			{
				return true;
			}

		}

		#endregion

		#region ���������Ƿ�Ϊ����

		/// <summary>
		/// ���������Ƿ�Ϊ����
		/// </summary>
		/// <param name="Mail_One">�����ַ���</param>
		/// <returns>bool</returns>
		public static bool IsNumeric(string num)
		{
			bool Validate_result = true;

			Validate_result = Regex.IsMatch(num.Trim(), @"^(-?[0-9]*[.]*[0-9]{0,3})$");

			if (!Validate_result)
			{

				return false;
			}
			else
			{
				return true;
			}

		}

		#endregion

		#region   ȡ��Html�е��ı�
		/// <summary>
		/// ȡ��Html�е��ı�
		/// </summary>
		/// <param name="strHtml"></param>
		/// <returns></returns>
		public static string StripHTML(string strHtml)
		{
			//All the regular expression for matching html, javascript, style elements and others.
			string[] aryRegex ={@"<%=[\w\W]*?%>",   @"<script[\w\W]*?</script>",    @"<style[\w\W]*?</style>",  @"<[/]?[\w\W]*?>",  @"([\r\n])[\s]+",
								   @"&(nbsp|#160);",   @"&(iexcl|#161);",              @"&(cent|#162);",           @"&(pound|#163);",  @"&(copy|#169);",
								   @"&#(\d+);",        @"-->",                         @"<!--.*\n"};
			//Corresponding replacment to the regular expressions.
			string[] aryReplacment = { "", "", "", "", "", " ", "\xa1", "\xa2", "\xa3", "\xa9", "", "\r\n", "" };
			string strStripped = strHtml;
			//Loop to replacing.
			for (int i = 0; i < aryRegex.Length; i++)
			{
				Regex regex = new Regex(aryRegex[i], RegexOptions.IgnoreCase);
				strStripped = regex.Replace(strStripped, aryReplacment[i]);
			}
			//Replace "\r\n" to an empty character.
			strStripped.Replace("\r\n", "");
			//Return stripped string.
			return strStripped;
		}
		#endregion		

		#region ȡ���ļ� UTF-8
		/// <summary>
		/// �ļ���ȫ��(·��),UTF-8
		/// </summary>
		/// <param name="PTemplate_index"></param>
		public static string  GetUTF8TextbyFile(string File)
		{
			//string PTemplate_index=EN_MTemplatePath + "Template_index.html";
			StreamReader sr=new StreamReader(File,System.Text.Encoding.UTF8 );
			string str=sr.ReadToEnd ();
			sr.Close ();
			return str;

		}
		#endregion	

		#region д���ļ� ,UTF-8
		/// <summary>
		/// д���ļ�,UTF-8
		/// </summary>
		/// <param name="str">д����ı�</param>
		/// <param name="pathFile">�ļ����ļ���</param>
		public static void WriteUTF8ByStringAndFile(string str,string pathFile)
		{			
			StreamWriter sr = new StreamWriter (pathFile,false,System.Text.Encoding.UTF8,400);
			sr.Write (str);
			sr.Close();
		}
		#endregion					

		#region ����һ����HTML����ķ�ҳ��ʽ���ַ�����
		/// <summary>
		/// ����һ����HTML����ķ�ҳ��ʽ���ַ�����
		/// </summary>
		/// <param name="total">�ܼ�¼��</param>
		/// <param name="per">ÿҳ��¼��</param>
		/// <param name="page">��ǰҳ��</param>
		/// <param name="query_string">Url����</param>
		/// <returns>����һ����HTML����ķ�ҳ��ʽ���ַ�����</returns>
		public string Pagination(int total,int per,int page,string query_string)
		{
			int allpage=0; 
			int next=0; 
			int pre=0; 
			int startcount=0; 
			int endcount=0; 
			string pagestr=""; 

			if(page<1){page=1;} 
			
			//������ҳ�� 
			if (per != 0) 
			{ 
				allpage = (total / per); 
				allpage = ((total % per) != 0 ? allpage + 1 : allpage); 
				allpage = (allpage == 0 ? 1 : allpage); 
			} 

			if(allpage == 1)//ֻ��һҳ����ʾ
			{
				return "";
			}

			next=page+1; 
			pre=page-1; 
			startcount=(page+5)>allpage?allpage-9:page-4;//�м�ҳ��ʼ��� 
			
			//�м�ҳ��ֹ��� 
			endcount = page<5 ? 10 : page+5; 
			if(startcount<1) {startcount=1;} //Ϊ�˱��������ʱ���������,�������С��1�ʹ����1��ʼ 
			 
			if(allpage<endcount){endcount=allpage;}//ҳ��+5�Ŀ����Ծͻ�������������Ŵ�����ҳ��,��ô��Ҫ���������ҳ����֮�� 
			//pagestr="<span>��"+ allpage +"ҳ</span>"; 

			
			
			//pagestr += "<span class=Page_s_box>";

			pagestr += "<UL class='PagNum'>";
			//��ʾ��ҳ
			//pagestr += page>1 ? "<LI><a class='backnext' href=\""+ query_string + "?page=1\">��ҳ</a></LI><LI><a class='backnext' href=\""+ query_string +"?page="+ pre  +"\">��һҳ</a></LI>": ""; 
			
			//����ʾ��ҳ
			pagestr += page>1 ? "<LI><a class='backnext' href=\""+ query_string +"?page="+ pre  +"\">��һҳ</a></LI>": ""; 
			
			//�м�ҳ����,�������ʱ�临�Ӷ�,��С�ռ临�Ӷ� 
			for(int i=startcount;i<=endcount;i++) 
			{  
				//pagestr += page==i ? "<LI class='now'>"+i : "</LI><LI  class='backnext'><a href=\""+ query_string +"?page="+ i +"\">"+ i +"</a></LI>"; 
				if(page==i)
				{
					pagestr +="<LI class='now'><a href='#'>"+ i.ToString () +"</a></LI>";
				}
				else
				{
					pagestr +="<LI  class='backnext'><a href=\""+ query_string +"?page="+ i +"\">"+ i +"</a></LI>";
				}
			} 

			////��ʾĩҳ
			//pagestr += page!=allpage ? "<LI><a class='backnext' href=\""+ query_string +"?page="+ next +"\">��һҳ</a></LI><LI><a class='backnext' href=\""+  query_string +"?page="+ allpage+"\">ĩҳ</a></LI>" : ""; 
			//����ʾĩҳ
			pagestr += page!=allpage ? "<LI><a class='backnext' href=\""+ query_string +"?page="+ next +"\">��һҳ</a></LI>" : ""; 

			pagestr += "</UL>";
			//pagestr += "</span>";

			return pagestr;  
		}


		

		/// <summary>
		/// ����һ����HTML����ķ�ҳ��ʽ���ַ�����--������
		/// </summary>
		/// <param name="total">�ܼ�¼��</param>
		/// <param name="per">ÿҳ��¼��</param>
		/// <param name="page">��ǰҳ��</param>
		/// <param name="query_string">Url����</param>
		/// <param name="_where">����</param> 
		/// <returns>����һ����HTML����ķ�ҳ��ʽ���ַ�����</returns>
		public string Pagination(int total,int per,int page,string pageURL,string _where)
		{
			if(_where.Length >0)
			{
				pageURL = pageURL + "?" +_where + "&";
			}
			else
			{
				pageURL = pageURL + "?" ;
			}

			int allpage=0; 
			int next=0; 
			int pre=0; 
			int startcount=0; 
			int endcount=0; 
			string pagestr=""; 

			if(page<1)
			{page=1;} 
			
			//������ҳ�� 
			if (per != 0) 
			{ 
				allpage = (total / per); 
				allpage = ((total % per) != 0 ? allpage + 1 : allpage); 
				allpage = (allpage == 0 ? 1 : allpage); 
			} 

			if(allpage == 1)//ֻ��һҳ����ʾ
			{
				return "";
			}
			next=page+1; 
			pre=page-1; 
			startcount=(page+5)>allpage?allpage-9:page-4;//�м�ҳ��ʼ��� 
			
			//�м�ҳ��ֹ��� 
			endcount = page<5 ? 10 : page+5; 
			if(startcount<1) {startcount=1;} //Ϊ�˱��������ʱ���������,�������С��1�ʹ����1��ʼ 
			 
			if(allpage<endcount){endcount=allpage;}//ҳ��+5�Ŀ����Ծͻ�������������Ŵ�����ҳ��,��ô��Ҫ���������ҳ����֮�� 
			//pagestr="<span>��"+ allpage +"ҳ</span>"; 

			//pagestr += "<span class=Page_s_box>";

			pagestr += "<UL class='PagNum'>";
			//��ʾ��ҳ
			//pagestr += page>1 ? "<LI><a class='backnext' href=\""+  pageURL  + "page=1\">��ҳ</a></LI><LI><a class='backnext' href=\""+  pageURL  +"page="+ pre  +"\">��һҳ</a></LI>": ""; 
			
			//����ʾ��ҳ
			pagestr += page>1 ? "<LI><a class='backnext' href=\""+  pageURL  +"page="+ pre  +"\">��һҳ</a></LI>": ""; 
			
			//�м�ҳ����,�������ʱ�临�Ӷ�,��С�ռ临�Ӷ� 
			for(int i=startcount;i<=endcount;i++) 
			{  
				//pagestr += page==i ? "<LI class='now'>"+i : "</LI><LI  class='backnext'><a href=\""+  pageURL  +"page="+ i +"\">"+ i +"</a></LI>"; 
				if(page==i)
				{
					pagestr +="<LI class='now'><a href='#'>"+ i.ToString () +"</a></LI>";
				}
				else
				{
					pagestr +="<LI  class='backnext'><a href=\""+  pageURL  +"page="+ i +"\">"+ i +"</a></LI>";
				}
			} 

			////��ʾĩҳ
			//pagestr += page!=allpage ? "<LI><a class='backnext' href=\""+  pageURL  +"page="+ next +"\">��һҳ</a></LI><LI><a class='backnext' href=\""+   pageURL  +"page="+ allpage+"\">ĩҳ</a></LI>" : ""; 
			
			//����ʾĩҳ
			pagestr += page!=allpage ? "<LI><a class='backnext' href=\""+  pageURL  +"page="+ next +"\">��һҳ</a></LI>" : ""; 

			pagestr += "</UL>";
			//	pagestr += "</span>";

			return pagestr; 
		}

		#endregion

		#region �����ַ�����һ�������ַ�
		/// <summary>
		/// �����ַ�����һ�������ַ�
		/// </summary>
		/// <param name="str">�ַ���</param>
		/// <param name="num">����</param>
		/// <returns></returns>
		public static string GetStrByNumber(string str,int num)
		{
			if(str.Length <= num)
			{
				return str;
			}
			else
			{
				return str.Substring(0,num-1)+"...";
			}
		}


		/// <summary>
		/// �����ַ�����һ�������ַ�
		/// </summary>
		/// <param name="str">�ַ���</param>
		/// <param name="num">����</param>
		/// <returns></returns>
		public static string GetStrByNumber(object obj,int num)
		{
			string str=obj.ToString ();
			if(str.Length <= num)
			{
				return str;
			}
			else
			{
				return str.Substring(0,num-1)+"...";
			}
		}
		#endregion

		#region SQL����������ַ��Ĺ��˴���
		/// <summary>
		///  Ҫ���˵��ַ���
		/// </summary>
		/// <param name="str"></param>
		/// <returns>���˺��.</returns>
		public static string CheckStr(string str,ref string msg)
		{
			string Fy_In = "''''|;|and|exec|insert|select|delete|update|count|*|%|chr|mid|master|truncate|char|declare|or|and|=|'";
			string[] Array_Fy_In = Fy_In.Split(char.Parse("|"));
    
			int i;
			for(i=0;i<Array_Fy_In.Length;i++)
			{
				str = str.Replace(Array_Fy_In[i].ToString(),"");
				if( Regex.IsMatch (str,Array_Fy_In[i].ToString()))
				{
					if(msg.Length > 0)
					{
						msg += " ," + Array_Fy_In[i].ToString(); 
					}
					else
					{
						msg = "�����зǷ��ַ�: " + Array_Fy_In[i].ToString();
					}
				}
			}
			return str;
		} 
		#endregion

		#region ���˲�SQL����


		#region  ���˲�SQL����(�滻';--���滻Ϊ����ȫ��)
		public static string updateSqlPara(string sqlStr)
		{
			sqlStr = sqlStr .Replace ("'","��");
			sqlStr = sqlStr .Replace (";","��");
			sqlStr = sqlStr .Replace ("--","����");
			
			sqlStr = sqlStr .Replace ("����","##");
			sqlStr = sqlStr .Replace ("������","###");
			sqlStr = sqlStr .Replace ("���ֹ�","###");
			sqlStr = sqlStr .Replace ("������","###");
						
			return sqlStr;
		}
		#endregion

		/// <summary>
		/// ���˲�SQL����
		/// </summary>
		/// <param name="args"></param>
		/// <returns></returns>
		public static bool CheckParams(ref string msg ,params object[] args)
		{
			//string Fy_In = "''''|;|exec|insert|select|delete|update|count|*|%|chr|mid|master|truncate|char|declare|or|and|=|'";  

			msg = "";
			bool isOK = true;
			string[] Lawlesses={ 
								   " exec "
								   // , "'"
								   // ,";"								
								   // ," or "
								   // ," and "								  
								   ,"insert"
								   ,"select"
								   ,"delete"
								   ,"delete "
								   ,"update"
								   ,"update "
								   ," count"
								   ,"master"
								   ,"truncate"
								   ,"char"
								   ,"declare"
								   ,"declare "
								   ,"exec master.dbo.xp_cmdshell"
								   ,"net localgroup administrators"   
								   ,"sitename"
								   ,"net user"
								   ,"xp_cmdshell"
								   ,"/add"								
							   };
			if(Lawlesses == null||Lawlesses.Length<=0)
			{
				return true;
			}
			//����������ʽ,��:Lawlesses��=�ź�'��,��������ʽΪ .*[=}'].* (������ʽ����������MSDN)
			//����,������������ͨ�ö��������޸ĵĺ���,���Զ���һ�����ַ����鵽������ʽ,ʵ��ʹ����,ֱ��д������ʽ���;
			string str_Regex=".*(";
			for(int i=0;i< Lawlesses.Length-1;i++)
			{
				str_Regex += Lawlesses[i]+"|";
			}

			str_Regex += Lawlesses[Lawlesses.Length-1]+").*";
			
			foreach(object arg in args)
			{				
				if(arg is string)//������ַ���,ֱ�Ӽ��
				{
					for (int i =0; i<Lawlesses.Length ;i++)
					{
						string temp = ".*("+ Lawlesses[i].ToString().Trim () +").*";
						if(Regex.Matches(arg.ToString().ToLower(),temp).Count>0)
						{						
							isOK = false;
							if(msg.Length > 0)
							{
								msg += "����" + Lawlesses[i].ToString().Trim () +"��";
							}
							else
							{
								msg = "��" + Lawlesses[i].ToString().Trim ()+ "��";
							}
						}
					}
				}
				else if(arg is ICollection)//�����һ������,���鼯����Ԫ���Ƿ��ַ���,���ַ���,�ͽ��м��
				{				
					foreach(object obj in (ICollection)arg)
					{
						if(obj is string)
						{
							for (int i =0; i<Lawlesses.Length ;i++)
							{
								string temp = ".*("+ Lawlesses[i].ToString().Trim () +").*";
								if(Regex.Matches(arg.ToString().ToLower(),temp).Count>0)
								{						
									isOK = false;
									if(msg.Length > 0)
									{
										msg += "����" + Lawlesses[i].ToString().Trim () +"��";
									}
									else
									{
										msg = "��" + Lawlesses[i].ToString().Trim ()+ "��";
									}
								}
							}
						}
					}
				}
			}
			return isOK;
		}	

		/// <summary>
		/// ���˲�SQL����
		/// </summary>
		/// <param name="args"></param>
		/// <returns></returns>
		public static bool CheckParamsAll(ref string msg ,params object[] args)
		{
			//string Fy_In = "''''|;|exec|insert|select|delete|update|count|*|%|chr|mid|master|truncate|char|declare|or|and|=|'";  

			msg = "";
			bool isOK = true;
			string[] Lawlesses={ 
								   " exec "
								   , "'"
								   ,";"
								   ,"--"
								   ," or "
								   ," and "								  
								   ,"insert"
								   ,"select"
								   ,"delete"
								   ,"delete "
								   ,"update"
								   ,"update "
								   ," count"
								   ,"master"
								   ,"truncate"
								   ,"char"
								   ,"declare"
								   ,"declare "
								   ,"exec master.dbo.xp_cmdshell"
								   ,"net localgroup administrators"   
								   ,"sitename"
								   ,"net user"
								   ,"xp_cmdshell"
								   ,"/add"								
							   };
			if(Lawlesses == null||Lawlesses.Length<=0)
			{
				return true;
			}
			//����������ʽ,��:Lawlesses��=�ź�'��,��������ʽΪ .*[=}'].* (������ʽ����������MSDN)
			//����,������������ͨ�ö��������޸ĵĺ���,���Զ���һ�����ַ����鵽������ʽ,ʵ��ʹ����,ֱ��д������ʽ���;
			string str_Regex=".*(";
			for(int i=0;i< Lawlesses.Length-1;i++)
			{
				str_Regex += Lawlesses[i]+"|";
			}

			str_Regex += Lawlesses[Lawlesses.Length-1]+").*";
			
			foreach(object arg in args)
			{				
				if(arg is string)//������ַ���,ֱ�Ӽ��
				{
					for (int i =0; i<Lawlesses.Length ;i++)
					{
						string temp = ".*("+ Lawlesses[i].ToString().Trim () +").*";
						if(Regex.Matches(arg.ToString().ToLower(),temp).Count>0)
						{						
							isOK = false;
							if(msg.Length > 0)
							{
								msg += "����" + Lawlesses[i].ToString().Trim () +"��";
							}
							else
							{
								msg = "��" + Lawlesses[i].ToString().Trim ()+ "��";
							}
						}
					}
				}
				else if(arg is ICollection)//�����һ������,���鼯����Ԫ���Ƿ��ַ���,���ַ���,�ͽ��м��
				{				
					foreach(object obj in (ICollection)arg)
					{
						if(obj is string)
						{
							for (int i =0; i<Lawlesses.Length ;i++)
							{
								string temp = ".*("+ Lawlesses[i].ToString().Trim () +").*";
								if(Regex.Matches(arg.ToString().ToLower(),temp).Count>0)
								{						
									isOK = false;
									if(msg.Length > 0)
									{
										msg += "����" + Lawlesses[i].ToString().Trim () +"��";
									}
									else
									{
										msg = "��" + Lawlesses[i].ToString().Trim ()+ "��";
									}
								}
							}
						}
					}
				}
			}
			return isOK;
		}	
		#endregion

		#region ѡ��ĳ�������˵�ֵ
		public static void BindSelected(System.Web.UI.WebControls.DropDownList htmlSelect,string selectValue)
		{
			try
			{
				for(int i=0;i<htmlSelect.Items.Count;i++)
				{
					if(htmlSelect.Items[i].Value==selectValue)
					{
						htmlSelect.Items[i].Selected=true;
						break;
					}
					else
					{
						htmlSelect.Items[i].Selected=false;
					}
				}
			}
			catch(Exception ex)
			{
				Common.Log.Logger.Log("Tools->BindSelected","��"+htmlSelect.ID.ToString()+":"+ex.Message);
			}
		}
		#endregion
	}
}
