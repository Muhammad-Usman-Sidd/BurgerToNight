using System.Globalization;
using System.Threading.Tasks;
using BurgerToNight.Repository.IRepository;

namespace BurgerToNightUI.Extension
{
    public static class Extensions
    {
        public static string ToCurrency(this int value)
        {
            return $"${value}";
        }
        public static string ToMinutes(this int value) 
        {
            return $"{value} Min";
        }
    }
}
