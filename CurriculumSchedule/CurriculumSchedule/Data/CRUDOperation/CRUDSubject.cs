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
    internal class CRUDSubject
    {
        public ObservableCollection<Subject> ReadSubject()
        {
            using (ScheduleContext context = new())
            {
                var subjects = new ObservableCollection<Subject>([.. context.Subjects]);
                return subjects;
            }
        }

        public bool CreateSubject(string subjectname, int semesternumber, int lecturehours, int practichours,
            int labhours, int attestationhours, int consultationhours, int totalhours)
        {
            {
                bool created = false;
                try
                {
                    using (ScheduleContext context = new())
                    {
                        Subject newSubject = new()
                        {
                            SubjectName = subjectname,
                            SemesterNumber = semesternumber,
                            LectureHours = lecturehours,
                            PracticHours = practichours,
                            LabHours = labhours,
                            AttestationHourse = attestationhours,
                            ConsultationHours = consultationhours,
                            TotalHours = totalhours
                        };
                        context.Subjects.Add(newSubject);
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

        public bool UpdateSubject(Subject newSubject)
        {
            bool updated = false;
            using (ScheduleContext context = new())
            {
                try
                {

                    Subject? oldSubject = context.Subjects.FirstOrDefault(id => id.Idsubject == newSubject.Idsubject);
                    if (oldSubject != null)
                    {
                        oldSubject.SubjectName = newSubject.SubjectName;
                        oldSubject.SemesterNumber = newSubject.SemesterNumber;
                        oldSubject.LectureHours = newSubject.LectureHours;
                        oldSubject.PracticHours = newSubject.PracticHours;
                        oldSubject.LabHours = newSubject.LabHours;
                        oldSubject.AttestationHourse = newSubject.AttestationHourse;
                        oldSubject.ConsultationHours = newSubject.ConsultationHours;
                        oldSubject.TotalHours = newSubject.TotalHours;
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

        public bool DeleteSubject(Subject deleteSubject)
        {
            bool deleted = false;
            using (ScheduleContext context = new())
            {
                try
                {
                    context.Subjects.Remove(deleteSubject);
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
