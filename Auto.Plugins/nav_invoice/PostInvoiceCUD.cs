using Auto.Common.src;
using Auto.Plugins.nav_agreement.AgreementHandler;
using Auto.Plugins.nav_invoice.Handlers;
using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto.Plugins.nav_invoice
{
    public class PostInvoiceCUD: BasePlugin
    {
        public override void ExecutePlugin(PluginObjects crmObjects)
        {
            try
            {
                AgreementHandler agreementHandler = new AgreementHandler(crmObjects);
                agreementHandler.SetFactsum();
            }
            catch (Exception ex)
            {
                crmObjects.TracingService.Trace(ex.ToString());

                throw new InvalidPluginExecutionException(ex.Message);
            }
        }
    }
}
