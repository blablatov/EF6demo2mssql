using AutoLotDAL.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace AutoLotDAL.Models
{
    public partial class Customer : EntityBase
    {
        [Index(IsUnique = false)]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Index(IsUnique = false)]
        [StringLength(50)]
        public string LastName { get; set; }

        public virtual ICollection<Order> Orders { get; set; } = new HashSet<Order>();

        [NotMapped]
        public string FullName => FirstName + " " + LastName;

        public static implicit operator Customer(string v)
        {
            throw new NotImplementedException();
        }
    }
}
