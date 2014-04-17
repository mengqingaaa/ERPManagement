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
	public partial class CustomerList : System.Web.UI.UserControl
	{
		private string urlSegment;
		public IEnumerable<Customer> customers = null;

		protected void Page_Load(object sender, EventArgs e)
		{
			IEnumerable<Customer> customerSet = new ERPMCModelContainer().CustomerSet;

			this.urlSegment = (this.Request.Url.Segments.Length > 1) ? 
				this.Request.Url.Segments[1].TrimEnd('/') :
				null;

			if (this.customers.Any())
				divErrNotExist.Visible = false;
			else
				divErrNotExist.Visible = true;

		}

		public IEnumerable<Customer> GetCustomers()
		{
			return this.customers;
		}

		public string GetCustomerLink(string customer)
		{
			return RouteTable.Routes.GetVirtualPath(null, this.urlSegment,
			new RouteValueDictionary { { "customer", customer } }).VirtualPath;
		}
	}
}