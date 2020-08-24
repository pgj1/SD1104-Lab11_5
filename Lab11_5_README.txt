

LAB: Database to C# to HTML
Lesson Time: 2 Hours

In this lab, you’ll write data to Sakila’s film table, read data, and write output to HTML.

Before Getting Started
Before we get started in C#, we need to do some cleanup on the SQL film table. Our database could 
have some issues that might cause us trouble in this lab, and we want to clean them up now.

Cleaning up Sakila Null Values
In this lab, we’ll be using the ToArray() method to pull data from our database into an array.
However, we’ll get an error when we do this if the film table has null values. While we could work 
around this, implementing a code fix would take too much time, so our fix is going to be to clean 
up Sakila’s null values first.

Open SQL management studio and select all data from the film table. For any records that have 
NULL values, we need to run UPDATE statements to replace the null data with real data. Your fixes might 
be different from ours, but we’ve included the . sql script we used to clean our data.

Checking for bad triggers
While working on this lab, we encountered an error when adding new films to the film table. 
The culprit was a bad trigger setup in the Sakila database called insert_film. This trigger is 
problematic because it tries to insert the same film_id into the film_text table. If you 
have this trigger in the film_text table, delete it before beginning the lab. After deleting 
the bad trigger, our C# code worked properly.

LAB Requirements
1. Create a connection to the Sakila database.
  ● Remember use EntityFramework, and inherit from DbContext
  ● Remember that you’ll need to Add EntityFramework with Install-Package

2. Create a class for working with the Sakila Film table The designers of Sakila made some “interesting” 
choices with the data types of their film table, and when we create a Film class in C#,
we need to know the correct data types to use. 

Below is chart to help you convert the Sakila SQL data types to C# data types

SQL Data Type		Correct C# DataType
int				int
varchar			string
text			string
tinyint			byte
decimal			decimal
smallint		Int16
datetime		DateTime

3. Using C# only, add the following films to Sakila.

Title
Description
year_released
rental_duration
rental_cost
length
replacement_cost
rating

[Include language ids & special features. Null columns not allowed in C#]
language_id
original_language_id
special_features

1917
War Drama by Director Sam Mendes
2019
3
5.99
179
19.99
R
7
7
Trailers


(See PDF file for all data)

4. Pull all of the data from the films table into C# into an array called allFilms. Use 
the ToArray() method to do this. If you get an error here, double check that the Sakila Film 
table doesn’t have any null values!

5. Filter the allFilms array using LINQ to only get the new 2019 films you added in step three.

6. Use a StringBuilder to create an HTML page that had a head, a title, a body, an h1 element, 
and an unordered list. The unordered list will hold the list of our new movies. The output of 
the filtered 2019 films should be similar to the output shown below.

7. Tip: Make sure the folder you write your .html file to EXISTS on your computer! 

If you get stuck on this lab, go back to the previous lessons and review the code, 
or get help from your instructor. Take your time on this lab, as this is very challenging!

Lastly, to see our solution, view the 11_5Solution files on GitHub.