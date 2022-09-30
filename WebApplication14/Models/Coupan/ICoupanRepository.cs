using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication14.Models
{
    public interface ICoupanRepository
    {
       List<Coupan> GetAllCoupan();
    Coupan AddCoupan(Coupan coupan);
        string DeleteCoupan(int id);
        string UpdateCoupan(int id, Coupan coupan);
    }
}