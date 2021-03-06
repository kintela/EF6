﻿using System;
using System.Collections.Generic;
using NinjaDomain.Clases.interfaces;

namespace NinjaDomain.Clases
{
    public class Clan:IModificacionHistory
    {
        public Clan()
        {
            Ninjas = new List<Ninja>();
        }
        public int Id { get; set; }
        public string ClanName { get; set; }
        public List<Ninja> Ninjas { get; set; }

        public DateTime DateModified { get ; set ; }
        public DateTime DateCreated { get ; set ; }
        public bool IsDirty { get ; set ; }
    }
}
