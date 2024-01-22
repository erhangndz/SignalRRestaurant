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
    public class TestimonialService : ITestimonialService
    {
        private readonly IRepository<Testimonial> _testimonialRepository;

        public TestimonialService(IRepository<Testimonial> testimonialRepository)
        {
            _testimonialRepository = testimonialRepository;
        }

        public void TAdd(Testimonial entity)
        {
            _testimonialRepository.Add(entity);
        }

        public int TCount()
        {
            return _testimonialRepository.Count();
        }

        public void TDelete(int id)
        {
            _testimonialRepository.Delete(id);
        }

        public int TFilterCount(Expression<Func<Testimonial, bool>> predicate)
        {
            return _testimonialRepository.FilterCount(predicate);
        }

        public List<Testimonial> TGetAll()
        {
            return _testimonialRepository.GetAll();
        }

        public Testimonial TGetById(int id)
        {
            return _testimonialRepository.GetById(id);
        }

        public List<Testimonial> TGetFilteredList(Expression<Func<Testimonial, bool>> predicate)
        {
            return _testimonialRepository.GetFilteredList(predicate);
        }

        public void TUpdate(Testimonial entity)
        {
           _testimonialRepository.Update(entity);
        }
    }
}
