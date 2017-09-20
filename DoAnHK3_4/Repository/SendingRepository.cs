using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DoAnHK3_4.Models;

namespace DoAnHK3_4.Repository
{
    public class SendingRepository : ISendingRepository
    {
        private GreetingDatabaseEntities GDE = new GreetingDatabaseEntities();

        public void create(Sending sending)
        {
            this.GDE.Sendings.Add(sending);
            this.GDE.SaveChanges();        
        }
    }
}