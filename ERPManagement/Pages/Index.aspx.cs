using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Routing;
using ERPManagement.Models;

using System.Web.Configuration;

namespace ERPManagement.Pages
{
	public partial class Index : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		public IEnumerable<string> getConfigData()
		{
			foreach ( string key in WebConfigurationManager.AppSettings)
			{
				yield return string.Format("{0} = {1}", key, WebConfigurationManager.AppSettings[key]);
			}
		}

	}
}