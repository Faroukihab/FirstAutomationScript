using Microsoft.Playwright;
using TF.Pages;
using NUnit.Framework;

namespace TF.PageTest
{

    public class TestClientPage
    {
        ILocator Locator;


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
            await Task.Delay(1000);
            // After clicking login button
            await page.WaitForURLAsync("http://185.227.111.191:666/dashboard");
            var client = new CleintPage(page);
            await client.EnterClientCrud();
            await client.Search();
            await client.CreateClient();
            await Task.Delay(1000);
            await client.VeiwClient();
            await Task.Delay(1000);
            await client.EditClient();
            await Task.Delay(1000);


        }
    }
}