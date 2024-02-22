using Azure;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace PlaywrightTests.Pages
{
    public class RequestTypeWithDDT
    {
        IPage _page;
        private readonly ILocator _CreateRequestBtn;
        private readonly ILocator _SearchBtn;
        private readonly ILocator _ResetlBtn;
        private readonly ILocator _SearchNamefield;
        private readonly ILocator _ViewBtn;
        private readonly ILocator _EditBtn;
        private readonly ILocator _EnglishNameField;
        private readonly ILocator _ArabicNameField;
        private readonly ILocator _ResponsetimeField;
        private readonly ILocator _UsersDropdownlist;
        private readonly ILocator _Requirments;
        private readonly ILocator _CreateBtn;
        private readonly ILocator _CancelBtn;
        private readonly ILocator _Masterdatabtn;

        public RequestTypeWithDDT(IPage page)
        {
            _page = page;
            _Masterdatabtn = _page.GetByText("Master Data");
            _CreateRequestBtn = _page.GetByRole(AriaRole.Button, new() { Name = "Create" });
            _EnglishNameField = _page.GetByLabel("English Name *");
            _ArabicNameField = _page.GetByLabel("Arabic Name *");
            _ResponsetimeField = _page.GetByLabel("Response Time *");
            _Requirments = _page.GetByLabel("Requirements");
            _CreateBtn = _page.GetByRole(AriaRole.Button, new() { Name = "Create" });
            _CancelBtn = _page.GetByRole(AriaRole.Button, new() { Name = "Cancel" });
            _SearchNamefield = _page.GetByLabel("Name");
            _SearchBtn = _page.GetByRole(AriaRole.Main).GetByRole(AriaRole.Button, new() { Name = "Search" });
            _ResetlBtn = _page.GetByRole(AriaRole.Main).GetByRole(AriaRole.Button, new() { Name = "Reset" });

        }
        public async Task EnterRequestTypeCrude()
        {
            await _Masterdatabtn.ClickAsync();
            await Task.Delay(1000);
            await _page.GetByRole(AriaRole.Link, new() { Name = "- Request Types" }).ClickAsync();
            await Task.Delay(1000);
        }
        public async Task CreateaRequest(string RequstEnglishName, string RequstArabicName, string ResponseTime)
        {
            await _CreateRequestBtn.ClickAsync();
            await _EnglishNameField.FillAsync(RequstEnglishName);
            await _ArabicNameField.FillAsync(RequstArabicName);
            await _ResponsetimeField.FillAsync(ResponseTime);
            await _page.Locator(".css-ebm2zr").ClickAsync();

            await _page.GetByText("Ali", new() { Exact = true }).ClickAsync();

            await _page.GetByRole(AriaRole.Button, new() { Name = "Create" }).ClickAsync();

        }
        public async Task SearchonCreatedRequested(string RequestSearchName)
        {
            await _SearchNamefield.FillAsync(RequestSearchName);
            await Task.Delay(1000);
            await _SearchBtn.ClickAsync();
            await Task.Delay(1000);
        }
        public async Task EnterviewPage()
        {
            await _page.GetByRole(AriaRole.Row, new() { Name = "اجازة offf 20.0" }).GetByRole(AriaRole.Link).First.ClickAsync();
        }
        public async Task EnterEditPage()
        {
            await _page.GetByRole(AriaRole.Row, new() { Name = "اجازة offf 20.0" }).GetByRole(AriaRole.Link).Nth(1).ClickAsync();
        }
    }

}
