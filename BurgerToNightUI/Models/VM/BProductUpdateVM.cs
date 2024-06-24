using BurgerToNightUI.Models.DTO;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BurgerToNightUI.Models.VM
{
    public class BProductUpdateVM
    {
        public BProductUpdateVM()
        {
            BProduct = new BProductUpdateDTO();
        }
        public BProductUpdateDTO BProduct { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> CategoryList { get; set; }
    }
}
