using System.ComponentModel.DataAnnotations;

namespace VidlyCoreAuth.Models
{
    public class Genre
    {
        public byte Id { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; }
    }
}