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
    public class MessageService : GenericService<Message>, IMessageService
    {
        public MessageService(IRepository<Message> repository) : base(repository)
        {
        }
    }
}
