using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TeamsMVC.Enums;

namespace TeamsMVC.Models.ViewModels
{
    public class PlayerViewModel
    {
        /// <summary>
        /// Идентификатор игрока
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        [Display(Name = "Имя")]
        [Required(ErrorMessage = "Поле имя является обязательным")]
        public string FirstName { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }

        /// <summary>
        /// Дата рождения
        /// </summary>
        [Display(Name = "Дата рождения")]
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Позиция
        /// </summary>
        [Display(Name = "Позиция")]
        public Position Position { get; set; }

        /// <summary>
        /// Идентификатор команды
        /// </summary>
        [Display(Name = "Команда")]
        public int? TeamId { get; set; }
    }
}