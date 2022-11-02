using Auto.Common.src;
using Auto.Plugins.nav_communication.Handlers;
using Auto.Plugins.nav_invoice.Handlers;
using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto.Plugins.nav_communication
{
    public class PreValidateCommunicationCU: BasePlugin
    {
        public override void ExecutePlugin(CrmObjects crmObjects)
        {
            try
            {
                CommunicationHandler communicationHandler = new CommunicationHandler(crmObjects);
                communicationHandler.ValidateMain();
            }
            catch (Exception ex)
            {
                crmObjects.TracingService.Trace(ex.ToString());

                throw new InvalidPluginExecutionException(ex.Message);
            }
        }
    }
}
