using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models_DB_and_Request.DB
{
    public class CityMenu
    {
        public int Id { get; set; }  // Primary Key
        public string City { get; set; } = string.Empty;        // Название города
        public Guid OrganizationId { get; set; }                 // ID организации
        public int ExternalMenuId { get; set; }                 // ID меню
        public string ExternalMenu { get; set; } = string.Empty; // JSON меню
        public DateTime CacheDayExternalMenu { get; set; }       // Дата истечения времени меню
    }
}
