using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuestGame.WebApi.Models
{
    public class RegistrationViewModel
    {
        [Display(Name="Логин")]
        [Required(ErrorMessage = "Поле обязательно к заполнению")]
        [DataType(DataType.EmailAddress)]
        public string Name { get; set; }

        [Display(Name="Пароль")]
        [Required(ErrorMessage = "Поле обязательно к заполнению")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name="Подтверждение пароля")]
        [Required(ErrorMessage = "Поле обязательно к заполнению")]
        [Compare("Password", ErrorMessage="Пароли не совпадают")]
        public string ConfirmationPassword { get; set; }
    }
}