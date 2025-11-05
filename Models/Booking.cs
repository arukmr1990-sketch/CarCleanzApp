using System;
using System.ComponentModel.DataAnnotations;

namespace CarCleanz.Models
{
    public class Booking
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public string VehicleType { get; set; }

        [Required]
        public string Service { get; set; }

        [Required]
        public DateTime BookingDate { get; set; }
    }
}