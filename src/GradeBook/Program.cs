using System;
using System.Collections.Generic;

namespace GradeBook
{
  class Program
  {
    static void Main(string[] args)
    {
      var book = new Book("Andrey's grade book");
      book.AddGrade(89.1);
      book.AddGrade(90.1);
      book.AddGrade(77.1);
      var result = book.GetStatistic();

      Console.WriteLine($"The lowest grade is {result.High}");
      Console.WriteLine($"The highest grade is {result.Low}");
      Console.WriteLine($"The average of grade is {result.Average:N1}");
    }
  }
}
