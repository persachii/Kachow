namespace Kachow.Shared.Models
{
	public class ParcelName
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public decimal Price { get; set; }
		public IEnumerable<Parcel> Parcels { get; set; }
	}
}

