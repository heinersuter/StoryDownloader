using System;

using StoryDownloader.Web;

namespace StoryDownloader
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            new Browser().DownloadStroy();
            Console.Read();
        }
    }
}
