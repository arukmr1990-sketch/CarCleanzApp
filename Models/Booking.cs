using System;
using System.ComponentModel.DataAnnotations;

namespace CarCleanz.Models
{
    public class Booking
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public string Address { get; set; }   // ? Replaces Email

        [Required]
        public string VehicleType { get; set; }  // Hatchback / Sedan / SUV

        [Required]
        public string HouseType { get; set; }    // Individual / Villa / Apartment

        [Required]
        public string CarNumber { get; set; }    // ? New field

        public int Price { get; set; }           // Auto-calculated
        public DateTime BookingDate { get; set; } = DateTime.Now;
    }
}