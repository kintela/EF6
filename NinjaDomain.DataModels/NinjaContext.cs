using System;
using System.Data.Entity;
using System.Linq;
using NinjaDomain.Clases;
using NinjaDomain.Clases.interfaces;


namespace NinjaDomain.DataModels
{
    public class NinjaContext:DbContext
    {
        public DbSet<Ninja> Ninjas { get; set; }
        public DbSet<Clan> Clans { get; set; }
        public DbSet<NinjaEquipment> Equipment { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Types().
                Configure(c=>c.Ignore("IsDirty"));
            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            foreach (var history in this.ChangeTracker.Entries()
                .Where(e=>e.Entity is IModificacionHistory && (e.State==EntityState.Added ||
                        e.State==EntityState.Modified))
                .Select(e=>e.Entity as IModificacionHistory)
            )
            {
                history.DateModified = DateTime.Now;
                if (history.DateCreated == DateTime.MinValue)
                {
                    history.DateCreated = DateTime.Now;
                }
            }

            int result = base.SaveChanges();

            foreach (var history in this.ChangeTracker.Entries()
                .Where(e=>e.Entity is IModificacionHistory)
                .Select(e=>e.Entity as IModificacionHistory)
                )
            {
                history.IsDirty = false;   
            }

            return result;
        }
    }
}
 