using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStoreApi.Models
{
    public interface ICategoryRepository
    {
        List<Category> GetAllCategory();
        List<Category> GetCategoryById(int id);
        Category AddCategory(Category category);
         string DeleteCategory(int id);
        string UpdateCategory(int id,Category category);


    }
}