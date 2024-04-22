﻿

namespace Kachow.Shared.Models
{
    public class DeliveryMethod
	{
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public IEnumerable<Parcel> Parcels { get; set; }
    }
}

