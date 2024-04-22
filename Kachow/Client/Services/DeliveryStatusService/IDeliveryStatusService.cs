using System;
using Kachow.Shared.DTOs;
using Kachow.Shared.Models;

namespace Kachow.Client.Services.DeliveryStatusService
{
	public interface IDeliveryStatusService
	{
        Task<List<DeliveryStatus>> GetAll();
        Task<DeliveryStatus> GetOne(int id);
        Task<bool> Add(DeliveryStatusDTO item);
        Task<DeliveryStatus> Edit(DeliveryStatus item);
        Task<bool> Remove(int id);
    }
}

