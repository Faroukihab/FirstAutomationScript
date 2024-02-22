using Microsoft.Playwright;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TF.Pages
{
    public class CompanyPage
    {
        IPage _page;
        private IPage page;
        private readonly ILocator _CompanyCrud;
        private readonly ILocator _Createbtn;
        private readonly ILocator _SearchbyName;
        private readonly ILocator _SeerchbyAlias;
        private readonly ILocator _SearchbyPrefix;
        private readonly ILocator _Searchbtn;
        private readonly ILocator _Resetbtn;
        private readonly ILocator _Viewbtn;
        private readonly ILocator _Editbtn;
        private readonly ILocator _Masterdatabtn;
        private readonly ILocator _CompanyArabicName;
        private readonly ILocator _CompanyNameEnglish;
        private readonly ILocator _CompanyPrefix;
        private readonly ILocator _CompanyAlias;
        private readonly ILocator _CommercailRegistration;
        private readonly ILocator _VatId;
        private readonly ILocator _CostCenter;
        private readonly ILocator _CompanyCityEnglish;
        private readonly ILocator _CompanyCityArabic;
        private readonly ILocator _EnglishDistrict;
        private readonly ILocator _ArabicDistrict;
        private readonly ILocator _EnglishStreet;
        private readonly ILocator _ArabicStreet;
        private readonly ILocator _PostalCode;
        private readonly ILocator _CreateCompanyBtn;
        public CompanyPage(IPage page)
        {
            _page = page;


            _Createbtn = _page.GetByRole(AriaRole.Button, new() { Name = "Create" });
            _SearchbyName = _page.GetByLabel("Name");
            _SeerchbyAlias = _page.Locator("[name='Alias']");
            _SearchbyPrefix = _page.Locator("[name='Prefix']");
            _Searchbtn = _page.GetByText("Search", new() { Exact = true });

            _Resetbtn = _page.Locator("[class='MuiButtonBase-root MuiButton-root MuiButton-contained MuiButton-containedWarning MuiButton-sizeMedium MuiButton-containedSizeMedium MuiButton-disableElevation MuiButton-root MuiButton-contained MuiButton-containedWarning MuiButton-sizeMedium MuiButton-containedSizeMedium MuiButton-disableElevation css-ngqxkm']");
            _Viewbtn = _page.GetByRole(AriaRole.Row, new() { Name = "المصرية الاولي للهندسة فرست First Egyptian Engineering First" }).GetByRole(AriaRole.Link).First;


            _Masterdatabtn = _page.GetByText(new Regex("Master Data", RegexOptions.IgnoreCase));
            _CompanyCrud = _page.GetByRole(AriaRole.Link, new() { Name = "- Companies" });
            _Editbtn = _page.GetByRole(AriaRole.Row, new() { Name = "المصرية الاولي للهندسة فرست First Egyptian Engineering First" }).GetByRole(AriaRole.Link).Nth(1);

            _CompanyArabicName = _page.GetByLabel("Company Name (In Arabic)");
            _CompanyNameEnglish = _page.GetByLabel("Company Name (In English)");
            _CompanyPrefix = _page.GetByLabel("Prefix");
            _CompanyAlias = _page.GetByLabel("Alias");
            _CommercailRegistration = _page.GetByLabel("Commerial Registeration");
            _VatId = _page.GetByLabel("VAT.ID.");
            _CostCenter = _page.GetByLabel("Cost Center");
            _CompanyCityEnglish = _page.GetByLabel("City (In English)");
            _CompanyCityArabic = _page.GetByLabel("City (In Arabic)");
            _EnglishDistrict = _page.GetByLabel("District (In English)");
            _ArabicDistrict = _page.GetByLabel("District (In Arabic)");
            _EnglishStreet = _page.GetByLabel("Street (In English)");
            _ArabicStreet = _page.GetByLabel("Street (In Arabic)");
            _PostalCode = _page.GetByLabel("Postal Code");
            _CreateCompanyBtn = _page.GetByRole(AriaRole.Button, new() { Name = "Create Company" });
        }


        public async Task EnterCompanyCrud()
        {
            await _Masterdatabtn.ClickAsync();
      
            await _CompanyCrud.ClickAsync();
        }
        public async Task SearchOnCompanyByName()
        {
            await _SearchbyName.FillAsync("Sana");
            await _Searchbtn.ClickAsync();

        }
        public async Task ClickEditBtn()
        {

            await _Editbtn.ClickAsync();
            await Task.Delay(1000);


        }

        public async Task ClickVeiwBtn()
        {
            await _Viewbtn.ClickAsync();
            await Task.Delay(1000);

        }
        public async Task CreateNewCompany()
        {
            await _Createbtn.ClickAsync();
            await _CompanyArabicName.FillAsync("2الابطال");
            await _CompanyNameEnglish.FillAsync("heros2");
            await _CompanyPrefix.FillAsync("hcee");
            await _CompanyAlias.FillAsync("hee");
            await _CommercailRegistration.FillAsync("1589258");
            await _VatId.FillAsync("45879");
            await _CostCenter.FillAsync("178998");
            await _page.Locator(".css-j7opp9").First.ClickAsync();

            await _page.Locator("#react-select-2-input").FillAsync("egypt");

            await _page.GetByText("Egypt", new() { Exact = true }).ClickAsync();

            await _page.Locator(".css-1wz0hzf-control > .css-j7opp9 > .css-ebm2zr").ClickAsync();

            await _page.GetByText("Alexandria", new() { Exact = true }).ClickAsync();

            await _CompanyCityArabic.FillAsync("الاسكندرية");
            await _EnglishDistrict.FillAsync("smouha");
            await _ArabicDistrict.FillAsync("سموحة");
            await _EnglishStreet.FillAsync("fawzy moaaz");
            await _ArabicStreet.FillAsync("فوزي معاذ");
            await _PostalCode.FillAsync("44565");
            await _CreateCompanyBtn.ClickAsync();
            await Task.Delay(10000);
            Console.WriteLine("Ok");



        }
    }
}
