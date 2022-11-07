using Auto.Common.src;
using Auto.Workflows.AgreementActivities.ValidatePayScheduleCreateHelpers;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Workflow;
using System;
using System.Activities;

namespace Auto.Workflows.AgreementActivities
{
    public class ValidatePaysScheduleCreateActivity : BaseActivity
    {
        [Input("Agreement")]
        [RequiredArgument]
        [ReferenceTarget("nav_agreement")]
        public InArgument<EntityReference> AgreementReference { get; set; }
        [Output("Validated")]
        public OutArgument<bool> IsValid { get; set; }
        public override void ExecuteAcivity(ActivityObjects activityObjects)
        {
            try
            {

                var agreementRef = AgreementReference.Get(activityObjects.Context) ?? throw new InvalidPluginExecutionException("Agreement not set");

                ValidatePayScheduleCreateHelper validatePayScheduleCreateHelper = new ValidatePayScheduleCreateHelper(activityObjects);

                bool isValid = validatePayScheduleCreateHelper.Validate(agreementRef);

                IsValid.Set(activityObjects.Context, isValid);
            }
            catch (Exception ex)
            {

                throw new InvalidPluginExecutionException(ex.Message);
            }

        }
    }
}
