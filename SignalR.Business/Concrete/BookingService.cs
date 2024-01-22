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
    public class BookingService : IBookingService
    {
        private readonly IRepository<Booking> _bookingRepository;

        public BookingService(IRepository<Booking> bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public void TAdd(Booking entity)
        {
            _bookingRepository.Add(entity);
        }

        public int TCount()
        {
            return _bookingRepository.Count();
        }

        public void TDelete(int id)
        {
            _bookingRepository.Delete(id);
        }

        public int TFilterCount(Expression<Func<Booking, bool>> predicate)
        {
           return _bookingRepository.FilterCount(predicate);
        }

        public List<Booking> TGetAll()
        {
           return _bookingRepository.GetAll();
        }

        public Booking TGetById(int id)
        {
            return _bookingRepository.GetById(id);
        }

        public List<Booking> TGetFilteredList(Expression<Func<Booking, bool>> predicate)
        {
           return _bookingRepository.GetFilteredList(predicate);
        }

        public void TUpdate(Booking entity)
        {
            _bookingRepository.Update(entity);
        }
    }
}
