using Microsoft.Playwright;

public class LaborOfficceWithDDT
{
    IPage _page;
    private readonly ILocator Places;
    private readonly ILocator Labor;
    private readonly ILocator CreatBtn;
    private readonly ILocator ViewBtn;
    private readonly ILocator EditBtn;
    private readonly ILocator ArabicName;
    private readonly ILocator EnglishName;
    private readonly ILocator ArabicAddress;
    private readonly ILocator EnglishAddress;


    public LaborOfficceWithDDT(IPage page)
    {
        _page = page;
        Places = _page.GetByText("Places");
        Labor = _page.GetByRole(AriaRole.Link, new() { Name = "Labor Office" });
        CreatBtn = _page.GetByRole(AriaRole.Button, new() { Name = "Create" });

        ArabicName = _page.GetByLabel("Arabic Name *");
        EnglishName = _page.GetByLabel("English Name *");
        ViewBtn = _page.GetByRole(AriaRole.Row, new() { Name = "جمال عبد الناصر gamal abdelnasser Alexandria miami Google Location" }).GetByRole(AriaRole.Link).Nth(2);
        EditBtn = _page.GetByRole(AriaRole.Row, new() { Name = "جمال عبد الناصر gamal abdelnasser Alexandria miami Google Location" }).GetByRole(AriaRole.Link).Nth(1);
        ArabicAddress = _page.GetByLabel("Arabic Address *");
        EnglishAddress = _page.GetByLabel("English Address *");

    }

    public async Task EnterLaborOfficcesPage()
    {
        await Places.ClickAsync();
        await Labor.ClickAsync();
        await Task.Delay(3000);
    }
    public async Task ViewLaborOffice()
    {
        await ViewBtn.ClickAsync();
        await Task.Delay(1000);
        await _page.GoBackAsync();
    }
    public async Task EditLaborOffice()
    {
        await EditBtn.ClickAsync();
        await Task.Delay(1000);
        await _page.GoBackAsync();
    }
    public async Task CreateLaborOfice(string LaborOfficeEnglishName, string LaborOfficeArabicName)
    {
        await CreatBtn.ClickAsync();
        await EnglishName.FillAsync(LaborOfficeEnglishName);
        await ArabicName.FillAsync(LaborOfficeArabicName);
        await _page.Locator(".css-ebm2zr").ClickAsync();

        await _page.GetByText("Alexandria", new() { Exact = true }).ClickAsync();

        await _page.GetByLabel("Districts *").ClickAsync();

        await _page.GetByText("rehan").ClickAsync();

        await _page.Locator("#menu- > .MuiBackdrop-root").ClickAsync();

        await _page.GetByLabel("Arabic Address *").ClickAsync();

        await _page.GetByLabel("Arabic Address *").ClickAsync();

        await _page.GetByLabel("Arabic Address *").FillAsync("اسكندرية");

        await _page.GetByLabel("Arabic Address *").PressAsync("Tab");

        await _page.GetByLabel("English Address *").FillAsync("alex");

        await _page.GetByRole(AriaRole.Button, new() { Name = "Save" }).ClickAsync();

        await _page.GetByRole(AriaRole.Button, new() { Name = "Save" }).ClickAsync();

    }

}


