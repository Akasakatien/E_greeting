using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoAnHK3_4.Models;

namespace DoAnHK3_4.Repository
{
    public interface ICardRepository
    {
        List<Greeting> findAll();
        List<Greeting> LatestCards(int n);
        Greeting find(int id);
    }
}
