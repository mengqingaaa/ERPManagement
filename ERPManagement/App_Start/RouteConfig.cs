using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace ERPManagement.App_Start
{
	public class RouteConfig
	{
		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.MapPageRoute("RDLC", "RDLC/{customer}", "~/Pages/RDLC.aspx");
			routes.MapPageRoute("SqlExec", "SqlExec/{customer}", "~/Pages/SqlExec.aspx");

			routes.MapPageRoute(null, "", "~/Pages/Index.aspx");
			routes.MapPageRoute(null, "home", "~/Pages/Index.aspx");
			routes.MapPageRoute(null, "RDLC", "~/Pages/RDLC.aspx");
			routes.MapPageRoute(null, "SqlExec", "~/Pages/SqlExec.aspx");
		}
	}
}