using System; 
using System.IO; 
using System.Web.UI.HtmlControls;

namespace HDSZCheckFlow.Bussiness
{
	/// <summary>
	/// 上传文件帮助类．不支持断点续传，应用于小文件上传
	/// </summary>
	public class upLoadFileBLL 
	{ 
		public upLoadFileBLL() 
		{ 
		} 

		//检查文件名中是否包含非法字符 # @ . ~
		public bool IsAllowString(HtmlInputFile hifile)
		{
			string strOldFilePath = ""; 
			string strExtension = ""; 

			string[]arrExtension = {"#","@",".","~","`","\\","!","'","＃"}; 

			bool returnvalue = true ; 

			if(hifile.PostedFile.FileName != string.Empty) 
			{ 
				strOldFilePath = hifile.PostedFile.FileName; 
				//取得上传文件名 

				strExtension =strOldFilePath.Substring (0, strOldFilePath.LastIndexOf(".")) ;

				strExtension = strExtension.Substring(strExtension.LastIndexOf("\\")+1 ); 



				//strExtension = strOldFilePath.Substring(strOldFilePath.LastIndexOf(".")); 
				//判断该扩展名是否合法 
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

		#region 是否允许该扩展名上传IsAllowedExtension 
		///<summary> 
		///是否允许该扩展名上传 
		///</summary> 
		///<paramname = "hifile">HtmlInputFile控件</param> 
		///<returns>允许则返回true,否则返回false</returns> 
		public bool IsAllowedExtension(HtmlInputFile hifile) 
		{ 
			string strOldFilePath = ""; 
			string strExtension = ""; 

			//允许上传的扩展名，可以改成从配置文件中读出 
			//string[]arrExtension = {".gif",".jpg",".jpeg",".bmp",".png",".xls",".csv"}; 
			string[]arrExtension = {".xls",".xlsx",".csv",".txt",".doc",".docx",".pdf",".jpg",".bmp"}; 

			if(hifile.PostedFile.FileName != string.Empty) 
			{ 
				strOldFilePath = hifile.PostedFile.FileName; 
				//取得上传文件的扩展名 
				strExtension = strOldFilePath.Substring(strOldFilePath.LastIndexOf(".")); 
				//判断该扩展名是否合法 
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


		#region 判断上传文件大小是否超过最大值IsAllowedLength 
		/// <summary> 
		/// 判断上传文件大小是否超过最大值 
		/// </summary> 
		/// <param name="hifile">HtmlInputFile控件</param> 
		/// <returns>超过最大值返回false,否则返回true.</returns> 
		public bool IsAllowedLength(HtmlInputFile hifile) 
		{ 
			//允许上传文件大小的最大值,可以保存在xml文件中,单位为 M 
			int i = 6; 
			//如果上传文件的大小超过最大值,返回flase,否则返回true. 
			if(hifile.PostedFile.ContentLength > i * 1024 * 1024) 
			{ 
				return false; 
			} 
			return true; 
		} 
		#endregion 


		#region 获取一个不重复的文件名GetUniqueString 
		/// <summary> 
		/// 获取一个不重复的文件名 
		/// </summary> 
		/// <returns></returns> 
		public string GetUniqueString() 
		{ 
			//得到的文件名形如：20050922101010 
			return DateTime.Now.ToString("yyyyMMddhhmmss"); 
		} 
		#endregion 


		#region 删除指定文件DeleteFile 
		/// <summary> 
		/// 删除指定文件 
		/// </summary> 
		/// <param name="strAbsolutePath">文件绝对路径</param> 
		/// <param name="strFileName">文件名</param> 
		public void DeleteFile(string strAbsolutePath, string strFileName) 
		{ 
			//判断路径最后有没有\符号，没有则自动加上 
			if(strAbsolutePath.LastIndexOf("\\") == strAbsolutePath.Length) 
			{ 
				//判断要删除的文件是否存在 
				if(File.Exists(strAbsolutePath + strFileName)) 
				{ 
					//删除文件 
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


		#region 上传文件并返回文件名 SaveFile 
		/// <summary> 
		/// 上传文件并返回文件名 
		/// </summary> 
		/// <param name="hifile">HtmlInputFile控件</param> 
		/// <param name="strAbsolutePath">绝对路径.如:Server.MapPath(@"Image/upload")与Server.MapPath(@"Image/upload/")均可,用\符号亦可</param> 
		/// <returns>返回的文件名即上传后的文件名</returns> 
		public string SaveFile(HtmlInputFile hifile,string strAbsolutePath) 
		{ 
			string strOldFilePath = "",strExtension = "",strNewFileName = ""; 

			//如果上传文件的文件名不为空 
			if(hifile.PostedFile.FileName != string.Empty) 
			{ 
				strOldFilePath = hifile.PostedFile.FileName; 
				//取得上传文件的扩展名 
				strExtension = strOldFilePath.Substring(strOldFilePath.LastIndexOf(".")); 
				//文件上传后的命名 
				strNewFileName = GetUniqueString() + strExtension; 
				//如果路径末尾为\符号，则直接上传文件 
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


		#region 重新上传文件，删除原有文件CoverFile 
		/// <summary> 
		/// 重新上传文件，删除原有文件 
		/// </summary> 
		/// <param name="ffFile">HtmlInputFile控件</param> 
		/// <param name="strAbsolutePath">绝对路径.如:Server.MapPath(@"Image/upload")与Server.MapPath(@"Image/upload/")均可,用\符号亦可</param> 
		/// <param name="strOldFileName">旧文件名</param> 
		public void CoverFile(HtmlInputFile ffFile,string strAbsolutePath,string strOldFileName) 
		{ 
			//获得新文件名 
			string strNewFileName = GetUniqueString(); 

			if(ffFile.PostedFile.FileName != string.Empty) 
			{ 
				//旧图片不为空时先删除旧图片 
				if(strOldFileName != string.Empty) 
				{ 
					DeleteFile(strAbsolutePath,strOldFileName); 
				} 
				SaveFile(ffFile,strAbsolutePath); 
			} 
		} 
		#endregion 


		/// <summary>
		/// 获取上传文件的路径,同时判断文件夹,是否存在,不存在则生成文件夹
		/// </summary>
		/// <param name="keys"></param>
		/// <param name="postedFileName"></param>
		/// <param name="fileURL"></param>
		/// <returns></returns>
		public  string getuploadFileName(string keys,string postedFileName,out string Name )
		{
			//上传路径定义为：配置路径\ + 年月\ + 单据头PK\ + 文件名 eg: 200806\120\说明.txt		
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

			//*************除了根目录,以下其他目录都需要判断是否存在,并创建文件夹*************************
			
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
		/// 获取上传文件的路径,同时判断文件夹,是否存在,不存在则生成文件夹(价格裁决)
		/// </summary>
		/// <param name="keys"></param>
		/// <param name="postedFileName"></param>
		/// <param name="fileURL"></param>
		/// <returns></returns>
		public  string getuploadFileNameForFinallyCheck(string keys,string postedFileName,out string Name )
		{
			//上传路径定义为：配置路径\ + 年月\ + 单据头PK\ + 文件名 eg: 200806\120\说明.txt
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

			//*************除了根目录,以下其他目录都需要判断是否存在,并创建文件夹*************************
			
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

		#region 上传文件并返回文件名 SaveFileKeepName 
		/// <summary> 
		/// 上传文件并返回文件名 
		/// </summary> 
		/// <param name="hifile">HtmlInputFile控件</param> 
		/// <param name="strAbsolutePath">完整路径,包含扩展名</param> 
		/// <returns>返回的文件名即上传后的文件名</returns> 
		public void SaveFileKeepName(HtmlInputFile hifile,string strAbsolutePath) 
		{ 
			//如果上传文件的文件名不为空 
			if(hifile.PostedFile.FileName != string.Empty) 
			{ 
				Scripting.FileSystemObject  fso=new  Scripting.FileSystemObjectClass();  
				//如果路径末尾为\符号，则直接上传文件 
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
		/// 获取附件路径
		/// </summary>
		/// <param name="applyHeadPk">单据头</param>
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
		/// 获取附件路径
		/// </summary>
		/// <param name="applyHeadPk">单据头</param>
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