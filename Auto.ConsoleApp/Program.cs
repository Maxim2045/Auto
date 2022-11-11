using Auto.Common.src.Entities;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Tooling.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Auto.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            //AppId и RedirectUri взял с msdn
            string conectionString = "AuthType=OAuth; Url=https://orgee44da84.crm4.dynamics.com/;UserName=MaximPolikarpov@Novicon987.onmicrosoft.com; Password=Scarecrow07; RequireNewInstance=true; AppId=51f81489-12ee-4a9e-aaae-a2591f45987d; RedirectUri=app://58145B91-0C36-4500-8554-080854F2AC97";
            CrmServiceClient client = new CrmServiceClient(conectionString);
            if (client.LastCrmException != null)
            {
                Console.WriteLine(client.LastCrmException.Message);
            }
            else
            {
                Console.WriteLine(client.OrganizationDetail.EnvironmentId);
            }

            var service = (IOrganizationService)client;

            QueryExpression query = new QueryExpression(nav_agreement.EntityLogicalName);
            query.ColumnSet = new ColumnSet(nav_agreement.Fields.nav_date);
            query.NoLock = true;
            //query.TopCount = 20;
            //query.Criteria.AddCondition(Account.Fields.Name, ConditionOperator.NotNull);

           // var link = query.AddLink(SystemUser.EntityLogicalName, Account.Fields.OwnerId, SystemUser.Fields.SystemUserId);
           // link.EntityAlias = "su";
           // link.Columns = new ColumnSet(SystemUser.Fields.FullName);

            var result = service.RetrieveMultiple(query);

            foreach (var entity in result.Entities.Select(x => x.ToEntity<nav_agreement>()))
            {
                Console.WriteLine($"{entity.Id} {entity.nav_name}");

                //var ownerRef = entity.OwnerId;
                //
                //var fullnameAliased = (string)entity.GetAttributeValue<AliasedValue>($"{link.EntityAlias}.{SystemUser.Fields.FullName}").Value;
                //
                //Console.WriteLine($">{fullnameAliased}");
                entity.nav_month = entity.nav_date.Value.Month;
                service.Update(entity);
            }

        //    nav_building building = new nav_building();
        //    building.nav_floors = 101;
        //    building.nav_developerid = result.Entities.FirstOrDefault()?.ToEntityReference();
        //    building.nav_name = "test object " + DateTime.Now;
        //
        //    var id = service.Create(building);
        //
        //    var buildingFromCrm = service.Retrieve("nav_building", id, new ColumnSet(true));
        //
        //    nav_building buildingToUpdate = new nav_building();
        //    buildingToUpdate.Id = id;
        //    buildingToUpdate.nav_floors = 15;

        //    service.Update(buildingToUpdate);

            // service.Delete(buildingToUpdate.LogicalName, id);


            Console.ReadKey();
        }
    }
}
