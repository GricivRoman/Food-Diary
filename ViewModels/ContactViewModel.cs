
using System.ComponentModel.DataAnnotations;

namespace FoodDiary.ViewModels
{
	public class ContactViewModel
    {
        [MinLength(5)]
        [Required]        
		public string Name { get; set; }
        
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        [Required]
        public string Subject { get; set; }
        
        
        [MaxLength (252, ErrorMessage ="Message is too long")]
        [Required]
        public string Message { get; set; }
		
	}
}