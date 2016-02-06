using System.Linq;
using System.Web.Mvc;
using AddressBook.Business.Logic.Implementations;
using AddressBook.Business.Logic.Interfaces;
using AddressBook.DAL;
using AddressBook.DAL.Repositories.Implementations;
using AddressBook.Models;
using WebMatrix.WebData;

namespace AddressBook.Controllers
{
    // [Authorize(Roles = "Admin")]
    public class ContactController : Controller
    {
        private readonly IContactLogic _contactLogic;
        private readonly IContactTypeLogic _contactTypeLogic;
        private readonly IUserLogic _userLogic;

        public ContactController()
        {
            var context = new AddressBookContext();

            _contactLogic = new ContactLogic(new ContactRepository(context));
            _contactTypeLogic = new ContactTypeLogic(new ContactTypeRepository(context));
            _userLogic = new UserLogic(new UserRepository(context));
        }

        public ActionResult Search(string search)
        {
            var contacts = _contactLogic.GetContacts();

            if (!string.IsNullOrEmpty(search))
            {
                contacts = contacts.Where(c => c.ContactName.ToLower().StartsWith(search.ToLower()));
            }
            return PartialView(contacts);
        }

        public ActionResult JsonSearch(string search)
        {
            var contacts = _contactLogic.GetContacts();

            if (!string.IsNullOrEmpty(search))
            {
                var searchToLower = search.ToLower();
                contacts = contacts.Where(c => c.ContactName.ToLower().StartsWith(searchToLower) ||
                                               c.ContactMidName.ToLower().StartsWith(searchToLower) ||
                                               c.ContactSurname.ToLower().StartsWith(searchToLower) ||
                                               c.ContactAddress.ToLower().StartsWith(searchToLower) ||
                                               c.ContactEmail.ToLower().StartsWith(searchToLower) ||
                                               c.ContactPhoneNumber.ToLower().StartsWith(searchToLower));
            }
            return Json(contacts, JsonRequestBehavior.AllowGet);
        }


        public ActionResult Index()
        {
            //TODO: make Sorting
            //ViewBag.SortNameParameter = string.IsNullOrEmpty(sortBy) ? "Name desc" : "";
            //ViewBag.SortSurnameParameter = sortBy == "Surname" ? "Surname desc" : "Surname";
            //ViewBag.SortPhoneNumberParameter = sortBy == "PhoneNumber" ? "PhoneNumber desc" : "PhoneNumber";
            //ViewBag.SortEmailParameter = sortBy == "Email" ? "Email desc" : "Email";

            var contacts = _contactLogic.GetContacts();

            return View(contacts);
        }

        public ActionResult Add()
        {
            //TODO: make ViewBag for drop down list
            var types = _contactTypeLogic.GetContactTypes();
            ViewBag.Types = new SelectList(types, "ContactTypeId", "ContactTypeName", 1);

            return View();
        }

        [HttpPost]
        public ActionResult Add(ContactView contactView)
        {
            //TODO: use auto-mapper
            var contact = new Contact();

            contact.ContactAddress = contactView.ContactAddress;
            contact.ContactEmail = contactView.ContactEmail;
            contact.ContactName = contactView.ContactName;
            contact.ContactMidName = contactView.ContactMidName;
            contact.ContactSurname = contactView.ContactSurname;
            contact.ContactPhoneNumber = contactView.ContactPhoneNumber;

            var id = int.Parse(contactView.ContactTypeID);
            contact.ContactType = _contactTypeLogic.GetContactTypeById(id);

            //TODO: fix default login admin 
            var authorId = WebSecurity.CurrentUserId;
            contact.User = _userLogic.GetUserById(authorId);

            _contactLogic.AddContact(contact);

            return RedirectToAction("Index");
        }

        //TODO: Tips
        //inlect
        //dependensy injection 
        //auto mapping 

        public ActionResult Edit(int id)
        {
            var сontact = _contactLogic.GetContactById(id);

            var types = _contactTypeLogic.GetContactTypes();

            ViewBag.ContactTypes = (from i in types
                select new SelectListItem {Selected = false, Text = i.ContactTypeName, Value = i.ContactTypeName})
                .ToList();

            //TODO: make ViewBag for drop down list
            var view = new ContactView();

            view.ContactName = сontact.ContactName;
            view.ContactSurname = сontact.ContactSurname;
            view.ContactMidName = сontact.ContactMidName;
            view.ContactEmail = сontact.ContactEmail;
            view.ContactAddress = сontact.ContactAddress;
            view.ContactId = сontact.ContactId;
            view.ContactPhoneNumber = сontact.ContactPhoneNumber;
            view.ContactTypeName = _contactTypeLogic.GetContactTypes();

            var l = view.ContactTypeName.Select(x =>
                new SelectListItem
                {
                    Text = x.ContactTypeName.ToString(),
                    Value = x.ContactTypeId.ToString()
                }).ToList();
            view.ContactTypeList = l;

            //TODO: clean view

            return View(view);
        }

        [HttpPost]
        public ActionResult Edit(ContactView contactView)
        {
            var contact = new Contact();
            //TODO: auto mapping
            contact.ContactId = contactView.ContactId;
            contact.ContactAddress = contactView.ContactAddress;
            contact.ContactEmail = contactView.ContactEmail;
            contact.ContactName = contactView.ContactName;
            contact.ContactMidName = contactView.ContactMidName;
            contact.ContactSurname = contactView.ContactSurname;
            contact.ContactPhoneNumber = contactView.ContactPhoneNumber;

            var id = int.Parse(contactView.ContactTypeID);
            var type = _contactTypeLogic.GetContactTypeById(id);
            contact.ContactType = type;

            var authorId = WebSecurity.CurrentUserId;
            var user = _userLogic.GetUserById(authorId);
            contact.User = user;

            _contactLogic.EditContact(contact);

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            _contactLogic.DeleteContact(id);

            return RedirectToAction("Index");
        }
    }
}