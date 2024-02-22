
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
    public class InsurancePakages
    {
        private readonly IPage _page;
        private readonly ILocator InsurancePakagesCreatBtn;
        private readonly ILocator InsurancePakagesViewBtn;
        private readonly ILocator InsurancePakagesEdtBtn;
        private readonly ILocator InsurancePakagesArabicName;
        private readonly ILocator InsurancePakagesEnglishName;
        private readonly ILocator _MasterData;
        private readonly ILocator InsurancePakagesCrud;
        private readonly ILocator InsurancePakagessaveBtn;
        private readonly ILocator InstallamentValueEMP;
        private readonly ILocator InstallamentValuespouse;
        private readonly ILocator InstallamentValuevhild;
        private readonly ILocator EmpsharEmp;
        private readonly ILocator Empsharspous;
        private readonly ILocator Empsharchild;
        public InsurancePakages(IPage page)
        {
            _page = page;

            InsurancePakagesCrud = _page.GetByRole(AriaRole.Link, new() { Name = "- Insurance Packages" });
            _MasterData = _page.GetByText(new Regex("Master Data", RegexOptions.IgnoreCase));
            InsurancePakagesCreatBtn = _page.GetByRole(AriaRole.Button, new() { Name = "Create" });
            InsurancePakagesArabicName = _page.GetByLabel("Package Name AR * ");
            InsurancePakagesEnglishName = _page.GetByLabel("Package Name EN  *");
            InsurancePakagesEdtBtn = _page.GetByRole(AriaRole.Row, new() { Name = "ذهبية golden Egyptian Insurance Life insurance" }).GetByRole(AriaRole.Link).Nth(1);
            InsurancePakagesViewBtn = _page.GetByRole(AriaRole.Row, new() { Name = "ذهبية golden Egyptian Insurance Life insurance" }).GetByRole(AriaRole.Link).First;
            InsurancePakagessaveBtn = _page.GetByRole(AriaRole.Button, new() { Name = "Create" });
        }
        public async Task EnterInsuranceCompaniesCrud()
        {
            await _MasterData.ClickAsync();
            await InsurancePakagesCrud.ClickAsync();
        }
        public async Task Createinsurancecompanies()
        {
            await InsurancePakagesCreatBtn.ClickAsync();
            await Task.Delay(2000);
            await InsurancePakagesEnglishName.FillAsync("Test4");
            await InsurancePakagesArabicName.FillAsync("تيست4");

            await _page.GetByRole(AriaRole.Combobox, new() { Name = "Insurance Company" }).Locator("span").Nth(1).ClickAsync();

            await _page.GetByRole(AriaRole.Option, new() { Name = "​Egypt", Exact = true }).ClickAsync();

            await _page.Locator("#insurance_type_id-list").ClickAsync();

            await _page.GetByRole(AriaRole.Option, new() { Name = "Life insurance" }).ClickAsync();

            await _page.GetByLabel("Installment Value *").ClickAsync();

            await _page.GetByLabel("Installment Value *").FillAsync("2000");

            await _page.GetByRole(AriaRole.Combobox, new() { Name = "Currency" }).Locator("span").First.ClickAsync();

            await _page.GetByRole(AriaRole.Option, new() { Name = "​Euro", Exact = true }).ClickAsync();

            await _page.GetByLabel("Emp. Share *").ClickAsync();

            await _page.GetByLabel("Emp. Share *").FillAsync("50");

            await InsurancePakagessaveBtn.ClickAsync();
            await _page.GotoAsync("http://185.227.111.191:666/insurance-packages");


        }
        public async Task VeiwInsuranceCompanies()
        {
            await InsurancePakagesViewBtn.ClickAsync();
            await Task.Delay(2000);
            await _page.GotoAsync("http://185.227.111.191:666/insurance-packages");
        }
        public async Task EditInsurancePakages()
        {
            await InsurancePakagesEdtBtn.ClickAsync();
            await Task.Delay(2000);
            await _page.GotoAsync("http://185.227.111.191:666/insurance-packages");
        }
        public async Task InsurancePakagesSearch()
        {
            await _page.GetByLabel("Name").ClickAsync();

            await _page.GetByLabel("Name").FillAsync("golden");

            await _page.GetByText("Search", new() { Exact = true }).ClickAsync();

        }

    }
}
