using AddressBook.Business;
using AddressBook.Controllers;
using AddressBook.DAL;
using AddressBook.Filters;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WebMatrix.WebData;

namespace AddressBook
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {

        protected void Application_Start()
        {
            Database.SetInitializer(new AddressBookDbInitializer());

            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();

            try
            {
                int adminId = 1;

                //TODO: убрать. заменив на Инитиалайзер
                //contactTypeHelper.AddDefaultContactTypes();
                //contactHelper.AddDefaultContacts(adminId);
            }
            catch
            {

            }

           

       
              
           
        }
    }
}