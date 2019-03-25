using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PPT.Domain.Core.Entities;

namespace PPT.Domain.entities
{
    [Serializable()]
    public class tblResultGame:BaseEntity
    {
        public Guid GameId { get; set; }
        public Guid WinPlayerId { get; set; }
    }
}
