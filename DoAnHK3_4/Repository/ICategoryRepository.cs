using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoAnHK3_4.Models;

namespace DoAnHK3_4.Repository
{
    public interface ICategoryRepository
    {
        List<Category> findAll();
        List<Category_Details> findAllCategoryDetail();
        Category_Details find(int id);
    }
}
