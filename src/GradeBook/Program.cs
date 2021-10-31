using System;
using System.Collections.Generic;

namespace GradeBook
{
  class Program
  {
    static void Main(string[] args)
    {
      var book = new Book("Andrey's grade book");
      book.GradeAdded += OnGradeAdded;

      while (true)
      {
        Console.WriteLine("Enter a grade or 'q' to quit");
        var input = Console.ReadLine();
        if (input == "q")
        {
          break;
        }
        try
        {
          var grade = double.Parse(input);
          book.AddGrade(grade);
        }
        catch (ArgumentException ex)
        {
          Console.WriteLine(ex.Message);
        }
        catch (FormatException ex)
        {
          book.AddGrade(input);
        }
      }

      var result = book.GetStatistic();


      Console.WriteLine($"The category is {Book.CATEGORY}");
      Console.WriteLine($"The book named is {book.Name}");
      Console.WriteLine($"The lowest grade is {result.Low}");
      Console.WriteLine($"The highest grade is {result.High}");
      Console.WriteLine($"The average of grade is {result.Average:N1}");
      Console.WriteLine($"The letter of grade is {result.Letter}");


    }
    static void OnGradeAdded(object sender, EventArgs e)
    {
      Console.WriteLine("A grade was added");
    }
  }

}
