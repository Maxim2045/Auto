using Auto.Common.src;
using Auto.Plugins.nav_invoice.Handlers;
using Microsoft.Xrm.Sdk;
using System;

namespace Auto.Plugins.nav_invoice
{
    public class PostInvoiceCreate: BasePlugin
    {
        public override void ExecutePlugin(PluginObjects crmObjects)
        {
            try
            {
                AgreementHandler agreementHandler = new AgreementHandler(crmObjects);
                agreementHandler.CreateFactsum();
            }
            catch (Exception ex)
            {
                crmObjects.TracingService.Trace(ex.ToString());

                throw new InvalidPluginExecutionException(ex.Message);
            }
        }
    }
}
