using Auto.Common.src;
using Auto.Common.src.Entities;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto.Workflows.AgreementActivities.PayScheduleHelpers
{
    public class InvoiceHelper
    {
        private readonly ActivityObjects activityObjects;
        public InvoiceHelper(ActivityObjects activityObjects)
        {
            this.activityObjects = activityObjects;
        }
        /// <summary>
        /// Удаление счетов, созданных системой
        /// </summary>
        /// <param name="agreementRef"></param>
        public void DelAutoInvoices(EntityReference agreementRef)
        {

            QueryExpression query = new QueryExpression(nav_invoice.EntityLogicalName);
            query.ColumnSet = new ColumnSet(nav_invoice.Fields.nav_fact, nav_invoice.Fields.nav_type);
            query.NoLock = true;
            query.TopCount = 1000;
            query.Criteria.AddCondition(nav_invoice.Fields.nav_dogovorid, ConditionOperator.Equal, agreementRef.Id);

            var result = activityObjects.Service.RetrieveMultiple(query);
            if (result.Entities != null)
            {
                foreach (var invoice in result.Entities.Select(x => x.ToEntity<nav_invoice>()))
                {
                    if (invoice.nav_type == nav_invoice_nav_type.auto)
                    {
                        activityObjects.Service.Delete(nav_invoice.EntityLogicalName, invoice.Id);
                    }
                }
            }
        }
    }
}
