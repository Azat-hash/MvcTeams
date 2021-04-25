using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TeamsMVC.Enums;

namespace TeamsMVC.Models
{
    /// <summary>
    /// Сущность "Команда"
    /// </summary>
    public class Team
    {
        public Team()
        {
            Sponsors = new List<Sponsor>();
            Players = new List<Player>();
        }

        /// <summary>
        /// Идентификатор команды
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название команды
        /// </summary>
        [Display(Name = "Название")]
        [Required(ErrorMessage = "Поле название является обязательным")]
        public string Name { get; set; }

        /// <summary>
        /// Конференция
        /// </summary>
        [Display(Name = "Конференция")]
        //[Required(ErrorMessage = "Поле конференция является обязательным")]
        public Conference? Conference { get; set; }

        /// <summary>
        /// Идентификатор тренера
        /// </summary>
        //[Display(Name = "Тренер")]
        public int? CoachId { get; set; }

        /// <summary>
        /// Тренет
        /// </summary>
        public Coach Coach { get;set;}

        /// <summary>
        /// Игроки команды
        /// </summary>
        public virtual ICollection<Player> Players { get;set;}

        /// <summary>
        /// Спонсоры
        /// </summary>
        public virtual ICollection<Sponsor> Sponsors { get; set; }
    }
}