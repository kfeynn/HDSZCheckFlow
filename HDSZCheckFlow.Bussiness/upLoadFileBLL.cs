using System; 
using System.IO; 
using System.Web.UI.HtmlControls;

namespace HDSZCheckFlow.Bussiness
{
	/// <summary>
	/// �ϴ��ļ������࣮��֧�ֶϵ�������Ӧ����С�ļ��ϴ�
	/// </summary>
	public class upLoadFileBLL 
	{ 
		public upLoadFileBLL() 
		{ 
		} 

		//����ļ������Ƿ�����Ƿ��ַ� # @ . ~
		public bool IsAllowString(HtmlInputFile hifile)
		{
			string strOldFilePath = ""; 
			string strExtension = ""; 

			string[]arrExtension = {"#","@",".","~","`","\\","!","'","��"}; 

			bool returnvalue = true ; 

			if(hifile.PostedFile.FileName != string.Empty) 
			{ 
				strOldFilePath = hifile.PostedFile.FileName; 
				//ȡ���ϴ��ļ��� 

				strExtension =strOldFilePath.Substring (0, strOldFilePath.LastIndexOf(".")) ;

				strExtension = strExtension.Substring(strExtension.LastIndexOf("\\")+1 ); 



				//strExtension = strOldFilePath.Substring(strOldFilePath.LastIndexOf(".")); 
				//�жϸ���չ���Ƿ�Ϸ� 
				for(int i = 0;i<arrExtension.Length;i++) 
				{ 
					if(strExtension.IndexOf(arrExtension[i].ToUpper()) >= 0) 
					{ 
						return false; 
					} 
				} 

			} 
			return returnvalue; 



		}

		#region �Ƿ��������չ���ϴ�IsAllowedExtension 
		///<summary> 
		///�Ƿ��������չ���ϴ� 
		///</summary> 
		///<paramname = "hifile">HtmlInputFile�ؼ�</param> 
		///<returns>�����򷵻�true,���򷵻�false</returns> 
		public bool IsAllowedExtension(HtmlInputFile hifile) 
		{ 
			string strOldFilePath = ""; 
			string strExtension = ""; 

			//�����ϴ�����չ�������Ըĳɴ������ļ��ж��� 
			//string[]arrExtension = {".gif",".jpg",".jpeg",".bmp",".png",".xls",".csv"}; 
			string[]arrExtension = {".xls",".xlsx",".csv",".txt",".doc",".docx",".pdf",".jpg",".bmp"}; 

			if(hifile.PostedFile.FileName != string.Empty) 
			{ 
				strOldFilePath = hifile.PostedFile.FileName; 
				//ȡ���ϴ��ļ�����չ�� 
				strExtension = strOldFilePath.Substring(strOldFilePath.LastIndexOf(".")); 
				//�жϸ���չ���Ƿ�Ϸ� 
				for(int i = 0;i<arrExtension.Length;i++) 
				{ 
					if(strExtension.ToUpper().Equals(arrExtension[i].ToUpper())) 
					{ 
						return true; 
					} 
				} 
			} 
			return false; 
		} 
		#endregion 


		#region �ж��ϴ��ļ���С�Ƿ񳬹����ֵIsAllowedLength 
		/// <summary> 
		/// �ж��ϴ��ļ���С�Ƿ񳬹����ֵ 
		/// </summary> 
		/// <param name="hifile">HtmlInputFile�ؼ�</param> 
		/// <returns>�������ֵ����false,���򷵻�true.</returns> 
		public bool IsAllowedLength(HtmlInputFile hifile) 
		{ 
			//�����ϴ��ļ���С�����ֵ,���Ա�����xml�ļ���,��λΪ M 
			int i = 6; 
			//����ϴ��ļ��Ĵ�С�������ֵ,����flase,���򷵻�true. 
			if(hifile.PostedFile.ContentLength > i * 1024 * 1024) 
			{ 
				return false; 
			} 
			return true; 
		} 
		#endregion 


		#region ��ȡһ�����ظ����ļ���GetUniqueString 
		/// <summary> 
		/// ��ȡһ�����ظ����ļ��� 
		/// </summary> 
		/// <returns></returns> 
		public string GetUniqueString() 
		{ 
			//�õ����ļ������磺20050922101010 
			return DateTime.Now.ToString("yyyyMMddhhmmss"); 
		} 
		#endregion 


		#region ɾ��ָ���ļ�DeleteFile 
		/// <summary> 
		/// ɾ��ָ���ļ� 
		/// </summary> 
		/// <param name="strAbsolutePath">�ļ�����·��</param> 
		/// <param name="strFileName">�ļ���</param> 
		public void DeleteFile(string strAbsolutePath, string strFileName) 
		{ 
			//�ж�·�������û��\���ţ�û�����Զ����� 
			if(strAbsolutePath.LastIndexOf("\\") == strAbsolutePath.Length) 
			{ 
				//�ж�Ҫɾ�����ļ��Ƿ���� 
				if(File.Exists(strAbsolutePath + strFileName)) 
				{ 
					//ɾ���ļ� 
					File.Delete(strAbsolutePath + strFileName); 
				} 
			} 
			else 
			{ 
				if(File.Exists(strAbsolutePath + "\\" + strFileName)) 
				{ 
					File.Delete(strAbsolutePath + "\\" + strFileName); 
				} 
			} 
		} 
		#endregion 


