using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;

namespace ERPMConsole.Model
{
	class SqlExecution
	{
		static public void SqlExec()
		{
			Console.WriteLine("Hello, World! \n And this is my first C# program");

			string sqlcmdPath = @"C:\Program Files\Microsoft SQL Server\110\Tools\Binn\SQLCMD.EXE";
			string sqlcmdArgs = @"-S (localdb)\v11.0 -U UserTest1 -P ZAQ!2wsx -i C:\test\TestScript.sql";

			ProcessStartInfo processInfo = new ProcessStartInfo();
			processInfo.FileName = sqlcmdPath;
			processInfo.Arguments = sqlcmdArgs;
			processInfo.CreateNoWindow = true;
			processInfo.UseShellExecute = false;
			processInfo.RedirectStandardOutput = true;
			processInfo.RedirectStandardError = true;

			Process sqlExecProcess = new Process();
			sqlExecProcess.StartInfo = processInfo;

			string outlog = "bbb";
			string errlog = "aaa";

			sqlExecProcess.Start();
			using (StreamReader reader = sqlExecProcess.StandardOutput)
			{
				outlog = reader.ReadToEnd();
			}

			using (StreamReader reader = sqlExecProcess.StandardError)
			{
				//				errlog = reader.ReadToEnd();
			}

			sqlExecProcess.WaitForExit();
			sqlExecProcess.Close();

			Console.WriteLine(outlog);
			Console.WriteLine(errlog);
			Console.WriteLine("Now is exiting");
		}
	}
}
