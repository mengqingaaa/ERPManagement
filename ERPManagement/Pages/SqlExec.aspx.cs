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
using ERPManagement.Models;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;

using ERPManagement.Pages.Helpers;

namespace ERPManagement.Pages
{
	public partial class SqlExec : System.Web.UI.Page
	{
		protected int customerCount = 0;
		protected IEnumerable<Customer> customers = null;
	
		private string sqlScriptContent;
		private IEnumerable<SqlExecution> SqlExecutionSet = null;

		protected void Page_Load(object sender, EventArgs e)
		{
			IEnumerable<Customer> customerSet = new ERPMCModelContainer().CustomerSet;

			this.customers = (this.Page.RouteData.Values["customer"] == null) ?
				customerSet :
				customerSet.Where(p => p.Code == this.Page.RouteData.Values["customer"].ToString());

			this.customerCount = this.customers.Count();
			if (this.customerCount == 1)
				functionContent.Visible = true;
			else
				functionContent.Visible = false;

			lblUploaderMsg.Text = "";
			btnSqlExecution.Enabled = false;		//	Disable btnSqlExecution
			txtAreaSqlScriptContent.InnerText = "";
		}

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

			string sqlFileName = Path.GetFileName(SqlUploader.PostedFile.FileName);
			string sqlFilePath = Path.Combine(Request.PhysicalApplicationPath, 
				"Uploads", 
				sqlFileName
				);
			ViewState["sqlFilePath"] = sqlFilePath;		//	Save the sqlFilePath value to the ViewState for the Sql Execution

			try
			{
				SqlUploader.PostedFile.SaveAs(sqlFilePath);
				lblUploaderMsg.Text = sqlFileName + " is uploaded";
				btnSqlExecution.Enabled = true;			//	Enable btnSqlExectution

				getSqlScriptContent(sqlFilePath);		// Read the Sql Script
				txtAreaSqlScriptContent.InnerText = sqlScriptContent;			//	Display the Sql script content

//				SqlExecutionSet = getSqlExecutionContext();						
				SqlExecution newSqlExecutionEntry = new SqlExecution { 
					CreatedTime = DateTime.Now,
					ScriptFileName = sqlFileName,
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

		protected void btnSqlExecution_Click(object sender, EventArgs e)
		{
			string sqlFilePath = ViewState["sqlFilePath"].ToString();

			getSqlScriptContent(sqlFilePath);			// Read the Sql Script
			txtAreaSqlScriptContent.InnerText = sqlScriptContent;

			string sqlcmdFilePath = WebConfigurationManager.AppSettings["sqlcmdFilePath"];

			string dbServer = this.customers.FirstOrDefault().DBServerName.ToString();
			string dbLoginName = this.customers.FirstOrDefault().DBLoginName.ToString();
			string dbPasswd = this.customers.FirstOrDefault().DBLoginPassword.ToString();
			string sqlcmdArgs = string.Format("-S {0} -U {1} -P {2} -i {3}", dbServer, dbLoginName, dbPasswd, sqlFilePath);

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
				lblExecuMsg.Text = "aaa";
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
			if (SqlUploader.PostedFile.FileName == "")
				return false;
			return true;
		}

		private bool chkFileExtension()
		{
			string fileExtention = Path.GetExtension(SqlUploader.PostedFile.FileName);

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

		private IEnumerable<SqlExecution> getSqlExecutionContext()
		{
			return new ERPMCModelContainer().SqlExecutionSet;
		}

	}
}