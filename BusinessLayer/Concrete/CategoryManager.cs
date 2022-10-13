using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categorydal;

        public CategoryManager(ICategoryDal categorydal)
        {
            _categorydal = categorydal;
        }

      

        public void CategoryAdd(Category category)
        {
            _categorydal.Insert(category);
        }

        public void CategoryDelete(Category category)
        {
            _categorydal.Delete(category);
        }

        public void CategoryUpdate(Category category)
        {
            _categorydal.Update(category);
        }

        public Category GetByID(int id)
        {
            return _categorydal.Get(x => x.CategoryID == id);
        }

        public List<Category> GetList()
        {
            return _categorydal.List();
        }

        public List<Category> GetListChart(Heading h)
        {
            //List<Heading> hd = new List<Heading>();
            //return _categorydal.List(x => x.CategoryID == h.CategoryID).Select(x => new Heading { CategoryID = x.CategoryID }).ToList();

            //return _categorydal.List(x => x.CategoryID == h.CategoryID).Select(h.HeadingName).Count();
            return _categorydal.List();
        }

        public List<Category> GetListChart()
        {
            throw new NotImplementedException();
        }
    }
}
