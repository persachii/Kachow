using System;
using Kachow.Shared.DTOs;
using Kachow.Shared.Models;

namespace Kachow.Client.Services.UserService
{
	public interface IUserService
	{
        Task<List<User>> GetAll();
        Task<User> GetOne(int id);
        Task<bool> Add(UserRegisterRequest item);
        Task<User> Edit(User item);
        Task<bool> Remove(int id);
    }
}

