using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CurriculumSchedule.Models.CRUDOperation
{
    internal class CRUDWeekday
    {
        public ObservableCollection<Weekday> ReadWeekday()
        {
            using (ScheduleContext context = new())
            {
                var weekdays = new ObservableCollection<Weekday>([.. context.CabinetTypes]);
                return weekdays;
            }
        }

        public bool CreateCabinetType(string nameweekday)
        {
            {
                bool created = false;
                try
                {
                    using (ScheduleContext context = new())
                    {
                        Weekday newWeekday = new()
                        {
                            NameWeekday = nameweekday
                        };
                        context.Weekdays.Add(newWeekday);
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

        public bool UpdateCabinetType(Weekday newweekday)
        {
            bool updated = false;
            using (ScheduleContext context = new())
            {
                try
                {

                    Weekday? oldWeekday = context.Weekdays.FirstOrDefault(id => id.Idweekday == newweekday.Idweekday);
                    if (oldWeekday != null)
                    {
                        oldWeekday.NameWeekday = newweekday.NameWeekday;
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

        public bool DeleteCabinetType(Weekday deleteWeekday)
        {
            bool deleted = false;
            using (ScheduleContext context = new())
            {
                try
                {
                    context.Weekdays.Remove(deleteWeekday);
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
