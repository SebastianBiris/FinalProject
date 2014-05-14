using System;
namespace ModelLayer
{
   public interface IWeekList
    {
        DateTime Day1 { get; set; }
        DateTime Day2 { get; set; }
        DateTime Day3 { get; set; }
        DateTime Day4 { get; set; }
        DateTime Day5 { get; set; }
        DateTime Day6 { get; set; }
        DateTime Day7 { get; set; }
        DateTime GetDay(string day);
        int Year { get; }
    }
}
