using NUnit.Framework;
using System;
using System.Web;
using System.Text;
using System.Net;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System.Threading;

namespace Test
{
    [TestFixture()]
    public class BrowserstackTest
    {
        private IWebDriver driver;

        [SetUp]
        public void Init()
        {
            //DesiredCapabilities capability = DesiredCapabilities.Chrome();
            //DesiredCapabilities capability = DesiredCapabilities.Android();
            DesiredCapabilities capability = OpenQA.Selenium.Remote.DesiredCapabilities.Android();
            capability.SetCapability("platformName", "ANDROID");
            capability.SetCapability(CapabilityType.Platform, "ANDROID");
            capability.SetCapability("deviceName", "43002623beeda00d");
            capability.SetCapability("app", "chrome");
            //capability.SetCapability("browserstack.user", "USERNAME");
            //capability.SetCapability("browserstack.key", "ACCESS_KEY");

                                        //DesiredCapabilities dc = new DesiredCapabilities();
                                        //DesiredCapabilities dc = OpenQA.Selenium.Remote.DesiredCapabilities.Android();
                                        //dc = DesiredCapabilities.Chrome();
                                        //dc = DesiredCapabilities.Android();
                                        //dc.SetCapability(CapabilityType.Platform, "ANDROID");
                                        //driver.GlobalDriver = new RemoteWebDriver(new Uri(URI), dc);
                                        //driver.GlobalDriver = new RemoteWebDriver(new Uri(URI), DesiredCapabilities.Chrome());

            driver = new RemoteWebDriver(
              new Uri("http://localhost:4444/wd/hub/"), capability //local
              //new Uri("http://10.154.1.49:4444/wd/hub/"), capability //server
            );
        }

        [Test]
        public void TestCase()
        {
            driver.Navigate().GoToUrl("http://www.google.com");
            Thread.Sleep(1000);
            driver.Navigate().GoToUrl("http://www.youtube.com");
            Thread.Sleep(1000);
            driver.Navigate().GoToUrl("http://www.bing.com");
            Thread.Sleep(1000);
            //StringAssert.Contains("Google", driver.Title);
            //IWebElement query = driver.FindElement(By.Name("q"));
            //query.SendKeys("Browserstack");
            //query.Submit();
        }

        [TearDown]
        public void Cleanup()
        {
            driver.Quit();
        }
    }
}