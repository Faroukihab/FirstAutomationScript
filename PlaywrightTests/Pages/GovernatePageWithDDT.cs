using Microsoft.Playwright;
using System;
using System.Threading.Tasks;

namespace PlaywrightTests.Pages
{
    public class GovernatesPageWithDDT
    {
        private readonly IPage _page;
        private readonly ILocator Places;
        private readonly ILocator governate;
        private readonly ILocator CreatBtn;
        private readonly ILocator SearchBtn;
        private readonly ILocator SearchbyName;
        private readonly ILocator searchBtn;
        private readonly ILocator ViewBtn;
        private readonly ILocator EditBtn;
        private readonly ILocator ArabicName;
        private readonly ILocator EnglishName;
        private readonly ILocator CreateCountryBtn;


        public GovernatesPageWithDDT(IPage page)
        {
            _page = page;
            Places = _page.GetByText("Places");
            governate = _page.GetByRole(AriaRole.Link, new() { Name = "- Governorates" });
            CreatBtn = _page.GetByRole(AriaRole.Button, new() { Name = "Create" });
            CreateCountryBtn = _page.GetByRole(AriaRole.Button, new() { Name = "Create" });
            ArabicName = _page.GetByLabel("Arabic Name *");
            EnglishName = _page.GetByLabel("English Name *");
            ViewBtn = _page.GetByRole(AriaRole.Cell, new() { Name = "Deactivate" }).GetByRole(AriaRole.Link).First;
            EditBtn = _page.GetByRole(AriaRole.Row, new() { Name = "Alexandria Egypt Deactivate" }).GetByRole(AriaRole.Link).Nth(1);
            SearchBtn = _page.GetByText("Search", new() { Exact = true });
            SearchbyName = _page.GetByLabel("Name");
        }

        public async Task EnterGovernatePage()
        {
            await Places.ClickAsync();
            await governate.ClickAsync();
            await Task.Delay(3000);
        }

        public async Task CreateGovernate(string governateEnglishName, string governateArabicName)
        {
            await CreatBtn.ClickAsync();
            await _page.ClickAsync("[data-test-id='create-governate-button']");
            await _page.FillAsync("#english-name-input", governateEnglishName);
            await _page.FillAsync("#arabic-name-input", governateArabicName);
            await _page.GetByRole(AriaRole.Textbox).Nth(2).FillAsync("eg");      
            await _page.GetByRole(AriaRole.Option, new() { Name = "​Egypt" }).ClickAsync();
            await CreateCountryBtn.ClickAsync();
        }

        // Implement other methods for viewing, editing, searching governates, etc.
    }
     
    class Program
    {
        static async Task Main(string[] args)
        {
            var playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync();
            var page = await browser.NewPageAsync();

            try
            {
                var governatesPage = new GovernatesPageWithDDT(page);

                await governatesPage.EnterGovernatePage();
                await governatesPage.CreateGovernate("ExampleEnglishName", "ExampleArabicName");

                // Perform other actions...

            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            finally
            {
                await browser.CloseAsync();
            }
        }
    }
}
