using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kachow.Server.Data.Models
{
	public class Worker
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 1)]
        public int Id { get; set; }
        public string Fullname { get; set; }
        public int PassportSeries { get; set; }
        public int PassportNumber { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Tin { get; set; }
        public IEnumerable<Feedback>? Feedbacks { get; set; }
    }
}

