using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using RefreshDB.Database.Framework;
using System.Threading.Tasks;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Text;
using RefreshDB.WebAPI.Backend.Models;

namespace RefreshDB.WebAPI.Backend.Controllers
{
    public class DatabasesController : ApiController
    {
        public List<string> GetDbsByInstance(int id)
        {
            //throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotImplemented));
            var instcnt = new InstancesController();

            Instance instobj = instcnt.GetInstanceById(id);

            List<string> results = new List<string>();
            string servername = instobj.name.ToString();
            string catalog = "master";
            string dbnames = "select name from sys.databases where database_id > 4 and name not in ('SBPTools')";

            var dbobject = new DbQueryExecutor();

            results = dbobject.MsSqlExecQuery(servername, catalog, dbnames);

            return results;
        }
    }
}
