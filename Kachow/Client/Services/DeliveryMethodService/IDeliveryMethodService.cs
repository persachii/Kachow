using System;
using Kachow.Shared.DTOs;
using Kachow.Shared.Models;

namespace Kachow.Client.Services.DeliveryMethodService
{
	public interface IDeliveryMethodService
	{
        Task<List<DeliveryMethod>> GetAll();
        Task<DeliveryMethod> GetOne(int id);
        Task<bool> Add(DeliveryMethodDTO item);
        Task<DeliveryMethod> Edit(DeliveryMethod item);
        Task<bool> Remove(int id);
    }
}

