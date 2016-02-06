using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.DAL
{
    public class ContactType
    {
        [Key]
        public int ContactTypeId { set; get; }

        [Display(Name = "Contact type")]
        public string ContactTypeName { set; get; }
    }
}
