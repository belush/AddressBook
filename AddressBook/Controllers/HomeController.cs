using System.Web.Mvc;
using AddressBook.Business;
using AddressBook.Business.Logic.Implementations;
using AddressBook.Business.Logic.Interfaces;
using AddressBook.DAL;
using AddressBook.DAL.Repositories.Implementations;
using AddressBook.Filters;

namespace AddressBook.Controllers
{
    [Culture]
    public class HomeController : Controller
    {
        private readonly IContactLogic _contactLogic;
        //TODO:remove
        private readonly CultureHelper cultureHelper = new CultureHelper();

        public HomeController()
        {
            var context = new AddressBookContext();

            _contactLogic = new ContactLogic(new ContactRepository(context));
        }

        public ActionResult Index(string searchBy, string search, string sortBy)
        {
            //TODO: make Sorting
            //ViewBag.SortNameParameter = string.IsNullOrEmpty(sortBy) ? "Name desc" : "";
            //ViewBag.SortSurnameParameter = sortBy == "Surname" ? "Surname desc" : "Surname";
            //ViewBag.SortPhoneNumberParameter = sortBy == "PhoneNumber" ? "PhoneNumber desc" : "PhoneNumber";
            //ViewBag.SortEmailParameter = sortBy == "Email" ? "Email desc" : "Email";

            var contacts = _contactLogic.GetContacts();

            return View(contacts);
        }

        //change language
        public ActionResult ChangeCulture(string lang)
        {
            var returnUrl = Request.UrlReferrer.AbsolutePath;

            var cookie = Request.Cookies["lang"];

            var cookie2 = cultureHelper.ChangeCulture(lang, cookie);

            Response.Cookies.Add(cookie2);

            return Redirect(returnUrl);
        }
    }
}