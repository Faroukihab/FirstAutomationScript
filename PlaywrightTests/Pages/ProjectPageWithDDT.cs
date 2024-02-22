using Azure;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.Playwright;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TF.Pages
{
    public class ProjectPageWithDDT
    {
        IPage _page;
        private object dynamicElement;
        private readonly ILocator _payroll;
        private readonly ILocator _projectcrude;
        private readonly ILocator _Newprojectcreatebutton;
        private readonly ILocator _projectAlias;
        private readonly ILocator _projectcreateButton;
        private readonly ILocator _searchprojectbycleintname;
        private readonly ILocator _GothethirdPagebutton;
        private readonly ILocator _Incometaxvalue;
        private readonly ILocator _Editbutton;

        public ProjectPageWithDDT(IPage page)
        {
            _page = page;
            _payroll = _page.GetByLabel("scrollable content").GetByText("Payroll");
            _projectcrude = _page.GetByRole(AriaRole.Link, new() { Name = "- Projects" });
            _Newprojectcreatebutton = _page.GetByRole(AriaRole.Button, new() { Name = "Create" });
            _projectAlias = _page.GetByLabel("alias *");
            _projectcreateButton = _page.GetByLabel("alias *");
            //_searchprojectbycleintname = _page.GetByLabel("Client Name");
            _Incometaxvalue = _page.Locator("p").Filter(new() { HasText = "841.45" });
            _GothethirdPagebutton = _page.GetByLabel("Page 3");
            _Editbutton = _page.GetByRole(AriaRole.Row, new() { Name = "Farouk Ihab 0.00 0.00 5,000." }).GetByRole(AriaRole.Button);
        }

        public async Task EnterrProjectcrude()
        {
            await _payroll.ClickAsync();
            await _projectcrude.ClickAsync();
            await Task.Delay(1000);
        }

        //public async Task SearchonProjects(string cleintname)
        //{
        //    await _searchprojectbycleintname.FillAsync(cleintname);
        //    await Task.Delay(1000);
        //}
        public async Task verifypayrollvalues()
        {
            await _GothethirdPagebutton.ClickAsync();
            await _page.GetByRole(AriaRole.Row, new() { Name = "mnd-ESCC0002P0014 mnd-ESCC0002 Eastern company ECC" }).GetByRole(AriaRole.Link).Nth(1).ClickAsync();
            await _page.Locator("div").Filter(new() { HasTextRegex = new Regex("^Payroll$") }).Nth(1).ClickAsync();
            await _page.GetByRole(AriaRole.Row, new() { Name = "Mohamed Hasan Ahmed 0.00 0.00" }).GetByRole(AriaRole.Button).ClickAsync();
            await Task.Delay(1000);

            var spanElements = await _page.QuerySelectorAllAsync("span");
            foreach (var spanElement in spanElements)
            {
                // Check if the text content of the current span element contains "Basic salary"
                if ((await spanElement.TextContentAsync()).Contains("Basic salary"))
                {
                    // Get the parent div element
                    var parentDiv = await spanElement.EvaluateAsync<IElementHandle>("(element) => element.closest('div')");

                    // Get the grandparent div element
                    var grandparentDiv = await parentDiv.EvaluateAsync<IElementHandle>("(element) => element.parentElement.parentElement");

                    // Find the input element of type number within the grandparent div
                    var inputElement = await grandparentDiv.QuerySelectorAsync("input[type=\"number\"]");

                    // Fill the input field with the value "10000"
                    await inputElement.FillAsync("20000");

                    // Log a message indicating that the field has been filled
                    Console.WriteLine("Number field filled with value: 10000");

                    // If you want to stop searching after finding the first occurrence, you can break out of the loop
                    break;
                }
            }









        }


    }
}
