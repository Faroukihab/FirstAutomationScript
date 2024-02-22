using ExcelDataReader;
using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Threading.Tasks;
using NUnit.Framework;
using TF.Pages;
using static Microsoft.Playwright.Assertions;

namespace TF.PageTest
{

    [TestFixture]
    public class TestInsurancePackagePagewithDDT
    {
        private IPlaywright playwright;
        private IBrowser browser;
        private IPage page;

        [SetUp]
        public async Task SetUp()
        {
            // Initialize Playwright
            playwright = await Playwright.CreateAsync();

            // Browser
            browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false,
                Args = new[] { "--start-maximized" }

            });

            // Page
            page = await browser.NewPageAsync();

            // Navigate to the login page
            await page.GotoAsync("http://185.227.111.191:666");
            await page.SetViewportSizeAsync(1920, 1080);
            var loginPage = new LoginPage(page);
            await loginPage.Login("farouk", "123456");
            await loginPage.ClickLogin();

            // Wait for the login process to complete
            await page.WaitForURLAsync("http://185.227.111.191:666/dashboard");
        }

        [Test]
        public async Task TestInsurancePackageCreation()
        {
            var testData = GetTestData();

            foreach (var data in testData)
            {
                string insurancepackagesearchname = data["insurancepackagesearchname"];
                string insurancepackageenglishname = data["insurancepackageenglishname"];
                string insurancepackagearabicname = data["insurancepackagearabicname"];
                // Create page objects
                var inspack = new InsurancePakagesWithDDT(page);

                // Perform methods
                await inspack.EnterInsuranceCompaniesCrud();
                await Task.Delay(1000);

                await inspack.InsurancePakagesSearch(insurancepackagesearchname);
                await Task.Delay(1000);

                await inspack.Createinsurancecompanies(insurancepackageenglishname, insurancepackagearabicname);
                await Task.Delay(1000);



            }
        }

        private static List<Dictionary<string, string>> GetTestData()
        {
            var testData = new List<Dictionary<string, string>>();

            // Open the Excel file
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            using (var stream = File.Open("C:\\Users\\fihab\\testdata.xlsx", FileMode.Open, FileAccess.Read))
            using (var reader = ExcelReaderFactory.CreateReader(stream))
            {
                var dataSet = reader.AsDataSet(new ExcelDataSetConfiguration
                {
                    ConfigureDataTable = _ => new ExcelDataTableConfiguration
                    {
                        UseHeaderRow = true
                    }
                });

                var dataTable = dataSet.Tables[0];

                // Iterate through rows and columns
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    var data = new Dictionary<string, string>();

                    for (int j = 0; j < dataTable.Columns.Count; j++)
                    {
                        var columnName = dataTable.Columns[j].ColumnName;
                        var cellValue = dataTable.Rows[i][j].ToString();
                        data[columnName] = cellValue;
                    }

                    testData.Add(data);
                }

                reader.Reset();
            } // The Excel file reader will be automatically closed and disposed here.

            return testData;
        }
    }

}