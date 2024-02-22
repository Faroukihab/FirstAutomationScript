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
    public class CleintPageWithDDT
    {
        private readonly IPage _page;
        private readonly ILocator CreatBtn;
        private readonly ILocator ViewBtn;
        private readonly ILocator EdtBtn;
        private readonly ILocator ArabicName;
        private readonly ILocator EnglishName;
        private readonly ILocator _CONTRACTS;
        private readonly ILocator ClientsCrud;
        private readonly ILocator saveBtn;
        private readonly ILocator Prefix;
        private readonly ILocator VatID;
        private readonly ILocator CommercialRegistration;
        private readonly ILocator SearchByName;
        private readonly ILocator SearchBtn;
        private readonly ILocator ClientNumber;

        public CleintPageWithDDT(IPage page)
        {
            _page = page;
            ClientsCrud = _page.GetByRole(AriaRole.Link, new() { Name = "- Clients" });
            _CONTRACTS = _page.GetByText(new Regex("Contracts", RegexOptions.IgnoreCase));
            CreatBtn = _page.GetByRole(AriaRole.Button, new() { Name = "Create" });
            ArabicName = _page.GetByLabel("Client Name (In Arabic) *");
            EnglishName = _page.GetByLabel("Client Name (In English) *");
            Prefix = _page.GetByLabel("Prefix *");
            VatID = _page.GetByLabel("VAT.ID. *");
            CommercialRegistration = _page.GetByLabel("Commerial Registeration *");
            EdtBtn = _page.GetByRole(AriaRole.Row, new() { Name = "بيبسي كولا مصر pepsi cola egypt PEPS" }).GetByRole(AriaRole.Link).Nth(1);
            ViewBtn = _page.GetByRole(AriaRole.Row, new() { Name = "بيبسي كولا مصر pepsi cola egypt PEPS" }).GetByRole(AriaRole.Link).First;
            saveBtn = _page.GetByRole(AriaRole.Button, new() { Name = "Create Client" });
            SearchByName = _page.GetByLabel("Name");
            SearchBtn = _page.GetByText("Search", new() { Exact = true });
            ClientNumber = _page.GetByLabel("Client Number *");



        }
        public async Task EnterClientCrud()
        {
            await _CONTRACTS.ClickAsync();
            await ClientsCrud.ClickAsync();
        }
        public async Task CreateClient(string CleintArabicName, string ClientEnglishName, string CleintPrefix, string CleintCommRegis, string CleintVat, string CleintNumber )
        {
            await CreatBtn.ClickAsync();
            await ArabicName.FillAsync(CleintArabicName);
            await EnglishName.FillAsync(ClientEnglishName);
            await Prefix.FillAsync(CleintPrefix);
            await CommercialRegistration.FillAsync(CleintCommRegis);
            await VatID.FillAsync(CleintVat);
            await ClientNumber.FillAsync(CleintNumber);
            await saveBtn.ClickAsync();
           



        }
        public async Task VeiwClient()
        {
            await ViewBtn.ClickAsync();
            await Task.Delay(1000);
            await _page.GoBackAsync();
        }
        public async Task EditClient()
        {
            await EdtBtn.ClickAsync();
            await Task.Delay(1000);
            await _page.GoBackAsync();
        }
        public async Task Search(string CleintSearchName)
        {
            await SearchByName.FillAsync(CleintSearchName);

            await SearchBtn.ClickAsync();

            await Task.Delay(2000);
        }
        public async Task Enterinsurancecompanies()
        {
            await _CONTRACTS.ClickAsync();
            await ClientsCrud.ClickAsync();
        }
    }
}
