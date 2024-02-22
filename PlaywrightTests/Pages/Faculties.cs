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
    public class Faculties
    {
        private readonly IPage _page;
        private readonly ILocator facultyCreatBtn;
        private readonly ILocator facultyViewBtn;
        private readonly ILocator facultyEdtBtn;
        private readonly ILocator facultyArabicName;
        private readonly ILocator facultyEnglishName;
        private readonly ILocator _MasterData;
        private readonly ILocator facultyCrud;
        private readonly ILocator facultysaveBtn;

        public Faculties(IPage page)
        {
            _page = page;

            facultyCrud = _page.GetByRole(AriaRole.Link, new() { Name = "Faculties" });
            _MasterData = _page.GetByText(new Regex("Master Data", RegexOptions.IgnoreCase));
            facultyCreatBtn = _page.GetByRole(AriaRole.Button, new() { Name = "Create" });
            facultyArabicName = _page.GetByLabel("Arabic Name *");
            facultyEnglishName = _page.GetByLabel("English Name *");
            facultyEdtBtn = _page.GetByRole(AriaRole.Row, new() { Name = "كلية التجارة Faculty of commerce Alexandria university" }).GetByRole(AriaRole.Link).Nth(1);
            facultyViewBtn = _page.GetByRole(AriaRole.Row, new() { Name = "كلية التجارة Faculty of commerce Alexandria university" }).GetByRole(AriaRole.Link).First;
            facultysaveBtn = _page.GetByRole(AriaRole.Button, new() { Name = "Save" });
        }

        public async Task CreateFaculty()
        {
            await facultyCreatBtn.ClickAsync();
            await Task.Delay(1000);
            await facultyArabicName.FillAsync("1تيست");
            await Task.Delay(1000);
            await facultyEnglishName.FillAsync("test1");
            await Task.Delay(1000);
            await _page.GetByRole(AriaRole.Main).Locator("svg").ClickAsync();
            await _page.GetByText("Luxor,", new() { Exact = true }).ClickAsync();
            await facultysaveBtn.ClickAsync();
        }
        public async Task ViewFaculty()
        {
            await facultyViewBtn.ClickAsync();
            await Task.Delay(1000);
            await _page.GotoAsync("http://185.227.111.191:666/general/faculties");
        }
        public async Task Editfaculty()
        {
            await facultyEdtBtn.ClickAsync();
            await Task.Delay(1000);
            await _page.GotoAsync("http://185.227.111.191:666/general/faculties");
        }
        public async Task Searchonfaculties()
        {
            await _page.GetByRole(AriaRole.Columnheader, new() { Name = "English Name " }).Locator("div span").ClickAsync();
            await _page.GetByText("Filter").ClickAsync();
            await _page.GetByRole(AriaRole.Textbox).ClickAsync();
            await _page.GetByRole(AriaRole.Textbox).FillAsync("faculty of commerce");
            await _page.GetByRole(AriaRole.Button, new() { Name = "Filter" }).ClickAsync();
        }
        public async Task EnterFacultiescrud()
        {
            await _MasterData.ClickAsync();
            await facultyCrud.ClickAsync();
        }
    }
}
