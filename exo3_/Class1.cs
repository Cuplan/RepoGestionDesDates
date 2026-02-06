using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exo3_
{
    public class Class1
    {

        public static int CalculateDayIndexInYear(int monthNumber, int dayNumberInMonth, int yearNumber)
        {
            ValidateCalendarDate(monthNumber, dayNumberInMonth, yearNumber);

            // Total de jours écoulés avant le début de chaque mois (année non bissextile)
            int[] totalDaysBeforeMonthStart =
            {
                0,    // January
                31,   // February
                59,   // March
                90,   // April
                120,  // May
                151,  // June
                181,  // July
                212,  // August
                243,  // September
                273,  // October
                304,  // November
                334   // December
            };

            int dayIndexInYear = totalDaysBeforeMonthStart[monthNumber - 1] + dayNumberInMonth;

            // Ajout du jour bissextile si la date est après février
            if (monthNumber > 2 && IsLeapCalendarYear(yearNumber))
            {
                dayIndexInYear++;
            }

            return dayIndexInYear;
        }

        private static void ValidateCalendarDate(int monthNumber, int dayNumberInMonth, int yearNumber)
        {
            if (monthNumber < 1 || monthNumber > 12)
            {
                throw new ArgumentOutOfRangeException(nameof(monthNumber),
                    "Month number must be between 1 and 12.");
            }

            int[] maxDaysPerMonth =
            {
                31, 28, 31, 30, 31, 30,
                31, 31, 30, 31, 30, 31
            };

            int maxAllowedDayInMonth = maxDaysPerMonth[monthNumber - 1];

            if (monthNumber == 2 && IsLeapCalendarYear(yearNumber))
            {
                maxAllowedDayInMonth = 29;
            }

            if (dayNumberInMonth < 1 || dayNumberInMonth > maxAllowedDayInMonth)
            {
                throw new ArgumentOutOfRangeException(nameof(dayNumberInMonth),
                    $"Day number must be between 1 and {maxAllowedDayInMonth} for month {monthNumber}.");
            }
        }

        private static bool IsLeapCalendarYear(int yearNumber)
        {
            return (yearNumber % 4 == 0)
                   && (yearNumber % 100 != 0 || yearNumber % 400 == 0);
        }


    }
}
