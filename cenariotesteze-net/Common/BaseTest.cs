using Coypu;
using Coypu.Drivers.Selenium;
using NUnit.Framework;
using System;
using System.IO;
using System.Threading;


namespace Zedelivery.Common
{
    public class BaseTest
    {
        protected BrowserSession Browser;

        [SetUp]
        public void Setup()
        {
            var configs = new SessionConfiguration
            {
                AppHost = "https://www.ze.delivery",
                SSL = true,
                Driver = typeof(SeleniumWebDriver),
                Browser = Coypu.Drivers.Browser.Chrome,
                Timeout = TimeSpan.FromSeconds(10)

            };

            Browser = new BrowserSession(configs);

            Browser.MaximiseWindow();
        }

        public void Takescreenshot()
        {
            var resultId = TestContext.CurrentContext.Test.ID;
            var shotPath = Environment.CurrentDirectory + "\\Screenshots";

            if(!Directory.Exists(shotPath))
            {
                Directory.CreateDirectory(shotPath);
            }

            var screenshot = $"{shotPath}\\{resultId}.png";
            
            Browser.SaveScreenshot(screenshot);
            TestContext.AddTestAttachment(screenshot);

        }

        [TearDown]
        public void Finish()
        {
            try
            {
                Takescreenshot();
            }
            catch (Exception e)
            {
                Console.WriteLine("Ocorreu um erro na captura do screenshot");
                throw new Exception(e.Message);
            }
            finally
            {
                Browser.Dispose();
            }

                      
        }
    }



}