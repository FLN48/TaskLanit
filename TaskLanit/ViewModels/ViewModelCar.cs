using System.ComponentModel.DataAnnotations;

namespace TaskLanit.Pages
{
    public class ViewModelCar
    {
        [Required(ErrorMessage = "Данное поле обязательно.")]
        [DataType(DataType.Text)]
        public string Color { get; set; } = "";
        [Required(ErrorMessage = "Данное поле обязательно.")]
        [DataType(DataType.Text)]
        public string CarMake { get; set; } = "";

        [Required(ErrorMessage = "Данное поле обязательно.")]
        [Range(1, 50, ErrorMessage = @"min={1} max={2}")]
        public int AddCarCount { get; set; } = 1;
    }
}
