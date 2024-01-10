using System.ComponentModel.DataAnnotations;
namespace GameStore.Client.Models
{
    public class Game
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(20)]
        public string Genre { get; set; } = string.Empty;

        [Range(1, 100)]
        public decimal Price { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}