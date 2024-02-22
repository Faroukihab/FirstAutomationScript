using DocumentFormat.OpenXml.Drawing.Charts;
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
    public class ContractorPage
    {
        private readonly IPage _page;
        private readonly ILocator CreatBtn;
        private readonly ILocator ViewBtn;
        private readonly ILocator EdtBtn;
        private readonly ILocator ArabicName;
        private readonly ILocator EnglishName;
        private readonly ILocator _CONTRACTS;
        private readonly ILocator contractorCrud;
        private readonly ILocator creatcontractor;
        private readonly ILocator PositionArabic;
        private readonly ILocator PositionEnglish;
        private readonly ILocator ClientPositionArabic;
        private readonly ILocator ClientPositionEnglish;
        private readonly ILocator ClientArabicName;
        private readonly ILocator ClientEnglishName;
        private readonly ILocator SearchByName;
        private readonly ILocator SearchBtn;
        private readonly ILocator Amount;
        

        public ContractorPage(IPage page)
        {
            _page = page;
            contractorCrud = _page.GetByRole(AriaRole.Link, new() { Name = "- Contracts", Exact = true });
            _CONTRACTS = _page.GetByText(new Regex("Contracts", RegexOptions.IgnoreCase));
            CreatBtn = _page.GetByRole(AriaRole.Button, new() { Name = "Create" });
            ClientArabicName = _page.Locator("#mui-55");
            ClientEnglishName = _page.Locator("#mui-56");
            ClientPositionArabic = _page.Locator("#mui-57");
            ClientPositionEnglish = _page.Locator("#mui-58");
            ArabicName = _page.Locator("#mui-50");
            EnglishName = _page.Locator("#mui-51");
            PositionArabic = _page.Locator("#mui-52");
            PositionEnglish = _page.Locator("#mui-53");



            EdtBtn = _page.GetByRole(AriaRole.Row, new() { Name = "mnd-orgC0004 orange 2022-11-01 2022-11-30 under_review" }).GetByRole(AriaRole.Link).Nth(1);
            ViewBtn = _page.GetByRole(AriaRole.Row, new() { Name = "mnd-orgC0004 orange 2022-11-01 2022-11-30 under_review" }).GetByRole(AriaRole.Link).First;
            creatcontractor = _page.GetByRole(AriaRole.Button, new() { Name = "Create" });
            SearchByName = _page.GetByLabel("Client Name");
            SearchBtn = _page.GetByText("Search", new() { Exact = true });
            Amount = _page.GetByLabel("Amount");




        }
        public async Task EnterClientCrud()
        {
            await _CONTRACTS.ClickAsync();
            await contractorCrud.ClickAsync();
        }
        public async Task CreateContract()
        {
            await CreatBtn.ClickAsync();

            await _page.Locator("#contract_type-list").ClickAsync();

            await _page.GetByRole(AriaRole.Option, new() { Name = "Offer" }).ClickAsync();

            await _page.Locator("#provider_company_id-list").ClickAsync();

            await _page.GetByRole(AriaRole.Option, new() { Name = "First Egyptian Engineering" }).ClickAsync();

            await _page.Locator("#company_costcenter_id-list").ClickAsync();

            await _page.GetByRole(AriaRole.Option, new() { Name = "HR" }).ClickAsync();


            await _page.Locator(".MuiContainer-root > div > div").First.ClickAsync();

            await _page.Locator("#mui-42").FillAsync("farouk");
            await Task.Delay(5000);

            await _page.Locator("#mui-42").FillAsync("تيست");

            await _page.Locator("#mui-42").PressAsync("Tab");

            await _page.Locator("#mui-43").FillAsync("test");

            await _page.Locator("#mui-43").PressAsync("Tab");

            await _page.Locator("#mui-44").FillAsync("تيستر");

            await _page.Locator("#mui-44").PressAsync("Tab");

            await _page.Locator("#mui-45").FillAsync("tester");

            await _page.Locator("#mui-45").PressAsync("Tab");





            await _page.GetByRole(AriaRole.Option, new() { Name = "sana soft company" }).First.ClickAsync();
            await _page.Locator(".MuiContainer-root > div > div > .MuiFormControl-root > .MuiInputBase-root").First.ClickAsync();

            await _page.Locator("#mui-42").FillAsync("تيست");

            await _page.Locator(".MuiContainer-root > div > div:nth-child(2)").First.ClickAsync();

            await _page.Locator("#mui-43").FillAsync("test");

            await _page.Locator("div:nth-child(3) > .MuiFormControl-root > .MuiInputBase-root").First.ClickAsync();

            await _page.Locator("#mui-44").FillAsync("تيستر");

            await _page.Locator("div:nth-child(4) > .MuiFormControl-root > .MuiInputBase-root").First.ClickAsync();

            await _page.Locator("#mui-45").FillAsync("tester");

            await _page.GetByLabel("Choose date").First.ClickAsync();

            await _page.GetByRole(AriaRole.Gridcell, new() { Name = "31" }).ClickAsync();

            await _page.GetByLabel("Choose date").Nth(1).ClickAsync();

            await _page.GetByText("August 2023").ClickAsync();

            await _page.GetByRole(AriaRole.Button, new() { Name = "2024" }).ClickAsync();

            await _page.GetByLabel("End Date *").ClickAsync();

            await _page.GetByLabel("Amount").ClickAsync();

            await _page.GetByLabel("Amount").FillAsync("1000");

            await _page.GetByLabel("Amount").PressAsync("Tab");

            await _page.GetByRole(AriaRole.Button, new() { Name = "Create Contract" }).ClickAsync();

            await _page.GetByRole(AriaRole.Button, new() { Name = "Create Contract" }).ClickAsync();




        }
        public async Task VeiwContract()
        {
            await ViewBtn.ClickAsync();
            await Task.Delay(1000);
            await _page.GoBackAsync();
        }
        public async Task EditContract()
        {
            await EdtBtn.ClickAsync();
            await Task.Delay(1000);
            await _page.GoBackAsync();
        }
        public async Task Search()
        {
            await SearchByName.FillAsync("Vodaone Egypt");
            await Task.Delay(1000);
            await SearchBtn.ClickAsync();
        }
        public async Task EnterContract()
        {
            
          
            await _CONTRACTS.ClickAsync();
            await contractorCrud.ClickAsync();
        }
    }
}
