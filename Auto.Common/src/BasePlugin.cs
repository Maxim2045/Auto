using Microsoft.Xrm.Sdk;
using System;

namespace Auto.Common.src
{
    /// <summary>
    /// Base realise plugin interface with current user service
    /// </summary>
    public abstract class BasePlugin : IPlugin
    {
        public void Execute(IServiceProvider serviceProvider)
        {

            var crmObjects = new CrmObjects();



            crmObjects.ServiceProvider = serviceProvider;
            crmObjects.TracingService = (ITracingService)serviceProvider.GetService(typeof(ITracingService));

            crmObjects.PluginContext = (IPluginExecutionContext)serviceProvider.GetService(typeof(IPluginExecutionContext));

            IOrganizationServiceFactory serviceFactory = (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));
            crmObjects.Service = serviceFactory.CreateOrganizationService(Guid.Empty);

            ExecutePlugin(crmObjects);

        }

        public virtual void ExecutePlugin(CrmObjects crmObjects)
        {

            throw new InvalidPluginExecutionException();

        }
    }
}
