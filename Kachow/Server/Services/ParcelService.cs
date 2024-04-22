
using Kachow.Server.Data;
using Kachow.Server.Data.Models;
using Kachow.Shared.DTOs;
using Microsoft.EntityFrameworkCore;

namespace Kachow.Server.Services
{
	public class ParcelService
	{
		private DataContext _context;
		public ParcelService(DataContext context)
		{
			_context = context;
		}

		public async Task<List<Parcel>> GetParcels()
		{
			var result = await _context.Parcels.Include(a => a.ParcelName).Include(b => b.DeliveryMethod).Include(c => c.DeliveryStatus).ToListAsync();
			return await Task.FromResult(result);
		}

		public async Task<Parcel?> GetParcel(int id)
		{

			var result = _context.Parcels.FirstOrDefault(parcel => parcel.Id == id);

			return await Task.FromResult(result);
		}

		public async Task<Parcel?> AddParcel(ParcelDTO parcel)
		{
			decimal price1 = await Task.FromResult(_context.DeliveryMethods.First(method => method.Id == parcel.DeliveryMethodId).Price) * new Random(10).Next();
			decimal price2 = await Task.FromResult(_context.ParcelNames.First(parcelName => parcelName.Id == parcel.DeliveryMethodId).Price) * new Random(10).Next();


			Parcel newParcel = new Parcel
			{
				ParcelName = await Task.FromResult(_context.ParcelNames.First(name => name.Id == parcel.ParcelNameId)),
				DepartmentAddress = parcel.DepartmentAddress,
				DestinationAddress = parcel.DestinationAddress,
				LastUpload = DateTime.UtcNow,
				DeliveryStatus = await Task.FromResult(_context.DeliveryStatuses.First(statusName => statusName.Id == 1)),
				User = await Task.FromResult(_context.Users.First(customer => customer.Id == parcel.UserId)),
				DeliveryMethod = await Task.FromResult(_context.DeliveryMethods.First(methodName => methodName.Id == parcel.DeliveryMethodId)),
				Price = price1 + price2
				//Price = await Task.FromResult(_context.DeliveryMethods.First(methodName => methodName.Name == parcel.DeliveryMethod).Price) * new Random(2000).Next(),
			};
			var result = _context.Parcels.Add(newParcel);
			await _context.SaveChangesAsync();
			return await Task.FromResult(result.Entity);
		}


		public async Task<bool> DeleteParcel(int id)
		{
			var parcel = await _context.Parcels.FirstOrDefaultAsync(p => p.Id == id);
			if (parcel != null)
			{
				_context.Parcels.Remove(parcel);
				await _context.SaveChangesAsync();
				return true;
			}

			return false;
		}

		public async Task<List<TrackedParcelDTO>> GetTrackedParcels()
		{
			var trackedParcel = await _context.Parcels.Include(a => a.ParcelName).Include(b => b.DeliveryMethod).Include(c => c.DeliveryStatus).ToListAsync();
			
			List<TrackedParcelDTO> result = new List<TrackedParcelDTO>();
			trackedParcel.ForEach(tr => result.Add(new TrackedParcelDTO
			{
				Id = tr.Id,
				Name = tr.ParcelName.Name,
				DeliveryMethodName = tr.DeliveryMethod.Name,
				DepartmentAddress = tr.DepartmentAddress,
				DestinationAddress = tr.DestinationAddress,
				DepartureDate = tr.DepartureDate.ToUniversalTime(),
				AnticipatedDeliveryDate = tr.AnticipatedDeliveryDate.ToUniversalTime(),
				Status = tr.DeliveryStatus.Name,
				LastUpload = tr.LastUpload.ToUniversalTime(),
				Price = tr.Price
			}));
			return await Task.FromResult(result);
		}

		public async Task<TrackedParcelDTO> GetTrackedParcel(int id)
		{

			var trackedParcel = await _context.Parcels.Include(a => a.ParcelName).Include(b => b.DeliveryMethod).Include(c => c.DeliveryStatus).FirstOrDefaultAsync(p => p.Id == id);

			TrackedParcelDTO result = new TrackedParcelDTO
			{
				Id = trackedParcel.Id,
				Name = trackedParcel.ParcelName.Name,
				DeliveryMethodName = trackedParcel.DeliveryMethod.Name,
				DepartmentAddress = trackedParcel.DepartmentAddress,
				DestinationAddress = trackedParcel.DestinationAddress,
				DepartureDate = trackedParcel.DepartureDate.ToUniversalTime(),
				AnticipatedDeliveryDate = trackedParcel.AnticipatedDeliveryDate.ToUniversalTime(),
				Status = trackedParcel.DeliveryStatus.Name,
				LastUpload = trackedParcel.LastUpload.ToUniversalTime(),
				Price = trackedParcel.Price
			};
			return await Task.FromResult(result);
		}
		/*
		private async Task<decimal> MakePriceAsync(ParcelDTO parcel)
        {
			decimal price1 = await Task.FromResult(_context.DeliveryMethods.First(method => method.Id == parcel.DeliveryMethodId).Price) * new Random(10).Next();
			decimal price2 = await Task.FromResult(_context.ParcelNames.First(parcelName => parcelName.Id == parcel.DeliveryMethodId).Price) * new Random(10).Next();
			return price1 + price2;
		} */

	}

}

