using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightTests.Pages
{
    public class DistrictPageWithDDt
    {
        IPage _page;
        private readonly ILocator Places;
        private readonly ILocator district;
        private readonly ILocator CreatBtn;
        private readonly ILocator ViewBtn;
        private readonly ILocator EditBtn;
        private readonly ILocator ArabicName;
        private readonly ILocator EnglishName;
        private readonly ILocator SaveBtn;
        public DistrictPageWithDDt(IPage page)
        {
            _page = page;
            Places = _page.GetByText("Places");
            district = _page.GetByRole(AriaRole.Link, new() { Name = "- Districts" });
            CreatBtn = _page.GetByRole(AriaRole.Button, new() { Name = "Create" });
            SaveBtn = _page.GetByRole(AriaRole.Button, new() { Name = "Save" });
            ArabicName = _page.GetByLabel("Arabic Name *");
            EnglishName = _page.GetByLabel("English Name *");
            ViewBtn = _page.GetByRole(AriaRole.Row, new() { Name = "اسماعليه ismailia Ismailia" }).GetByRole(AriaRole.Link).Nth(1);
            EditBtn = _page.GetByRole(AriaRole.Row, new() { Name = "اسماعليه ismailia Ismailia" }).GetByRole(AriaRole.Link).First;


        }

        public async Task EnterdistrictPage()
        {
            await Places.ClickAsync();
            await district.ClickAsync();
            await Task.Delay(3000);
        }
        public async Task ViewCountry()
        {
            await ViewBtn.ClickAsync();
            await Task.Delay(1000);
            await _page.GoBackAsync();

        }
        public async Task EditCountryPage()
        {
            await EditBtn.ClickAsync();
            await Task.Delay(1000);
            await _page.GoBackAsync();
        }
        public async Task CreateDistrict(string DistrictEnglishName, string DistrictArabicName)
        {
            await CreatBtn.ClickAsync();
            await EnglishName.FillAsync(DistrictEnglishName);
            await ArabicName.FillAsync(DistrictArabicName);
            await _page.Locator(".css-ebm2zr").ClickAsync();

            await _page.GetByText("Alexandria", new() { Exact = true }).ClickAsync();

            await _page.GetByRole(AriaRole.Button, new() { Name = "Save" }).ClickAsync();

            await SaveBtn.ClickAsync();

        }

    }


}