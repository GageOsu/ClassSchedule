using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CurriculumSchedule.Model;
using Microsoft.EntityFrameworkCore;

namespace CurriculumSchedule.Models.CRUDOperation
{
    internal class CRUDLesson
    {
        public ObservableCollection<Lesson> ReadLesson()
        {
            using (ScheduleContext context = new())
            {
                var Lesson = new ObservableCollection<Lesson>([.. context.Lessons.Include(id => id.IddayNavigation).Include(id => id.IdlessonNumberNavigation).Include(id => id.IdcabinetNavigation)
                    .Include(id => id.IdgroupNavigation).Include(id => id.IdsubjectNavigation).Include(id => id.IdteacherNavigation)]);
                return Lesson;
            }
        }

        public bool CreateLesson(Day Idday, LessonNumber IdlessonNumber, Cabinet Idcabinet, Group Idgroup, Subject Idsubject, Teacher Idteacher)
        {
            {
                bool created = false;
                try
                {
                    using (ScheduleContext context = new())
                    {
                        Lesson newLesson = new()
                        {
                          Idday = Idday.Idday,
                          IdlessonNumber = IdlessonNumber.IdlessonNumber,
                          Idcabinet = Idcabinet.Idcabinet,
                          Idgroup = Idgroup.Idgroup,
                          Idsubject = Idsubject.Idsubject,
                          Idteacher = Idteacher.Idteacher
                        };
                        context.Lessons.Add(newLesson);
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

        public bool UpdateLesson(Lesson newLesson)
        {
            bool updated = false;
            using (ScheduleContext context = new())
            {
                try
                {

                    Lesson? oldLesson = context.Lessons.FirstOrDefault(id => id.Idlesson == newLesson.Idlesson);
                    if (oldLesson != null)
                    {
                        oldLesson.Idday = newLesson.Idday;
                        oldLesson.IdlessonNumber = newLesson.IdlessonNumber;
                        oldLesson.Idcabinet = newLesson.Idcabinet;
                        oldLesson.Idgroup = newLesson.Idgroup;
                        oldLesson.Idsubject = newLesson.Idsubject;
                        oldLesson.Idteacher = newLesson.Idteacher;
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

        public bool DeleteLesson(Lesson deleteLesson)
        {
            bool deleted = false;
            using (ScheduleContext context = new())
            {
                try
                {
                    context.Lessons.Remove(deleteLesson);
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
