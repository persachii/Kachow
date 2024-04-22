using System;
using Kachow.Shared.Models;

namespace Kachow.Shared.DTOs
{
    public class ParcelDTO
    {
        public int UserId { get; set; }
        public int ParcelNameId { get; set; }
        public string DepartmentAddress { get; set; }
        public string DestinationAddress { get; set; }
        public int DeliveryMethodId { get; set; }
    }
}

