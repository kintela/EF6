using System;
using System.Collections.Generic;

namespace NinjaDomain.cla
{
    public class Classes
    {
        public class Ninja
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public bool ServedInOniwaban { get; set; }
            public Clan Clan { get; set; }
            public int ClanID { get; set; }
            public List<NinjaEquipment> EquipedOwned { get; set; }
        }

        public class Clan
        {
            public int Id { get; set; }
            public string ClanName { get; set; }
            public List<Ninja> Ninjas { get; set; }
        }

        public class NinjaEquipment
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public EquipmentType Type { get; set; }
            public Ninja Ninja { get; set; }
        }
    }
}
