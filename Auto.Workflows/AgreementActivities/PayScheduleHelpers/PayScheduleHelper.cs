using Auto.Common.src;
using Auto.Common.src.Entities;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;

namespace Auto.Workflows.AgreementActivities.PayScheduleHelpers
{
    public class PayScheduleHelper
    {
        private readonly ActivityObjects activityObjects;
        public PayScheduleHelper(ActivityObjects activityObjects)
        {
            this.activityObjects = activityObjects;
        }
        /// <summary>
        /// Создание графика платежей
        /// </summary>
        /// <param name="agreementRef"></param>
        /// <exception cref="InvalidPluginExecutionException"></exception>
        public void CreateSchedule(EntityReference agreementRef)
        {

            var agreementFromCrm = activityObjects.Service.Retrieve(nav_agreement.EntityLogicalName, agreementRef.Id, new ColumnSet(true))
                ?? throw new InvalidPluginExecutionException("agreementFromCrm is null");

            InvoiceHelper invoiceHelper = new InvoiceHelper(activityObjects);
            invoiceHelper.DelAutoInvoices(agreementRef);

            var agreement = agreementFromCrm.ToEntity<nav_agreement>();

            //задал статично создание 5-ти записей, чтобы не плодить записи при тестах
            int countInvoices = 5; //int.Parse((Convert.ToInt32(agreement.nav_creditperiod ?? 0) * 12).ToString()); 

            DateTime date = DateTime.Now;
            DateTime firstDayOfMonth = new DateTime(date.Year, date.Month, 1);

            decimal sumpayPerMonth = (agreement.nav_summa == null ? 0 : agreement.nav_summa.Value) / countInvoices;
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
                var id = activityObjects.Service.Create(nav_Invoice);
            }
            nav_agreement ag = new nav_agreement();
            ag.Id = agreement.Id;
            ag.nav_paymentplandate = DateTime.Now.AddDays(1);
            activityObjects.Service.Update(ag);
        }

    }
}
