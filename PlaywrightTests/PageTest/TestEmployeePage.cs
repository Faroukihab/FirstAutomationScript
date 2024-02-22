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
using static Microsoft.Playwright.Assertions;

namespace TF.PageTest
{
    [DebuggerDisplay("{isMessageVisible}")]
    public class TestEmployeePage
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
          //  await page.SetViewportSizeAsync(1920, 1080);
            var loginPage = new LoginPage(page);

            await loginPage.Login("farouk", "123456");
            await loginPage.ClickLogin();
            await Task.Delay(1000);
            // After clicking login button
            await page.WaitForURLAsync("http://185.227.111.191:666/dashboard");
            var Emp = new Employee(page);
           await Emp.EnterEmployeePage();
            await Task.Delay(1000);
            await Emp.ClickonEditBtn();
            await Task.Delay(1000); 
            await page.GoBackAsync();
            await Emp.SeachOnEmployee();
            await Task.Delay(2000);
            var searchresult = page.GetByText("Farouk");
            //Assert.NotNull(searchresult);
            await Emp.CreateNewEmp();
            await Task.Delay(2000);
            var successmessage = page.GetByText("Created Successfully");
            //Assert.NotNull(successmessage);

        }
    }
}