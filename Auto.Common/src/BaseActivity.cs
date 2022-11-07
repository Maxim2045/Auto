using Microsoft.Xrm.Sdk;
using System.Activities;

namespace Auto.Common.src
{
    public abstract class BaseActivity: CodeActivity
    {
        protected override void Execute(CodeActivityContext context)
        {

            var acivityObjects = new ActivityObjects();

            acivityObjects.Context = context;

            var serviceFactory = context.GetExtension<IOrganizationServiceFactory>() ?? throw new InvalidPluginExecutionException();

            acivityObjects.ServiceFactory = serviceFactory;

            acivityObjects.Service = serviceFactory.CreateOrganizationService(null) ?? throw new InvalidPluginExecutionException();

            ExecuteAcivity(acivityObjects);

        }

        public virtual void ExecuteAcivity(ActivityObjects activityObjects)
        {

            throw new InvalidPluginExecutionException();

        }
    }
}
