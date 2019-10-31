using System;
using System.Security;
using Microsoft.Dynamics365.UIAutomation.Api;
using Microsoft.Dynamics365.UIAutomation.Api.UCI;
using Microsoft.Dynamics365.UIAutomation.Browser;
using Microsoft.Dynamics365.UIAutomation.Sample.Web;
using Microsoft.Dynamics365.UIAutomation.Sample.Web.PATSR;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Microsoft.Dynamics365.UIAutomation.Sample.UCI.PATSR
{
    [TestClass]
    public class AnonymousCaseTest
    {
        PersonaSwitch personaSwitcher = new PersonaSwitch();

        private readonly SecureString _username = System.Configuration.ConfigurationManager.AppSettings["OnlineUsername"].ToSecureString();
        private readonly SecureString _password = System.Configuration.ConfigurationManager.AppSettings["OnlinePassword"].ToSecureString();
        private readonly Uri _xrmUri = new Uri(System.Configuration.ConfigurationManager.AppSettings["OnlineCrmUrl"].ToString());


        [TestMethod]
        public void AnonymousCaseCreation()
        {
            var client = new WebClient(TestSettings.Options);
            using (var xrmApp = new XrmApp(client))
            {
                xrmApp.OnlineLogin.Login(_xrmUri, _username, _password);

                xrmApp.Navigation.OpenApp("PATS-R");

                xrmApp.Navigation.OpenGroupSubArea("Service", "Anonymous Case");

                xrmApp.Entity.SetValue(new BooleanItem { Name = "patsr_automatedtestfield", Value = true });

                xrmApp.Entity.SetValue("veo_description", "This case was auto created by our automated testing");

                Api.UCI.LookupItem facilityLookup = new Api.UCI.LookupItem { Name = "patsr_requestfacility", Value = "629" };
                xrmApp.Entity.SetValue(facilityLookup);
                xrmApp.ThinkTime(3000);

                //This method doesn't work on the customerid field at the moment. Requires a fix on the EasyRepro API PG is reviewing it
                //xrmApp.Entity.SetValue(new LookupItem[] { new LookupItem { Name = "customerid", Value = "Allison B" } });

                xrmApp.ThinkTime(3000);
                xrmApp.Entity.SetValue("patsr_contactingentitynames", "Automated Test Patient");

                xrmApp.Entity.SetValue("patsr_callbacknumber", "555-867-5309");

                xrmApp.Entity.Save();

               
                //working code for clicking on any subgrid button
                xrmApp.ThinkTime(3000);
                xrmApp.Entity.ClickSubgridButton("Contacting Entities ", "New Contacting Entity");

                //need remaining logic for editing the quick create record
                //xrmApp.QuickCreate.SetValue(new OptionSet { Name="patsr_contactingentity", Value="Veteran"});
                xrmApp.QuickCreate.SetValue("patsr_name", "Automated Veteran");
                xrmApp.QuickCreate.SetValue("patsr_phonenumber", "111-222-3333");
                xrmApp.QuickCreate.SetValue("patsr_contactingentitydetail", "This is a contacting entity made by our automated testing");
                //personaSwitcher.switchToPARole();


            }
        }

    }
}
