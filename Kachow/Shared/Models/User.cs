using System;
namespace Kachow.Shared.Models
{
	public class User
	{
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; } = new byte[32];
        public byte[] PasswordSalt { get; set; } = new byte[32];
        public string? VerificationToken { get; set; }
        public DateTime? VerifiedAt { get; set; }
        public string? PasswordResetToken { get; set; }
        public DateTime? ResetTokenExpires { get; set; }
        public string? Fullname { get; set; }
        public string? Phone { get; set; }
        public IEnumerable<Parcel>? Parcels { get; set; }
        public IEnumerable<RefundCases>? RefundCases { get; set; }
    }
}

