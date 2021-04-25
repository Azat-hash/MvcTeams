using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeamsMVC.Models
{
    /// <summary>
    /// Сущность "Тренер"
    /// </summary>
    public class Coach
    {
        /// <summary>
        /// Идентификатор игрока
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        [Required(ErrorMessage = "Поле имя является обязательным")]
        public string FirstName { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        [Required(ErrorMessage = "Поле фамилия является обязательным")]
        public string LastName { get; set; }

        /// <summary>
        /// ФИО
        /// </summary>
        public virtual string FullName { get => $"{FirstName} {LastName}"; }

        /// <summary>
        /// Дата рождения
        /// </summary>
        [Required(ErrorMessage = "Поле дата рождения является обязательным")]
        public DateTime DateOfBirth { get; set; }
    }
}