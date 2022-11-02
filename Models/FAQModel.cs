namespace XBCAD_WebApp.Models
{
    public class FAQModel
    {
        public int id { get; set; }
        public string Question { get; set; }
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
