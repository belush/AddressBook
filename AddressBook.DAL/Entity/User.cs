using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.DAL
{
    [Table("User")]
    public class User
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        public string UserLogin { get; set; }

        public string UserName { get; set; }

        public string UserSurname { get; set; }

        public string UserMidName { get; set; }

        public string UserPhoneNumber { get; set; }

        public string UserEmail { get; set; }

        public string UserComment { get; set; }

        public string UserConfirmString { get; set; }

        public string UserPassword { get; set; }

        public bool UserConfirmedEmail { set; get; }
    }
}
