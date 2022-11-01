using Auto.Common.src.Entities;
using Auto.Common.src;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk.Query;
using System.Security.Principal;

namespace Auto.Plugins.nav_agreement.AgreementHandler
{
    public class ContactHandler
    {
        private readonly CrmObjects crmObjects;
        public ContactHandler(CrmObjects crmObjects)
        {
            this.crmObjects = crmObjects;
        }
        public void SetFirstAgreementDate()
        {
            var agreement = crmObjects.Target.ToEntity<Common.src.Entities.nav_agreement>();
            var contactFromCrm = crmObjects.Service.Retrieve("contact", agreement.nav_contact.Id, new ColumnSet(Contact.Fields.nav_date));

            if (contactFromCrm.ToEntity<Contact>().nav_date == null)
            {
                Contact contact = new Contact
                {
                    Id = contactFromCrm.Id,
                    nav_date = agreement.nav_date
                };

                crmObjects.Service.Update(contact);
            }
        }
    }
}
