using AutoLotDAL.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace AutoLotDAL.Models
{ 

    [Table("Inventory")]
    public partial class Inventory : EntityBase
    {
        [Index(IsUnique = false)]
        [StringLength(50)]
        public string Make { get; set; }

        [Index(IsUnique = false)]
        [StringLength(50)]
        public string Color { get; set; }

        [Index(IsUnique = false)]
        [StringLength(50)]
        public string PetName { get; set; }

        public virtual ICollection<Order> Orders { get; set; } = new HashSet<Order>();
    }
}
