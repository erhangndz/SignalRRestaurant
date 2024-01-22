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
    public class AboutService : IAboutService
    {
        private readonly IRepository<About> _aboutRepository;
       

        public AboutService(IRepository<About> aboutRepository)
        {
            _aboutRepository = aboutRepository;
   
        }

        public void TAdd(About entity)
        {
            _aboutRepository.Add(entity);
        }

        public int TCount()
        {
          return _aboutRepository.Count();
        }

        public void TDelete(int id)
        {
            _aboutRepository.Delete(id);
        }

        public int TFilterCount(Expression<Func<About, bool>> predicate)
        {
            return _aboutRepository.FilterCount(predicate);
        }

        public List<About> TGetAll()
        {
            return _aboutRepository.GetAll();
        }

        public About TGetById(int id)
        {
           return _aboutRepository.GetById(id);
        }

        public List<About> TGetFilteredList(Expression<Func<About, bool>> predicate)
        {
           return _aboutRepository.GetFilteredList(predicate);
        }

        public void TUpdate(About entity)
        {
           _aboutRepository.Update(entity);
        }
    }
}
