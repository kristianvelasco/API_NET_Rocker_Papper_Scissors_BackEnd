using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PPT.Domain.Core.Entities
{
   [Serializable()]
        public class BaseEntity : IStatefulObject
        {
            #region Constructor
            public BaseEntity()
            {
                this.ObjectState = ObjectState.Unchanged;
            }
            #endregion

            #region Properties
            [Key]
            public Guid Id { get; set; }

            [NotMapped]
            public ObjectState ObjectState { get; set; }
            #endregion
        }
    
}
