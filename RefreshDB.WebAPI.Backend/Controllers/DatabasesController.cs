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
using NLog;

namespace RefreshDB.WebAPI.Backend.Controllers
{
    public class DatabasesController : ApiController
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public List<string> GetDbsByInstance(int id)
        {
            logger.Info("Getting databasename for instanceid {0}", id.ToString());
            //throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotImplemented));
            var instcnt = new InstancesController();

            Instance instobj = instcnt.GetInstanceById(id);

            List<string> results = new List<string>();
            string servername = instobj.name.ToString();
            string catalog = "master";
            string dbnames = "select name from sys.databases where database_id > 4";

            var dbobject = new DbQueryExecutor();

            results = dbobject.MsSqlExecQuery(servername, catalog, dbnames);

            return results;
        }
    }
}
