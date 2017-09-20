using DoAnHK3_4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoAnHK3_4.Repository
{
    public class AccountInfoRepository
    {
        GreetingDatabaseEntities greeting = null;
        public AccountInfoRepository()
        {
            greeting = new GreetingDatabaseEntities();
        }
        public Account findAccount(string username)
        {
            return greeting.Accounts.SingleOrDefault(x => x.username.Equals(username));
        }
        public Role findRole()
        {
            return greeting.Roles.First(x => x.id == 1);
        }

        public Account findAccountInfo(string username)
        {
            return greeting.Accounts.FirstOrDefault(x => x.username.Equals(username));
        }
        public void AddOject(Account account)
        {

            greeting.Accounts.Add(account);
            greeting.SaveChanges();

        }
        public void EditOject(Account account)
        {
            greeting.Accounts.Attach(account);
            greeting.Entry(account).State = System.Data.Entity.EntityState.Modified;
            greeting.Configuration.ValidateOnSaveEnabled = false;
            greeting.SaveChanges();
        }
    }
}