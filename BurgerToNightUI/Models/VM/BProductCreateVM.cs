using BurgerToNightUI.Models.DTO;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BurgerToNightUI.Models.VM
{
    public class BProductCreateVM
    {
        public BProductCreateVM()
        {
            BProduct = new BProductCreateDTO();
            CategoryList = new List<SelectListItem>();
        }
        public BProductCreateDTO BProduct { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> CategoryList { get; set; }
        
    }
}
