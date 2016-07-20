using Northwind.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwind.Entities;
using Northwind.Dal.Abstract;

namespace Northwind.Bll.Concrete
{
    public class CategoryManager : ICategoryService
    {
        public ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }
        public List<Category> GelAll()
        {
            return _categoryDal.GelAll();
        }
    }
}
