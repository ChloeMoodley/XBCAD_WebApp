using System.ComponentModel.DataAnnotations;

namespace XBCAD_WebApp.Models
{
    public class FAQModel
    {
        public string? id { get; set; }

        [Required]
        public string Question { get; set; }

        [Required]
        public string Answer { get; set; }

        public FAQModel()
        {

        }

        public FAQModel(string question, string answer)
        {
            this.Question = question;
            this.Answer = answer;
        }

    }
}
