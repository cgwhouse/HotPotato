using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading.Tasks;

namespace WidenBotWeb.Scripts;

public class Sample
{
    public Sample() { }

    public async Task Run()
    {
        IWebDriver driver = new ChromeDriver();

        driver.Navigate().GoToUrl("https://google.com");

        await Task.Delay(5000);

        driver.Quit();
    }
}
