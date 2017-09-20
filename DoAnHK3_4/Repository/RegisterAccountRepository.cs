using DoAnHK3_4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoAnHK3_4.Repository
{
    public class RegisterAccountRepository
    {
        GreetingDatabaseEntities greeting = null;
        public RegisterAccountRepository()
        {
            greeting = new GreetingDatabaseEntities();
        }

        public int CountAccount(string username)
        {
            return greeting.Accounts.Count(c => c.username.Equals(username));
        }
        public Role role()
        {
            return greeting.Roles.First(x => x.id == 1);
        }
        public void AddAccount(Account account)
        {

            greeting.Accounts.Add(account);
            greeting.SaveChanges();
        }
    }
}