using Kachow.Shared.DTOs;
using Kachow.Shared.Models;

namespace Kachow.Client.Services.ParcelService
{
    public interface IParcelService
    {
        Task<IEnumerable<Parcel>> GetAll();
        Task<List<TrackedParcelDTO>> GetAllTrackedParcels();
        Task<TrackedParcelDTO> GetAllTrackedParcel(int id);
        Task<Parcel> GetOne(int id);
        Task<bool> Add(ParcelDTO item);
        Task<Parcel> Edit(Parcel item);
        Task<bool> Remove(int id);

    }
}

