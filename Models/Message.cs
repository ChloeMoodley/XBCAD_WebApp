using System.ComponentModel.DataAnnotations;

namespace XBCAD_WebApp.Models
{
    public class Message
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string ProblemDescriptionQuestion { get; set; }

        public string ContactDetails { get; set; }
        public DateTime DatePosted { get; set; }
    }
}
