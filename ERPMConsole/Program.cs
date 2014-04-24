using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERPMConsole.Model;

using System.IO;
//using System.Security.Cryptography;


namespace ERPMConsole
{
	class Program
	{
		static void Main(string[] args)
		{
//			Console.WriteLine("Test for key and IV generator from user password");

//			testKeyAndIV();

//			Console.WriteLine("The generated key is: {0}", key);
//			Console.WriteLine("The generated IV is: {0}", IV);
			
			string SQLFilePath = @"c:\tmp\tmp.sql";
			string NewFilePath = @"c:\tmp\new.sql";
			string SqlContent = File.ReadAllText(SQLFilePath, Encoding.GetEncoding(932));
			File.WriteAllText(NewFilePath, string.Format(SqlContent, "lalal"), Encoding.Unicode);

//			StreamReader r = new StreamReader(SQLFilePath, true);




			Console.Write(SqlContent, "lalal");
		}
/*
		static private string passwd = "t";
		static private string salt = "testSalt";

		static private string key;
		static private string IV;
		static private void testKeyAndIV()
		{
			byte[] binSalt = Convert.FromBase64String(salt);
			Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(passwd, binSalt);

			byte[
				] binKey = rfc2898DeriveBytes.GetBytes(16);
			byte[] binIV = rfc2898DeriveBytes.GetBytes(16);

			key = Convert.ToBase64String(binKey);
			IV = Convert.ToBase64String(binIV);
		}
 */ 
	}
}
