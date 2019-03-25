using System;
using System.ComponentModel.DataAnnotations;
using PPT.Domain.Core.Entities;

namespace PPT.Domain.entities
{
    public partial class tblGame:BaseEntity
    {
        public Guid FirstPlayer { get; set; }

        public Guid SecondPlayer { get; set; }

        public DateTime DateCreated { get; set; }
    }
}
