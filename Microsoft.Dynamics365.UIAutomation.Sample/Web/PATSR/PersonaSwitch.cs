using System;
using System.Security;
using Microsoft.Dynamics365.UIAutomation.Api.UCI;
using Microsoft.Dynamics365.UIAutomation.Browser;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Microsoft.Dynamics365.UIAutomation.Sample.Web.PATSR
{
    [TestClass]
    public class PersonaSwitch
    {

        private readonly SecureString _username = System.Configuration.ConfigurationManager.AppSettings["OnlineUsername"].ToSecureString();
        private readonly SecureString _password = System.Configuration.ConfigurationManager.AppSettings["OnlinePassword"].ToSecureString();
        private readonly Uri _xrmUri = new Uri(System.Configuration.ConfigurationManager.AppSettings["OnlineCrmUrl"].ToString());

        [TestMethod]
        public void switchToPARole()
        {
            var client = new WebClient(TestSettings.Options);
            using (var xrmBrowser = new Api.Browser(TestSettings.Options))
            {
                xrmBrowser.LoginPage.Login(_xrmUri, _username, _password);
                xrmBrowser.GuidedHelp.CloseGuidedHelp();

                xrmBrowser.ThinkTime(500);
                xrmBrowser.Navigation.OpenSubArea("Settings", "Personas");

                //open up PA Persona to switch
                xrmBrowser.ThinkTime(1000);
                xrmBrowser.Grid.OpenRecord(0);

                xrmBrowser.Entity.SetValue(new Api.TwoOption { Name = "veo_makeitso", Value = "true" });

                xrmBrowser.Entity.Save();

            }
        }

        [TestMethod]
        public void switchToPASuperRole()
        {
            var client = new WebClient(TestSettings.Options);
            using (var xrmBrowser = new Api.Browser(TestSettings.Options))
            {
                xrmBrowser.LoginPage.Login(_xrmUri, _username, _password);
                xrmBrowser.GuidedHelp.CloseGuidedHelp();

                xrmBrowser.ThinkTime(500);
                xrmBrowser.Navigation.OpenSubArea("Settings", "Personas");

                //open up PA Persona to switch
                xrmBrowser.ThinkTime(1000);
                xrmBrowser.Grid.OpenRecord(1);

                xrmBrowser.Entity.SetValue(new Api.TwoOption { Name = "veo_makeitso", Value = "true" });

                xrmBrowser.Entity.Save();

            }
        }

        [TestMethod]
        public void switchToSLUserRole()
        {
            var client = new WebClient(TestSettings.Options);
            using (var xrmBrowser = new Api.Browser(TestSettings.Options))
            {
                xrmBrowser.LoginPage.Login(_xrmUri, _username, _password);
                xrmBrowser.GuidedHelp.CloseGuidedHelp();

                xrmBrowser.ThinkTime(500);
                xrmBrowser.Navigation.OpenSubArea("Settings", "Personas");

                //open up PA Persona to switch
                xrmBrowser.ThinkTime(1000);
                xrmBrowser.Grid.OpenRecord(3);

                xrmBrowser.Entity.SetValue(new Api.TwoOption { Name = "veo_makeitso", Value = "true" });

                xrmBrowser.Entity.Save();

            }
        }

        [TestMethod]
        public void switchToSLAdvocateRole()
        {
            var client = new WebClient(TestSettings.Options);
            using (var xrmBrowser = new Api.Browser(TestSettings.Options))
            {
                xrmBrowser.LoginPage.Login(_xrmUri, _username, _password);
                xrmBrowser.GuidedHelp.CloseGuidedHelp();

                xrmBrowser.ThinkTime(500);
                xrmBrowser.Navigation.OpenSubArea("Settings", "Personas");

                //open up PA Persona to switch
                xrmBrowser.ThinkTime(1000);
                xrmBrowser.Grid.OpenRecord(2);

                xrmBrowser.Entity.SetValue(new Api.TwoOption { Name = "veo_makeitso", Value = "true" });

                xrmBrowser.Entity.Save();

            }
        }

        [TestMethod]
        public void switchToVPACRole()
        {
            var client = new WebClient(TestSettings.Options);
            using (var xrmBrowser = new Api.Browser(TestSettings.Options))
            {
                xrmBrowser.LoginPage.Login(_xrmUri, _username, _password);
                xrmBrowser.GuidedHelp.CloseGuidedHelp();

                xrmBrowser.ThinkTime(500);
                xrmBrowser.Navigation.OpenSubArea("Settings", "Personas");

                //open up PA Persona to switch
                xrmBrowser.ThinkTime(1000);
                xrmBrowser.Grid.OpenRecord(4);

                xrmBrowser.Entity.SetValue(new Api.TwoOption { Name = "veo_makeitso", Value = "true" });

                xrmBrowser.Entity.Save();

            }
        }

    }
}
