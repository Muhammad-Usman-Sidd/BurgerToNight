﻿using BurgerToNightAPI.Data;
using BurgerToNightAPI.Models;
using BurgerToNightAPI.Repository;
using BurgerToNightAPI.Repository.IRepository;

namespace BurgerToNightAPI.Repository
{
    public class CartRepo : Repository<Cart>, ICartRepo
    {
        private readonly BurgerDbContext _db;
        public CartRepo(BurgerDbContext db) : base(db)
        {
            _db = db;

        }
        public async Task<Cart> UpdateAsync(Cart entity)
        {
            _db.Cart.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}