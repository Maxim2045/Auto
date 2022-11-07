using Auto.Common.src;
using Auto.Common.src.Entities;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;

namespace Auto.Plugins.nav_agreement.AgreementHandler
{
    public class ContactHandler
    {
        private readonly PluginObjects crmObjects;
        public ContactHandler(PluginObjects crmObjects)
        {
            this.crmObjects = crmObjects;
        }
        public void SetFirstAgreementDate()
        {
            var agreement = crmObjects.Target.ToEntity<Common.src.Entities.nav_agreement>();
            var contactFromCrm = crmObjects.Service.Retrieve("contact", agreement.nav_contact.Id, new ColumnSet(Contact.Fields.nav_date))
                ?? throw new InvalidPluginExecutionException("contactFromCrm is null");

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
