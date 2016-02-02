using System;
using System.Diagnostics;
using StoryDownloader.Web;

namespace StoryDownloader
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            string url;
            if (args.Length != 1)
            {
                url = Console.ReadLine();
            }
            else
            {
                url = args[0];
            }
            new Browser().DownloadStroy(url);

            Process.Start(Browser.OutputFile);
        }
    }
}
