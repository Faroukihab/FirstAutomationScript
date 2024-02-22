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
using NUnit.Framework.Constraints;

namespace TF.PageTest
{

    public class TestFacultiesPage
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
            var faculties = new Faculties(page);
            faculties.EnterFacultiescrud();
            faculties.CreateFaculty();
            await Task.Delay(1000);
            await faculties.ViewFaculty();
            await faculties.Editfaculty();
            await faculties.Searchonfaculties();
            var searchResultElement = page.GetByText("Faculty of commerce");
            var searchText = await searchResultElement.InnerTextAsync();
            //Assert.IsTrue(searchText.Contains("Faculty of commerce"), "Expected word was not found in the search result.");
            browser.CloseAsync();
        }
    }
}