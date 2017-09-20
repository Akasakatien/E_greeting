using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using DoAnHK3_4.Models;

namespace DoAnHK3_4.Repository
{
    public class PaymentRepository
    {
        GreetingDatabaseEntities greeting = null;
        public PaymentRepository()
        {
            greeting = new GreetingDatabaseEntities();
        }

        public Service findService(int id)
        {
            return greeting.Services.FirstOrDefault(x => x.id == id);
        }
        public Payment findPay(int id)
        {
            return greeting.Payments.FirstOrDefault(x => x.accountId == id);
        }
        public void EditPayment(Payment payment)
        {
            greeting.Payments.Attach(payment);

            greeting.Entry(payment).State = System.Data.Entity.EntityState.Modified;

            greeting.SaveChanges();
        }
        public void AddPayment(Payment payment)
        {
            greeting.Payments.Add(payment);
            greeting.SaveChanges();
        }
    }
}