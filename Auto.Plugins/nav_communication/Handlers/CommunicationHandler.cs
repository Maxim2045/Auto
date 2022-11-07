using Auto.Common.src;
using Auto.Common.src.Entities;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System.Collections.Generic;
using System.Linq;
using com = Auto.Common.src.Entities.nav_communication;

namespace Auto.Plugins.nav_communication.Handlers
{
    public class CommunicationHandler
    {
        private readonly PluginObjects crmObjects;
        public CommunicationHandler(PluginObjects crmObjects)
        {
            this.crmObjects = crmObjects;
        }
        public void ValidateMain()
        {
            var communication = crmObjects.Target.ToEntity<com>();

            var message = crmObjects.PluginContext.MessageName.ToUpper();
            switch (message)
            {
                case "CREATE":
                    var resC = GetAllCommunicationFromUser(communication);
                    if (communication.nav_main == true)
                    {
                        if (resC.Count(x => x.nav_type == communication.nav_type && x.nav_main == communication.nav_main) >= 1)
                        {
                            throw new InvalidPluginExecutionException($"Срество связи с основным {communication.nav_type.Value} уже имеется");
                        }
                    }
                    break;
                case "UPDATE":

                    var comFromCrm = crmObjects.Service.Retrieve("nav_communication", communication.Id, new ColumnSet(com.Fields.nav_type, com.Fields.nav_main, com.Fields.nav_contactid)).ToEntity<com>()
                        ?? throw new InvalidPluginExecutionException("comFromCrm is null");
                    var resU = GetAllCommunicationFromUser(comFromCrm);

                    if (communication.nav_main == true)
                    {

                        if (resU.Count(x => x.nav_type == comFromCrm.nav_type && x.nav_main == communication.nav_main) >= 1)
                        {
                            throw new InvalidPluginExecutionException($"Срество связи с основным {comFromCrm.nav_type.Value} уже имеется"); // надо бы получить название типа
                        }
                        
                    }
                    break;
            }
        
        }
        private IEnumerable<com> GetAllCommunicationFromUser(com communication)
        {
            crmObjects.TracingService.Trace("Execute GetAllCommunicationFromUser");

            QueryExpression query = new QueryExpression(com.EntityLogicalName);
            query.ColumnSet = new ColumnSet(com.Fields.nav_type, com.Fields.nav_main);
            query.NoLock = true;
            query.TopCount = 1000;
            //query.Criteria.AddFilter()
            query.Criteria.AddCondition(com.Fields.nav_contactid, ConditionOperator.Equal, communication.nav_contactid.Id);

            var result = crmObjects.Service.RetrieveMultiple(query).Entities.Select(x => x.ToEntity<com>())
                ?? throw new InvalidPluginExecutionException("GetAllCommunicationFromUser result is null");
            crmObjects.TracingService.Trace("Return result GetAllCommunicationFromUser");

            return result;
        }
    }
}
