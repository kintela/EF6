﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NinjaDomain.Clases;
using System.Data.Entity;
using System.Diagnostics;

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

        public Ninja GetNinjaById(int id)
        {
            using (var context = new NinjaContext())
            {
                return context.Ninjas.Find(id);
                // return context.Ninjas.AsNoTracking().SingleOrDefault(n => n.Id == id);
            }
        }

        public void SaveUpdatedNinja(Ninja ninja)
        {
            using (var context = new NinjaContext())
            {
                context.Entry(ninja).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void SaveNewNinja(Ninja ninja)
        {
            using (var context = new NinjaContext())
            {
                context.Ninjas.Add(ninja);
                context.SaveChanges();
            }
        }

        public void DeleteNinja(int ninjaId)
        {
            using (var context = new NinjaContext())
            {
                var ninja = context.Ninjas.Find(ninjaId);
                context.Entry(ninja).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public void SaveNewEquipment(NinjaEquipment equipment, int ninjaId)
        {
            //paying the price of not having a foreign key here. 
            //reason #857 why I prefer foreign keys!
            using (var context = new NinjaContext())
            {
                var ninja = context.Ninjas.Find(ninjaId);
                ninja.EquipmentOwned.Add(equipment);

                context.SaveChanges();
            }
        }

        public void SaveUpdatedEquipment(NinjaEquipment equipment, int ninjaId)
        {
            //paying the price of not having a foreign key here. 
            //reason #858 why I prefer foreign keys!
            using (var context = new NinjaContext())
            {
                var equipmentWithNinjaFromDatabase =
                  context.Equipment.Include(n => n.Ninja).FirstOrDefault(e => e.Id == equipment.Id);

                context.Entry(equipmentWithNinjaFromDatabase).CurrentValues.SetValues(equipment);

                context.SaveChanges();
            }
        }

        public List<Ninja> GetQueryableNinjasWithClan(string query, int page, int pageSize)
        {
            using (var context = new NinjaContext())
            {
                context.Database.Log = message => Debug.WriteLine(message);
                var linqQuery = context.Ninjas.Include(n => n.Clan);
                if (!string.IsNullOrEmpty(query))
                {
                    linqQuery = linqQuery.Where(n => n.Name.Contains(query));
                }
                if (page > 0 && pageSize > 0)
                {
                    linqQuery = linqQuery.OrderBy(n => n.Name).Skip(page - 1).Take(pageSize);
                }

                return linqQuery.ToList();
            }
        }
    }
}
