using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightTests.Pages
{
    public class BirthPlacesPageWithDDt
    {
        IPage _page;
        private IPage page;
        private readonly ILocator _PlacesCrud;
        private readonly ILocator BirthPlaces;
        private readonly ILocator ViewBtn;
        private readonly ILocator EditBtn;
        private readonly ILocator CreatBtn;
        private readonly ILocator ArabicName;
        private readonly ILocator EnglishName;
        private readonly ILocator SaveBtn;

        public BirthPlacesPageWithDDt(IPage page)
        {
            _page = page;

            _PlacesCrud = _page.GetByText("Places");
            SaveBtn = _page.GetByRole(AriaRole.Button, new() { Name = "Save" });
            BirthPlaces = _page.GetByRole(AriaRole.Link, new() { Name = "- Birth Places" });
            ViewBtn = _page.GetByRole(AriaRole.Row, new() { Name = "sidigaber sidigaber Egypt Alexandria" }).GetByRole(AriaRole.Link).Nth(1);
            EditBtn = _page.GetByRole(AriaRole.Row, new() { Name = "sidigaber sidigaber Egypt Alexandria" }).GetByRole(AriaRole.Link).First;
            CreatBtn = _page.GetByRole(AriaRole.Button, new() { Name = "Create" });
            ArabicName = _page.GetByLabel("Arabic Name *");
            EnglishName = _page.GetByLabel("English Name *");




        }
        public async Task EnterBirhPlacePages()
        {
            await _PlacesCrud.ClickAsync();
            await BirthPlaces.ClickAsync();
            await Task.Delay(1000);
        }
        public async Task ViewBirthPage()
        {
            await ViewBtn.ClickAsync();
            await Task.Delay(1000);
        }
        public async Task EditBirhPage()
        {
            await EditBtn.ClickAsync();
            await Task.Delay(1000);
        }
        public async Task CreateBirthPlace(string BirthPlaceArabicName, string BirthPlaceEnglishName)
        {
            await CreatBtn.ClickAsync();
            await ArabicName.FillAsync(BirthPlaceArabicName);
            await EnglishName.FillAsync(BirthPlaceEnglishName);
            await _page.GetByRole(AriaRole.Main).Locator("svg").First.ClickAsync();

            await _page.GetByText("Afghanistan", new() { Exact = true }).ClickAsync();

            await _page.GetByRole(AriaRole.Main).Locator("svg").Nth(1).ClickAsync();

            await _page.GetByText("devce", new() { Exact = true }).ClickAsync();


            await SaveBtn.ClickAsync();

        }


    }



}
