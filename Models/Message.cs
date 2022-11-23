using System.ComponentModel.DataAnnotations;

namespace XBCAD_WebApp.Models
{
    public class Message
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string ProblemDescriptionQuestion { get; set; }

        public double ContactDetails { get; set; }

        public string Other { get;set; }


       // public DateTime DatePosted { get; set; }

        public Message()
        {

        }

        public Message(string Name, string ProblemDescriptionQuestion, double ContactDetails, string Other )
        {
            this.Name = Name;
            this.ProblemDescriptionQuestion = ProblemDescriptionQuestion;
            this.ContactDetails = ContactDetails;
            this.Other = Other;
        }
    }
}
