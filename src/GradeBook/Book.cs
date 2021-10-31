using System;
using System.Collections.Generic;

namespace GradeBook
{
  public delegate void GradeAddedDelegate(object sender, EventArgs args);
  public class Book
  {
    public Book(string name)
    {
      this.grades = new List<double>();
      this.Name = name;
    }
    public void AddGrade(string letter)
    {
      switch (letter)
      {
        case "A":
          AddGrade(90);
          break;
        case "B":
          AddGrade(80);
          break;
        case "C":
          AddGrade(70);
          break;
        case "D":
          AddGrade(60);
          break;
        default:
          break;
      }
    }
    public void AddGrade(double grade)
    {
      if (grade <= 100 && grade >= 0)
      {
        this.grades.Add(grade);
        if (GradeAdded != null)
        {
          GradeAdded(this, new EventArgs());
        }
      }
      else
      {
        throw new ArgumentException($"Invalid {nameof(grade)}");
      }
    }
    public event GradeAddedDelegate GradeAdded;
    public Statistics GetStatistic()
    {
      var result = new Statistics();
      result.Average = 0.0;
      result.High = double.MinValue;
      result.Low = double.MaxValue;

      for (var i = 0; i < grades.Count; i++)
      {
        result.High = Math.Max(result.High, grades[i]);
        result.Low = Math.Min(result.Low, grades[i]);
        result.Average += grades[i];
      }
      result.Average /= grades.Count;

      switch (result.Average)
      {
        case var d when d >= 90.0:
          result.Letter = 'A';
          break;
        case var d when d >= 80.0:
          result.Letter = 'B';
          break;
        case var d when d >= 70.0:
          result.Letter = 'C';
          break;
        case var d when d >= 60.0:
          result.Letter = 'D';
          break;
        default:
          result.Letter = 'F';
          break;
      }
      return result;
    }
    private List<double> grades;
    public string Name
    {
      get
      {
        return name;
      }
      set
      {
        if (!String.IsNullOrEmpty(value))
        {
          name = value;
        }
      }
    }
    public string name;
    public const string CATEGORY = "Science";
  }
}