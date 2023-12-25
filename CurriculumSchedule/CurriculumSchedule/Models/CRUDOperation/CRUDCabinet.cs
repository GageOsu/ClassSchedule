using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CurriculumSchedule.Models.CRUDOperation
{
    internal class CRUDCabinet
    {
        public ObservableCollection<Cabinet> ReadCabinet()
        {
            using (ScheduleContext context = new())
            {
                var cabinet = new ObservableCollection<Cabinet>([.. context.Cabinets.Include(u => u.IdcabinetNavigation)]);
                return cabinet;
            }
        }

        public bool CreateCabinet(CabinetType cabinetType, int ammountPlaces, string cabinetNumber)
        {
            {
                bool created = false;
                try
                {
                    using (ScheduleContext context = new())
                    {
                        Cabinet newCabinet = new()
                        {
                            IdcabinetType = cabinetType.Idcabinet,
                            AmmountPlaces = ammountPlaces,
                            CabinetNumber = cabinetNumber
                        };
                        context.Cabinets.Add(newCabinet);
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

        public bool UpdateCabinet(Cabinet newCabinet)
        {
            bool updated = false;
            using(ScheduleContext context = new())
            {
                try
                {

                    Cabinet? oldCabinet = context.Cabinets.FirstOrDefault(id => id.Idcabinet == newCabinet.Idcabinet);
                    if (oldCabinet != null)
                    {
                        oldCabinet.IdcabinetType = newCabinet.IdcabinetType;
                        oldCabinet.AmmountPlaces = newCabinet.AmmountPlaces;
                        oldCabinet.CabinetNumber = newCabinet.CabinetNumber;
                        context.SaveChanges();
                        updated = true;
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    updated = false;
                }
            }
            return updated;
        }

        public bool DeleteCabinet(Cabinet deleteCabinet)
        {
            bool deleted = false;
            using(ScheduleContext context = new())
            {
                try
                {
                    context.Cabinets.Remove(deleteCabinet);
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
