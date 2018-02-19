using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinjaDomain.Clases.interfaces
{
    public interface IModificacionHistory
    {
        DateTime DateModified { get; set; }
        DateTime DateCreated { get; set; }

        bool IsDirty { get; set; }
    }
}
