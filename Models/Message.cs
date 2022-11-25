using System.ComponentModel.DataAnnotations;

namespace XBCAD_WebApp.Models
{
    //assisted with adding models Rick-Anderson (2022)
    public class Message
    {
        //this code was modified by Troelsen & Japikse (2017)
        [Key]
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string ProblemDescriptionQuestion { get; set; }

        public double ContactDetails { get; set; }

        public string Other { get;set; }


        // public DateTime DatePosted { get; set; }
        //this code was modified by Troelsen & Japikse (2017)
        public Message()
        {

        }

        //this code was modified by Troelsen & Japikse (2017)
        public Message(string Name, string ProblemDescriptionQuestion, double ContactDetails, string Other )
        {
            this.Name = Name;
            this.ProblemDescriptionQuestion = ProblemDescriptionQuestion;
            this.ContactDetails = ContactDetails;
            this.Other = Other;
        }
    }
}
