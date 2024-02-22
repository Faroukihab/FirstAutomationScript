﻿using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TF.Pages
{
    public class InsuranceCompanieswithDDT
    {
        private readonly IPage _page;
        private readonly ILocator InsuranceCompaniesCreatBtn;
        private readonly ILocator InsuranceCompaniesViewBtn;
        private readonly ILocator InsuranceCompaniesEdtBtn;
        private readonly ILocator InsuranceCompaniesArabicName;
        private readonly ILocator InsuranceCompaniesEnglishName;
        private readonly ILocator _MasterData;
        private readonly ILocator InsuranceCompaniesCrud;
        private readonly ILocator InsuranceCompaniessaveBtn;

        public InsuranceCompanieswithDDT(IPage page)
        {
            _page = page;

            InsuranceCompaniesCrud = _page.GetByRole(AriaRole.Link, new() { Name = "- Insurance Companies" });
            _MasterData = _page.GetByText(new Regex("Master Data", RegexOptions.IgnoreCase));
            InsuranceCompaniesCreatBtn = _page.GetByRole(AriaRole.Button, new() { Name = "Create" });
            InsuranceCompaniesArabicName = _page.GetByLabel("Arabic Name *");
            InsuranceCompaniesEnglishName = _page.GetByLabel("English Name *");
            InsuranceCompaniesEdtBtn = _page.GetByRole(AriaRole.Row, new() { Name = "Egypt Egypt" }).GetByRole(AriaRole.Link).Nth(1);
            InsuranceCompaniesViewBtn = _page.GetByRole(AriaRole.Row, new() { Name = "Egyptian Insurance Åland Islands" }).GetByRole(AriaRole.Link).First;
            InsuranceCompaniessaveBtn = _page.GetByRole(AriaRole.Button, new() { Name = "Save" });

        }
        public async Task EnterInsuranceCompaniesCrud()
        {
            await _MasterData.ClickAsync();
            await InsuranceCompaniesCrud.ClickAsync();
        }
        public async Task Createinsurancecompanies(string InsuranceCompanyArabicName, string InsuranceCompanyEnglishName)
        {
            await InsuranceCompaniesCreatBtn.ClickAsync();
            await InsuranceCompaniesArabicName.FillAsync(InsuranceCompanyArabicName);
            await InsuranceCompaniesEnglishName.FillAsync(InsuranceCompanyEnglishName);
            //await _page.Locator(".css-13ytdlh").ClickAsync();

            await _page.Locator(".css-j7opp9").ClickAsync();

            await _page.GetByText("Afghanistan", new() { Exact = true }).ClickAsync();

            await _page.GetByRole(AriaRole.Button, new() { Name = "Save" }).ClickAsync();

            await Task.Delay(1000);
            await InsuranceCompaniessaveBtn.ClickAsync();
        }
        public async Task VeiwInsuranceCompanies()
        {
            await InsuranceCompaniesViewBtn.ClickAsync();
            await _page.GotoAsync("http://185.227.111.191:666/general/insurance-companies");
        }
        public async Task EditInsuranceCompanies()
        {
            await InsuranceCompaniesEdtBtn.ClickAsync();
            await _page.GotoAsync("http://185.227.111.191:666/general/insurance-companies");
        }
        public async Task InsuranceCompaniesSearch(string InsuranceCompanySearchName)
        {
            await _page.GetByLabel("Name").ClickAsync();

            await _page.GetByLabel("Name").FillAsync(InsuranceCompanySearchName);

            await _page.GetByLabel("Name").PressAsync("Tab");

            await _page.Locator(".css-8mmkcg").ClickAsync();

            await _page.Locator("#react-select-9-input").FillAsync("egy");

            await _page.Locator("#react-select-9-option-64").ClickAsync();

            await _page.GetByText("Search", new() { Exact = true }).ClickAsync();
        }
        public async Task Enterinsurancecompanies()
        {
            await _MasterData.ClickAsync();
            await InsuranceCompaniesCrud.ClickAsync();
        }
    }
}
