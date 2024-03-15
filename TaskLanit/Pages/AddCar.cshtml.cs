using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TaskLanit.Pages
{
    public class AddCarModel : PageModel
    {
        [BindProperty]
        public string Message { get; set; }
        [BindProperty]
        public ViewModelCar viewModelCar { get; set; } = new ViewModelCar();

        public AddCarModel()
        {
           
        }
        public async Task<IActionResult> OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPost() 
        {
            for (int i=0;i < viewModelCar.AddCarCount;i++) 
            {
                ACar car = null;

                if (viewModelCar.CarMake == "Mercedes")
                {
                    car = new Mercedes(viewModelCar.Color);
                }
                else
                {
                    car = new BMV(viewModelCar.Color);
                }

                List<ACarShowroom> aCarShowrooms = HttpContext.RequestServices.GetServices<ACarShowroom>().ToList();
                aCarShowrooms.Sort((x, y) => x.GetCarsCount(car).CompareTo(y.GetCarsCount(car)));

                bool checkAdd = false;
                foreach (var item in aCarShowrooms)
                {
                    if (item.CheckCountCars(car))
                    {
                        item.AddCar(car);
                        checkAdd = true;
                        break;
                    }
                }
                if (!checkAdd)
                {
                    Message = $"Не удалось добавить {viewModelCar.AddCarCount-i} Авто";
                    return Page();
                }
                Message = "";
            }
            return Page();
        }
    }
}
