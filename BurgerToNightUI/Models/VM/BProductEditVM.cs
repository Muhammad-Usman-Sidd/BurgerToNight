using BurgerToNightUI.Models.DTO;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BurgerToNightUI.Models.VM
{
    public class BProductEditVM
    {
        public BProductEditVM()
        {
            BProduct = new BProductEditDTO();
        }
        public BProductEditDTO BProduct { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> CategoryList { get; set; }
    }
}
