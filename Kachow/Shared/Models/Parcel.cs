

namespace Kachow.Shared.Models
{
    public class Parcel
    {
        public int Id { get; set; }
        public ParcelName ParcelName { get; set; }
        public string DepartmentAddress { get; set; }
        public string DestinationAddress { get; set; }
        public User User { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime AnticipatedDeliveryDate { get; set; }
        public DateTime LastUpload { get; set; }
        public DeliveryStatus DeliveryStatus { get; set; }
        public DeliveryMethod DeliveryMethod { get; set; }
        public decimal Price { get; set; }
    }
}

