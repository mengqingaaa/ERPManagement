using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Routing;
using ERPManagement.Models;

namespace ERPManagement.Controls
{
	public partial class FunctionMenuList : System.Web.UI.UserControl
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		public IEnumerable<FuncMenu> GetFunctionMenu()
		{
			return new ERPMCModelContainer().FuncMenuSet;
		}

		public string CreateHtmlLink(string menuName)
		{
			return string.Format("<a href='/{0}' >{1}</a>", menuName, menuName);
		}
	}
}