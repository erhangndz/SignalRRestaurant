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
    public class FeatureService : IFeatureService
    {
        private readonly IRepository<Feature> _featureRepository;

        public FeatureService(IRepository<Feature> featureRepository)
        {
            _featureRepository = featureRepository;
        }

        public void TAdd(Feature entity)
        {
           _featureRepository.Add(entity);
        }

        public int TCount()
        {
          return _featureRepository.Count();
        }

        public void TDelete(int id)
        {
            _featureRepository.Delete(id);
        }

        public int TFilterCount(Expression<Func<Feature, bool>> predicate)
        {
            return _featureRepository.FilterCount(predicate);
        }

        public List<Feature> TGetAll()
        {
            return _featureRepository.GetAll();
        }

        public Feature TGetById(int id)
        {
           return _featureRepository.GetById(id);
        }

        public List<Feature> TGetFilteredList(Expression<Func<Feature, bool>> predicate)
        {
            return _featureRepository.GetFilteredList(predicate);
        }

        public void TUpdate(Feature entity)
        {
            _featureRepository.Update(entity);
        }
    }
}
