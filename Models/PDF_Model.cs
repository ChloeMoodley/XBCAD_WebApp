using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace XBCAD_WebApp.Models
{
    public class PDF_Model
    {
        public int pdf_id { get; set; } = 0;

        [Required]
        public string pdf_name { get; set; } = "";

        [Required]
        public string pdf_path { get; set; } = "";


        [Required]
        public string pdf_uploadUrl { get; set; }

        public List<PDF_Model> Files { get; set; } = new List<PDF_Model>();

/*        public PDF_Model()
        {

        }

        public PDF_Model(string description, string image)
        {
            this.pdf_description = description;
            this.pdf_upload = image;
        }*/
    }
}
