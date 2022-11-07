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

            var pluginObjects = new PluginObjects();



            pluginObjects.ServiceProvider = serviceProvider;
            pluginObjects.TracingService = (ITracingService)serviceProvider.GetService(typeof(ITracingService)) ?? throw new InvalidPluginExecutionException();

            pluginObjects.PluginContext = (IPluginExecutionContext)serviceProvider.GetService(typeof(IPluginExecutionContext)) ?? throw new InvalidPluginExecutionException();

            IOrganizationServiceFactory serviceFactory = (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory))
                ?? throw new InvalidPluginExecutionException();
            pluginObjects.Service = serviceFactory.CreateOrganizationService(Guid.Empty) ?? throw new InvalidPluginExecutionException();

            ExecutePlugin(pluginObjects);

        }

        public virtual void ExecutePlugin(PluginObjects pluginObjects)
        {

            throw new InvalidPluginExecutionException();

        }
    }
}
