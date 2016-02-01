using System;

using OpenQA.Selenium;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Support.UI;

namespace StoryDownloader.Web
{
    public class Browser
    {
        public void DownloadStroy()
        {
            IWebDriver driver = new PhantomJSDriver();
            driver.Navigate().GoToUrl("http://www.google.com/");


            var query = driver.FindElement(By.Name("q"));
            query.SendKeys("Cheese");
            query.Submit();

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.Title.ToLower().StartsWith("cheese"));

            Write("Page title is: " + driver.Title);

            driver.Quit();
        }

        private static void Write(string message)
        {
            var oldColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(message);
            Console.ForegroundColor = oldColor;
        }
    }
}
