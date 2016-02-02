using System.Linq;
using OpenQA.Selenium;

namespace StoryDownloader.Web
{
    public static class WebDriverExtensions
    {
        public static IWebElement TryFindElement(this IWebDriver webDriver, By by)
        {
            var elements = webDriver.FindElements(by);
            if (elements.Count > 0)
            {
                return elements.First();
            }
            return null;
        }

        public static string GetOuterHtml(this IWebElement element)
        {
            return element.GetAttribute("outerHTML");
        }

        public static string GetInnerHtml(this IWebElement element)
        {
            return element.GetAttribute("innerHTML");
        }
    }
}
