using System.Data.Entity;
using Ninja.Domain.Clases;


namespace NinjaDomain.DataModels
{
    public class NinjaContext:DbContext
    {
        public DbSet<Ninja.Domain.Clases.Ninja> Ninjas { get; set; }
        public DbSet<Ninja.Domain.Clases.Clan> Clan { get; set; }
        public DbSet<Ninja.Domain.Clases.NinjaEquipment> Equipment { get; set; }
    }
}
 