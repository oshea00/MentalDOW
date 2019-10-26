using NUnit.Framework;
using System;

namespace MentalDOW.Test
{
    public class DOWTests : DayOfWeek
    {

        [TestCase(2419, 12, 31, ExpectedResult = DOW.Tuesday)]
        [TestCase(2019, 12, 31, ExpectedResult = DOW.Tuesday)]
        [TestCase(2020, 1, 1, ExpectedResult = DOW.Wednesday)]
        [TestCase(2020, 2, 3, ExpectedResult = DOW.Monday)]
        [TestCase(2020, 12, 31, ExpectedResult = DOW.Thursday)]
        [TestCase(1752, 9, 14, ExpectedResult = DOW.Thursday)]
        public DOW CanGetDOW(int year, int month, int day)
        {
            return GetDOW(year, month, day);
        }

        public void GetNonUSGregorianDOWThrowsException()
        {
            Assert.Throws<Exception>(() => DayOfWeek.GetDOW(1752, 9, 2));
        }

        [TestCase(1752, 9, 14, ExpectedResult = true)]
        [TestCase(1752, 9, 13, ExpectedResult = false)]
        public bool CanCalculateUSGregorian(int year, int month, int day)
        {
            return DayOfWeek.DateIsUSGregorian(year, month, day);
        }

        [TestCase(2719, ExpectedResult = 3)]
        [TestCase(2419, ExpectedResult = 2)]
        [TestCase(2319, ExpectedResult = 3)]
        [TestCase(2219, ExpectedResult = 5)]
        [TestCase(2119, ExpectedResult = 0)]
        [TestCase(2019, ExpectedResult = 2)]
        [TestCase(1919, ExpectedResult = 3)]
        [TestCase(1819, ExpectedResult = 5)]
        [TestCase(1719, ExpectedResult = 0)]
        public int CanCalculateYearCode(int year)
        {
            return DayOfWeek.YearCode(year);
        }

        [Test]
        public void CenturiesBefore1700ThrowsException()
        {
            Assert.Throws<Exception>(()=>DayOfWeek.YearCode(1600));
        }

        [TestCase(2400, ExpectedResult = true)]
        [TestCase(2003, ExpectedResult = false)]
        [TestCase(2000, ExpectedResult = true)]
        [TestCase(1904, ExpectedResult = true)]
        [TestCase(1900, ExpectedResult = false)]
        public bool CanCalculateLeapYear(int year)
        {
            return DayOfWeek.IsLeapYear(year);
        }

        [TestCase(2000, 1, ExpectedResult = 5)]
        [TestCase(2000, 2, ExpectedResult = 1)]
        [TestCase(2001, 1, ExpectedResult = 6)]
        [TestCase(2001, 2, ExpectedResult = 2)]
        [TestCase(2001, 3, ExpectedResult = 2)]
        [TestCase(2001, 4, ExpectedResult = 5)]
        [TestCase(2001, 5, ExpectedResult = 0)]
        [TestCase(2001, 6, ExpectedResult = 3)]
        [TestCase(2001, 7, ExpectedResult = 5)]
        [TestCase(2001, 8, ExpectedResult = 1)]
        [TestCase(2001, 9, ExpectedResult = 4)]
        [TestCase(2001, 10, ExpectedResult = 6)]
        [TestCase(2001, 11, ExpectedResult = 2)]
        [TestCase(2001, 12, ExpectedResult = 4)]
        public int CanCalculateMonthCode(int year, int month)
        {
            return DayOfWeek.MonthCode(year, month);
        }

        [Test]
        public void CanCalculate400YearsOfDOW()
        {
            var startingDate = new DateTime(1752, 9, 14);
            for (int i=0; i < (int) (400 * 365.25); i++)
            {
                var date = startingDate.AddDays(i);
                if ((int) date.DayOfWeek != (int) GetDOW(date.Year,date.Month,date.Day))
                {
                    Assert.Fail();
                    break;
                }

            }
            Assert.Pass();
        }
    }
}