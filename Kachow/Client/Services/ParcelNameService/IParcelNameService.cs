using System;
using Kachow.Shared.DTOs;
using Kachow.Shared.Models;

namespace Kachow.Client.Services.ParcelNameService
{
	public interface IParcelNameService
	{
        Task<List<ParcelName>> GetAll();
        Task<ParcelName> GetOne(int id);
        Task<bool> Add(ParcelNameDTO item);
        Task<ParcelName> Edit(ParcelName item);
        Task<bool> Remove(int id);
    }
}

