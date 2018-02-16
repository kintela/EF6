using System;
using System.Collections.Generic;
using Ninja.Domain.Clases.interfaces;

namespace Ninja.Domain.Clases
{
    public class Ninja:IModificacionHistory
    {
        public Ninja()
        {
            EquipedOwned = new List<NinjaEquipment>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public bool ServedInOniwaban { get; set; }
        public Clan Clan { get; set; }
        public int ClanID { get; set; }
        public List<NinjaEquipment> EquipedOwned { get; set; }
        public System.DateTime DateOfBirth { get; set; }


        public DateTime DateModified { get ; set; }
        public DateTime DateCreated { get ; set ; }
        public bool IsDirty { get ; set ; }
    }
}
