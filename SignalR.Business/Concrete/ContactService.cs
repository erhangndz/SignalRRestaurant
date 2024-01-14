using SignalR.DataAccess.Interfaces;
using SignalR.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.Business.Concrete
{
    public class ContactService : GenericService<Contact>
    {
        public ContactService(IRepository<Contact> repository) : base(repository)
        {
        }
    }
}
