using Auto.Common.src.Entities;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk.Workflow;
using System;
using System.Activities;
using System.Linq;

namespace Auto.Workflows.AgreementActivities
{
    public class PaysScheduleActivity : CodeActivity
    {
        [Input("Agreement")]
        [RequiredArgument]
        [ReferenceTarget("nav_agreement")]
        public InArgument<EntityReference> AgreementReference { get; set; }

        protected override void Execute(CodeActivityContext context)
        {

            var serviceFactory = context.GetExtension<IOrganizationServiceFactory>() ?? throw new InvalidPluginExecutionException("IOrganizationServiceFactory !!!!!!");

            var service = serviceFactory.CreateOrganizationService(null) ?? throw new InvalidPluginExecutionException("CreateOrganizationService !!!!!!");

            var agreementRef = AgreementReference.Get(context) ?? throw new InvalidPluginExecutionException("Get context !!!!!!");

            var tracingService = context.GetExtension<ITracingService>();

            //tracingService.Trace("000000000000000!!!!!!!!!!!!!");

            var agreementFromCrm = service.Retrieve(nav_agreement.EntityLogicalName, agreementRef.Id, new ColumnSet(true))
                ?? throw new InvalidPluginExecutionException("agreementFromCrm is null");

          //  tracingService.Trace("111111111111111!!!!!!!!!!!!!");
            DelAutoInvoices(service, agreementRef);

           // tracingService.Trace("222222222222222222!!!!!!!!!!!!!");
            var agreement = agreementFromCrm.ToEntity<nav_agreement>();

            int countInvoices = 5;
            //int.Parse((Convert.ToInt32(agreement.nav_creditperiod ?? 0) * 12).ToString());

           // tracingService.Trace("3333333333333333333333!!!!!!!!!!!!!");

            DateTime date = DateTime.Now;
            DateTime firstDayOfMonth = new DateTime(date.Year, date.Month, 1);

            decimal sumpayPerMonth = (agreement.nav_summa == null ? 0 : agreement.nav_summa.Value) / countInvoices;

            // tracingService.Trace("4444444444444444444444444!!!!!!!!!!!!!");


            // nav_invoice nav_Invoice = new nav_invoice();
            // nav_Invoice.nav_name = $"Платеж {firstDayOfMonth}";
            // nav_Invoice.nav_type = nav_invoice_nav_type.auto;
            // nav_Invoice.nav_amount = new Money(sumpayPerMonth);
            // nav_Invoice.nav_dogovorid = agreementRef;
            // nav_Invoice.OwnerId = agreement.OwnerId;
            // nav_Invoice.nav_date = DateTime.Now;
            // nav_Invoice.nav_paydate = DateTime.Now;
            // var id = service.Create(nav_Invoice);

            // Entity newInvoice = new Entity("nav_invoice");
            // newInvoice["nav_name"] = $"Платеж {firstDayOfMonth}";
            // var id = service.Create(newInvoice);

            for (int i = 0; i < countInvoices; i++)
            {
                firstDayOfMonth = firstDayOfMonth.AddMonths(1);
                nav_invoice nav_Invoice = new nav_invoice();
                nav_Invoice.nav_name = $"Платеж {firstDayOfMonth}";
                nav_Invoice.nav_type = nav_invoice_nav_type.auto;
                nav_Invoice.nav_amount = new Money(sumpayPerMonth);
                nav_Invoice.nav_dogovorid = agreementRef;
                nav_Invoice.OwnerId = agreement.OwnerId;
                nav_Invoice.nav_date = DateTime.Now;
                nav_Invoice.nav_paydate = firstDayOfMonth;
                var id = service.Create(nav_Invoice);
            }
            nav_agreement ag = new nav_agreement();
            ag.Id = agreement.Id;
            ag.nav_paymentplandate = DateTime.Now.AddDays(1);
            service.Update(ag);
        }


        private void DelAutoInvoices(IOrganizationService service, EntityReference agreementRef)
        {

            QueryExpression query = new QueryExpression(nav_invoice.EntityLogicalName);
            query.ColumnSet = new ColumnSet(nav_invoice.Fields.nav_fact, nav_invoice.Fields.nav_type);
            query.NoLock = true;
            query.TopCount = 1000;
            query.Criteria.AddCondition(nav_invoice.Fields.nav_dogovorid, ConditionOperator.Equal, agreementRef.Id);

            //  var result = service.RetrieveMultiple(query).Entities; //.Select(x => x.ToEntity<nav_invoice>())



            var result = service.RetrieveMultiple(query);
            if (result.Entities != null)
            {
                foreach (var invoice in result.Entities.Select(x => x.ToEntity<nav_invoice>()))
                {
                    if (invoice.nav_type == nav_invoice_nav_type.auto)
                    {
                        service.Delete(nav_invoice.EntityLogicalName, invoice.Id);
                    }
                }
            }
        }
    }
}
