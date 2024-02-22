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
    public class TestBanksPage
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
            page.Request += (_, request) => Console.WriteLine(request.Method + "---" + request.Url);
            page.Response += (_, response) => Console.WriteLine(response.Status + "---" + response.Url);
            var bankpage = new BanksPage(page);
            await bankpage.EnterBankPage();
            await bankpage.ClickonEditBtn();
            await page.GotoAsync("http://185.227.111.191:666/general/banks");
            await bankpage.ClickonEditBtn();
            await page.GotoAsync("http://185.227.111.191:666/general/banks");
            await bankpage.SeachOnBanks();
            var searchResultElement = page.GetByText("CIB");
            var searchText = await searchResultElement.InnerTextAsync();
            //Assert.IsTrue(searchText.Contains("CIB"), "Expected word was not found in the search result.");

            await bankpage.CreateNewBank();
        
            await Task.Delay(1000);

          var  Locator =   page.Locator("div").Filter(new() { HasText = "Bank Created Successfully" }).Nth(3);

            // Assert the appearance of the success message
            var successMessage =  page.GetByText("Bank Created Successfully");
            //Assert.NotNull(successMessage);
        }



      
            //await bankpage.SearchOnCreatedBank();
            //await Task.Delay(10000);
            //var searchresultElement  = page.GetByText("543223");
            //var searchtext = await searchResultElement.InnerTextAsync();
            //Assert.IsTrue(searchtext.Contains("543223"), "Expected word was not found in the search result.");

            //var successMessageLocator = page.GetByText("Bank Created Successfully");
            //await Task.Delay(10000);
            //var isMessageVisible = await successMessageLocator.IsVisibleAsync();
            //await Task.Delay(10000);
            //Assert.IsTrue(isMessageVisible);
            //await Task.Delay(1000);
            //Console.WriteLine("Bank created successfully");

            //await page.WaitForSelectorAsync("Bank Created Successfully");
            //await Task.Delay(1000);
            // Assert the presence of the message using the Expect class
            //Assert.IsTrue(await page.QuerySelectorAsync("Bank Created Successfully") != null, "The message element should exist on the page");

           // var locator = page.Locator(".title");
            //await Expect(locator).ToContainTextAsync("substring");
            //await Expect(locator).ToContainTextAsync(new Regex("Bank Created Successfully"));

            //await Expect(page).Not.ToHaveURL("error");
           
        }
    }
