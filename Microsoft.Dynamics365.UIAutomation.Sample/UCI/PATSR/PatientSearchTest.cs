using System;
using System.Security;
using System.Threading;
using Microsoft.Dynamics365.UIAutomation.Api.UCI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Dynamics365.UIAutomation.Sample;
using OpenQA.Selenium;
using Microsoft.Dynamics365.UIAutomation.Browser;


namespace Microsoft.Dynamics365.UIAutomation.Sample.UCI.PatientSearch
{
    [TestClass]
    public class PatientSearchTest
    {

        private readonly SecureString _username = System.Configuration.ConfigurationManager.AppSettings["OnlineUsername"].ToSecureString();
        private readonly SecureString _password = System.Configuration.ConfigurationManager.AppSettings["OnlinePassword"].ToSecureString();
        private readonly Uri _xrmUri = new Uri(System.Configuration.ConfigurationManager.AppSettings["OnlineCrmUrl"].ToString());

        [TestMethod]
        public void AutomatePatientSearch()
        {
         var client = new WebClient(TestSettings.Options);
            using (var xrmApp = new XrmApp(client))
            {
                xrmApp.OnlineLogin.Login(_xrmUri, _username, _password);

                Thread.Sleep(10000);

                xrmApp.Navigation.OpenApp("PATS-R");

                xrmApp.Navigation.OpenSubArea("Service", "Patient Search");

                Thread.Sleep(10000);
                //Perform MVI Search
                xrmApp.Entity.PatientSearch();


                /*

                //Add New Case
                Thread.Sleep(10000);

                xrmApp.Entity.AddCase();
                Thread.Sleep(10000);
                xrmApp.Entity.SetValue("veo_description", "Test Case");
                xrmApp.Entity.Save();

                ////Assert case is added
                Thread.Sleep(15000);
                //Go to Case history tab
                xrmApp.Entity.SwitchTab("Claim");

                //    //Verify case is crated
                //    //var cases = xrmApp.Grid.GetGridItems().ToString();
                //    //if (!(cases.Contains("Case Created")))
                //    //{ Assert.Fail("Case not created"); }


                //    ////Add Request
                Thread.Sleep(5000);
                xrmApp.Entity.AddRequest();
                Thread.Sleep(5000);

                xrmApp.QuickCreate.SetValue("id-d44f94cf-f72d-43cf-986b-ab74fc888e4c-2-description", "Test Request");
                //    xrmApp.QuickCreate.SetValue(new LookupItem { Name = "patsr_requestfacility", Value = "629 - New Orleans" });
                //  xrmApp.QuickCreate.SetValue(new LookupItem { Name = "patsr_requestsubfacility", Value = "" });
                xrmApp.QuickCreate.SetValue(new OptionSet() { Name = "id-d44f94cf-f72d-43cf-986b-ab74fc888e4c-13-patsr_prioritycode", Value = "1 - Crisis" });
                xrmApp.QuickCreate.Save();
                Thread.Sleep(10000);


                //    ////Verify request is crated
                //    ////var req = xrmApp.Grid.GetGridItems().ToString();
                //    ////if (!(cases.Contains("Test Request")))
                //    ////{ Assert.Fail("Request not created"); }



                ////assert request is added
                //Go to veteran tab and assert
                xrmApp.Entity.SwitchTab("Veteran");
                Thread.Sleep(3000);
                //Go to Medical tab and assert
                xrmApp.Entity.SwitchTab("Medical");
                Thread.Sleep(3000);
                */
            }
        }
        

    }
}
