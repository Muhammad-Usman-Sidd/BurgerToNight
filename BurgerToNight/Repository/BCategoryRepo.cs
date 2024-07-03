using BurgerToNightAPI.Data;
using BurgerToNightAPI.Models;
using BurgerToNightAPI.Repository;
using BurgerToNightAPI.Repository.IRepository;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BurgerToNightAPI.Repository
{
    public class BCategoryRepo:Repository<BurgerCategory>, IBCategoryRepo
    {
        private readonly BurgerDbContext _db;

        public BCategoryRepo(BurgerDbContext db) : base(db)
        {
            _db = db;
        }

        //public ActionResult<BurgerCategroy> NameCheck(BurgerCategroy entity,BurgerCategoryDTO burgerCategoryDTO)
        //{
        //    if (entity.Title.ToLower() == burgerCategoryDTO.Title.ToLower()){
        //        return ModelStateError;
        //    }
        //    return entity;
        //}

        public async Task<BurgerCategory> UpdateAsync(BurgerCategory entity)
        {
            _db.BCategories.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
