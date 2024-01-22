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
    public class ContactService : IContactService
    {
        private readonly IRepository<Contact> _contactRepository;

        public ContactService(IRepository<Contact> contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public void TAdd(Contact entity)
        {
            _contactRepository.Add(entity);
        }

        public int TCount()
        {
           return _contactRepository.Count();
        }

        public void TDelete(int id)
        {
           _contactRepository.Delete(id);
        }

        public int TFilterCount(Expression<Func<Contact, bool>> predicate)
        {
            return _contactRepository.FilterCount(predicate);
        }

        public List<Contact> TGetAll()
        {
           return _contactRepository.GetAll();
        }

        public Contact TGetById(int id)
        {
            return _contactRepository.GetById(id);
        }

        public List<Contact> TGetFilteredList(Expression<Func<Contact, bool>> predicate)
        {
            return _contactRepository.GetFilteredList(predicate);
        }

        public void TUpdate(Contact entity)
        {
            _contactRepository.Update(entity);
        }
    }
}
