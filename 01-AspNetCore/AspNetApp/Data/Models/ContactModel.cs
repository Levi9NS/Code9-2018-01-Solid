using System.ComponentModel.DataAnnotations;

namespace AspNetApp.Data.Models
{
    public class ContactModel
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(60)]
        public string Name { get; set; }
        [Required, MaxLength(20)]
        public string PhoneNumber { get; set; }
        public bool Favorite { get; set; }
    }
}
