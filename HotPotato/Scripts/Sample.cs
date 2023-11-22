using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace HotPotato.Scripts;

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
