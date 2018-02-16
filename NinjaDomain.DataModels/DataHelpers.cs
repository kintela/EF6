using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninja.Domain.Clases;

namespace NinjaDomain.DataModels
{
    public class DataHelpers
    {
        public static void NewDbWithSeed()
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<NinjaContext>());

            using (var context=new NinjaContext())
            {
                if (context.Ninjas.Any())
                {
                    return;
                }

                var vtClan = context.Clans.Add(new Clan { ClanName="Vermont Clan"});
                var turtleClan= context.Clans.Add(new Clan { ClanName = "Turtles" });
                var amClan = context.Clans.Add(new Clan { ClanName = "American Ninja Warriors" });
            }
        }
    }
}
