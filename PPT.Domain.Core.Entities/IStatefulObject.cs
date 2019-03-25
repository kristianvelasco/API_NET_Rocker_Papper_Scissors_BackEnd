using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPT.Domain.Core.Entities
{
    public interface IStatefulObject
    {
        ObjectState ObjectState { get; set; }
    }

    public enum ObjectState
    {
        Added,
        Unchanged,
        Modified,
        Deleted
    }
}
