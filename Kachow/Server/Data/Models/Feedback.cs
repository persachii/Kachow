using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kachow.Server.Data.Models
{
	public class Feedback
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 1)]
        public int Id { get; set; }
        public int Rate { get; set; }
        public string? Description { get; set; }
        public int ParcelForeignKey { get; set; }
        public Parcel Parcel { get; set; }
        public Worker Worker { get; set; }
    }
}

