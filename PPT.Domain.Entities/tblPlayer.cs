using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using PPT.Domain.Core.Entities;

namespace PPT.Domain.entities
{
    [Serializable()]
    public class tblPlayer:BaseEntity
    {
        public string Name { get; set; }
    }
}
