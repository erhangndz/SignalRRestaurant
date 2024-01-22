using SignalR.Business.Interfaces;
using SignalR.DataAccess.Interfaces;
using SignalR.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.Business.Concrete
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> _categoryRepository;

        public CategoryService(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }


        public void TAdd(Category entity)
        {
            _categoryRepository.Add(entity);
        }

        public int TCount()
        {
          return _categoryRepository.Count();
        }

        public void TDelete(int id)
        {
           _categoryRepository.Delete(id);
        }

        public int TFilterCount(Expression<Func<Category, bool>> predicate)
        {
            return _categoryRepository.FilterCount(predicate);
        }

        public List<Category> TGetAll()
        {
            return _categoryRepository.GetAll();
        }

        public Category TGetById(int id)
        {
            return _categoryRepository.GetById(id);
        }

        public List<Category> TGetFilteredList(Expression<Func<Category, bool>> predicate)
        {
            return _categoryRepository.GetFilteredList(predicate);
        }

        public void TUpdate(Category entity)
        {
            _categoryRepository.Update(entity);
        }
    }
}
