using System;
using System.Collections.Generic;

namespace GradeBook
{
  public class Book
  {
    public Book(string name)
    {
      this.grades = new List<double>();
      this.Name = name;
    }
    public void AddGrade(double grade)
    {
      this.grades.Add(grade);
    }
    public Statistics GetStatistic()
    {
      var result = new Statistics();
      result.Average = 0.0;
      result.High = double.MinValue;
      result.Low = double.MaxValue;

      foreach (var number in grades)
      {
        result.High = Math.Max(result.High, number);
        result.Low = Math.Min(result.Low, number);
        result.Average += number;
      }
      result.Average /= grades.Count;
      return result;
    }
    private List<double> grades;
    public string Name;
  }
}