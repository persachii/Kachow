
using Kachow.Server.Data;
using Kachow.Server.Data.Models;
using Kachow.Shared.DTOs;
using Microsoft.EntityFrameworkCore;

namespace Kachow.Server.Services
{
	public class DeliveryMethodService
	{
		private DataContext _context;
		public DeliveryMethodService(DataContext context)
		{
			_context = context;
		}

		public async Task<List<DeliveryMethod>> GetDeliveryMethods()
		{
			var result = await _context.DeliveryMethods.ToListAsync();
			return await Task.FromResult(result);
		}

        public async Task<DeliveryMethod?> AddDeliveryMethod(DeliveryMethodDTO method)
        {
            DeliveryMethod newMethod = new DeliveryMethod
            {
                Name = method.Name,
                Price = method.Price,
            };
            var result = _context.DeliveryMethods.Add(newMethod);
            await _context.SaveChangesAsync();
            return await Task.FromResult(result.Entity);
        }
    }
}

