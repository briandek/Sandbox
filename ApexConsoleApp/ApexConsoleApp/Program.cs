using ApExplorer;
using ApExplorer.Amazon.ECS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApexConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            AmazonProductExplorer apex = new AmazonProductExplorer("", "", "");

            apex._BasicHttpBinding.MaxReceivedMessageSize = 99999;

            string[] responseGroup = new string[] { "ItemAttributes", "Small" };

            ItemSearchResponse response = apex.SearchItemByTitle("VideoGames", "far cry 3", responseGroup);

            var responseList = response.Items.SelectMany(i => i.Item);

            foreach (Item item in responseList)
            {
                Console.WriteLine(item.ASIN + " : " + item.ItemAttributes.Title.Trim() + " ");

                if (item.ItemAttributes.ListPrice != null)
                {
                    Console.WriteLine(item.ItemAttributes.ListPrice.FormattedPrice);
                }

                Console.WriteLine(item.ItemAttributes.ReleaseDate);
                Console.WriteLine(item.ItemAttributes.Genre);

                if (item.ItemAttributes.Platform != null)
                {
                    foreach (string p in item.ItemAttributes.Platform)
                    {
                        Console.WriteLine(p);
                    }
                }
                //if (item.ItemAttributes.Feature != null)
                //{
                //    foreach (string f in item.ItemAttributes.Feature)
                //    {
                //        Console.WriteLine(f);
                //    }
                //}

                Console.WriteLine("");

                
            }

            Console.WriteLine("{0} results found", response.Items.Sum(i => Int32.Parse(i.TotalResults)));
        }
    }
}
