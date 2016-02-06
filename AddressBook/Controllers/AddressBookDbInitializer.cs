using AddressBook.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AddressBook.Controllers
{
    public class AddressBookDbInitializer : DropCreateDatabaseAlways<AddressBookContext>
    {
        public override void InitializeDatabase(AddressBookContext context)
        {
            context.ContactTypes.Add(new ContactType() { ContactTypeId = 1, ContactTypeName = "test" });
            context.ContactTypes.Add(new ContactType() { ContactTypeId = 2, ContactTypeName = "test2" });
            context.ContactTypes.Add(new ContactType() { ContactTypeId = 3, ContactTypeName = "test3" });

            context.Users.Add(new User()
            {
                UserId = 20,
                UserComment = "",
                UserConfirmedEmail = true,
                UserLogin = "user5",
                UserPassword = "1234567"
            });

            context.Contacts.Add(new Contact()
            {
                ContactId = 1,
                ContactName = "Иван",
                ContactMidName = "Иванович",
                ContactSurname = "Иванов",
                ContactAddress = "г. Харьков",
                ContactEmail = "ivan@gmail.com",
                ContactPhoneNumber = "0663456932",
                ContactType = new ContactType() { ContactTypeId=1,ContactTypeName="test"}
            });

            context.Contacts.Add(new Contact()
            {
                ContactId = 2,
                ContactName = "Петр",
                ContactMidName = "Петрович",
                ContactSurname = "Петров",
                ContactAddress = "г. Киев",
                ContactEmail = "petr@gmail.com",
                ContactPhoneNumber = "0664487503",
                ContactType = new ContactType() { ContactTypeId = 2, ContactTypeName = "test2" }
            });

            context.Contacts.Add(new Contact()
            {
                ContactId = 3,
                ContactName = "Василий",
                ContactMidName = "Васильевич",
                ContactSurname = "Васильев",
                ContactAddress = "г. Москва",
                ContactEmail = "vasya@gmail.com",
                ContactPhoneNumber = "06756237942",
                ContactType = new ContactType() { ContactTypeId = 2, ContactTypeName = "test2" }
            });

            context.Contacts.Add(new Contact()
            {
                ContactId = 4,
                ContactName = "Коля",
                ContactMidName = "Васильевич",
                ContactSurname = "Васильев",
                ContactAddress = "г. Минск",
                ContactEmail = "sdf@gmail.com",
                ContactPhoneNumber = "06755656",
                ContactType = new ContactType() { ContactTypeId = 3, ContactTypeName = "test2" }
            });

            context.Contacts.Add(new Contact()
            {
                ContactId = 5,
                ContactName = "Рома",
                ContactMidName = "Васильевич",
                ContactSurname = "Иваов",
                ContactAddress = "г. Белгород",
                ContactEmail = "dfffff@gmail.com",
                ContactPhoneNumber = "067332323",
                ContactType = new ContactType() { ContactTypeId = 2, ContactTypeName = "test2" }
            });


            base.InitializeDatabase(context);
        }
    }
}