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


namespace TF.PageTest
{

    public class TestBankTransactionTypes
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
            var banktransactiontypes = new BankTransactionTypes(page);
            page.Request += (_, request) => Console.WriteLine(request.Method + "---" + request.Url);
            page.Response += (_, response) => Console.WriteLine(response.Status + "---" + response.Url);
            await banktransactiontypes.Enterbanktransactiontypes();
            await banktransactiontypes.CreateNewbanktransactiontypes();
            await Task.Delay(10000);
            await banktransactiontypes.ViewBankTransactionTypesEditBtn();
            await Task.Delay(10000);
            await banktransactiontypes.EditBankTransactionTypes();
            await Task.Delay(1000);
           
            
            await banktransactiontypes.SeachOnbanktransactiontypes();
            await Task.Delay(5000);
            //var searchResultElement = page.GetByText("Test32");
            //var searchText = await searchResultElement.InnerTextAsync();
            //Assert.IsTrue(searchText.Contains("Test32"), "Expected word was not found in the search result.");
            //await Task.Delay(1000);




        }
    }
}