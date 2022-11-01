﻿using Auto.Common.src;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;

namespace Auto.Plugins.nav_invoice.Handlers
{
    public class AgreementHandler
    {
        private readonly CrmObjects crmObjects;
        public AgreementHandler(CrmObjects crmObjects)
        {
            this.crmObjects = crmObjects;
        }
        public void SetFactsum()
        {
            var message = crmObjects.PluginContext.MessageName.ToUpper();
            switch (message)
            {
                case "CREATE":
                    crmObjects.TracingService.Trace("0 !!!!");
                    var invoiceC = crmObjects.Target.ToEntity<Common.src.Entities.nav_invoice>();
                    var agreementFromCrmC = crmObjects.Service.Retrieve("nav_agreement", invoiceC.nav_dogovorid.Id, new ColumnSet(Common.src.Entities.nav_agreement.Fields.nav_factsumma,
                                                                                                                                    Common.src.Entities.nav_agreement.Fields.nav_summa));
                    UpdateAgreementFactSum(invoiceC, agreementFromCrmC, message);

                    break;
                case "UPDATE":
                    crmObjects.TracingService.Trace("0 !!!!");
                    var invoiceU = crmObjects.Target.ToEntity<Common.src.Entities.nav_invoice>();
                    var invoiceFromCrmU = crmObjects.Service.Retrieve("nav_invoice", invoiceU.Id, new ColumnSet(Common.src.Entities.nav_invoice.Fields.nav_fact,
                                                                                                                Common.src.Entities.nav_invoice.Fields.nav_dogovorid,
                                                                                                                Common.src.Entities.nav_invoice.Fields.nav_amount));

                    var agreementFromCrmU = crmObjects.Service.Retrieve("nav_agreement", invoiceFromCrmU.ToEntity<Common.src.Entities.nav_invoice>().nav_dogovorid.Id, new ColumnSet(Common.src.Entities.nav_agreement.Fields.nav_factsumma,
                                                                                                                                                                                      Common.src.Entities.nav_agreement.Fields.nav_summa));
                    crmObjects.TracingService.Trace("666 !!!!");
                    UpdateAgreementFactSum(invoiceFromCrmU.ToEntity<Common.src.Entities.nav_invoice>(), agreementFromCrmU, message);

                    break;
                case "DELETE":  // Pre operation ヽ(・∀・)ﾉ
                    var invoiceD = crmObjects.TargetRef;
                    var invoiceFromCrmD = crmObjects.Service.Retrieve("nav_invoice", invoiceD.Id, new ColumnSet(Common.src.Entities.nav_invoice.Fields.nav_fact,
                                                                                                                Common.src.Entities.nav_invoice.Fields.nav_dogovorid,
                                                                                                                Common.src.Entities.nav_invoice.Fields.nav_amount));

                    var agreementFromCrmD = crmObjects.Service.Retrieve("nav_agreement", invoiceFromCrmD.ToEntity<Common.src.Entities.nav_invoice>().nav_dogovorid.Id, new ColumnSet(Common.src.Entities.nav_agreement.Fields.nav_factsumma));
                    UpdateAgreementFactSum(invoiceFromCrmD.ToEntity<Common.src.Entities.nav_invoice>(), agreementFromCrmD, message);

                    break;
            }
        }
        private void UpdateAgreementFactSum(Common.src.Entities.nav_invoice invoice, Entity agreementFromCrm, string message)
        {
            if (invoice.nav_fact != null)
            {
                Common.src.Entities.nav_agreement agreement = new Common.src.Entities.nav_agreement();
                agreement.Id = invoice.nav_dogovorid.Id;
                if (invoice.nav_fact == true && message != "DELETE")
                {
                    var agreemntCrm = agreementFromCrm.ToEntity<Common.src.Entities.nav_agreement>();

                    decimal existSum = agreemntCrm.nav_factsumma == null ? 0 : agreemntCrm.nav_factsumma.Value;
                    decimal inputAmount = invoice.nav_amount == null ? 0 : invoice.nav_amount.Value;
                    decimal agreementSum = agreemntCrm.nav_summa == null ? 0 : agreemntCrm.nav_summa.Value;
                    if (agreementSum > existSum + inputAmount)
                    {
                        agreement.nav_factsumma = new Money(existSum + inputAmount);

                        Common.src.Entities.nav_invoice nav_Invoice = new Common.src.Entities.nav_invoice
                        {
                            Id = invoice.Id,
                            nav_paydate = DateTime.Now
                        };
                        crmObjects.Service.Update(nav_Invoice);
                    }
                    else if(agreementSum == existSum + inputAmount)
                    {
                        agreement.nav_factsumma = new Money(existSum + inputAmount);

                        Common.src.Entities.nav_invoice nav_Invoice = new Common.src.Entities.nav_invoice
                        {
                            Id = invoice.Id,
                            nav_paydate = DateTime.Now
                        };
                        crmObjects.Service.Update(nav_Invoice);

                        agreement.nav_fact = true;
                    }
                    else

                    {
                        throw new InvalidPluginExecutionException("Сумма счетов больше суммы договора");
                    }
                }
                else
                {
                    crmObjects.TracingService.Trace("0 !!!!");
                    decimal existSum = agreementFromCrm.ToEntity<Common.src.Entities.nav_agreement>().nav_factsumma == null ? 0 : agreementFromCrm.ToEntity<Common.src.Entities.nav_agreement>().nav_factsumma.Value;
                    crmObjects.TracingService.Trace("1 !!!!");
                    decimal inputAmount = invoice.nav_amount == null ? 0 : invoice.nav_amount.Value;
                    crmObjects.TracingService.Trace("2 !!!!");
                    agreement.nav_factsumma = new Money(existSum - inputAmount);
                    crmObjects.TracingService.Trace("3 !!!!");
                    agreement.nav_factsumma = agreement.nav_factsumma.Value < 0 ? new Money(0) : agreement.nav_factsumma;
                }

                crmObjects.Service.Update(agreement);
            }
        }
    }
}