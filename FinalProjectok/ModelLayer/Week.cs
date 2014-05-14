using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Windows;

using InterfaceLayer;

namespace ModelLayer
{
    public class Week
    {
        public static DateTime GetFirstDayOfWeek(int year, int week, DayOfWeek firstDayOfWeek)
        {
            return GetWeekOneDayOne(year,firstDayOfWeek);
        }


        # region Method Get first day of first week //**Sebi**
        public static DateTime GetWeekOneDayOne(int year, DayOfWeek firstDayOfWeek)
        {
            DateTime date = new DateTime(year, 1, 1);

            date = date.AddDays(firstDayOfWeek - date.DayOfWeek);

            int weekOfYear = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(date, CalendarWeekRule.FirstFourDayWeek, firstDayOfWeek);
            if (weekOfYear == 52 || weekOfYear == 53)
            { date = date.AddDays(7 * System.Math.Sign(weekOfYear - 1) - 3); }
            else if (weekOfYear == 2)
            { date = date.AddDays(7 * System.Math.Sign(weekOfYear - 1) - 10); }
            else if (weekOfYear == 1)
            { date = date.AddDays(7 * System.Math.Sign(weekOfYear - 1) - 3); }
            return date;
        }
        #endregion

        #region get week of year //**Sebi**
        public  int GetWeekOfYear()
        {
           CultureInfo currentCulture = CultureInfo.CurrentCulture;
           int weekNo = currentCulture.Calendar.GetWeekOfYear(DateTime.Now,currentCulture.DateTimeFormat.CalendarWeekRule,currentCulture.DateTimeFormat.FirstDayOfWeek);
           return weekNo;
        }
        #endregion
    }
}
