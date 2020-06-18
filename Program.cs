using System;
using AngleSharp;
using AngleSharp.Dom;

namespace WebCrawler_AngleSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            GetContent();
            Console.ReadKey();
        }

        static private async void GetContent()
        {
            var config = Configuration.Default.WithDefaultLoader();
            var context = BrowsingContext.New(config);
            string url = "https://mraovat.nguoi-viet.com/classified/phong-cho-thue-rooms-to-share-browse-88.aspx";
            var document = await context.OpenAsync(url);

            //var selectedItems = document.All.Where(m => m.LocalName == "td" && m.ClassList.Contains("TBLRoll"));
            //view mor selectors syntax at
            //https://www.w3schools.com/cssref/css_selectors.asp
            //OR
            //var selectedItems = document.QuerySelectorAll("table.listingsTBL td.TBLRoll div.ListingDescription>a");
            var selectedItems = document.QuerySelectorAll("table.listingsTBL td.TBLRoll");
            var i1 = document.QuerySelectorAll("table.listingsTBL td");

            foreach (var item in selectedItems)
            {
                try
                {
                    //only get new item
                    if (item.QuerySelector("div.ListingNewNDate>img") != null)
                    {
                        string content = item.QuerySelector("div.ListingDescription>a").Text().Trim();
                        string datetime = item.QuerySelector("div.ListingNewNDate>span").Text();
                        Console.WriteLine(content);
                        Console.WriteLine(datetime);
                    }
                }
                catch (Exception e) { 
                //suppress exception
                }
            }
        }
    }
}
