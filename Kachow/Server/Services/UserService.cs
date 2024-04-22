using System;
using Kachow.Server.Data;
using Kachow.Server.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Kachow.Server.Services
{
	public class UserService
	{
		private DataContext _context;
		public UserService(DataContext context)
		{
			_context = context;
		}

		public async Task<List<User>> GetUsers()
		{
			var result = await _context.Users.ToListAsync();
			return await Task.FromResult(result);
		}
	}
}

