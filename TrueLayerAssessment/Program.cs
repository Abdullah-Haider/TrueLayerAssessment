using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using System.Web;

namespace TrueLayerAssessment
{
    class Program
    {
        static void Main(string[] args)
        {

            var web = new HtmlWeb();
            var document = web.Load("https://news.ycombinator.com/");


            var titles = document.DocumentNode.SelectNodes("//a[@class='storylink']");
            var authors = document.DocumentNode.SelectNodes("//a[@class='hnuser']");
            var points = document.DocumentNode.SelectNodes("//span[@class='score']");
            var comments = document.DocumentNode.SelectNodes("//*[@class='storylink']");
            var ranks = document.DocumentNode.SelectNodes("//span[@class='rank']");

            List<string> AuthorList = new List<string>();
            List<string> TitleList = new List<string>();
            List<string> URIList = new List<string>();
            List<string> PointsList = new List<string>();
            List<string> CommentsList = new List<string>();
            List<string> RanksList = new List<string>();

            //Create titles, uris, and comments list.
            foreach (var title in titles)
            {
                TitleList.Add(HttpUtility.HtmlDecode(title.InnerHtml));
                URIList.Add(HttpUtility.HtmlDecode(title.Attributes["href"].Value));
                CommentsList.Add("5");
            }


            //Create a list to hold authors information
            foreach (var author in authors)
            {
                AuthorList.Add(HttpUtility.HtmlDecode(author.InnerHtml));
            }

            //Create list of points
            foreach (var point in points)
            {
                PointsList.Add(HttpUtility.HtmlDecode(point.InnerHtml.Replace("points", "").Trim()));
            }


            //Create list of comments
            foreach (var comment in comments)
            {
                CommentsList.Add(HttpUtility.HtmlDecode(comment.InnerHtml.Replace("&nbsp;comments", "").Trim()));
            }
            //Create ranks list
            foreach (var rank in ranks)
            {
                RanksList.Add(HttpUtility.HtmlDecode(rank.InnerHtml).Replace("points", "").Trim());
            }

            //Prompt user for the input
            Console.Write("Enter the number of posts data to view:  ");

            int count = 0;
            bool pass = false;

            //Validate user input for a positive value within the range of avaliable items
            while (!pass)
            {
                //Read an integer value
                count = Convert.ToInt32(Console.ReadLine());
                if (count < 1)
                {
                    //Validate if negative or zero
                    Console.WriteLine("Invalid Input. Please Try again.");

                }
                else if (count >= AuthorList.Capacity)
                {
                    //Validate for a value above the list size
                    Console.WriteLine("The number must not exceed " + AuthorList.Capacity + "\nPlease try again.");
                }
                else
                {
                    break;
                }


            }


            //Create and display JSON array for the items
            Console.WriteLine("[");
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine("{");
                Console.WriteLine("\t\"title\": \"" + TitleList[i] + "\",");
                Console.WriteLine("\t\"uri\": \"" + URIList[i] + "\",");
                Console.WriteLine("\t\"author\": \"" + AuthorList[i] + "\",");
                Console.WriteLine("\t\"points\": \"" + PointsList[i] + "\",");
                Console.WriteLine("\t\"comments\": \"" + CommentsList[i] + "\",");
                Console.WriteLine("\t\"rank\": \"" + RanksList[i] + "\"");
                Console.WriteLine("},");
            }
            Console.WriteLine("]");
            //Keep Displaying
            Console.Read();

        }
    }
}






