using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DoAnHK3_4.Models;

namespace DoAnHK3_4.Repository
{
    public class CardRepository : ICardRepository
    {
        private GreetingDatabaseEntities GDE = new GreetingDatabaseEntities();
 
        public List<Category_Details> findAllCategoryDetail()
        {
            return GDE.Category_Details.ToList();
        }
        public Greeting find(int id)
        {
            return GDE.Greetings.Find(id);
        }

        public List<Greeting> LatestCards(int n)
        {
            return GDE.Greetings.OrderByDescending(p => p.id).Take(n).ToList();
        }

        public List<Greeting> findAll()
        {
            return GDE.Greetings.ToList();
        }
    }
}