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
    public class NotificationService(IRepository<Notification> _notificationRepository) : INotificationService
    {
        
        public void TAdd(Notification entity)
        {
           _notificationRepository.Add(entity);
        }

        public int TCount()
        {
           return _notificationRepository.Count();
        }

        public void TDelete(int id)
        {
           _notificationRepository.Delete(id);
        }

        public int TFilterCount(Expression<Func<Notification, bool>> predicate)
        {
            return _notificationRepository.FilterCount(predicate);
        }

        public List<Notification> TGetAll()
        {
            return _notificationRepository.GetAll();
        }

        public Notification TGetById(int id)
        {
            return _notificationRepository.GetById(id);
        }

        public List<Notification> TGetFilteredList(Expression<Func<Notification, bool>> predicate)
        {
            return _notificationRepository.GetFilteredList(predicate);
        }

        public void TUpdate(Notification entity)
        {
            _notificationRepository.Update(entity);
        }
    }
}
