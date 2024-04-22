using System;

namespace Kachow.Shared.DTOs
{
    public class TrackedParcelDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DeliveryMethodName { get; set; }
        public string DepartmentAddress { get; set; }
        public string DestinationAddress { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime AnticipatedDeliveryDate { get; set; }
        public string Status { get; set; }
        public DateTime LastUpload { get; set; }
        public decimal Price { get; set; }
    }
}

