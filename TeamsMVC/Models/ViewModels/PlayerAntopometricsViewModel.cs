using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TeamsMVC.Models.ViewModels
{
    /// <summary>
    /// Модель представления для заполнения антропометрических данных игрока
    /// </summary>
    public class PlayerAntopometricsViewModel
    {
        /// <summary>
        /// Идентификатор антропометрических данных
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Идентификатор игрока
        /// </summary>
        public int PlayerId { get; set; }

        /// <summary>
        /// Рост
        /// </summary>
        [Display(Name = "Рост")]
        [Required(ErrorMessage = "Поле рост должно быть заполнено")]
        public int Height { get; set; }

        /// <summary>
        /// Вес
        /// </summary>
        [Display(Name = "Вес")]
        [Required(ErrorMessage = "Поле вес должно быть заполнено")]
        public int Weight { get; set; }

        /// <summary>
        /// Размер ноги
        /// </summary>
        [Display(Name = "Размер ноги")]
        [Required(ErrorMessage = "Поле размер ноги должно быть заполнено")]
        public int ShoeSize { get; set; }
    }
}