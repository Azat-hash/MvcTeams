using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeamsMVC.Models
{
    /// <summary>
    /// Сущность "Антропометрические данные клиента"
    /// </summary>
    public class PlayerAntropometrics
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Идентификатор игрока
        /// </summary>
        public int PlayerId { get; set; }

        /// <summary>
        /// Рост
        /// </summary>
        public int? Height { get; set; }

        /// <summary>
        /// Вес
        /// </summary>
        public int? Weight { get; set; }

        /// <summary>
        /// Размер ноги
        /// </summary>
        public int? ShoeSize { get; set; }

        /// <summary>
        /// Ссылка на игрока
        /// </summary>
        public Player Player { get; set; }
    }
}