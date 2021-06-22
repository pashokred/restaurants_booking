using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class Table
    {
        public Table(int capacity, TableType tableType, bool isReserved)
        {
            Capacity = capacity;
            TableType = tableType;
            IsReserved = isReserved;
        }
        
        [Required(ErrorMessage = "The field must not be empty")]
        [Display(Name = "Restaurant")]
        public int RestaurantId { get; set; }
        public int Id { get; set; }
        [Required(ErrorMessage = "The field must not be empty")]
        [Display(Name = "Capacity of people, that can set the table")]
        public int Capacity { get; set; }
        
        [Required(ErrorMessage = "The field must not be empty")]
        [Display(Name = "Table type ('Standard' or 'Outdoor')")]
        public TableType TableType { get; set; }
        
        [Required(ErrorMessage = "The field must not be empty")]
        [Display(Name = "Is table reserved")]
        public bool IsReserved { get; set; }
        public virtual Restaurant Restaurant { get; set; }
    }
}