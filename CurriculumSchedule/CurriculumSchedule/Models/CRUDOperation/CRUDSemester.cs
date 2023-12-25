using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CurriculumSchedule.Models.CRUDOperation
{
    internal class CRUDSemester
    {
        public ObservableCollection<Semester> ReadSemester()
        {
            using (ScheduleContext context = new())
            {
                var Semester = new ObservableCollection<Semester>([.. context.Semesters]);
                return Semester;
            }
        }

        public bool CreateSemester(string Year, byte EvenOdd)
        {
            {
                bool created = false;
                try
                {
                    using (ScheduleContext context = new())
                    {
                        Semester newSemester = new()
                        {
                            Year = Year,
                            EvenOdd = EvenOdd  
                        };
                        context.Semesters.Add(newSemester);
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

        public bool UpdateSemester(Semester newSemester)
        {
            bool updated = false;
            using (ScheduleContext context = new())
            {
                try
                {

                    Semester? oldSemester = context.Semesters.FirstOrDefault(id => id.Idsemester == newSemester.Idsemester);
                    if (oldSemester != null)
                    {
                        oldSemester.Year = newSemester.Year;
                        oldSemester.EvenOdd = newSemester.EvenOdd;
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

        public bool DeleteSemester(Semester deleteSemester)
        {
            bool deleted = false;
            using (ScheduleContext context = new())
            {
                try
                {
                    context.Semesters.Remove(deleteSemester);
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
}
