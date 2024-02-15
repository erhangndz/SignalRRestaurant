using SignalR.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.Business.Interfaces
{
    public interface INotificationService:IGenericService<Notification>
    {
        int UnreadNotificationCount();
        int ReadNotificationCount();

        void MarkAsRead(int id);
        void MarkAsUnread(int id);
    }
}
