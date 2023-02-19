using FoodDiary.Data.Entities;

namespace FoodDiary.ViewModels.Food
{
    public class ProductListViewModel
    {
        public string SheetName { get; set; }

        public ICollection<ProductViewModel> Products { get; set; }

    }
}
