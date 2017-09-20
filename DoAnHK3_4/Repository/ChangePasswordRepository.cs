using DoAnHK3_4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoAnHK3_4.Repository
{
    public class ChangePasswordRepository
    {
        GreetingDatabaseEntities greeting = null;
        public ChangePasswordRepository()
        {
            greeting = new GreetingDatabaseEntities();
        }

        public Account findAccount(string userName)
        {
            return greeting.Accounts.FirstOrDefault(x => x.username.Equals(userName));
        }
        public void AddChange(Account account)
        {
            greeting.Accounts.Attach(account);
            greeting.Entry(account).State = System.Data.Entity.EntityState.Modified;
            greeting.Configuration.ValidateOnSaveEnabled = false;
            greeting.SaveChanges();
        }
    }
}