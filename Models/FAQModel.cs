using System.ComponentModel.DataAnnotations;

namespace XBCAD_WebApp.Models
{
    //assisted with adding models Rick-Anderson (2022)
    public class FAQModel
    {
        //this code was modified by Troelsen & Japikse (2017)
        public string? id { get; set; }

        [Required]
        public string Question { get; set; }

        [Required]
        public string Answer { get; set; }

        //this code was modified by Troelsen & Japikse (2017)
        public FAQModel()
        {

        }

        //this code was modified by Troelsen & Japikse (2017)
        public FAQModel(string question, string answer)
        {
            this.Question = question;
            this.Answer = answer;
        }

    }
}
