namespace Kachow.Shared.Models
{
	public class RefundCases
	{
        public int Id { get; set; }
        public User User { get; set; }
        public int Status { get; set; }
        public DateTime LastUpload { get; set; }
    }
}

