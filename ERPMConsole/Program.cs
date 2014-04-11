using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ERPMConsole
{
	class Program
	{
		static void Main(string[] args)
		{
			DateTime now = DateTime.Now;
			string datetimePattern = "yyyy-MM-dd HH:mm:ss.fff";
			Console.WriteLine(now.ToString(datetimePattern));
		}
	}
}
