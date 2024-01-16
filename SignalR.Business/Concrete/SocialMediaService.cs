using SignalR.Business.Interfaces;
using SignalR.DataAccess.Interfaces;
using SignalR.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public void TDelete(int id)
        {
            _socialMediaRepository.Delete(id);
        }

        public List<SocialMedia> TGetAll()
        {
          return _socialMediaRepository.GetAll();
        }

        public SocialMedia TGetById(int id)
        {
            return _socialMediaRepository.GetById(id);
        }

        public List<SocialMedia> TGetFilteredList(Func<SocialMedia, bool> predicate)
        {
           return _socialMediaRepository.GetFilteredList(predicate);
        }

        public void TUpdate(SocialMedia entity)
        {
           _socialMediaRepository.Update(entity);
        }
    }
}
