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

namespace RefreshDB.WebAPI.Backend.Controllers
{
    public class RundeckController : ApiController
    {
        public dynamic GetAllEnvironments()
        {
            dynamic env = new EnvironmentsController();
            {

                List<RefreshDB.Database.Framework.Environment> list = env.Get();

                Func<RefreshDB.Database.Framework.Environment, JObject> objToJson =
                    o => new JObject(
                            new JProperty("name", o.name),
                            new JProperty("value", o.id));

                string result = new JObject(new JArray(list.Select(objToJson))).ToString();

                return Json(result);
            }
        }
    }
}
