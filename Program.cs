using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Linq;


namespace Lab11_5_Database_C_HTML
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Lab 11.5 Database to C# to HTML! ***** \n");
           
            // Create database context
            SakilaContext context = new SakilaContext();
           
          // Create new films
             Film movie1917 = new Film("1917", "War Drama by Director Sam Mendes", "2019", 3, 5.99m, 179, 19.99m, "R");
             Film joker = new Film("JOKER", "Oscar-Nominated SuperHero Drama", "2019", 3, 6.99m, 182, 23.99m, "R");
             Film starWars = new Film("STAR WARS: THE RISE OF SKYWALKER", "Trash Disney Fan-fic", "2019", 3, 4.99m, 202, 21.99m, "PG-13");
             Film toystory5 = new Film("TOY STORY 5", "Toys come to life again", "2019", 3, 4.99m, 180, 20.99m, "PG");
             Film sunshine = new Film("SUNSHINE", "Evil can't hide in the light", "2019", 3, 2.99m, 120, 16.99m, "R");

            // Add new films to database
              context.Film.Add(movie1917); 
              context.Film.Add(joker);
              context.Film.Add(starWars);
              context.Film.Add(toystory5);
              context.Film.Add(sunshine);

            //save changes in sakila database 
            context.SaveChanges();

            // put database table into array
            Film[] allFilms = context.Film.ToArray();

            //test connection print all film names and ids
            Console.WriteLine("allFilms array contents: \n");
            foreach (Film f in allFilms)
            {
                Console.WriteLine(" Title: " + f.title + ",  Film Id: " + f.film_id);

            }

            //check database using LINQ query 

            List<Film> linqList = null;   //clear linqList from previous code testing - just in case
            Console.WriteLine(" \n What is in linqList: " + linqList + "\n"); //Is it really empty?

            //putting 2019 films into linqList. Test by printing to console 
            linqList = (from f in allFilms
                                    where f.release_year  == "2019"
                                    select f).ToList();
         
            foreach (Film f in linqList)
            {
                Console.WriteLine("Film: " + f.title + "  Release year: " + f.release_year + "  Rating: " + f.rating);
            }

            //building html file
            //creating StringBuilder 
            StringBuilder sb = new StringBuilder();
            string openingHtml = "<html> \n <title> Lab 11.5 Databases</title> \n" + 
                "<body style = 'background-color: aliceblue'> \n  " +
                "<h1 style = 'color: darkblue; font-family: arial'>Newly Available Rentals</h1> \n";

             string openingUL = "<ul style = 'font-family: arial'> \n ";

             sb.Append(openingHtml);
             sb.Append("<p> Following is a list of our newest available rental films. </br> If you are interested in one, act quickly. " +
                 "Only a few copies of each are available!</p> </br> \n ");
             sb.Append(openingUL);

            //add list items to StringBuilder
            foreach (Film f in linqList)
            {
                string rentalListName = f.title;
                string rentalListYear = f.release_year;
                decimal rentalListCost = f.rental_rate;
                string rentalListRating = f.rating;

                sb.Append("<li> Film: " + rentalListName + ", Release Year: " + rentalListYear + ", Rental Cost: " + f.rental_rate + ", Film Rating: " + f.rating + "</li> " + "\n");
            }
            //close html code
            sb.Append("</ul> \n </body> \n </html>");
            //View StringBuilder contents 
            Console.WriteLine("Testing StringBuilder");
            Console.WriteLine(sb);

            //Send HTML code to html file on computer
            string fileName = @"D:\_ACT\ACT_Web-App_Dev\SD1104-A\_Source\Lab11_5\Lab11-5_Database-C-HTML.html";
            File.WriteAllText(fileName, sb.ToString());

            //End of lab
            Console.WriteLine(" ***** END OF LAB 11.5 *****");


        }
    }
}


