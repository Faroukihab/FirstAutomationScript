using DocumentFormat.OpenXml.Bibliography;
using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightTests.Pages
{
    public class GovernatesPage
    {
        IPage _page;
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

        public GovernatesPage(IPage page)
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

        public async Task EnterGovaernatePage()
        {
            await Places.ClickAsync();
            await governate.ClickAsync();
            await Task.Delay(3000);
        }
        public async Task ViewCountry()
        {
            await ViewBtn.ClickAsync();
        }
        public async Task EditCountryPage()
        {
            await EditBtn.ClickAsync();
        }
        public async Task CreateGovernate()
        {
            await CreatBtn.ClickAsync();
            await EnglishName.FillAsync("zifta");
            await ArabicName.FillAsync("زفتة");
            await _page.GetByLabel("Country").Locator("span").Nth(1).ClickAsync();

            await _page.GetByRole(AriaRole.Textbox).Nth(2).ClickAsync();

            await _page.GetByRole(AriaRole.Textbox).Nth(2).FillAsync("eg");

            await _page.GetByRole(AriaRole.Option, new() { Name = "​Egypt" }).ClickAsync();
            await CreateCountryBtn.ClickAsync();

        }
        public async Task SearchonCountries()
        {
            await SearchbyName.FillAsync("Alex");
            await SearchBtn.ClickAsync();
            await Task.Delay(1000);
        }
    }


}