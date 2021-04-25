using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TeamsMVC.Enums;

namespace TeamsMVC.Models
{
    /// <summary>
    /// Сущность "Игрок"
    /// </summary>
    public class Player 
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
        /// Полное имя
        /// </summary>
        public virtual string FullName { get => $"{FirstName} {LastName}";}

        /// <summary>
        /// Дата рождения
        /// </summary>
        [Required(ErrorMessage = "Поле дата рождения является обязательным")]
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Позиция
        /// </summary>
        [Required(ErrorMessage = "Поле позиция является обязательным")]
        public Position Position { get; set; }

        /// <summary>
        /// Идентификатор команды
        /// </summary>
        public int? TeamId { get; set; }

        /// <summary>
        /// Ссылка на команду
        /// </summary>
        public Team Team { get; set; }

        /// <summary>
        /// Антропометрические данные игрока
        /// </summary>
        public virtual PlayerAntropometrics PlayerAntropometrics { get; set; }
    }
}