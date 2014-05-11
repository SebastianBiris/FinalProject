using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    class WeekList
    {
        public DateTime _day1, _day2, _day3, _day4, _day5, _day6, _day7;
        int _year;

        public WeekList(int year, DateTime day1, DateTime day2, DateTime day3, DateTime day4, DateTime day5, DateTime day6, DateTime day7)
        {
            _year = year;
            _day1 = day1;
            _day2 = day2;
            _day3 = day3;
            _day4 = day4;
            _day5 = day5;
            _day6 = day6;
            _day7 = day7;      
        }

        #region method GetDay // **Sebi**


public DateTime GetDay(string day)
{
if (day=="Day1")
            {
                return _day1;
            }
            else if (day == "Day2")
            {
                return _day2;
                
            }
            else if (day == "Day3")
            {
                return _day3;

            }
            else if (day == "Day4")
            {
                return _day4;

            }
            else if (day == "Day5")
            {
                return _day5;

            }
            else if (day == "Day6")
            {
                return _day6;

            }
            else 
            {
                return _day7;

            }

            
        }

#endregion

        #region Properties // **Sebi**
        public int Year
        {
            get { return _year; }
           private set { _year = value; }
        }

        public DateTime Day1
        {
            get { return _day1; }
            set { _day1 = value; }
        }

        public DateTime Day2
        {
            get { return _day2; }
            set { _day2 = value; }
        }

        public DateTime Day3
        {
            get { return _day3; }
            set { _day3 = value; }
        }

        public DateTime Day4
        {
            get { return _day4; }
            set { _day4 = value; }
        }

        public DateTime Day5
        {
            get { return _day5; }
            set { _day5 = value; }
        }

        public DateTime Day6
        {
            get { return _day6; }
            set { _day6 = value; }
        }

        public DateTime Day7
        {
            get { return _day7; }
            set { _day7 = value; }
        }

        #endregion
    }
}
