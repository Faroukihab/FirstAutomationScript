using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TF.PageTest;

namespace TF.Pages
{
    public class CurrnncyPage
    {
        IPage _page;
        private IPage page;
        private readonly ILocator CurrencySearchByName;
        private readonly ILocator CurrencySearchBtn;
        private readonly ILocator CurrencyEdtBtn;
        private readonly ILocator CurrencyViwBtn;
        private readonly ILocator CurrencyCreatBtn;
        private readonly ILocator CurrencyEnglishName;
        private readonly ILocator CurrencyArabicName;
        private readonly ILocator CurrencyAbb;
        private readonly ILocator _MasterData;
        private readonly ILocator _CurrencyCrude;



        public CurrnncyPage(IPage page)

        {
            _page = page;
            CurrencySearchByName = _page.GetByLabel("Name");
            CurrencySearchBtn = _page.GetByText("Search", new() { Exact = true });
            CurrencyCreatBtn = _page.GetByRole(AriaRole.Button, new() { Name = "Create" });
            CurrencyEdtBtn = _page.GetByRole(AriaRole.Row, new() { Name = "UAE Dirham AED" }).GetByRole(AriaRole.Link).Nth(1);
            CurrencyViwBtn = _page.GetByRole(AriaRole.Row, new() { Name = "Euro EUR 40.0000" }).GetByRole(AriaRole.Link).First;
            CurrencyEnglishName = _page.GetByLabel("English Name");
            CurrencyArabicName = _page.GetByLabel("Arabic Name");
            CurrencyAbb = _page.GetByLabel("Abbreviation *");
            _MasterData = _page.GetByText(new Regex("Master Data", RegexOptions.IgnoreCase));
            _CurrencyCrude = _page.GetByRole(AriaRole.Link, new() { Name = "- Currencies" });


        }

        public async Task EnterCurrencyCrud()
        {
            await _MasterData.ClickAsync();
            await _CurrencyCrude.ClickAsync();
        }
        public async Task SearchOnCurrency()
        {
            await CurrencySearchByName.FillAsync("Euro");
            await CurrencySearchBtn.ClickAsync();
        }
        public async Task ClickOnViewBtn()
        {
            await CurrencyViwBtn.ClickAsync();
        }
        public async Task ClickOnEditBtn()
        {
            await CurrencyEdtBtn.ClickAsync();
        }
        public async Task CreateNewCurrency()
        {
            await CurrencyCreatBtn.ClickAsync();
            await CurrencyEnglishName.FillAsync("yanni");
            await CurrencyArabicName.FillAsync("ياني");
            await CurrencyAbb.FillAsync("YN");
        }
    }
}