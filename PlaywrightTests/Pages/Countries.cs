using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightTets.Pages
{
    public class Countries
    { 
        IPage _page;
        private readonly ILocator _PlacesCrud;
        private readonly ILocator CountryCrude ;
        private readonly ILocator ViewBtn;
        private readonly ILocator SearchBtn;
        private readonly ILocator SearchByName;

        public Countries(IPage page)
        {
            _page = page;
            _PlacesCrud = _page.GetByText("Places");
            CountryCrude = _page.GetByRole(AriaRole.Link, new() { Name = "- Countries" });
            ViewBtn = _page.GetByRole(AriaRole.Row, new() { Name = "أفغانستان Afghanistan افغاني Afghan" }).GetByRole(AriaRole.Link);
            SearchBtn = _page.GetByRole(AriaRole.Main).GetByRole(AriaRole.Button, new() { Name = "Search" });
            SearchByName = _page.GetByLabel("Country Name"); 

        }
        public async Task EnterCountriesPage()
        {
            await _PlacesCrud.ClickAsync();
            await CountryCrude.ClickAsync();
        }
        public async Task SearchonCountry()
        {
            await SearchByName.FillAsync("Egypt");
            await SearchBtn.ClickAsync();   
           
        }
        public async Task ViewCountryPage()
        {
            await ViewBtn.ClickAsync();
         
        }

    }
}
