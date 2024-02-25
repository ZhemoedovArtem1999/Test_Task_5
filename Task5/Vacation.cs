using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5
{
    public class Vacation
    {
        Dictionary<string, List<DateTime>> vacationDictionary;
        List<string> aviableWorkingDaysOfWeekWithoutWeekends = new List<string>() { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday" };
        List<DateTime> vacations;
        Random gen;
        DateTime startDateYear;
        DateTime endDateYear;
        int daysPerYear;
        int vacationCount;
        string[] vacationSteps;

        public Vacation(Dictionary<string, List<DateTime>> vacationDictionary)
        {
            this.vacationDictionary = vacationDictionary;
            this.aviableWorkingDaysOfWeekWithoutWeekends = new List<string>() { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday" };
            this.vacations = new();
            this.gen = new Random();
            this.startDateYear = new DateTime(DateTime.Now.Year, 1, 1);
            this.endDateYear = new DateTime(DateTime.Today.Year, 12, 31);
            this.daysPerYear = (endDateYear - startDateYear).Days;
            this.vacationCount = 28;
            this.vacationSteps = new string[] { "7", "14" };
        }

        public Dictionary<string, List<DateTime>> DistributeVacation()
        {
            foreach (var vacantionList in vacationDictionary)
            {
                List<DateTime> dateList = vacantionList.Value;
                int vacantionCountEmployee;
                if (dateList.Count == 0)
                    vacantionCountEmployee = vacationCount;
                else
                {
                    vacantionCountEmployee = vacationCount - dateList.Count;
                }
                this.DistributeVacantionEmployee(dateList, vacantionCountEmployee);

            }
            return this.vacationDictionary;

        }

        private void DistributeVacantionEmployee(List<DateTime> dateList, int vacantionCountEmployee)
        {
            while (vacantionCountEmployee > 0)
            {
                DateTime startDate = this.startDateYear.AddDays(gen.Next(daysPerYear));
                DateTime endDate;
                int vacantionDayCount;
                if (!aviableWorkingDaysOfWeekWithoutWeekends.Contains(startDate.DayOfWeek.ToString()))
                    continue;
                if (vacantionCountEmployee == 7)
                {
                    endDate = startDate.AddDays(7);
                    vacantionDayCount = 7;
                }
                else
                {
                    vacantionDayCount = int.Parse(vacationSteps[gen.Next(vacationSteps.Length)]);
                    endDate = startDate.AddDays(vacantionDayCount);

                }

                if (this.IsValidCreateVacantion(dateList, startDate, endDate))
                {
                    for (DateTime dt = startDate; dt < endDate; dt = dt.AddDays(1))
                    {
                        this.vacations.Add(dt);
                        dateList.Add(dt);
                    }
                    vacantionCountEmployee -= vacantionDayCount;
                }
            }
        }

        private bool IsValidCreateVacantion(List<DateTime> dateList, DateTime startDate, DateTime endDate)
        {
            bool canCreateVacation = false;
            bool existStart = false;
            bool existEnd = false;
            if (!this.vacations.Any(element => element >= startDate && element <= endDate))
            {
                if (!this.vacations.Any(element => element.AddDays(3) >= startDate && element.AddDays(3) <= endDate))
                {
                     existStart = dateList.Any(element => (element.AddMonths(1).Month == startDate.Month && element.AddMonths(1).Day >= startDate.Day) || (element.AddMonths(1).Month == endDate.Month && element.AddMonths(1).Day >= endDate.Day));
                     existEnd = dateList.Any(element => (element.AddMonths(-1).Month == startDate.Month && element.AddMonths(-1).Day <= startDate.Day) || (element.AddMonths(-1).Month == endDate.Month && element.AddMonths(-1).Day <= endDate.Day));

                    if (!existStart && !existEnd)
                        canCreateVacation = true;
                }
            }
            return canCreateVacation;
        }

    }
}
