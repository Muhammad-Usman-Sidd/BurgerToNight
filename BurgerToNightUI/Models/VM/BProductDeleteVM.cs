using BurgerToNightUI.Models.DTO;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BurgerToNightUI.Models.VM
{
    public class BProductDeleteVM
    {
        public BProductDeleteVM()
        {
            BProduct = new BProductDTO();
        }
        public BProductDTO BProduct { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> CategoryList { get; set; }
        
    }
}
