using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefreshDB.Database.Framework
{
    public class DatabaseActionRepository : IDatabaseActionRepository
    {
        private RefreshDBEntities _ctx;

        public DatabaseActionRepository(RefreshDBEntities ctx)
        {
            _ctx = ctx;
        }

        // Environment Actions
        public IQueryable<Environment> GetAllEnvironments()
        {
            return _ctx.Environments.AsQueryable();
        }

        public Environment GetEnvironmentById(int environmentid)
        {
            return _ctx.Environments.Find(environmentid);
        }

        // Script Actions
        public IQueryable<Script> GetAllScripts()
        {
            return _ctx.Scripts.AsQueryable();
        }

        public Script GetScriptById(int id)
        {
            return _ctx.Scripts.Find(id);
        }

        // Instances Actions
        public IQueryable<Instance> GetAllInstances()
        {
            return _ctx.Instances.AsQueryable();
        }

        public Instance GetInstanceById(int id)
        {
            return _ctx.Instances.Find(id);
        }

        public IQueryable<Instance> GetInstanceByEnvironmentId(int environmentid)
        {
            return _ctx.Instances.Where(c => c.environment_id == environmentid);
        }
    }
}
