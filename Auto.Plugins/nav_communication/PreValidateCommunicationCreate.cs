using Auto.Common.src;
using Auto.Plugins.nav_communication.Handlers;
using Microsoft.Xrm.Sdk;
using System;

namespace Auto.Plugins.nav_communication
{
    public class PreValidateCommunicationCreate: BasePlugin
    {
        public override void ExecutePlugin(PluginObjects crmObjects)
        {
            try
            {
                CommunicationHandler communicationHandler = new CommunicationHandler(crmObjects);
                communicationHandler.ValidateMainForUpdate();
            }
            catch (Exception ex)
            {
                crmObjects.TracingService.Trace(ex.ToString());

                throw new InvalidPluginExecutionException(ex.Message);
            }
        }
    }
}
