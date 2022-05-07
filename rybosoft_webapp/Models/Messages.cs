using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace rybosoft_webapp.Models
{
    public class Messages
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MessageId { get; set; }

        [Required]
        [StringLength(50)]
        public string? UserId { get; set; }

        [Required]
        [StringLength(500)]
        public string? MessageText { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime RecordDate { get; set; }
    }
}
