using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TaskLanit.Pages
{
    public class AddCarModel : PageModel
    {
        [BindProperty]
        public ViewModelCar viewModelCar { get; set; } = new ViewModelCar();

        public AddCarModel()
        {
           
        }
        public async Task<IActionResult> OnGet(ViewModelCar _viewModelCar)
        {
            if (_viewModelCar != null)
            {
                viewModelCar = _viewModelCar;
            }
            return Page();
        }

        public async Task<IActionResult> OnPost() 
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            for (int i=0;i < viewModelCar.AddCarCount;i++) 
            {
                ACar car = HttpContext.RequestServices.GetServices<ACar>().First(c => c.m_CarMake == viewModelCar.CarMake);
                car.m_ColorCar = viewModelCar.Color;

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
                    viewModelCar.Message = $"Не удалось добавить {viewModelCar.AddCarCount-i} Авто";
                    return RedirectToPage("AddCar", viewModelCar);
                }
                viewModelCar.Message = "";
            }
            return RedirectToPage("AddCar", viewModelCar);
        }
    }
}
