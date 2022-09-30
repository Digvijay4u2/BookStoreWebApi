using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStoreApi.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int Position { get; set; }
        public DateTime CreatedAt { get; set; }

        public Category()
        {

        }

        public Category(int catId, string catName,string des,string Img,int pos,DateTime createdAt)
        {
            this.CategoryId = catId;
            this.CategoryName = catName;
            this.Description = des;
            this.Image = Img;
            this.Position = pos;
            this.CreatedAt = createdAt;
        }
    }


}