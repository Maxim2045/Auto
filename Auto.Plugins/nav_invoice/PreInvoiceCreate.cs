using Auto.Common.src;
using Auto.Plugins.nav_invoice.Handlers;
using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto.Plugins.nav_invoice
{
    public class PreInvoiceCreate : BasePlugin
    {
        public override void ExecutePlugin(CrmObjects crmObjects)
        {
            try
            {
                InvoiceHandler invoiceHandler = new InvoiceHandler(crmObjects);
                invoiceHandler.SetDefaultInvoiceType();
            }
            catch(Exception ex)
            {
                crmObjects.TracingService.Trace(ex.ToString());

                throw new InvalidPluginExecutionException(ex.Message);
            }
        }
    }
}
