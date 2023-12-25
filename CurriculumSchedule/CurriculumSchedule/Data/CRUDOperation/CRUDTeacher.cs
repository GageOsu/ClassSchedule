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
    internal class CRUDTeacher
    {
        public ObservableCollection<Teacher> ReadTeacher()
        {
            using (ScheduleContext context = new())
            {
                var teachers = new ObservableCollection<Teacher>([.. context.Teachers]);
                return teachers;
            }
        }

        public bool CreateTeacher(string name, string surname, string middlename, bool status)
        {
            {
                bool created = false;
                try
                {
                    using (ScheduleContext context = new())
                    {
                        Teacher newTeacher = new()
                        {
                            Name = name,
                            Surname = surname,
                            MiddleName = middlename,
                            Status = status
                        };
                        context.Teachers.Add(newTeacher);
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

        public bool UpdateTeacher(Teacher newTeacher)
        {
            bool updated = false;
            using (ScheduleContext context = new())
            {
                try
                {

                    Teacher? oldTeacher = context.Teachers.FirstOrDefault(id => id.Idteacher == newTeacher.Idteacher);
                    if (oldTeacher != null)
                    {
                        oldTeacher.Name = newTeacher.Name;
                        oldTeacher.Surname = newTeacher.Surname;
                        oldTeacher.MiddleName = newTeacher.MiddleName;
                        oldTeacher.Status = newTeacher.Status;
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

        public bool DeleteTeacher(Teacher deleteTeacher)
        {
            bool deleted = false;
            using (ScheduleContext context = new())
            {
                try
                {
                    context.Teachers.Remove(deleteTeacher);
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
