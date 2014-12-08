using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using RefreshDB.Database.Framework;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections;

namespace RefreshDB.WebAPI.Backend.Controllers
{
    public class RundeckController : ApiController
    {
        // Return all environments
        public dynamic Get()
        {
            dynamic env = new EnvironmentsController();
            {
                List<RefreshDB.Database.Framework.Environment> list = env.Get();

                // Rename EF columns to Rundeck style
                Func<RefreshDB.Database.Framework.Environment, JObject> objToJson =
                    o => new JObject(
                            new JProperty("name", o.name),
                            new JProperty("value", o.id));

                return Json(new JArray(list.Select(objToJson)));
            }
        }

        // Return instances for an environment
        public dynamic GetInstanceByEnvId(int id)
        {
            dynamic inst = new InstancesController();
            {
                List<Instance> list = inst.GetInstanceByEnvironmentId(id);

                // Rename EF columns to Rundeck style
                Func<Instance, JObject> objToJson =
                    o => new JObject(
                            new JProperty("name", o.name),
                            new JProperty("value", o.id));

                return Json(new JArray(list.Select(objToJson)));
            }
        }

        // Return instances for an environment
        public dynamic GetDatabasesByInstance(int id)
        {
            dynamic dbs = new DatabasesController();
            {
                List<string> list = dbs.GetDatabasesByInstance(id);

                // Rename EF columns to Rundeck style
                Func<string, JObject> objToJson =
                    o => new JObject(
                            new JProperty("name", o),
                            new JProperty("value", o));

                return Json(new JArray(list.Select(objToJson)));
            }
        }

        // Return source savesetfile for a database
        public dynamic GetSourceSavesetPathByInstance(int id, string name)
        {
            dynamic inst = new InstancesController();
            {
                List<Instance> list = inst.GetInstanceByEnvironmentId(id);

                // Rename EF columns to Rundeck style
                Func<Instance, JObject> objToJson =
                    o => new JObject(
                            new JProperty("name", o.sourcesavesetpath + "\\SQLRefreshDB_" + name + ".BAK"),
                            new JProperty("value", o.sourcesavesetpath + "\\SQLRefreshDB_" + name + ".BAK"));

                return Json(new JArray(list.Select(objToJson)));
            }
        }

        // Return source savesetfile for a database
        public dynamic GetDestinationSavesetPathByInstance(int id)
        {
            dynamic inst = new InstancesController();
            {
                Instance myinstance = inst.GetInstanceById(id);

                // Add the Instance object to a new Instance list
                List<Instance> list = new List<Instance>();
                list.Add(myinstance);

                // Rename EF columns to Rundeck style
                Func<Instance, JObject> objToJson =
                    o => new JObject(
                            new JProperty("name", o.destinationsavesetpath),
                            new JProperty("value", o.destinationsavesetpath));

                return Json(new JArray(list.Select(objToJson)));
            }
        }
    }
}