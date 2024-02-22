using Microsoft.Playwright;
using NUnit.Framework.Constraints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TF.Pages

{

    public class CurrnncyPageWithDDT
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



        public CurrnncyPageWithDDT(IPage page)

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
        public async Task SearchOnCurrency(string CurrencySearchName)
        {
            await CurrencySearchByName.FillAsync(CurrencySearchName);
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
        public async Task CreateNewCurrency(string CurrencyenglishName, string CurrencyarabicName, string Abb)
        {
            await CurrencyCreatBtn.ClickAsync();
            await CurrencyEnglishName.FillAsync(CurrencyenglishName);
            await CurrencyArabicName.FillAsync(CurrencyarabicName);
            await CurrencyAbb.FillAsync(Abb);
            await CurrencyCreatBtn.ClickAsync();
        }
    }
}