using Microsoft.Playwright;

public class IssueCenterWithDDT
{
    IPage _page;
    private readonly ILocator Places;
    private readonly ILocator IssueCenter;
    private readonly ILocator CreatBtn;
    private readonly ILocator ViewBtn;
    private readonly ILocator EditBtn;
    private readonly ILocator ArabicName;
    private readonly ILocator EnglishName;
    private readonly ILocator SearhByName;
    private readonly ILocator SearchBtn;


    public IssueCenterWithDDT(IPage page)
    {
        _page = page;
        Places = _page.GetByText("Places");
        IssueCenter = _page.GetByRole(AriaRole.Link, new() { Name = "Issue Centers" });
        CreatBtn = _page.GetByRole(AriaRole.Button, new() { Name = "Create" });
        ViewBtn = _page.GetByRole(AriaRole.Row, new() { Name = "بولاق الدكرور" }).GetByRole(AriaRole.Link).First;
        EditBtn = _page.GetByRole(AriaRole.Row, new() { Name = "بولاق الدكرور" }).GetByRole(AriaRole.Link).Nth(1);
        ArabicName = _page.GetByLabel("Arabic Name *");
        EnglishName = _page.GetByLabel("English Name *");
        SearhByName = _page.GetByLabel("Name");
        SearchBtn = _page.GetByText("Search", new() { Exact = true });




    }

    public async Task EnterIssueCenterPage()
    {
        await Places.ClickAsync();
        await IssueCenter.ClickAsync();
        await Task.Delay(1000);
    }
    public async Task ViewIssueCenter()
    {
        await ViewBtn.ClickAsync();
        await Task.Delay(1000);
        await _page.GoBackAsync();
    }
    public async Task EditIssueCenter()
    {
        await EditBtn.ClickAsync();
        await Task.Delay(1000);
        await _page.GoBackAsync();
    }
    public async Task CreateIssueCenter(string IssueCenterEnglishName, string IssueCenterArabicName)
    {
        await CreatBtn.ClickAsync();
        await EnglishName.FillAsync(IssueCenterEnglishName);
        await ArabicName.FillAsync(IssueCenterArabicName);
        await _page.Locator(".css-ebm2zr").ClickAsync();

        await _page.GetByText("Alexandria", new() { Exact = true }).ClickAsync();

        await _page.GetByRole(AriaRole.Button, new() { Name = "Create" }).ClickAsync();

    }

    public async Task SeachOnIssueCenter(string IsssueCenterSearchName)
    {
        await SearhByName.FillAsync(IsssueCenterSearchName);
        await SearchBtn.ClickAsync();
    }

}


