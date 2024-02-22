using ExcelDataReader;
using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TF.Pages;

namespace TF.PageTest
{
    public   class LoginTestDDT
    {
        [SetUp]
        public void setup()
        {

        }

        [Test]
        public  async Task Main()
        {
            // Initialize Playwright
            
            using var playwright = await Playwright.CreateAsync();
            //Browser
            await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false,
                Args = new[] { "--start-maximized" }
            });
            //Page
            var page = await browser.NewPageAsync();

            // Read data from Excel sheet
            var testData = ReadTestDataFromExcel();

            // Perform login with different test data
            foreach (var data in testData)
            {
                string username = data["Username"];
                await Task.Delay(1000);
                string password = data["Password"];

                // Navigate to the login page
                await page.GotoAsync("http://185.227.111.191:666");
                await Task.Delay(1000);
                // Create page objects
                var loginPage = new LoginDDT(page);
                var dashboardPage = new DashboardPage(page);

                // Perform login
                loginPage.EnterUsername(username);
                await Task.Delay(1000);
                loginPage.EnterPassword(password);
                loginPage.ClickLoginButton();
                await Task.Delay(3000);
                

                // Wait for the login process to complete
                page.WaitForNavigationAsync();

                // Verify login success or failure
                if (dashboardPage.IsLoggedIn())
                    
                {
                    
                    Console.WriteLine($"Login successfull for {username}");
                   
                }
                else
                {
                    
                    Console.WriteLine($"Login failled for {username}");
                }
            }
        }

        static List<Dictionary<string, string>> ReadTestDataFromExcel()
        {
            var testData = new List<Dictionary<string, string>>();

            // Open the Excel file
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            using (var stream = File.Open("C:\\Users\\fihab\\testdata.xlsx", FileMode.Open, FileAccess.Read))

            using (var reader = ExcelReaderFactory.CreateReader(stream))
            {

                // Read the data from the first worksheet

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

            }

            return testData;
        }
    }

    }

