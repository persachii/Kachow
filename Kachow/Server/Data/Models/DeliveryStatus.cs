using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kachow.Server.Data.Models
{
    public class DeliveryStatus
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 1)]
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Parcel>? Parcels { get; set; }
    }
}

