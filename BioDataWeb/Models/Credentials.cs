using System.ComponentModel.DataAnnotations;

namespace BioDataWeb.Models
{
    public class Credentials
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }
        
        [Required]
        public string LastName { get; set; }

        [Required]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Only Numbers are allowed!")]
        [StringLength(11, ErrorMessage = "The Cell No. cannot exceed 11 digits!")]
        public string CellNo { get; set; }

        public DateTime DateTimeCreated {get; set; } = DateTime.Now;
    }
}
