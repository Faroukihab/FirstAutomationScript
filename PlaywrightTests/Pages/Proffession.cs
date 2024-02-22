using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TF.Pages
{
    public class Proffession
    {
        private readonly IPage _page;
        private readonly ILocator ProCreatBtn;
        private readonly ILocator ProViewBtn;
        private readonly ILocator ProEdtBtn;
        private readonly ILocator ProArabicName;
        private readonly ILocator ProEnglishName;
        private readonly ILocator _MasterData;
        private readonly ILocator ProffessionCrud;
        private readonly ILocator ProsaveBtn;

        public Proffession(IPage page)
        {
            _page = page;

            ProffessionCrud = _page.GetByRole(AriaRole.Link, new() { Name = "- Professions" });
            _MasterData = _page.GetByText(new Regex("Master Data", RegexOptions.IgnoreCase));
            ProCreatBtn = _page.GetByRole(AriaRole.Button, new() { Name = "Create" });
            ProArabicName = _page.GetByLabel("Arabic Name *");
            ProEnglishName = _page.GetByLabel("English Name *");
            ProEdtBtn = _page.GetByRole(AriaRole.Row, new() { Name = "hki مىن" }).GetByRole(AriaRole.Link).First;
            ProViewBtn = _page.GetByRole(AriaRole.Row, new() { Name = "hki مىن" }).GetByRole(AriaRole.Link).Nth(1);
            ProsaveBtn = _page.GetByRole(AriaRole.Button, new() { Name = "Save" });
        }
        public async Task EnterProffessionCrud()
        {
            await _MasterData.ClickAsync();
            await ProffessionCrud.ClickAsync();
        }
        public async Task CreateProffesssion()
        {
            await ProCreatBtn.ClickAsync();
            await ProArabicName.FillAsync("تيست21");
            await ProEnglishName.FillAsync("Test12");
            await _page.GetByRole(AriaRole.Main).Locator("svg").ClickAsync();
            await _page.GetByText("Engineering", new() { Exact = true }).ClickAsync();
            await ProsaveBtn.ClickAsync();
        }
        public async Task VeiwPro()
        {
            await ProViewBtn.ClickAsync();
            _page.GotoAsync("http://185.227.111.191:666/general/professions");
        }
        public async Task EditPro()
        {
            await ProEdtBtn.ClickAsync();
            _page.GotoAsync("http://185.227.111.191:666/general/professions");
        }
    }
}
