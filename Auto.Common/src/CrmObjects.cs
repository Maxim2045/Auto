using Microsoft.Xrm.Sdk;
using System;

namespace Auto.Common.src
{
    public class CrmObjects
    {
        public IServiceProvider ServiceProvider { get; set; }
        public ITracingService TracingService { get; set; }
        public IPluginExecutionContext PluginContext { get; set; }
        public IOrganizationService Service { get; set; }

        public Entity Target
        {
            get { return (Entity)PluginContext.InputParameters["Target"]; }
        }

        public EntityReference TargetRef
        {
            get { return (EntityReference)PluginContext.InputParameters["Target"]; }
        }
    }
}
