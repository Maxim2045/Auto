using Auto.Common.src;
using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auto.Common.src.Entities;

namespace Auto.Plugins.nav_invoice.Handlers
{
    public class InvoiceHandler
    {
        private readonly CrmObjects crmObjects;
        public InvoiceHandler(CrmObjects crmObjects)
        {
            this.crmObjects = crmObjects;
        }
        public void SetDefaultInvoiceType()
        {
            var invoice = crmObjects.Target.ToEntity<Common.src.Entities.nav_invoice>();
            if(invoice.nav_type == null)
            {
                invoice.nav_type = nav_invoice_nav_type.__808630000;
            }
        }
    }
}
