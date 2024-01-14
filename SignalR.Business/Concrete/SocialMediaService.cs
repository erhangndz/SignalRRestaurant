using SignalR.DataAccess.Interfaces;
using SignalR.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.Business.Concrete
{
    public class SocialMediaService : GenericService<SocialMedia>
    {
        public SocialMediaService(IRepository<SocialMedia> repository) : base(repository)
        {
        }
    }
}
