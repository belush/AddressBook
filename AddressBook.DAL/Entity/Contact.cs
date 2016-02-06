using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AddressBook;

namespace AddressBook.DAL
{
   // [MetadataType(typeof(ContactMetaData))]
    public class Contact
    {
        [Key]
        public int ContactId { set; get; }

        [Required]
        [Display(Name = "ContactName", ResourceType = typeof(Resources.Resource))]
        public string ContactName { set; get; }

        [Required]
        [Display(Name = "Surname", ResourceType = typeof(Resources.Resource))]
        public string ContactSurname { set; get; }

        [Required]
        [Display(Name = "Midname", ResourceType = typeof(Resources.Resource))]
        public string ContactMidName { set; get; }

        [Required]
        [Display(Name = "PhoneNumber", ResourceType = typeof(Resources.Resource))]
        public string ContactPhoneNumber { set; get; }

        [Required]
        [Display(Name = "Address", ResourceType = typeof(Resources.Resource))]
        public string ContactAddress { set; get; }

        [Required]
        [Display(Name = "Email", ResourceType = typeof(Resources.Resource))]
        public string ContactEmail { set; get; }

        [Required]
        [Display(Name = "ContactType", ResourceType = typeof(Resources.Resource))]
        public virtual ContactType ContactType { set; get; }

        public virtual User User { set; get; }
    }
}
