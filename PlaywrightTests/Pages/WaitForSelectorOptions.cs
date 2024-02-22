using Microsoft.Playwright;

namespace TF.Pages
{
    internal class WaitForSelectorOptions : PageWaitForSelectorOptions
    {
        public int Timeout { get; set; }
    }
}