using Microsoft.Playwright;
using NUnit.Framework.Constraints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TF.Pages
{
    public class CompanyPageWithDDT
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
        public CompanyPageWithDDT(IPage page)
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
        public async Task SearchOnCompanyByName(string companysearchname)
        {
            await _SearchbyName.FillAsync(companysearchname);
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
        public async Task CreateNewCompany(string companyarabicname, string companyenglishname, string companyprefix, string companyalias,
            string commercialregistration, string vatid, string costcenter, string companycityarabic, string companyenglishdistrict,
            string companyarabicdistrict, string englishstreet, string arabicstreet, string postalcode)
        {

            { 
                    await _Createbtn.ClickAsync();
                    await _CompanyArabicName.FillAsync(companyarabicname);
                    await _CompanyNameEnglish.FillAsync(companyenglishname);
                    await _CompanyPrefix.FillAsync(companyprefix);
                    await _CompanyAlias.FillAsync(companyalias);
                    await _CommercailRegistration.FillAsync(commercialregistration);
                    await _VatId.FillAsync(vatid);
                    await _CostCenter.FillAsync(costcenter);
                await _page.Locator(".css-ebm2zr").First.ClickAsync();

                await _page.GetByText("Afghanistan", new() { Exact = true }).ClickAsync();



                await _page.Locator(".css-1wz0hzf-control > .css-j7opp9 > .css-ebm2zr").ClickAsync();

                await _page.GetByText("devce", new() { Exact = true }).ClickAsync();


                await _CompanyCityArabic.FillAsync(companycityarabic);
                    await _EnglishDistrict.FillAsync(companyenglishdistrict);
                    await _ArabicDistrict.FillAsync(companyarabicdistrict);
                    await _EnglishStreet.FillAsync(englishstreet);
                    await _ArabicStreet.FillAsync(arabicstreet);
                    await _PostalCode.FillAsync(postalcode);
                    await _CreateCompanyBtn.ClickAsync();
                    await Task.Delay(10000);

                    Console.WriteLine("Ok");
                }



        }
       }

    }

