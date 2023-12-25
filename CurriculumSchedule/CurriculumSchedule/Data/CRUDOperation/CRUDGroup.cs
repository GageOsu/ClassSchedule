using CurriculumSchedule.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CurriculumSchedule.Models.CRUDOperation
{
    internal class CRUDGroup
    {
        public ObservableCollection<Group> ReadGroup()
        {
            using (ScheduleContext context = new())
            {
                var Group = new ObservableCollection<Group>([.. context.Groups]);
                return Group;
            }
        }

        public bool CreateGroup(string groupNumber, string shortNumber, int studentAmmount)
        {
            {
                bool created = false;
                try
                {
                    using (ScheduleContext context = new())
                    {
                        Group newGroup = new()
                        {
                            GroupNumber = groupNumber,
                            ShortNumber = shortNumber,
                            StudentAmmount = studentAmmount
                        };
                        context.Groups.Add(newGroup);
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

        public bool UpdateGroup(Group newGroup)
        {
            bool updated = false;
            using (ScheduleContext context = new())
            {
                try
                {

                    Group? oldGroup = context.Groups.FirstOrDefault(id => id. Idgroup == newGroup.Idgroup);
                    if (oldGroup != null)
                    {
                        oldGroup.GroupNumber = newGroup.GroupNumber;
                        oldGroup.ShortNumber = newGroup.ShortNumber;
                        oldGroup.StudentAmmount = newGroup.StudentAmmount;
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

        public bool DeleteGroup(Group deleteGroup)
        {
            bool deleted = false;
            using (ScheduleContext context = new())
            {
                try
                {
                    context.Groups.Remove(deleteGroup);
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

