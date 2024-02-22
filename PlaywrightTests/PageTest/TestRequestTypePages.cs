using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TF.Pages;
using NUnit.Framework;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Playwright.NUnit;
using System.Diagnostics;
using PlaywrightTests.Pages;

namespace TF.PageTest
{
    [DebuggerDisplay("{isMessageVisible}")]
    public class TestRequestTypePages
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
            page.Request += (_, request) => Console.WriteLine(request.Method + "---" + request.Url);
            page.Response += (_, response) => Console.WriteLine(response.Status + "---" + response.Url);
            var request = new RequestType(page);
            await request.EnterRequestTypeCrude();
            await Task.Delay(1000);
            await request.CreateaRequest();
            await Task.Delay(9000);
            await request.SearchonCreatedRequested();
            await Task.Delay(1000);
            await page.GotoAsync("http://185.227.111.191:666/general/request_types");
            await request.EnterviewPage();
            await Task.Delay(1000);
            await page.GoBackAsync();
            await request.EnterEditPage();
            await Task.Delay(1000);
            await page.GoBackAsync();

        }
    }
}