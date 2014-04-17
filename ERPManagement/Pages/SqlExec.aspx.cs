using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data.SqlClient;
using System.Diagnostics;			//	For Executing sqlcmd.exe
using System.Web.Configuration;		//	For fetching Web appSettings Configuration
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;

using ERPManagement.Models;
using ERPManagement.Pages.Helpers;

using ERPManagement.Pages.Helpers;

namespace ERPManagement.Pages
{
	public partial class SqlExec : System.Web.UI.Page
	{
		protected int customerCount = 0;
	
		private string sqlScriptContent = string.Empty;
		private Customer customerEntity = null;
		private int selectedDBType = 0;		//	DB:SqlExecution:DBType	0:Business DB	1:SystemDB	
														// Values from rblDBSelection.SelectedIndex

		protected void Page_Load(object sender, EventArgs e)
		{

			using (var context = new ERPMCModelContainer())
			{
				string urlCustomerSeg = this.Page.RouteData.Values["customer"] == null ? string.Empty : this.Page.RouteData.Values["customer"].ToString();
				if (urlCustomerSeg == string.Empty)
					ucCustomerList.customers = context.CustomerSet.AsNoTracking().ToList();				// !!!!! ToList() save the Entities to the memory without relating to the Context
				else
					ucCustomerList.customers = context.CustomerSet.Where(p => p.Code == urlCustomerSeg).ToList();

				customerCount = ucCustomerList.customers.Count();
				if (customerCount == 1)
				{
					customerEntity = ucCustomerList.customers.First();
					functionContent.Visible = true;
					if (!IsPostBack)
					{
						rblDBSelection.Items.Add(new ListItem(
							string.Format("Business Database: {0}", customerEntity.DBBizName),
							customerEntity.DBBizName
							));
						rblDBSelection.Items.Add(new ListItem(
							string.Format("System Database: {0}", customerEntity.DBSysname),
							customerEntity.DBSysname
							));
					}
				}
				else
					functionContent.Visible = false;
			}

			lblUploaderMsg.Text = "";
			btnSqlExecution.Enabled = false;		//	Disable btnSqlExecution
			txtAreaSqlScriptContent.InnerText = "";

			if (!IsPostBack)
			{
				btnSqlUploader.Enabled = false;
				fuplSqlUploader.Enabled = false;
				lblUploaderMsg.Text = "Please Select a Database";
			}

		}

		/// <summary>
		/// Upload the Sql script
		/// </summary>
		/// <remarks>
		/// ViewState Add:
		///	sqlFilePath: the full path of Sql script saved in local
		///	logId: the logId related to the SqlExecution
		/// </remarks>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void btnSqlUploader_Click(object sender, EventArgs e)
		{
			if (!chkFileExist())
			{
				lblUploaderMsg.Text = "No file is specified";
				btnSqlExecution.Enabled = false;			//	Disable btnSqlExecution
				return;
			}

			if (!chkFileExtension())
			{
				lblUploaderMsg.Text = "This type of file is not allowed";
				btnSqlExecution.Enabled = false;			//	Disable btnSqlExecution
				return;
			}

			string uploadFileName = Path.GetFileName(fuplSqlUploader.PostedFile.FileName);
			string savedFileName = "SQL" + Utility.getNowDateTime();
			string sqlFilePath = Path.Combine(Request.PhysicalApplicationPath, 
				"Uploads", 
				savedFileName
				);
			ViewState["sqlFilePath"] = sqlFilePath;		//	Save the sqlFilePath value to the ViewState for the Sql Execution

			selectedDBType = rblDBSelection.SelectedIndex;		//	Get the selected DB type
			try
			{
				fuplSqlUploader.PostedFile.SaveAs(sqlFilePath);			//	Save the Sql script file
				lblUploaderMsg.Text = uploadFileName + " is uploaded";
				btnSqlExecution.Enabled = true;			//	Enable btnSqlExectution

				getSqlScriptContent(sqlFilePath);		// Read the Sql Script
				txtAreaSqlScriptContent.InnerText = sqlScriptContent;			//	Display the Sql script content

//				SqlExecutionSet = getSqlExecutionContext();						
				SqlExecution newSqlExecutionEntry = new SqlExecution { 
					CustomerId = customerEntity.CustomoerId,
					DBType = selectedDBType,
					CreatedTime = DateTime.Now,
					UploadFileName = uploadFileName,
					SavedFileName = savedFileName,
					ScriptFilePath = Path.GetDirectoryName(sqlFilePath)
					};
				
				using (var context = new ERPMCModelContainer())
				{
					context.SqlExecutionSet.Add(newSqlExecutionEntry);			//	Create SqlExecution Entry
					context.SaveChanges();

					int newEntryId = newSqlExecutionEntry.SqlExecutionId;
					lblUploaderMsg.Text = newEntryId.ToString();
				}
			}
			catch (Exception err)
			{
				lblUploaderMsg.Text = err.Message;
			}


		}

