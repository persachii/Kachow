namespace Kachow.Shared.Models
{
    public class DeliveryStatus
	{
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Parcel> Parcels { get; set; }
    }
}

