using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightTests.Pages
{
    public class EmployeeRequestListPage
    {
        IPage _page;
        private readonly ILocator Searchbyrequesttitle;
        private readonly ILocator Searchbyrequesttype;
        private readonly ILocator Searchbyrequeststatus;
        private readonly ILocator SearchBtn;
        private readonly ILocator ResetBtn;
        private readonly ILocator ResponsetoRequestBtn;
        private readonly ILocator AcceptBtn;
        private readonly ILocator RejectBtn;
        private readonly ILocator _Masterdatabtn;
        private readonly ILocator EmployeeRequst;
        public EmployeeRequestListPage (IPage page)
        {
            _page = page;
            Searchbyrequesttitle = _page.GetByLabel("Request Title");
            SearchBtn = _page.GetByRole(AriaRole.Main).GetByRole(AriaRole.Button, new() { Name = "Search" });
            ResetBtn = _page.GetByRole(AriaRole.Button, new() { Name = "Reset" });
            ResponsetoRequestBtn = _page.GetByRole(AriaRole.Row, new() { Name = "Mariam Vacation Mohamed Hasan Ahmed 2023-07-16 2023-07-26 pending" }).GetByRole(AriaRole.Link);
            AcceptBtn = _page.GetByRole(AriaRole.Button, new() {Name = "Accept" });
            _Masterdatabtn = _page.GetByText("Master Data");
            EmployeeRequst = _page.GetByRole(AriaRole.Link, new() { Name = "- Employees Requests" });
            RejectBtn = _page.GetByRole(AriaRole.Button, new() { Name = "Reject" });
        }
        public async Task EnterEmployeeRequestCrude()
        {
            await _Masterdatabtn.ClickAsync();
            await EmployeeRequst.ClickAsync();
            await Task.Delay(1000);
        }
        public async Task Acceptemployeerequest()
        {
            await ResponsetoRequestBtn.ClickAsync();
            await AcceptBtn.ClickAsync();
            await Task.Delay(1000);

        }
        public async Task RejectEmpRequest()
        {
            await ResponsetoRequestBtn.ClickAsync();
            await RejectBtn.ClickAsync();
            await Task.Delay(1000);
        }
    }
   
}
