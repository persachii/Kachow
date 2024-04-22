
using Kachow.Server.Data;
using Kachow.Server.Data.Models;
using Kachow.Shared.DTOs;
using Microsoft.EntityFrameworkCore;

namespace Kachow.Server.Services
{
    public class ParcelNameService 
    {
		private DataContext _context;
		public ParcelNameService(DataContext context)
		{
			_context = context;
		}



        public async Task<List<ParcelName>> GetParcelNames()
        {
            var result = await _context.ParcelNames.ToListAsync();
            return await Task.FromResult(result);
        }

        public async Task<ParcelName?> AddParcelName(ParcelNameDTO name)
        {
            ParcelName newName = new ParcelName
            {
                Name = name.Name,
                Price = name.Price
            };
            var result = _context.ParcelNames.Add(newName);
            await _context.SaveChangesAsync();
            return await Task.FromResult(result.Entity);
        }
    }
}

