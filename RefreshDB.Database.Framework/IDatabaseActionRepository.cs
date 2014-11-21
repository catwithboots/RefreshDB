using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefreshDB.Database.Framework
{
    public interface IDatabaseActionRepository
    {
        // Environment interfaces
        IQueryable<Environment> GetAllEnvironments();
        Environment GetEnvironmentById(int environmentid);

        // Script interfaces
        IQueryable<Script> GetAllScripts();
        Script GetScriptById(int id);

        // Instances interfaces
        IQueryable<Instance> GetAllInstances();
        Instance GetInstanceById(int id);
        IQueryable<Instance> GetInstanceByEnvironmentId(int environmentid);
    }
}
