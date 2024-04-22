using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kachow.Server.Data.Models

{
    public class RefundCases
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 1)]
        public int Id { get; set; }
        public User User { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public DateTime LastUpload { get; set; }
    }
}

