using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeamsMVC.Models
{
    /// <summary>
    /// Сущность "Спонсор"
    /// </summary>
    public class Sponsor
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Команды
        /// </summary>
        public virtual ICollection<Team> Teams { get; set; }
    }
}