using Auto.Common.src;
using Auto.Common.src.Entities;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System.Linq;

namespace Auto.Workflows.AgreementActivities.InvoiceFullPayHelpers
{
    public class InvoiceFullPaymHelper
    {
        private readonly ActivityObjects activityObjects;
        public InvoiceFullPaymHelper(ActivityObjects activityObjects)
        {
            this.activityObjects = activityObjects;
        }
        /// <summary>
        /// Проверка на имеющиеся счета у договора
        /// </summary>
        /// <param name="agreementReference"></param>
        /// <returns></returns>
        public bool HasAgreementInvoice(EntityReference agreementReference)
        {
            QueryExpression query = new QueryExpression(nav_invoice.EntityLogicalName);
            query.ColumnSet = new ColumnSet(nav_invoice.Fields.nav_name);
            query.NoLock = true;
            query.TopCount = 1000;
            query.Criteria.AddCondition(nav_invoice.Fields.nav_dogovorid, ConditionOperator.Equal, agreementReference.Id);

         
            var result = activityObjects.Service.RetrieveMultiple(query).Entities;

            if (result.Any())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
