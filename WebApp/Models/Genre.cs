using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }
        
        [Required(ErrorMessage ="Can't be empty.")]
        [MaxLength(25)]
        [DisplayName("Genre Name")]
        public string Name { get; set; } 
    }
}
