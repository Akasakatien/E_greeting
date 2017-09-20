using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using DoAnHK3_4.Models;

namespace DoAnHK3_4.Security
{
    public class CustomPrincipal : IPrincipal
    {
        private Account Account;
        public CustomPrincipal(Account account)
        {
            Account = account;
        }
        public IIdentity Identity
        {
            get;
            set;
        }

        public bool IsInRole(string role)
        {
            string[] Roles = role.Split(new char[] { ',' });
            return Roles.Any(r=>Account.Role.name.Contains(r.Trim()));
        }
    }
}