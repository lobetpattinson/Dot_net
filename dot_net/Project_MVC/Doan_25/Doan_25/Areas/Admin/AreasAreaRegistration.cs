using System.Web.Mvc;

namespace Doan_25.Areas.Admin
{
    public class AreasAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { Controller = "Home",action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}