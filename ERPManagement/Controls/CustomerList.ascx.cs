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
		private IEnumerable<Customer> customers;
//		protected bool isCustomerExists = false;

		protected void Page_Load(object sender, EventArgs e)
		{
			IEnumerable<Customer> customerSet = new ERPMCModelContainer().CustomerSet;

			this.urlSegment = (this.Request.Url.Segments.Length > 1) ? 
				this.Request.Url.Segments[1].TrimEnd('/') :
				null;

			this.customers = (this.Page.RouteData.Values["customer"] == null) ?
				customerSet :
				customerSet.Where(p => p.Code == this.Page.RouteData.Values["customer"].ToString());

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