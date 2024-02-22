using System.Threading.Tasks;
using Microsoft.Playwright;
using Microsoft.VisualStudio.TestPlatform.CrossPlatEngine.Helpers;
using NUnit.Framework;
using TF.Pages;

namespace TF.Tests
{
    public class TestloginPage
    {
        [SetUp]
        public void setup()
        {

        }

        [Test]
        public async Task Testlogin()
        {
            //playwright 
            using var playwright = await Playwright.CreateAsync();
            //Browser
            await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false,
                Args = new[] { "--start-maximized" }
            });
            //Page
            var page = await browser.NewPageAsync();

            await page.GotoAsync("http://185.227.111.191:666");
            // Maximize the window
            await page.SetViewportSizeAsync(1920, 1080);
            var loginPage = new LoginPage(page);
  
            await loginPage.Login("farouk", "123456");
            await loginPage.ClickLogin();
            await Task.Delay(5000);
            // After clicking login button
            await page.WaitForURLAsync("http://185.227.111.191:666/dashboard");
            //Assert.AreEqual("http://185.227.111.191:666/dashboard", page.Url);



            // await loginPage.ClickForgetPassAsync();
        }
    }
}
