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
            var selectedItems = document.QuerySelectorAll("table.listingsTBL~td.TBLRoll~div.ListingDescription>a");
            var i1 = document.QuerySelectorAll("table.listingsTBL");

            foreach (var item in selectedItems)
            {
                Console.WriteLine(item.Text());
                Console.WriteLine(item.InnerHtml);
            }
        }
    }
}
