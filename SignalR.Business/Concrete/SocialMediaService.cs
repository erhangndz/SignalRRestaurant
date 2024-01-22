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
    public class SocialMediaService : ISocialMediaService
    {
        private readonly IRepository<SocialMedia> _socialMediaRepository;

        public SocialMediaService(IRepository<SocialMedia> socialMediaRepository)
        {
            _socialMediaRepository = socialMediaRepository;
        }

        public void TAdd(SocialMedia entity)
        {
            _socialMediaRepository.Add(entity);
        }

        public int TCount()
        {
          return _socialMediaRepository.Count();
        }

        public void TDelete(int id)
        {
            _socialMediaRepository.Delete(id);
        }

        public int TFilterCount(Expression<Func<SocialMedia, bool>> predicate)
        {
            return _socialMediaRepository.FilterCount(predicate);
        }

        public List<SocialMedia> TGetAll()
        {
          return _socialMediaRepository.GetAll();
        }

        public SocialMedia TGetById(int id)
        {
            return _socialMediaRepository.GetById(id);
        }

        public List<SocialMedia> TGetFilteredList(Expression<Func<SocialMedia, bool>> predicate)
        {
           return _socialMediaRepository.GetFilteredList(predicate);
        }

        public void TUpdate(SocialMedia entity)
        {
           _socialMediaRepository.Update(entity);
        }
    }
}
