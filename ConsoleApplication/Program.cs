using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NinjaDomain.DataModels;
using System.Data.Entity;
using Ninja.Domain.Clases;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(new NullDatabaseInitializer<NinjaContext>());
            ProjectionQuery();
            Console.ReadLine();

        }

        private static void InsertNinja()
        {
            var ninja = new Ninja.Domain.Clases.Ninja
            {
                Name="Sonia",
                ServedInOniwaban=false,
                DateOfBirth=new DateTime(1972,12,27),
                ClanID=1
            };
            using (var context = new NinjaContext())
            {
                context.Database.Log = Console.WriteLine;
                context.Ninjas.Add(ninja);
                context.SaveChanges();
            };

            Console.ReadLine();
        }

        private static void InsertMultipleNinja()
        {
            var ninja1 = new Ninja.Domain.Clases.Ninja
            {
                Name = "Leonardo",
                ServedInOniwaban = false,
                DateOfBirth = new DateTime(1985, 12, 27),
                ClanID = 1
            };
            var ninja2 = new Ninja.Domain.Clases.Ninja
            {
                Name = "Raphael",
                ServedInOniwaban = false,
                DateOfBirth = new DateTime(1985, 1, 1),
                ClanID = 1
            };

            using (var context = new NinjaContext())
            {
                context.Database.Log = Console.WriteLine;
                context.Ninjas.AddRange(new List<Ninja.Domain.Clases.Ninja> { ninja1, ninja2 });
                context.SaveChanges();
            };

        }

        private static void SimpleNinjaQueries()
        {
            using (var context = new NinjaContext())
            {
                var ninja = context.Ninjas
                    .Where(n => n.DateOfBirth >= new DateTime(1984, 1, 1))
                    .OrderBy(n => n.Name)
                    .Skip(1).Take(1)
                    .FirstOrDefault();
                     
                    Console.WriteLine(ninja.Name);
            }
        }

        private static void QueryAndUpdateNinja()
        {
            using (var context=new NinjaContext())
            {
                context.Database.Log = Console.WriteLine;
                var ninja = context.Ninjas.FirstOrDefault();
                ninja.ServedInOniwaban = (!ninja.ServedInOniwaban);
                context.SaveChanges();
            }
        }

        private static void QueryAndUpdateNinjaDisconnevted()
        {
            Ninja.Domain.Clases.Ninja ninja;

            using (var context = new NinjaContext())
            {
                context.Database.Log = Console.WriteLine;
                ninja = context.Ninjas.FirstOrDefault();
            }

            ninja.ServedInOniwaban = (!ninja.ServedInOniwaban);

            using (var context=new NinjaContext())
            {
                context.Database.Log = Console.WriteLine;
                context.Ninjas.Attach(ninja);
                context.Entry(ninja).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        private static void retrieveDataWithFind()
        {
            var keyval = 7;
            using (var context=new NinjaContext())
            {
                context.Database.Log = Console.WriteLine;
                var ninja = context.Ninjas.Find(keyval);

                Console.WriteLine("After Find#1:" + ninja.Name);

                var someNinja = context.Ninjas.Find(keyval);
                Console.WriteLine("After Find#2:"+ someNinja.Name);

                ninja = null;
            }
        }

        private static void RetrievedataWithStoreProc()
        {
            using (var context=new NinjaContext())
            {
                context.Database.Log = Console.WriteLine;
                var ninjas = context.Ninjas.SqlQuery("exec GetOldNinjas").ToList();

                //foreach (var ninja in ninjas)
                //{
                //    Console.WriteLine(ninja.Name);
                //}
            }
        }

        private static void DeleteNinjaOLD()
        {
            using (var context=new NinjaContext())
            {
                context.Database.Log = Console.WriteLine;
                var ninja = context.Ninjas.FirstOrDefault();
                context.Ninjas.Remove(ninja);
                context.SaveChanges();
            }
        }

        private static void DeleteNinja()
        {
            Ninja.Domain.Clases.Ninja ninja;

            using (var context = new NinjaContext())
            {
                context.Database.Log = Console.WriteLine;
                ninja = context.Ninjas.FirstOrDefault();
            }
            using (var context = new NinjaContext())
            {
                context.Database.Log = Console.WriteLine;
                context.Entry(ninja).State = EntityState.Deleted;
                context.SaveChanges();
            }

        }

        private static void DeleteNinjaWithKeyValue()
        {
            var keyval = 9;
            using (var context = new NinjaContext())
            {
                context.Database.Log = Console.WriteLine;
                context.Database.ExecuteSqlCommand("exec DeleteNinjaViaId {0}",keyval);
            }
        }

        private static void InsertNinjaWithEquipment()
        {
            using (var context=new NinjaContext())
            {
                context.Database.Log = Console.WriteLine;

                var ninja = new Ninja.Domain.Clases.Ninja
                {
                    Name="Kacy Catanzaro",
                    ServedInOniwaban=false,
                    DateOfBirth=new DateTime(1990,1,14),
                    ClanID=1
                };

                var muscles = new NinjaEquipment
                {
                    Name="Muscles",
                    Type=EquipmentType.Tool
                };

                var spunk = new NinjaEquipment
                {
                    Name = "Spunk",
                    Type = EquipmentType.Weapon
                };

                context.Ninjas.Add(ninja);
                ninja.EquipedOwned.Add(muscles);
                ninja.EquipedOwned.Add(spunk);

                context.SaveChanges();

            }

        }

        private static void SimpleNinjaGraphQuery()
        {
            using (var context=new NinjaContext())
            {
                context.Database.Log = Console.WriteLine;

                var ninja = context.Ninjas.FirstOrDefault(n => n.Name.StartsWith("Kacy"));
                Console.WriteLine("Ninja retrieved:" + ninja.Name);
                Console.WriteLine("Ninja Equipment Count: {0}", ninja.EquipedOwned.Count());
            }
        }

        private static void ProjectionQuery()
        {
            using (var context=new NinjaContext())
            {
                context.Database.Log = Console.WriteLine;

                var ninjas = context.Ninjas
                    .Select(n => new { n.Name, n.DateOfBirth, n.EquipedOwned })
                    .ToList();
            }
        }

    }
}
