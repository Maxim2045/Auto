using Auto.Common.src;
using Auto.Workflows.AgreementActivities.PayScheduleHelpers;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Workflow;
using System;
using System.Activities;

namespace Auto.Workflows.AgreementActivities
{
    public class PaysScheduleActivity : BaseActivity
    {
        [Input("Agreement")]
        [RequiredArgument]
        [ReferenceTarget("nav_agreement")]
        public InArgument<EntityReference> AgreementReference { get; set; }

        public override void ExecuteAcivity(ActivityObjects activityObjects)
        {
            try
            {
                var agreementRef = AgreementReference.Get(activityObjects.Context) ?? throw new InvalidPluginExecutionException("Agreement not set");

                PayScheduleHelper payScheduleHelper = new PayScheduleHelper(activityObjects);
                payScheduleHelper.CreateSchedule(agreementRef);
            }
            catch (Exception ex)
            {

                throw new InvalidPluginExecutionException(ex.Message);
            }
        }
    }
}
