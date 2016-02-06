using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AddressBook.DAL;
using System.Web.Mvc;

namespace AddressBook.Models
{
    public class ContactView
    {
        public int ContactId { set; get; }
        public string ContactName { set; get; }
        public string ContactSurname { set; get; }
        public string ContactMidName { set; get; }
        public string ContactPhoneNumber { set; get; }
        public string ContactAddress { set; get; }
        public string ContactEmail { set; get; }
        //mus silmp
        public string ContactTypeID { get; set; }
        public IEnumerable<ContactType> ContactTypeName { get; set; }

        public IEnumerable<SelectListItem> ContactTypeList { get; set; }

    }
}