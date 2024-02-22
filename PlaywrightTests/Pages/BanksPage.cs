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
    public class BanksPage
    {
        IPage _page;
        //  private IPage page;
        private readonly ILocator _SearchBanksbyName;
        private readonly ILocator _Masterdatabtn;
        private readonly ILocator _BanksCrude;
        private readonly ILocator _BankSearchBtn;
        private readonly ILocator _BankEditBtn;
        private readonly ILocator _BankViewBtn;
        private readonly ILocator _BankCreate;
        private readonly ILocator _BankArabicName;
        private readonly ILocator _BankEnglishName;
        private readonly ILocator _BankCode;
        private readonly ILocator _BankSaveBtn;
        private readonly ILocator _SearchBankByCode;




        public BanksPage(IPage page)
        {
            _page = page;
            _Masterdatabtn = _page.GetByText("Master Data");
            _BanksCrude = _page.GetByRole(AriaRole.Link, new() { Name = "- Banks" });
            _SearchBanksbyName = _page.GetByLabel("Name");
            _BankSearchBtn = _page.GetByText("Search", new() { Exact = true });
            _BankEditBtn = _page.GetByRole(AriaRole.Row, new() { Name = "سي اي بي CIB 123456789" }).GetByRole(AriaRole.Link).Nth(1);
            _BankViewBtn = _page.GetByRole(AriaRole.Row, new() { Name = "سي اي بي CIB 123456789" }).GetByRole(AriaRole.Link).First;
            _BankCreate = _page.GetByRole(AriaRole.Button, new() { Name = "Create" });
            _BankArabicName = _page.GetByLabel("Arabic Name");
            _BankEnglishName = _page.GetByLabel("English Name");
            _BankCode = _page.GetByLabel("Code");
            _BankSaveBtn = _page.GetByRole(AriaRole.Button, new() { Name = "Save" });
            _SearchBankByCode = _page.GetByLabel("Code");


        }
        public async Task EnterBankPage()
        {
            await _Masterdatabtn.ClickAsync();
            await Task.Delay(1000);
            await _BanksCrude.ClickAsync();
            await Task.Delay(1000);
        }
        public async Task SeachOnBanks()
        {
            await _SearchBanksbyName.FillAsync("CIB");
            await _BankSearchBtn.ClickAsync();
            await Task.Delay(1000);
        }
        public async Task ClickonViewBtn()
        {
            await _BankViewBtn.ClickAsync();
        }
        public async Task ClickonEditBtn()
        {
            await _BankEditBtn.ClickAsync();
        }
        public async Task CreateNewBank()
        {
            await _BankCreate.ClickAsync();
            //  await _BankArabicName.FillAsync("11تيست");
            await _BankEnglishName.FillAsync("T46");
            //  await _BankCode.FillAsync("445578");
            await _BankSaveBtn.ClickAsync();
            await Task.Delay(1000);
        }
        //public async Task SearchOnCreatedBank()
        //{
        //    await _SearchBankByCode.FillAsync("543223");
        //   await _BankSearchBtn.ClickAsync();
        //   await Task.Delay(1000);
        //}
    }

}
