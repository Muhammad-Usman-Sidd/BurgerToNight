using BurgerToNight.Data;
using BurgerToNight.Models;
using BurgerToNight.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace BurgerToNight.Repository.IRepository
{
    public interface IBCategoryRepo:IRepository<BurgerCategory>
    {
        Task<BurgerCategory> UpdateAsync(BurgerCategory entity);
        //ActionResult<BurgerCategroy> NameCheck(BurgerCategroy entity,BurgerCategoryDTO burgerCategroyDTO);

    }
}
