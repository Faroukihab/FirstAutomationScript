using System;
using Microsoft.Playwright;
using ExcelDataReader;

namespace TF.Pages;
 public class LoginDDT
{
    private readonly IPage page;

    public LoginDDT(IPage page)
    {
        this.page = page;
    } 

    public void EnterUsername(string username)
    {
        page.FillAsync("input[name=username]", username);
    }

    public void EnterPassword(string password)
    {
        page.FillAsync("input[name=password]", password);
    }

    public void ClickLoginButton()
    {
        page.ClickAsync("button[type=submit]");
    }
}

public class DashboardPage
{
    private readonly IPage page;

    public DashboardPage(IPage page)
    {
        this.page = page;
    }

    public bool IsLoggedIn()
    {
        return page.Url == "http://185.227.111.191:666/dashboard";
    }
}