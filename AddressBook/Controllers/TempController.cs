using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;

namespace AddressBook.Controllers
{
    public class TempController : Controller
    {
        //in account controller
        //login as admin function
        public ActionResult LoginAsAdmin()
        {
            try
            {

                WebSecurity.Login("admin1", "admin1admin1");

                return RedirectToAction("Index", "Home");
            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Home");
            }
        }

    }
}
