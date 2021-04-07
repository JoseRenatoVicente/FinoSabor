using System.ComponentModel.DataAnnotations;

namespace FinoSabor.Application.ViewModels
{
    public class EmailTestVM
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
