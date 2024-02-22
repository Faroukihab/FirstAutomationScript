using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TF.Pages
{
    public class UnivercitiesAndInstitue
    {
        IPage _page;
        private IPage page;
        private readonly ILocator UniCreatBtn;
        private readonly ILocator UniViewBtn;
        private readonly ILocator UniEdtBtn;
        private readonly ILocator UniArabicName;
        private readonly ILocator UniEnglishName;
        private readonly ILocator _MasterData;
        private readonly ILocator UniCrud;
        public UnivercitiesAndInstitue(IPage page)

        {

            _page = page;

            UniCreatBtn = _page.GetByRole(AriaRole.Button, new() { Name = "Create" });
            UniViewBtn = _page.GetByRole(AriaRole.Row, new() { Name = "الاقصر جامعة, Luxor, Private Egypt Luxor" }).GetByRole(AriaRole.Link).First;
            UniEdtBtn = _page.GetByRole(AriaRole.Row, new() { Name = "الاقصر جامعة, Luxor, Private Egypt Luxor" }).GetByRole(AriaRole.Link).Nth(1);
            UniArabicName = _page.GetByLabel("Arabic Name");
            UniEnglishName = _page.GetByLabel("English Name");
            _MasterData = _page.GetByText(new Regex("Master Data", RegexOptions.IgnoreCase));
            UniCrud = _page.GetByRole(AriaRole.Link, new() { Name = "Universities and Institutes" });
        }
        public async Task CreateNewUni()
        {
            await UniCreatBtn.ClickAsync();
            await UniEnglishName.FillAsync("ziiiiifta");
            await UniArabicName.FillAsync("جامعة زززززززفتي ");
            await _page.GetByRole(AriaRole.Button, new() { Name = "University Type Public" }).ClickAsync();

            await _page.GetByRole(AriaRole.Option, new() { Name = "Public" }).ClickAsync();

            await _page.GetByLabel("Country").Locator("span").Nth(1).ClickAsync();

            await _page.GetByRole(AriaRole.Textbox).Nth(2).FillAsync("egy");

            await _page.GetByRole(AriaRole.Textbox).Nth(2).PressAsync("ArrowDown");

            await _page.GetByRole(AriaRole.Textbox).Nth(2).PressAsync("ArrowDown");

            await _page.GetByRole(AriaRole.Textbox).Nth(2).FillAsync("egypt");

            await _page.GetByRole(AriaRole.Option, new() { Name = "​Egypt" }).ClickAsync();

            await  _page.Locator(".css-ebm2zr").ClickAsync();

            await _page.GetByText("Alexandria", new() { Exact = true }).ClickAsync();

            await _page.GetByRole(AriaRole.Button, new() { Name = "Save" }).ClickAsync();

            await Task.Delay(1000);


        }
        public async Task ClickOnViewBtn()
        {
            await UniViewBtn.ClickAsync();

        }
        public async Task ClickOnEdtBtn()
        {
            await UniEdtBtn.ClickAsync();
        }
        public async Task EnterUniCrud()
        {
            await _MasterData.ClickAsync();
            await UniCrud.ClickAsync();
        }
        public async Task SearchOnUni()
        {
            await _page.GetByRole(AriaRole.Columnheader, new() { Name = "Arabic Name  " }).Locator("div span").ClickAsync();

            await _page.GetByText("Filter").ClickAsync();

            await _page.GetByRole(AriaRole.Textbox).ClickAsync();

            await _page.GetByRole(AriaRole.Textbox).FillAsync("الاسكندرية");

            await _page.GetByRole(AriaRole.Button, new() { Name = "Filter" }).ClickAsync();

        }
    }
}
