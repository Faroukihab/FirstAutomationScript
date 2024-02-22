using Microsoft.Playwright;

public class InsuranceOfficcesPage
{
    IPage _page;
    private readonly ILocator Places;
    private readonly ILocator insurance;
    private readonly ILocator CreatBtn;
    private readonly ILocator ViewBtn;
    private readonly ILocator EditBtn;
    private readonly ILocator ArabicName;
    private readonly ILocator EnglishName;
    private readonly ILocator ArabicAddress;
    private readonly ILocator EnglishAddress;
   

    public InsuranceOfficcesPage(IPage page)
    {
        _page = page;
        Places = _page.GetByText("Places");
        insurance = _page.GetByRole(AriaRole.Link, new() { Name = "Insurance Offices" });
        CreatBtn = _page.GetByRole(AriaRole.Button, new() { Name = "Create" });
      
        ArabicName = _page.GetByLabel("Arabic Name *");
        EnglishName = _page.GetByLabel("English Name *");
        ViewBtn = _page.Locator("a:nth-child(2)").First;
        EditBtn = _page.Locator("td:nth-child(6) > a").First;
        ArabicAddress = _page.GetByLabel("Arabic Address *");
        EnglishAddress = _page.GetByLabel("English Address *");

    }

    public async Task EnterInsuranceOfficcesPage()
    {
        await Places.ClickAsync();
        await insurance.ClickAsync();
        await Task.Delay(3000);
    }
    public async Task ViewInsuranceOffice()
    {
        await ViewBtn.ClickAsync();
        await Task.Delay(1000);
        await _page.GoBackAsync();
    }
    public async Task EditInsuranceOffice()
    {
        await EditBtn.ClickAsync();
        await Task.Delay(1000);
        await _page.GoBackAsync();
    }
    public async Task CreateInsuranceOfice()
    {
        await CreatBtn.ClickAsync();
        await EnglishName.FillAsync("test2");
        await ArabicName.FillAsync("تيست21");
        await _page.Locator(".css-ebm2zr").ClickAsync();

        await _page.GetByText("Alexandria", new() { Exact = true }).ClickAsync();

        await _page.GetByLabel("Districts *").ClickAsync();

        await _page.GetByText("miami").ClickAsync();

        await _page.Locator("#menu- > .MuiBackdrop-root").ClickAsync();

        await _page.GetByLabel("Arabic Address *").ClickAsync();

        await _page.GetByLabel("Arabic Address *").FillAsync("اسكندرية");

        await _page.GetByLabel("Arabic Address *").PressAsync("Tab");

        await _page.GetByLabel("English Address *").FillAsync("alexandria");

        await _page.GetByRole(AriaRole.Button, new() { Name = "Save" }).ClickAsync();

    }
   
}


