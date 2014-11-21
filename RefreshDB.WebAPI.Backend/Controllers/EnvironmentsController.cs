using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RefreshDB.Database.Framework;

namespace RefreshDB.WebAPI.Backend.Controllers
{
    public class EnvironmentsController : ApiController
    {
        public List<RefreshDB.Database.Framework.Environment> Get()
        {
            IDatabaseActionRepository repo = new DatabaseActionRepository(new RefreshDBEntities());
            {
                return repo.GetAllEnvironments().ToList();
            }
        }

        public dynamic GetEnvironmentById(int id)
        {
            IDatabaseActionRepository repo = new DatabaseActionRepository(new RefreshDBEntities());
            {
                return repo.GetEnvironmentById(id);
            }
        }
    }
}
