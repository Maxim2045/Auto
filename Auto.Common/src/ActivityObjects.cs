using Microsoft.Xrm.Sdk;
using System.Activities;

namespace Auto.Common.src
{
    public class ActivityObjects
    {
        public CodeActivityContext Context { get; set; } 
        public IOrganizationServiceFactory ServiceFactory { get; set; }

        public IOrganizationService Service { get; set; }   

    }
}
