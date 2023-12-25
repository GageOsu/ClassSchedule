using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CurriculumSchedule.Models.CRUDOperation
{
    internal class CRUDDay
    {
        public ObservableCollection<Day> ReadDay()
        {
            using (ScheduleContext context = new())
            {
                var Day = new ObservableCollection<Day>([.. context.Days]);
                return Day;
            }
        }

        public bool CreateDay(Week week, Weekday weekday, DateOnly date)
        {
            {
                bool created = false;
                try
                {
                    using (ScheduleContext context = new())
                    {
                        Day newDay = new()
                        {
                            Idweek = week.Idweek,
                            Idweekday = weekday.Idweekday,
                            DateDay = date
                        };
                        context.Days.Add(newDay);
                        context.SaveChanges();
                        created = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    created = false;
                }
                return created;
            }
        }

        public bool UpdateDay(Day newDay)
        {
            bool updated = false;
            using (ScheduleContext context = new())
            {
                try
                {

                    Day? oldDay = context.Days.FirstOrDefault(id => id.Idday == newDay.Idday);
                    if (oldDay != null)
                    {
                        oldDay.Idweekday = newDay.Idweekday;
                        oldDay.Idweek = newDay.Idweek;
                        oldDay.DateDay = newDay.DateDay;
                        context.SaveChanges();
                        updated = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    updated = false;
                }
            }
            return updated;
        }

        public bool DeleteDay(Day deleteDay)
        {
            bool deleted = false;
            using (ScheduleContext context = new())
            {
                try
                {
                    context.Days.Remove(deleteDay);
                    context.SaveChanges();
                    deleted = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    deleted = false;
                }
            }
            return deleted;
        }

    }
}

