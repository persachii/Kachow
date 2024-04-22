
using Kachow.Server.Data;
using Kachow.Server.Data.Models;
using Kachow.Shared.DTOs;
using Microsoft.EntityFrameworkCore;

namespace Kachow.Server.Services
{
	public class DeliveryStatusService
	{
		private DataContext _context;
		public DeliveryStatusService(DataContext context)
		{
			_context = context;
		}

		public async Task<List<DeliveryStatus>> GetDeliveryStatuses()
		{
			var result = await _context.DeliveryStatuses.ToListAsync();
			return await Task.FromResult(result);
		}

		public async Task<DeliveryStatus?> AddDeliveryStatus(DeliveryStatusDTO status)
		{
			DeliveryStatus newStatus = new DeliveryStatus
			{
				Name = status.Name
			};
			var result = _context.DeliveryStatuses.Add(newStatus);
			await _context.SaveChangesAsync();
			return await Task.FromResult(result.Entity);
		}
	}
}

