using System.Security.AccessControl;
using static BurgerToNight.Utility.SD;
namespace BurgerToNightUI.Models
{
    public class APIRequest
    {
        public ApiType ApiType { get; set; } = ApiType.GET;
        public string Url { get; set; }
        public object Data { get; set; }
    }
}
