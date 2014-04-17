using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPManagement.Pages.Helpers
{
	public class Utility
	{
		static public string getNowDateTime()
		{
			string dateTimePattern = "yyyyMMddHHmmssfff";
			return DateTime.Now.ToString(dateTimePattern);
		}
	}
}