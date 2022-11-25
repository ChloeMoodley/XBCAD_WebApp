using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace XBCAD_WebApp.Models
{
    //assisted with adding models Rick-Anderson (2022)
    public class PDF_Model
    {
        //this code was modified by Troelsen & Japikse (2017)
        public int pdf_id { get; set; } = 0;

        [Required]
        public string pdf_name { get; set; } = "";

        [Required]
        public string pdf_path { get; set; } = "";

        [Required]
        public string pdf_uploadUrl { get; set; }

        //code modified by ASP.NET Core PDF Viewer || PDF Upload || 100% Free (2021)
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
