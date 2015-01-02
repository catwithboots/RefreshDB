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
using System.IO;
using RefreshDB.WebAPI.Backend.Models;
using RefreshDB.ExceptionHandler;
using NLog;

namespace RefreshDB.WebAPI.Backend.Controllers
{

    public class RundeckController : ApiController
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        // Return all environments
        public dynamic Get()
        {
            logger.Info("Getting All environments");
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

        // Return explicitely the instance name because rundeck can only pass option values to the workflow
        public dynamic GetInstanceNameByInstance(int id)
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
                            new JProperty("name", o.name),
                            new JProperty("value", o.name));

                return Json(new JArray(list.Select(objToJson)));
            }
        }

        // Return server for an instance
        public dynamic GetServerByInstance(int id)
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
                            new JProperty("name", o.servername),
                            new JProperty("value", o.servername));

                return Json(new JArray(list.Select(objToJson)));
            }
        }

        // Return instances for an environment
        public dynamic GetDatabasesByInstance(int id)
        {
            dynamic dbs = new DatabasesController();
            {
                List<string> list = dbs.GetDbsByInstance(id);

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
                Instance myinstance = inst.GetInstanceById(id);

                // Add the Instance object to a new Instance list
                List<Instance> list = new List<Instance>();
                list.Add(myinstance);

                // Remove the special characters from the database name, which should't be used any way!!!
                string transformedname = Transformer.RemoveSpecialCharacters(name);

                // Rename EF columns to Rundeck style
                Func<Instance, JObject> objToJson =
                    o => new JObject(
                            new JProperty("name", o.sourcesavesetpath + "\\SQLRefreshDB_" + transformedname + ".BAK"),
                            new JProperty("value", o.sourcesavesetpath + "\\SQLRefreshDB_" + transformedname + ".BAK"));

                return Json(new JArray(list.Select(objToJson)));
            }
        }

        // Return destination saveset path for the backup
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

        // Return True/False because it's a hassle in rundeck to do name/value pairs
        public dynamic GetBoolean()
        {
            string strJSON = "[{\"name\":\"True\", \"value\":\"1\"}, {\"name\":\"False\", \"value\":\"0\"}]";
            JArray rows = JArray.Parse(strJSON);
            return Json(rows);
        }

        public HttpResponseMessage GetOops()
        {
            logger.Info("Getting an oopsie");
            throw new Exception("Ooopsie!");
        }
    }
}