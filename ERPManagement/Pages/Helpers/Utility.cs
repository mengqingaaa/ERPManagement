using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;

namespace ERPManagement.Pages.Helpers
{
	public class Utility
	{
		static public string getNowDateTime()
		{
			string dateTimePattern = "yyyyMMddHHmmssfff";
			return DateTime.Now.ToString(dateTimePattern);
		}

		/// <summary>
		/// Generates a pseudo-random string
		///	<para>int stringType
		///	
		///	</para>
		/// </summary>
		/// <returns>Random String</returns>
		static public string GetRandomString(int stringType, int stringLength)
		{
			string lowercaseAlphabet = "abcdefghijklmnopqrstuvwxyz";
			string uppercaseAlphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
			string number = "0123456789";
			string charSet = string.Empty;
			Random randomPos = new Random();

			if (stringType % 8 == 0)
				charSet = number;
			else
			{
				if (stringType % 2 == 1)
					charSet += number;
				if ((stringType >> 1) % 2 == 1)
					charSet += lowercaseAlphabet;
				if ((stringType >> 2) % 2 == 1)
					charSet += uppercaseAlphabet;
			}

			return new string(Enumerable.Repeat(charSet, stringLength).Select(
				x => x[randomPos.Next(charSet.Length)]).ToArray());
		}

		static public string GetTimestamp()
		{
			DateTime now = DateTime.Now;
			string datetimePattern = "yyyy-MM-dd HH:mm:ss.fff";
			return now.ToString(datetimePattern);
		}

	}
}