		#region �ϴ��ļ��������ļ��� SaveFile 
		/// <summary> 
		/// �ϴ��ļ��������ļ��� 
		/// </summary> 
		/// <param name="hifile">HtmlInputFile�ؼ�</param> 
		/// <param name="strAbsolutePath">����·��.��:Server.MapPath(@"Image/upload")��Server.MapPath(@"Image/upload/")����,��\�������</param> 
		/// <returns>���ص��ļ������ϴ�����ļ���</returns> 
		public string SaveFile(HtmlInputFile hifile,string strAbsolutePath) 
		{ 
			string strOldFilePath = "",strExtension = "",strNewFileName = ""; 

			//����ϴ��ļ����ļ�����Ϊ�� 
			if(hifile.PostedFile.FileName != string.Empty) 
			{ 
				strOldFilePath = hifile.PostedFile.FileName; 
				//ȡ���ϴ��ļ�����չ�� 
				strExtension = strOldFilePath.Substring(strOldFilePath.LastIndexOf(".")); 
				//�ļ��ϴ�������� 
				strNewFileName = GetUniqueString() + strExtension; 
				//���·��ĩβΪ\���ţ���ֱ���ϴ��ļ� 
				if(strAbsolutePath.LastIndexOf("\\") == strAbsolutePath.Length) 
				{ 
					hifile.PostedFile.SaveAs(strAbsolutePath + strNewFileName); 
				} 
				else 
				{ 
					hifile.PostedFile.SaveAs(strAbsolutePath + "\\" + strNewFileName); 
				} 
			} 
			return strNewFileName; 
		} 
		#endregion 


		#region �����ϴ��ļ���ɾ��ԭ���ļ�CoverFile 
		/// <summary> 
		/// �����ϴ��ļ���ɾ��ԭ���ļ� 
		/// </summary> 
		/// <param name="ffFile">HtmlInputFile�ؼ�</param> 
		/// <param name="strAbsolutePath">����·��.��:Server.MapPath(@"Image/upload")��Server.MapPath(@"Image/upload/")����,��\�������</param> 
		/// <param name="strOldFileName">���ļ���</param> 
		public void CoverFile(HtmlInputFile ffFile,string strAbsolutePath,string strOldFileName) 
		{ 
			//������ļ��� 
			string strNewFileName = GetUniqueString(); 

			if(ffFile.PostedFile.FileName != string.Empty) 
			{ 
				//��ͼƬ��Ϊ��ʱ��ɾ����ͼƬ 
				if(strOldFileName != string.Empty) 
				{ 
					DeleteFile(strAbsolutePath,strOldFileName); 
				} 
				SaveFile(ffFile,strAbsolutePath); 
			} 
		} 
		#endregion 


