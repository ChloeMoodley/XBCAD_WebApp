using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace XBCAD_WebApp.Models
{
    public class PDF_Model
    {
        public string? pdf_id { get; set; }

        [Required]
        public string pdf_description { get; set; }

        [Required]
        public string pdf_upload { get; set; }

        public PDF_Model()
        {

        }

        public PDF_Model(string description, string image)
        {
            this.pdf_description = description;
            this.pdf_upload = image;
        }
    }
}
