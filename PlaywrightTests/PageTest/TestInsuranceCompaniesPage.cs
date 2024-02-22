using Microsoft.Playwright;
using TF.Pages;
using NUnit.Framework;

namespace TF.PageTest
{

    public class TestInsuranceCompaniesPage
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
            var insurancecompanies = new InsuranceCompanies(page);
            await insurancecompanies.Enterinsurancecompanies();
            await insurancecompanies.Createinsurancecompanies();
            await Task.Delay(5000);
            await insurancecompanies.VeiwInsuranceCompanies();
            await Task.Delay(2000);
            await insurancecompanies.EditInsuranceCompanies();
            await Task.Delay(2000);
            await insurancecompanies.InsuranceCompaniesSearch();
            await Task.Delay(1000);
            var searchResultElement = page.GetByText("El w8d");
            var searchText = await searchResultElement.InnerTextAsync();
            //Assert.IsTrue(searchText.Contains("El w8d"), "Expected word was not found in the search result.");
            await Task.Delay(1000);
            await browser.CloseAsync();
        }
    }
}