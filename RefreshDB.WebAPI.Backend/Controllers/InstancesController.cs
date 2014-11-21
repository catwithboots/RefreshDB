using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RefreshDB.Database.Framework;

namespace RefreshDB.WebAPI.Backend.Controllers
{
    public class InstancesController : ApiController
    {
        public List<Instance> Get()
        {
            IDatabaseActionRepository repo = new DatabaseActionRepository(new RefreshDBEntities());
            {
                return repo.GetAllInstances().ToList();
            }
        }

        public Instance GetInstanceById(int id)
        {
            IDatabaseActionRepository repo = new DatabaseActionRepository(new RefreshDBEntities());
            {
                return repo.GetInstanceById(id);
            }
        }

        public List<Instance> GetInstanceByEnvironmentId(int environmentid)
        {
            IDatabaseActionRepository repo = new DatabaseActionRepository(new RefreshDBEntities());
            {
                return repo.GetInstanceByEnvironmentId(environmentid).ToList();
            }
        }
    }
}
