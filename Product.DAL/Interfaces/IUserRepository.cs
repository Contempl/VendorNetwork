﻿using Product.Domain.Entity;

namespace Product.DAL.Interfaces;

public interface IUserRepository : IRepository<User>
{
	Task<User> GetByIdAsync(int id);
	Task<User> GetByEmailAsync (string email);
}