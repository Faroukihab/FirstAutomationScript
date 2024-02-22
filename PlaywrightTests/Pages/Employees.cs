using Microsoft.Playwright;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TF.Pages
{
    public class Employee
    {
        IPage _page;
        //  private IPage page;
        private readonly ILocator _SearchBanksbyName;
        private readonly ILocator _Employeesbtn;
        private readonly ILocator _EmployeeCrude;
        private readonly ILocator _EmployeeSearchBtn;
        private readonly ILocator _EmployeeEditBtn;
        private readonly ILocator _EmployeeCreate;
        private readonly ILocator _EmployeeArabicName;
        private readonly ILocator _EmployeeEnglishName;
       




        public Employee(IPage page)
        {
            _page = page;
            _Employeesbtn = _page.GetByText("Employees");
            _EmployeeCrude = _page.GetByRole(AriaRole.Link, new() { Name = "- Employee" });
            _SearchBanksbyName = _page.GetByLabel("Employee Name");
            _EmployeeSearchBtn = _page.GetByText("Search", new() { Exact = true });
            _EmployeeEditBtn =  _page.GetByRole(AriaRole.Row, new() { Name = "Mohamed Hasan Ahmed N/A sse-VFNC0006P0006 6 Test1" }).GetByRole(AriaRole.Link);
            _EmployeeCreate = _page.GetByRole(AriaRole.Button, new() { Name = "Create" });
            _EmployeeArabicName = _page.GetByLabel("Arabic Name");
            _EmployeeEnglishName = _page.GetByLabel("English Name");
        


        }
        public async Task EnterEmployeePage()
        {
            await _Employeesbtn.ClickAsync();
            await Task.Delay(1000);
            await _EmployeeCrude.ClickAsync();
            await Task.Delay(1000);
        }
        public async Task SeachOnEmployee()
        {
            await _SearchBanksbyName.FillAsync("Farouk");
            await _EmployeeSearchBtn.ClickAsync();
            await Task.Delay(5000);
        }
        
        public async Task ClickonEditBtn()
        {
            await _EmployeeEditBtn.ClickAsync();
        }
        public async Task CreateNewEmp()
        {
            await _page.GetByRole(AriaRole.Button, new() { Name = "Create" }).ClickAsync();

            await _page.GetByLabel("Arabic Name *").ClickAsync();

            await _page.GetByLabel("Arabic Name *").FillAsync("T06");

            await _page.GetByLabel("Arabic Name *").PressAsync("Tab");

            await _page.GetByLabel("English Name *").FillAsync("T06");

            await _page.GetByLabel("Gender *").ClickAsync();

            await _page.GetByRole(AriaRole.Option, new() { Name = "Male", Exact = true }).ClickAsync();

            await _page.GetByLabel("Religion *").ClickAsync();

            await _page.GetByRole(AriaRole.Option, new() { Name = "Muslim" }).ClickAsync();

            await _page.GetByLabel("ID Issue Date *").ClickAsync();

            await _page.GetByLabel("ID Issue Date *").FillAsync("09/03/2023");

            await _page.GetByLabel("ID Issue Date *").PressAsync("Tab");

            await _page.GetByLabel("Choose date, selected date is Mar 9, 2023").PressAsync("Tab");

            await _page.GetByLabel("ID Expiry Date *").FillAsync("09/02/2030");

            await _page.GetByLabel("ID Expiry Date *").PressAsync("Tab");

             await _page.Locator(".css-ebm2zr").First.ClickAsync();

            await _page.Locator("#react-select-2-input").FillAsync("alexandria");

            await _page.Locator("#react-select-2-input").PressAsync("Tab");

            await _page.Locator("#react-select-2-input").PressAsync("Tab");

            await _page.Locator("#issue_center_id-list").PressAsync("Tab");

            await _page.Locator("#issue_center_id-list").ClickAsync();

            await _page.GetByRole(AriaRole.Option, new() { Name = "Al dekhila" }).ClickAsync();




            await _page.GetByLabel("ID Issue Number").FillAsync("123r5w");

       

            await _page.GetByLabel("Arabic Address *").ClickAsync();

            await _page.GetByLabel("Arabic Address *").FillAsync("الاسكندرية");

            await _page.GetByLabel("Arabic Address *").PressAsync("Tab");

            await _page.GetByLabel("English Address *").FillAsync("Alexandria");

            await _page.Locator(".MuiCardContent-root > div:nth-child(2) > div > div > .css-b62m3t-container > .MuiFormControl-root > .css-1wz0hzf-control > .css-1wy0on6 > .css-1xc3v61-indicatorContainer > .css-8mmkcg").ClickAsync();

            await _page.Locator("#react-select-4-input").FillAsync("egypt");

            await _page.Locator("#react-select-4-input").PressAsync("Tab");


            await _page.Locator("div:nth-child(2) > div > .css-b62m3t-container > .MuiFormControl-root > .css-1wz0hzf-control > .css-j7opp9").ClickAsync();

            await _page.Locator("#react-select-5-input").FillAsync("Alexandria");

            await _page.Locator("#react-select-5-input").PressAsync("Tab");



            await _page.GetByRole(AriaRole.Main).Locator("div").Filter(new() { HasText = "Place of Birth" }).Nth(3).ClickAsync();

            await _page.GetByRole(AriaRole.Option, new() { Name = "sidigaber" }).ClickAsync();


            await _page.GetByLabel("Name In Bank").ClickAsync();

            await _page.GetByLabel("Name In Bank").FillAsync("T01");

            await _page.GetByLabel("Account Number").ClickAsync();

            await _page.GetByLabel("Account Number").FillAsync("12345");

            await _page.Locator("div:nth-child(4) > div > .css-b62m3t-container > .MuiFormControl-root > .css-1wz0hzf-control > .css-j7opp9 > .css-ebm2zr").ClickAsync();

            await _page.GetByText("bank", new() { Exact = true }).ClickAsync();

            await _page.Locator("div:nth-child(5) > div > .css-b62m3t-container > .MuiFormControl-root > .css-1wz0hzf-control > .css-j7opp9 > .css-ebm2zr").ClickAsync();

            await _page.GetByText("Euro", new() { Exact = true }).ClickAsync();

            await _page.GetByText("Education").ClickAsync();

            await _page.GetByRole(AriaRole.Button, new() { Name = "Create" }).ClickAsync();

            //await _page.GetByLabel("ID Number *").ClickAsync();

            //await _page.GetByLabel("ID Number *").ClickAsync();

            //await _page.GetByLabel("ID Number *").DblClickAsync();

            //await _page.GetByLabel("ID Number *").PressAsync("ArrowLeft");

            //await _page.GetByLabel("ID Number *").PressAsync("ArrowLeft");

            //await _page.GetByLabel("ID Number *").PressAsync("ArrowLeft");

            //await _page.GetByLabel("ID Number *").PressAsync("ArrowLeft");

            await _page.GetByLabel("ID Number *").FillAsync("27512060200899");

            //await _page.GetByLabel("ID Number *").PressAsync("ArrowRight");

            //await _page.GetByLabel("ID Number *").PressAsync("ArrowRight");

            //await _page.GetByLabel("ID Number *").PressAsync("ArrowRight");

            //await _page.GetByLabel("ID Number *").FillAsync("25512060200899");

            await _page.GetByLabel("ID Number *").PressAsync("Tab");

            //await _page.GetByLabel("ID Number *").ClickAsync();

            //await _page.GetByLabel("ID Number *").PressAsync("ArrowLeft");

            //await _page.GetByLabel("ID Number *").PressAsync("ArrowLeft");

            //await _page.GetByLabel("ID Number *").PressAsync("ArrowLeft");

           //await _page.GetByLabel("ID Number *").FillAsync("25512060200898");

            await _page.GetByRole(AriaRole.Button, new() { Name = "Create" }).ClickAsync();

            await _page.Locator("#university_id-list").ClickAsync();

            await _page.GetByRole(AriaRole.Option, new() { Name = "Alexandria university" }).ClickAsync();

            await _page.Locator("#faculty_id-list").ClickAsync();

            await _page.GetByRole(AriaRole.Option, new() { Name = "Engineering" }).ClickAsync();

            await _page.GetByLabel("​", new() { Exact = true }).ClickAsync();

            await _page.GetByRole(AriaRole.Option, new() { Name = "Bachelors" }).ClickAsync();

            await _page.GetByLabel("Bachelors").ClickAsync();

            await _page.GetByRole(AriaRole.Option, new() { Name = "Bachelors" }).ClickAsync();

            await _page.Locator("form").GetByLabel("Choose date").ClickAsync();

            await _page.GetByRole(AriaRole.Button, new() { Name = "2021" }).ClickAsync();

            await _page.GetByRole(AriaRole.Button, new() { Name = "Jun" }).ClickAsync();

            await _page.Locator("form").GetByRole(AriaRole.Button, new() { Name = "Add" }).ClickAsync();

            await _page.GetByText("Miscellaneous").ClickAsync();

            await _page.Locator("#military_status-list").ClickAsync();

            await _page.GetByRole(AriaRole.Option, new() { Name = "final Exempt" }).ClickAsync();

            await _page.GetByLabel("Military Number *").ClickAsync();
                
            await _page.GetByLabel("Military Number *").FillAsync("123456");

            await _page.Locator("div:nth-child(3) > .MuiFormControl-root > .MuiInputBase-root").ClickAsync();

            await _page.GetByLabel("​", new() { Exact = true }).ClickAsync();

            await _page.GotoAsync("http://185.227.111.191:666/employees");

            await _page.GetByLabel("Employee Name").ClickAsync();

            await _page.GetByLabel("Employee Name").FillAsync("t05");

            await _page.GetByText("Search", new() { Exact = true }).ClickAsync();

            await _page.GetByRole(AriaRole.Row, new() { Name = "T01 23-09-27774 Bachelors" }).GetByRole(AriaRole.Link).ClickAsync();

            await _page.GetByRole(AriaRole.Button, new() { Name = "Cancel" }).ClickAsync();


        }

    }

}
