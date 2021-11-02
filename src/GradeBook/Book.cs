using System;
using System.Collections.Generic;
using System.IO;

namespace GradeBook
{
  public delegate void GradeAddedDelegate(object sender, EventArgs args);

  public class NamedObject
  {
    public NamedObject(string name)
    {
      Name = name;
    }
    public string Name
    {
      get;
      set;
    }
  }

  public interface IBook
  {
    void AddGrade(double grade);
    Statistics GetStatistics();
    string Name { get; }
    event GradeAddedDelegate GradeAdded;
  }
  public abstract class Book : NamedObject, IBook
  {
    public Book(string name) : base(name)
    {
    }

    public abstract event GradeAddedDelegate GradeAdded;

    public abstract void AddGrade(double grade);

    public abstract Statistics GetStatistics();
  }

  public class DiskBook : Book
  {
    public DiskBook(string name) : base(name)
    {
    }

    public override event GradeAddedDelegate GradeAdded;

    public override void AddGrade(double grade)
    {
      var writer = File.AppendText($"{Name}.txt");
      writer.WriteLine(grade);
      writer.Close();

    }

    public override Statistics GetStatistics()
    {
      throw new NotImplementedException();
    }
  }
  public class InMemoryBook : Book
  {
    public InMemoryBook(string name) : base(name)
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
    public override void AddGrade(double grade)
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
    public override event GradeAddedDelegate GradeAdded;
    public override Statistics GetStatistics()
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
    public const string CATEGORY = "Science";
  }
}