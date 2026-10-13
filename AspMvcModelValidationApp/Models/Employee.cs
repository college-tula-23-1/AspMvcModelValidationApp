using System.ComponentModel.DataAnnotations;

namespace AspMvcModelValidationApp.Models
{
    public class Employee
    {
        public string? Id { get; set; }


        [Required(ErrorMessage = "Поле Имя обязательно для заполнения")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Неверная длина")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Поле Возраст обязательно для заполнения")]
        [Range(1, 100, ErrorMessage = "Недопустимый диапазон возраста")]
        public int Age { get; set; }

        //[RegularExpression(@"^\w+@[\w\._]+\.[A-Za-z]{2,5}$", ErrorMessage = "Неверный формат email")]
        [EmailAddress(ErrorMessage = "Неверный формат email")]
        public string? Email { get; set; }


        [Required]
        [StringLength(50, MinimumLength = 8)]
        public string Password { get; set; } = null!;

        [Compare("Password", ErrorMessage = "Пароль не совпадает")]
        public string ConfirmPassword { get; set; } = null!;
    }
}
