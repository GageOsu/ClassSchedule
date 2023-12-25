using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CurriculumSchedule.Model;

namespace CurriculumSchedule.Models.CRUDOperation
{
    internal class CRUDWeek
    {
        public ObservableCollection<Week> ReadWeek()
        {
            using (ScheduleContext context = new())
            {
                var week = new ObservableCollection<Week>([.. context.Weeks]);
                return week;
            }
        }

        public bool CreateWeek(Semester semester)
        {
            {
                bool created = false;
                try
                {
                    using (ScheduleContext context = new())
                    {
                        Week newWeek= new()
                        {
                            Idsemester = semester.Idsemester,
                        };
                        context.Weeks.Add(newWeek);
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

        public bool UpdateWeek(Week newweek)
        {
            bool updated = false;
            using (ScheduleContext context = new())
            {
                try
                {

                    Week? oldWeek = context.Weeks.FirstOrDefault(id => id.Idweek== newweek.Idweek);
                    if (oldWeek != null)
                    {
                        oldWeek.Idsemester = newweek.Idsemester;
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

        public bool DeleteWeek(Week deleteWeek)
        {
            bool deleted = false;
            using (ScheduleContext context = new())
            {
                try
                {
                    context.Weeks.Remove(deleteWeek);
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
