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

namespace Auto.Workflows.AgreementActivities
{
    public class InvoiceFullPayActivity: CodeActivity
    {
        [Input("Agreement")]
        [RequiredArgument]
        [ReferenceTarget("nav_agreement")]
        public InArgument<EntityReference> AgreementReference { get; set; }
        [Output("Is paym exist")]
        public OutArgument<bool> IsHasInvoice{ get; set; }
        protected override void Execute(CodeActivityContext context)
        {
            var serviceFactory = context.GetExtension<IOrganizationServiceFactory>() ?? throw new InvalidPluginExecutionException();

            var service = serviceFactory.CreateOrganizationService(null) ?? throw new InvalidPluginExecutionException();


            var agreementRef = AgreementReference.Get(context) ?? throw new InvalidPluginExecutionException(); 



            QueryExpression query = new QueryExpression(nav_invoice.EntityLogicalName);
            query.ColumnSet = new ColumnSet(nav_invoice.Fields.nav_name);
            query.NoLock = true;
            query.TopCount = 1000;
            query.Criteria.AddCondition(nav_invoice.Fields.nav_dogovorid, ConditionOperator.Equal, agreementRef.Id);

            //var result = service.RetrieveMultiple(query).Entities.Select(x => x.ToEntity<nav_invoice>())
            //
            var result = service.RetrieveMultiple(query).Entities;

            if (result.Any())
            {
                IsHasInvoice.Set(context, true);
            }
            else
            {
                IsHasInvoice.Set(context, false);
            }


        }
    }
}
