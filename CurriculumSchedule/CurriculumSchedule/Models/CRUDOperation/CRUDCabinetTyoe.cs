using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CurriculumSchedule.Models.CRUDOperation
{
    internal class CRUDCabinetTyoe
    {
        public ObservableCollection<CabinetType> ReadCabinetType()
        {
            using (ScheduleContext context = new())
            {
                var cabinet = new ObservableCollection<CabinetType>([.. context.CabinetTypes]);
                return cabinet;
            }
        }

        public bool CreateCabinetType(string cabinetName, string discription)
        {
            {
                bool created = false;
                try
                {
                    using (ScheduleContext context = new())
                    {
                        CabinetType newCabinetType = new()
                        {
                            CabinetName = cabinetName,
                            Discription = discription,
                        };
                        context.CabinetTypes.Add(newCabinetType);
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

        public bool UpdateCabinetType(CabinetType newCabinetType)
        {
            bool updated = false;
            using (ScheduleContext context = new())
            {
                try
                {

                    CabinetType? oldCabinetType = context.CabinetTypes.FirstOrDefault(id => id.Idcabinet == newCabinetType.Idcabinet);
                    if (oldCabinetType != null)
                    {
                        oldCabinetType.CabinetName = newCabinetType.CabinetName;
                        oldCabinetType.Discription = newCabinetType.Discription;
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

        public bool DeleteCabinetType(CabinetType deleteCabinetType)
        {
            bool deleted = false;
            using (ScheduleContext context = new())
            {
                try
                {
                    context.CabinetTypes.Remove(deleteCabinetType);
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
