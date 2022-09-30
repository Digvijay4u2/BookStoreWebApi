using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication14.Models
{
    public class Coupan
    {
        public int CoupanId { get; set; }
        public int CategoryId { get; set; }
        public string CoupanName { get; set; }
        public string Description { get; set; }
        public decimal Discount { get; set; }


        public Coupan()
        {

        }

        public Coupan(int coupanId,int categoryId,string coupanName,string discription,decimal discount)
        {
            this.CoupanId = coupanId;
            this.CategoryId = categoryId;
            this.CoupanName = coupanName;
            this.Description = discription;
            this.Discount = discount;
        }
    }
}