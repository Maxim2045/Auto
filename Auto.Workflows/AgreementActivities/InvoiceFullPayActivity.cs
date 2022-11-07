using Microsoft.Xrm.Sdk.Workflow;
using Microsoft.Xrm.Sdk;
using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auto.Common.src.Entities;
using Auto.Common.src;
using Microsoft.Xrm.Sdk.Query;
using Auto.Workflows.AgreementActivities.InvoiceFullPayHelpers;

namespace Auto.Workflows.AgreementActivities
{
    public class InvoiceFullPayActivity : BaseActivity
    {
        [Input("Agreement")]
        [RequiredArgument]
        [ReferenceTarget("nav_agreement")]
        public InArgument<EntityReference> AgreementReference { get; set; }
        [Output("Is paym exist")]
        public OutArgument<bool> HasInvoice { get; set; }
        public override void ExecuteAcivity(ActivityObjects activityObjects)
        {

            try
            {
                var agreementRef = AgreementReference.Get(activityObjects.Context) ?? throw new InvalidPluginExecutionException("Agreement not set");

                InvoiceFullPaymHelper invoiceFullPaym = new InvoiceFullPaymHelper(activityObjects);
                bool hasInvoice = invoiceFullPaym.HasAgreementInvoice(agreementRef);
 
                HasInvoice.Set(activityObjects.Context, hasInvoice);
            }

            catch (Exception ex)
            {

                throw new InvalidPluginExecutionException(ex.Message);
            }
        }


    }
}

