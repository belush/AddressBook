using System.Web.Mvc;
using AddressBook.Business.Logic.Implementations;
using AddressBook.Business.Logic.Interfaces;
using AddressBook.DAL;
using AddressBook.DAL.Repositories.Implementations;

namespace AddressBook.Controllers
{
    public class ContactTypeController : Controller
    {
        private readonly IContactTypeLogic _contactTypeLogic;


        public ContactTypeController()
        {
            var context = new AddressBookContext();

            _contactTypeLogic = new ContactTypeLogic(new ContactTypeRepository(context));
        }

        public ActionResult Index()
        {
            var contactTypes = _contactTypeLogic.GetContactTypes();

            return View(contactTypes);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(ContactType contactType)
        {
            _contactTypeLogic.AddContactType(contactType);

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var contactType = _contactTypeLogic.GetContactTypeById(id);

            return View(contactType);
        }

        [HttpPost]
        public ActionResult Edit(ContactType contactType)
        {
            _contactTypeLogic.EditContactType(contactType);

            return RedirectToAction("Index");
        }
    }
}