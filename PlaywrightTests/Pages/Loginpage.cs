using System.Threading.Tasks;
using Microsoft.Playwright;

namespace TF.Pages
{
    public class LoginPage
    {
        private readonly ILocator _textUsername;
        private readonly ILocator _textPassword;
        private readonly ILocator _btnLogin;
        private readonly ILocator _btnForget;
        private readonly IPage _page;

        public LoginPage(IPage page)
        {
            _page = page;
            _btnLogin = _page.Locator("button.MuiButton-containedPrimary");
            _textUsername = _page.Locator("[name='username']");
            _textPassword = _page.Locator("[name='password']");
            //  _btnForget = (ILocator?)_page.QuerySelectorAsync("button:has-text('forgot password?')").GetAwaiter().GetResult();
        }

        public async Task Login(string username, string password)
        {
            await _textUsername.FillAsync(username);
            await _textPassword.FillAsync(password);
        }

        public async Task ClickLogin()
        {
            await _btnLogin.ClickAsync();
        }

        // public async Task ClickForgetPassAsync()
        // {
        //     await _btnForget.ClickAsync();
        // }
    }
}
