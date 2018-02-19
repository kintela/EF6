using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NinjaDomain.Clases;
using System.Data.Entity;

namespace NinjaDomain.DataModels
{
    public class DisconnectedRepository
    {
        public List<Ninja> GetNinjasWithClan()
        {
            using (var context = new NinjaContext())
            {
                //return context.Ninjas.Include(n => n.Clan).ToList();
                return context.Ninjas.AsNoTracking().Include(n => n.Clan).ToList();
            }
        }

        public Ninja GetNinjaWithEquipment(int id)
        {
            using (var context = new NinjaContext())
            {
                return context.Ninjas.AsNoTracking().Include(n => n.EquipmentOwned)
                  .FirstOrDefault(n => n.Id == id);
            }
        }

        public Ninja GetNinjaWithEquipmentAndClan(int id)
        {
            using (var context = new NinjaContext())
            {
                return context.Ninjas.AsNoTracking().Include(n => n.EquipmentOwned)
                  .Include(n => n.Clan)
                  .FirstOrDefault(n => n.Id == id);
            }
        }
    }
}
