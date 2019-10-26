using System;
using System.Collections.Generic;
using System.Text;

namespace MentalDOW
{
    public class DayOfWeek
    {
        static int[] centuryOffset = { 0, 5, 3, 1 };
        static int[] monthCode = { 0, 6, 2, 2, 5, 0, 3, 5, 1, 4, 6, 2, 4 };
        public enum DOW { Sunday, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday }

        public static DOW GetDOW(int year, int month, int day)
        {
            if (DateIsUSGregorian(year,month,day))
                return (DOW) ((YearCode(year) + MonthCode(year, month) + day) % 7);

            throw new Exception("Not a valid US Gregorian date.");
        }

        protected static bool DateIsUSGregorian(int year, int month, int day)
        {
            return year * 10000 + month * 100 + day >= 17520914;
        }

        protected static int YearCode(int yr)
        {
            var century = yr / 100;
            if (century < 17)
                throw new Exception("Can't handle dates prior to 1700's");
            var year = yr % 100;
            return ((year + (year / 4)) % 7 + centuryOffset[century % 4]) % 7;
        }

        protected static bool IsLeapYear(int year)
        {
            if (year % 4 == 0)
                if (year % 100 == 0)
                    if (year % 400 == 0)
                        return true;
                    else
                        return false;
                else
                    return true;
            else
                return false;
        }

        protected static int MonthCode(int year, int month)
        {
            if ((month == 1 || month == 2) && IsLeapYear(year))
                return monthCode[month] - 1;
            return monthCode[month];
        }
    }
}
