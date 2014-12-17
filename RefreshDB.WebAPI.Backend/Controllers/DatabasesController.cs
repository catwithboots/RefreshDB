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
        public List<string> GetDatabasesByInstance(int id)
        {
            var instcnt = new InstancesController();

            Instance instobj = instcnt.GetInstanceById(id);

            string WinrmPort = System.Configuration.ConfigurationManager.AppSettings["WinrmPort"];

            string strPrefix;
            if (System.Configuration.ConfigurationManager.AppSettings["WinrmSSL"] == "true")
            {
                strPrefix = "https://";
            }
            else
            {
                strPrefix = "http://";
            }

            string winrmurl = strPrefix + instobj.servername + ":" + WinrmPort + "/wsman";
            string schema = @"http://schemas.microsoft.com/powershell/Microsoft.PowerShell";
            string username = System.Configuration.ConfigurationManager.AppSettings[@"WinrmUsername"];
            string password = System.Configuration.ConfigurationManager.AppSettings[@"WinrmPassword"];
            
            List<string> psresults = new List<string>();

            // Execute powershell script to return database names via winrm
            Runspace remoteRunspace = null;

            WSManHelper.openRunspace(winrmurl, schema, username, password, ref remoteRunspace);

            using (PowerShell powershell = PowerShell.Create())
            {
                powershell.Runspace = remoteRunspace;
                string psscript = File.ReadAllText(System.Web.Hosting.HostingEnvironment.MapPath("~/PowershellScripts/RunSQLStatement.ps1"));
                powershell.AddScript(psscript);
                powershell.Commands.AddParameter("SqlServer", instobj.name.ToString());
                powershell.Commands.AddParameter("SqlCatalog", "master");
                powershell.Commands.AddParameter("SqlQuery", "select name from sys.databases where database_id > 4 and name not in ('SBPTools')");
                powershell.Invoke();
                var results = powershell.Invoke();
                remoteRunspace.Close();
                foreach (PSObject obj in results)
                {
                    psresults.Add(obj.Properties["name"].Value.ToString());
                }
            }

            return psresults;

        }
        
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
