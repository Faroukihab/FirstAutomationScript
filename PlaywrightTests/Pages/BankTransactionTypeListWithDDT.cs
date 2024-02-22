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
    public class BankTransactionTypesWithDDT
    {
        IPage _page;

        private readonly ILocator _Search;
        private readonly ILocator _Masterdatabtn;
        private readonly ILocator _BankTransactionTypes;
        private readonly ILocator _SearchBtn;
        private readonly ILocator _BankTransactionTypesEditBtn;
        private readonly ILocator _BankTransactionTypesViewBtn;
        private readonly ILocator _BankTransactionTypesCreateBtn;
        private readonly ILocator _BankTransactionTypesArabicName;
        private readonly ILocator _BankTransactionTypesEnglishName;
        private readonly ILocator _BankSaveBtn;





        public BankTransactionTypesWithDDT(IPage page)
        {
            _page = page;
            _Masterdatabtn = _page.GetByText("Master Data");
            _BankTransactionTypes = _page.GetByRole(AriaRole.Link, new() { Name = "- Bank Transactions Types" });
            _Search = _page.GetByLabel("Name");
            _SearchBtn = _page.GetByRole(AriaRole.Main).GetByRole(AriaRole.Button, new() { Name = "Search" });
            _BankTransactionTypesEditBtn = _page.GetByRole(AriaRole.Row, new() { Name = "اقساط installments" }).GetByRole(AriaRole.Link).Nth(1);
            _BankTransactionTypesViewBtn = _page.GetByRole(AriaRole.Row, new() { Name = "اقساط installments" }).GetByRole(AriaRole.Link).First;
            _BankTransactionTypesCreateBtn = _page.GetByRole(AriaRole.Button, new() { Name = "Create" });
            _BankTransactionTypesArabicName = _page.GetByLabel("Arabic Name *");
            _BankTransactionTypesEnglishName = _page.GetByLabel("English Name *");
            _BankSaveBtn = _page.GetByRole(AriaRole.Button, new() { Name = "Create" });



        }
        public async Task Enterbanktransactiontypes()
        {
            await _Masterdatabtn.ClickAsync();
            await _BankTransactionTypes.ClickAsync();

        }
        public async Task SeachOnbanktransactiontypes(string banktransactiontypesearch)
        {
            await _Search.FillAsync(banktransactiontypesearch);
            await _SearchBtn.ClickAsync();
            await Task.Delay(1000);
        }
        public async Task ClickonViewBtn()
        {
            await _BankTransactionTypesViewBtn.ClickAsync();
            await Task.Delay(1000);
            await _page.GoBackAsync();
        }
        public async Task ClickonEditBtn()
        {
            await _BankTransactionTypesEditBtn.ClickAsync();
            await Task.Delay(1000);
            await _page.GoBackAsync();
        }
        public async Task CreateNewbanktransactiontypes(string BankTransactionTypesArabicName, string BankTransactionTypesEnglishName)
        {
            await _BankTransactionTypesCreateBtn.ClickAsync();
            await _BankTransactionTypesArabicName.FillAsync(BankTransactionTypesArabicName);
            await _BankTransactionTypesEnglishName.FillAsync(BankTransactionTypesEnglishName);
            await _BankSaveBtn.ClickAsync();

        }
        public async Task EditBankTransactionTypes()
        {
            await _BankTransactionTypesEditBtn.ClickAsync();
            await Task.Delay(1000);
            await _page.GoBackAsync();
        }
        public async Task ViewBankTransactionTypesEditBtn()
        {
            await _BankTransactionTypesViewBtn.ClickAsync();
            await Task.Delay(1000);
            await _page.GoBackAsync();
        }
    }

}
