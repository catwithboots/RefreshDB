using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RefreshDB.Database.Framework;

namespace RefreshDB.WebAPI.Backend.Controllers
{
    public class ScriptsController : ApiController
    {
        public List<Script> Get()
        {
            IDatabaseActionRepository repo = new DatabaseActionRepository(new RefreshDBEntities());
            {
                return repo.GetAllScripts().ToList();
            }
        }

        public Script GetScriptById(int id)
        {
            IDatabaseActionRepository repo = new DatabaseActionRepository(new RefreshDBEntities());
            {
                return repo.GetScriptById(id);
            }
        }
    }
}
