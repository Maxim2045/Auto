using Auto.Common.src;
using Auto.Common.src.Entities;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System.Linq;

namespace Auto.Workflows.AgreementActivities.ValidatePayScheduleCreateHelpers
{
    public class ValidatePayScheduleCreateHelper
    {
        private readonly ActivityObjects activityObjects;
        public ValidatePayScheduleCreateHelper(ActivityObjects activityObjects)
        {
            this.activityObjects = activityObjects;
        }
        /// <summary>
        /// Валидация создания графика платежей
        /// </summary>
        /// <param name="agreementRef"></param>
        /// <returns></returns>
        public bool Validate(EntityReference agreementRef)
        {

            QueryExpression query = new QueryExpression(nav_invoice.EntityLogicalName);
            query.ColumnSet = new ColumnSet(nav_invoice.Fields.nav_fact, nav_invoice.Fields.nav_type);
            query.NoLock = true;
            query.TopCount = 1000;
            query.Criteria.AddCondition(nav_invoice.Fields.nav_dogovorid, ConditionOperator.Equal, agreementRef.Id);


            var result = activityObjects.Service.RetrieveMultiple(query).Entities;


            if (result != null)
            {
                if (result.Select(x => x.ToEntity<nav_invoice>()).Where(x => x.nav_type == nav_invoice_nav_type.manual || (x.nav_fact ?? false)).Any())
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return true;
            }
        }
    }
}
