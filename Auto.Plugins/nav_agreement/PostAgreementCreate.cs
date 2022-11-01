using Auto.Common.src;
using Auto.Plugins.nav_agreement.AgreementHandler;
using Auto.Plugins.nav_invoice.Handlers;
using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto.Plugins.nav_agreement
{
    public class PostAgreementCreate: BasePlugin
    {
        public override void ExecutePlugin(CrmObjects crmObjects)
        {

            try
            {
                ContactHandler contactHandler = new ContactHandler(crmObjects);
                contactHandler.SetFirstAgreementDate();
            }
            catch (Exception ex)
            {
                crmObjects.TracingService.Trace(ex.ToString());

                throw new InvalidPluginExecutionException(ex.Message);
            }
        }
    }
}
