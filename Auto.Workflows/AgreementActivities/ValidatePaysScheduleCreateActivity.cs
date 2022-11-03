using Microsoft.Xrm.Sdk.Workflow;
using Microsoft.Xrm.Sdk;
using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auto.Common.src.Entities;
using Microsoft.Xrm.Sdk.Query;

namespace Auto.Workflows.AgreementActivities
{
    public class ValidatePaysScheduleCreateActivity : CodeActivity
    {
        [Input("Agreement")]
        [RequiredArgument]
        [ReferenceTarget("nav_agreement")]
        public InArgument<EntityReference> AgreementReference { get; set; }
        [Output("Validated")]
        public OutArgument<bool> IsValid { get; set; }
        protected override void Execute(CodeActivityContext context)
        {
            var serviceFactory = context.GetExtension<IOrganizationServiceFactory>() ?? throw new InvalidPluginExecutionException();

            var service = serviceFactory.CreateOrganizationService(null) ?? throw new InvalidPluginExecutionException();
       
                var tracingService = context.GetExtension<ITracingService>();


            var agreementRef = AgreementReference.Get(context) ?? throw new InvalidPluginExecutionException();

          //  tracingService.Trace("1 !!!!!");


            QueryExpression query = new QueryExpression(nav_invoice.EntityLogicalName);
            query.ColumnSet = new ColumnSet(nav_invoice.Fields.nav_fact, nav_invoice.Fields.nav_type);
            query.NoLock = true;
            query.TopCount = 1000;
            query.Criteria.AddCondition(nav_invoice.Fields.nav_dogovorid, ConditionOperator.Equal, agreementRef.Id);

            //  var result = service.RetrieveMultiple(query).Entities.Select(x => x.ToEntity<nav_invoice>())
            //      ?? throw new InvalidPluginExecutionException("result is null");

            var result = service.RetrieveMultiple(query).Entities;

         //   tracingService.Trace("2 !!!!!");

            if (result != null)
            {

                tracingService.Trace("3 !!!!!");
                if (result.Select(x => x.ToEntity<nav_invoice>()).Where(x => x.nav_type == nav_invoice_nav_type.manual || (x.nav_fact ?? false)).Any())
                {
                    IsValid.Set(context, false);
                    tracingService.Trace("4 !!!!!");
                }
                else
                {
                    IsValid.Set(context, true);
                }
            }
            else
            {
                IsValid.Set(context, true);
            }
        }
    }
}
