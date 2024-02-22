using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TF.Pages;

namespace TF.PageTest
{
    public class TestcompanyPage
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
            await Task.Delay(1000);
            // After clicking login button
            await page.WaitForURLAsync("http://185.227.111.191:666/dashboard");

            var com = new CompanyPage(page);
           await com.EnterCompanyCrud();
            await com.CreateNewCompany();
            await com.ClickEditBtn();
            await Task.Delay(3000);
            await page.GoBackAsync();

            await com.ClickVeiwBtn();
            await Task.Delay(3000);
            await page.GoBackAsync();

           
            await com.SearchOnCompanyByName();
            await Task.Delay(1000);
        }
    }
}