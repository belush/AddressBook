using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading;
using System.Web.Mvc;
using WebMatrix.WebData;
using AddressBook.Models;
using AddressBook.DAL;
using System.Web.Security;
using AddressBook.Business;


namespace AddressBook.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public sealed class InitializeSimpleMembershipAttribute : ActionFilterAttribute
    {
        private static SimpleMembershipInitializer _initializer;
        private static object _initializerLock = new object();
        private static bool _isInitialized;

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // Ensure ASP.NET Simple Membership is initialized only once per app start
            LazyInitializer.EnsureInitialized(ref _initializer, ref _isInitialized, ref _initializerLock);
        }

        private class SimpleMembershipInitializer
        {
            DefaultInitializer defaultInit = new DefaultInitializer();

            public SimpleMembershipInitializer()
            {
                Database.SetInitializer<AddressBookContext>(null);

                try
                {
                    using (var context = new AddressBookContext())
                    {
                        if (!context.Database.Exists())
                        {
                            // Create the SimpleMembership database without Entity Framework migration schema
                            ((IObjectContextAdapter)context).ObjectContext.CreateDatabase();
                        }
                    }

                    WebSecurity.InitializeDatabaseConnection("AddressBookConnection", "User", "UserId", "UserLogin", autoCreateTables: true);

                    defaultInit.CreateRoles();
                    defaultInit.CreateAdmin();

                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException("The ASP.NET Simple Membership database could not be initialized. For more information, please see http://go.microsoft.com/fwlink/?LinkId=256588", ex);
                }
            }
        }

        private class DefaultInitializer
        {
            SimpleRoleProvider roles = (SimpleRoleProvider)Roles.Provider;
            SimpleMembershipProvider membership = (SimpleMembershipProvider)Membership.Provider;

         

            public void CreateRoles()
            {
                 if (!roles.RoleExists("Admin"))
                    {
                        roles.CreateRole("Admin");
                    }
                    if (!roles.RoleExists("User"))
                    {
                        roles.CreateRole("User");
                    }
            }

            public void CreateAdmin()
            {
                if (membership.GetUser("admin1", false) == null)
                {
                    WebSecurity.CreateUserAndAccount("admin1", "admin1admin1",
                       new
                       {
                           UserName = "admin1",
                           UserSurname = "admin1",
                           UserMidName = "admin1",
                           UserEmail = "belushko@gmail.com",
                           UserComment = "admin1",
                           UserPhoneNumber = "777",
                           UserPassword = "admin1admin1",
                           UserLogin = "admin1",
                           UserConfirmedEmail = true
                       });

                    roles.AddUsersToRoles(new[] { "admin1" }, new[] { "Admin" });
                }
            }

            //public void CreateDefaultContactTypes()
            //{
            //    contactHelper.AddDefaultContactTypes();
            //}

            //public void CreateDefaultContacts()
            //{
            //    contactHelper.AddDefaultContacts();
            //}
                    

                    
        }
    }
}
