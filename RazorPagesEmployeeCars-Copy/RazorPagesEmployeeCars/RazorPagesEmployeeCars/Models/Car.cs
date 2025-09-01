using System.ComponentModel.DataAnnotations;

namespace RazorPagesEmployeeCars.Models
{
    public class Car
    {
        public int Id { get; set; }

        [Required, StringLength(30)]
        public string Make { get; set; } = string.Empty;

        [Required, StringLength(30)]
        public string Model { get; set; } = string.Empty;

        [Range(1900, 2100)]
        public int Year { get; set; }

        [Required, StringLength(15)]
        public string LicensePlate { get; set; } = string.Empty;

        public int EmployeeId { get; set; }
        public Employee? Employee { get; set; }
    }
}
