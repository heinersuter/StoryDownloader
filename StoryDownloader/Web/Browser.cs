using System;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.PhantomJS;

namespace StoryDownloader.Web
{
    public class Browser
    {
        public static string OutputFile { get; } = "output.html";

        public void DownloadStroy(string url)
        {
            if (File.Exists(OutputFile))
            {
                File.Delete(OutputFile);
            }

            WriteFile("<!DOCTYPE html><html xmlns=\"http://www.w3.org/1999/xhtml\"><head><meta charset=\"utf-8\"/></head><body>");

            IWebDriver driver = new PhantomJSDriver();
            driver.Navigate().GoToUrl(url);

            var isTextAvailable = true;
            while (isTextAvailable)
            {
                Log($"Reading page: {driver.Title}");

                var contentDiv = driver.FindElement(By.ClassName("b-story-body-x"));
                WriteFile(contentDiv.GetInnerHtml());

                var nextButton = driver.TryFindElement(By.CssSelector("a.b-pager-next"));
                if (nextButton != null)
                {
                    nextButton.Click();
                    Log("Navigating to next page");
                }
                else
                {
                    isTextAvailable = false;
                }
            }

            WriteFile("</body></html>");

            driver.Quit();
        }

        private static void Log(string message)
        {
            var oldColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(message);
            Console.ForegroundColor = oldColor;
        }

        private static async void WriteFile(string message)
        {
            using (var stream = File.AppendText(OutputFile))
            {
                await stream.WriteLineAsync(message);
            }
        }
    }
}