		/// <summary>
		/// ��ȡ�ϴ��ļ���·��,ͬʱ�ж��ļ���,�Ƿ����,�������������ļ���
		/// </summary>
		/// <param name="keys"></param>
		/// <param name="postedFileName"></param>
		/// <param name="fileURL"></param>
		/// <returns></returns>
		public  string getuploadFileName(string keys,string postedFileName,out string Name )
		{
			//�ϴ�·������Ϊ������·��\ + ����\ + ����ͷPK\ + �ļ��� eg: 200806\120\˵��.txt		
			string returnValue= "";
			Name = "" ;
			Entiy.ApplySheetHead applyHead=Entiy.ApplySheetHead.Find(int.Parse(keys));
			DateTime dt=applyHead.ApplyDate;
			string applyDate = dt.ToString("yyyyMM");
			applyHead= null;

			string upLoad = System.Configuration.ConfigurationSettings.AppSettings["ApplyAnnexUpFile"];

			string applyName= postedFileName;
			string fileName =  applyName.Substring(applyName.LastIndexOf(@"\",applyName.Length)+1);

			returnValue = upLoad + @"\" + applyDate + @"\" + keys + @"\" + fileName ;

			Name = fileName ;

			//*************���˸�Ŀ¼,��������Ŀ¼����Ҫ�ж��Ƿ����,�������ļ���*************************
			
			Scripting.FileSystemObject  fso=new  Scripting.FileSystemObjectClass();  
			if(!fso.FolderExists(upLoad + @"\" + applyDate))
			{
				fso.CreateFolder(upLoad + @"\" + applyDate);
			}
			if(!fso.FolderExists(upLoad + @"\" + applyDate + @"\" + keys))
			{
				fso.CreateFolder(upLoad + @"\" + applyDate + @"\" + keys);
			}
			//*********************************************************************************************

			return  returnValue ;
		}

		/// <summary>
		/// ��ȡ�ϴ��ļ���·��,ͬʱ�ж��ļ���,�Ƿ����,�������������ļ���(�۸�þ�)
		/// </summary>
		/// <param name="keys"></param>
		/// <param name="postedFileName"></param>
		/// <param name="fileURL"></param>
		/// <returns></returns>
		public  string getuploadFileNameForFinallyCheck(string keys,string postedFileName,out string Name )
		{
			//�ϴ�·������Ϊ������·��\ + ����\ + ����ͷPK\ + �ļ��� eg: 200806\120\˵��.txt
			string returnValue= "";
			Name = "" ;
			//Entiy.ApplySheetHead applyHead=Entiy.ApplySheetHead.Find(int.Parse(keys));
			Entiy.AssetFinallyPriceCheck FinallyCheck = Entiy.AssetFinallyPriceCheck.Find(int.Parse(keys));
			DateTime dt=FinallyCheck.MakeDate ;
			string applyDate = dt.ToString("yyyyMM");
			//FinallyCheck= null;

			string upLoad = System.Configuration.ConfigurationSettings.AppSettings["ApplyAnnexUpFileForFinallyCheck"];

			string applyName= postedFileName;
			string fileName =  applyName.Substring(applyName.LastIndexOf(@"\",applyName.Length)+1);

			returnValue = upLoad + @"\" + applyDate + @"\" + keys + @"\" + fileName ;

			Name = fileName ;

			//*************���˸�Ŀ¼,��������Ŀ¼����Ҫ�ж��Ƿ����,�������ļ���*************************
			
			Scripting.FileSystemObject  fso=new  Scripting.FileSystemObjectClass();  
			if(!fso.FolderExists(upLoad + @"\" + applyDate))
			{
				fso.CreateFolder(upLoad + @"\" + applyDate);
			}
			if(!fso.FolderExists(upLoad + @"\" + applyDate + @"\" + keys))
			{
				fso.CreateFolder(upLoad + @"\" + applyDate + @"\" + keys);
			}
			//*********************************************************************************************

			return  returnValue ;
		}

		#region �ϴ��ļ��������ļ��� SaveFileKeepName 
		/// <summary> 
		/// �ϴ��ļ��������ļ��� 
		/// </summary> 
		/// <param name="hifile">HtmlInputFile�ؼ�</param> 
		/// <param name="strAbsolutePath">����·��,������չ��</param> 
		/// <returns>���ص��ļ������ϴ�����ļ���</returns> 
		public void SaveFileKeepName(HtmlInputFile hifile,string strAbsolutePath) 
		{ 
			//����ϴ��ļ����ļ�����Ϊ�� 
			if(hifile.PostedFile.FileName != string.Empty) 
			{ 
				Scripting.FileSystemObject  fso=new  Scripting.FileSystemObjectClass();  
				//���·��ĩβΪ\���ţ���ֱ���ϴ��ļ� 
				if(fso.FileExists(strAbsolutePath) ) 
				{ 
					fso.DeleteFile(strAbsolutePath,false);
					hifile.PostedFile.SaveAs(strAbsolutePath); 
					
				
				} 
				else 
				{ 
					hifile.PostedFile.SaveAs(strAbsolutePath); 
				} 
			} 
		}
		#endregion 

		/// <summary>
		/// ��ȡ����·��
		/// </summary>
		/// <param name="applyHeadPk">����ͷ</param>
		/// <returns></returns>
		public static string getAnnexPath(int applyHeadPk)
		{

			string returnValue="";
			Entiy.ApplySheetHead applyHead=Entiy.ApplySheetHead.Find(applyHeadPk);
			if(applyHead!=null  )
			{
				DateTime dt=applyHead.ApplyDate;
				string applyDate = dt.ToString("yyyyMM");
				applyHead= null;
				string upLoad = System.Configuration.ConfigurationSettings.AppSettings["ApplyAnnexUpFile"];

				returnValue = upLoad + @"\" + applyDate + @"\" + applyHeadPk.ToString().Trim() + @"\" ;
			}
			return returnValue ;
		}

		/// <summary>
		/// ��ȡ����·��
		/// </summary>
		/// <param name="applyHeadPk">����ͷ</param>
		/// <returns></returns>
		public static string getAnnexPathForFinallyCheck(int FinallyCheckId)
		{
			string returnValue="";

			Entiy.AssetFinallyPriceCheck FinallyCheck = Entiy.AssetFinallyPriceCheck.Find(FinallyCheckId);
			if(FinallyCheck != null )
			{
				string applyDate = FinallyCheck.MakeDate.ToString("yyyyMM");

				string upLoad = System.Configuration.ConfigurationSettings.AppSettings["ApplyAnnexUpFileForFinallyCheck"];
				
				returnValue = upLoad + @"\" + applyDate + @"\" + FinallyCheckId.ToString().Trim() + @"\" ;
			}

			return returnValue ;

		}



	} 
}