		/// <summary>
		/// Execute the Sql script
		/// Log: use the ViewState["LogId"] as key
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void btnSqlExecution_Click(object sender, EventArgs e)
		{
			string sqlFilePath = ViewState["sqlFilePath"].ToString();

			getSqlScriptContent(sqlFilePath);			// Read the Sql Script
			txtAreaSqlScriptContent.InnerText = sqlScriptContent;

			string sqlcmdFilePath = WebConfigurationManager.AppSettings["sqlcmdFilePath"];

			string dbServer = customerEntity.DBServerName;
			string dbLoginName = customerEntity.DBLoginName;
			string dbPasswd = customerEntity.DBLoginPassword;
			string sqlcmdArgs = string.Format("-S {0} -U {1} -P {2} -i \"{3}\"", dbServer, dbLoginName, dbPasswd, sqlFilePath);

			lblUploaderMsg.Text = sqlcmdFilePath + " " + sqlcmdArgs;
			try
			{
				ProcessStartInfo processInfo = new ProcessStartInfo(sqlcmdFilePath, sqlcmdArgs);
				processInfo.UseShellExecute = false;
				processInfo.RedirectStandardOutput = true;
				processInfo.RedirectStandardError = true;
				processInfo.CreateNoWindow = true;

				Process psSqlExec = new Process();
				psSqlExec.StartInfo = processInfo;

				psSqlExec.Start();
				using (StreamReader reader = psSqlExec.StandardOutput)
				{
					lblExecuMsg.Text = reader.ReadToEnd();
				}
				using (StreamReader reader = psSqlExec.StandardError)
				{
					lblExecuMsg.Text += reader.ReadToEnd();
				}
				psSqlExec.WaitForExit();
				psSqlExec.Close();
			}
			catch (Exception err)
			{
				lblExecuMsg.Text = err.Message;
			}

			/*
						string executionMsg = "";
						string connectionString = @"Data Source=(localdb)\v11.0;Initial Catalog=BizTest2;Integrated Security=True";
			
						try
						{
							using (SqlConnection sqlConn = new SqlConnection(connectionString))			//	Require Importing the System.Data.Sqlclient Namespace
							{
								Microsoft.SqlServer.Management.Smo.Server server = new Microsoft.SqlServer.Management.Smo.Server(
									new ServerConnection(sqlConn)
									);

								executionMsg = server.ConnectionContext.ExecuteNonQuery(sqlScriptContent).ToString();

								lblUploaderMsg.Text = executionMsg.ToString();
							}
						}
						catch (Exception err)
						{
							lblUploaderMsg.Text = err.Message;
						}
			*/
		}

		private bool chkFileExist()
		{
			if (fuplSqlUploader.PostedFile.FileName == "")
				return false;
			return true;
		}

		private bool chkFileExtension()
		{
			string fileExtention = Path.GetExtension(fuplSqlUploader.PostedFile.FileName);

			switch (fileExtention.ToLower())
			{
				case ".sql":		//	Hard coding, pay attentsion to the "."
					break;
				default:
					return false;
			}
			return true;
		}

		private void getSqlScriptContent(string fileName)
		{
			FileInfo sqlScriptFile = new FileInfo(fileName);
			StreamReader streamReaderHandler = sqlScriptFile.OpenText();
			sqlScriptContent = streamReaderHandler.ReadToEnd();
			streamReaderHandler.Close();
		}

		protected void rblDBSelection_SelectedIndexChanged(object sender, EventArgs e)
		{
			btnSqlUploader.Enabled = true;
			fuplSqlUploader.Enabled = true;
			lblUploaderMsg.Text = string.Format("{0} has been selected. Then please upload the Sql script file.", rblDBSelection.SelectedValue);
		}

	}
}