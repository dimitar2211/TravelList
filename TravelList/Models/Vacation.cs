using System.ComponentModel.DataAnnotations;

namespace TravelList.Models
{
    public class Vacation
    {
        public int Id { get; set; }

        [Required]
        public string Continent { get; set; }

        [Required]
        public string Country { get; set; }

        [Range(0, double.MaxValue)]
        [Display(Name = "Ticket Cost")]
        public decimal TicketCost { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Budget { get; set; }
    }
}