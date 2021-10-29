using System;
using Xunit;

namespace GradeBook.Test
{
  public class BookTests
  {
    [Fact]
    public void BookCalculatesAnAverageGrade()
    {
      var book = new Book("");
      book.AddGrade(89.1);
      book.AddGrade(90.4);
      book.AddGrade(72.6);

      var result = book.GetStatistic();
      Assert.Equal(72.6, result.Low);
      Assert.Equal(90.4, result.High);
      Assert.Equal(84, result.Average, 1);
    }
  }
}
