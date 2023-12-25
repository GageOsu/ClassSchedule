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
    internal class CRUDLessonNumber
    {
        public ObservableCollection<LessonNumber> ReadLessonNumber()
        {
            using (ScheduleContext context = new())
            {
                var LessonNumber = new ObservableCollection<LessonNumber>([.. context.LessonNumbers]);
                return LessonNumber;
            }
        }

        public bool CreateLessonNumber(int LessonNumber1)
        {
            {
                bool created = false;
                try
                {
                    using (ScheduleContext context = new())
                    {
                        LessonNumber newLessonNumber = new()
                        {
                            LessonNumber1 = LessonNumber1,
                        };
                        context.LessonNumbers.Add(newLessonNumber);
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

        public bool UpdateLessonNumber(LessonNumber newLessonNumber)
        {
            bool updated = false;
            using (ScheduleContext context = new())
            {
                try
                {

                    LessonNumber? oldLessonNumber = context.LessonNumbers.FirstOrDefault(id => id.IdlessonNumber == newLessonNumber.IdlessonNumber);
                    if (oldLessonNumber != null)
                    {
                        oldLessonNumber.LessonNumber1 = newLessonNumber.LessonNumber1;
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

        public bool DeleteLessonNumber(LessonNumber deleteLessonNumber)
        {
            bool deleted = false;
            using (ScheduleContext context = new())
            {
                try
                {
                    context.LessonNumbers.Remove(deleteLessonNumber);
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

