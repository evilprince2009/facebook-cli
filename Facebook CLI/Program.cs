using Microsoft.Playwright;

namespace Facebook_CLI
{
    class Program
    {
        static async Task Main()
        {
            string url = "https://www.facebook.com";
            using IPlaywright playwright = await Playwright.CreateAsync();
            BrowserTypeLaunchOptions options = new()
            {
                Headless = true,
                SlowMo = 2000
            };
            await using IBrowser browser = await playwright.Firefox.LaunchAsync(options);
            IBrowserContext context = await browser.NewContextAsync();
            IPage page = await context.NewPageAsync();
            await page.GotoAsync(url);
            string title = await page.TitleAsync();
            Console.WriteLine($"{title.Split(" ")[0]} loaded.");
        }
    }
}