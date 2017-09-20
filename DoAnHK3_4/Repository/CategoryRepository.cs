using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DoAnHK3_4.Models;

namespace DoAnHK3_4.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private GreetingDatabaseEntities GDE = new GreetingDatabaseEntities();


        public List<Category> findAll()
        {
            return GDE.Categories.ToList();
        }
        public List<Category_Details> findAllCategoryDetail()
        {
            return GDE.Category_Details.ToList();
        }
        public Category_Details find(int id)
        {
            return GDE.Category_Details.Find(id);
        }

    }
}