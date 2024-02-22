using Microsoft.Playwright;

public class CivilOfficceWithDDT
{
    IPage _page;
    private readonly ILocator Places;
    private readonly ILocator Civil;
    private readonly ILocator CreatBtn;
    private readonly ILocator ViewBtn;
    private readonly ILocator EditBtn;
    private readonly ILocator ArabicName;
    private readonly ILocator EnglishName;
    private readonly ILocator ArabicAddress;
    private readonly ILocator EnglishAddress;


    public CivilOfficceWithDDT(IPage page)
    {
        _page = page;
        Places = _page.GetByText("Places");
        Civil = _page.GetByRole(AriaRole.Link, new() { Name = "Civil Offices" });
        CreatBtn = _page.GetByRole(AriaRole.Button, new() { Name = "Create" });

        ArabicName = _page.GetByLabel("Arabic Name *");
        EnglishName = _page.GetByLabel("English Name *");
        ViewBtn = _page.GetByRole(AriaRole.Row, new() { Name = "اللالا Isadora Parker Alexandria san Google Location" }).GetByRole(AriaRole.Link).Nth(2); ;
        EditBtn = _page.GetByRole(AriaRole.Row, new() { Name = "اللالا Isadora Parker Alexandria san Google Location" }).GetByRole(AriaRole.Link).Nth(1); ;
        ArabicAddress = _page.GetByLabel("Arabic Address *");
        EnglishAddress = _page.GetByLabel("English Address *");

    }

    public async Task EnterCivilOfficcesPage()
    {
        await Places.ClickAsync();
        await Civil.ClickAsync();
        await Task.Delay(3000);
    }
    public async Task ViewCivilOffice()
    {
        await ViewBtn.ClickAsync();
        await Task.Delay(1000);
        await _page.GoBackAsync();
    }
    public async Task EditCivilOffice()
    {
        await EditBtn.ClickAsync();
        await Task.Delay(1000);
        await _page.GoBackAsync();
    }
    public async Task CreateCivilOfice(string CivilOfficeEnglishName, string CivilOfficeArabicName)
    {
        await CreatBtn.ClickAsync();
        await _page.GetByLabel("Arabic Name *").ClickAsync();

        await _page.GetByLabel("Arabic Name *").FillAsync(CivilOfficeArabicName);

        await _page.GetByLabel("Arabic Name *").PressAsync("Tab");

        await _page.GetByLabel("English Name *").FillAsync(CivilOfficeEnglishName);

        await _page.GetByLabel("English Name *").PressAsync("Tab");

        await _page.Locator(".css-15lsz6c-indicatorContainer").ClickAsync();

        await _page.GetByText("Alexandria", new() { Exact = true }).ClickAsync();

        await _page.GetByLabel("Districts *").ClickAsync();

        await _page.GetByText("miami").ClickAsync();

        await _page.Locator("#menu- > .MuiBackdrop-root").ClickAsync();

        await _page.GetByLabel("Arabic Address *").ClickAsync();

        await _page.GetByLabel("Arabic Address *").FillAsync("الاسكندرية");

        await _page.GetByLabel("Arabic Address *").PressAsync("Tab");

        await _page.GetByLabel("English Address *").FillAsync("alexandria");

        await _page.GetByRole(AriaRole.Button, new() { Name = "Save" }).ClickAsync();


    }

}


