using Microsoft.Build.Framework;
using System.Drawing;

namespace XBCAD_WebApp.Models
{
    //assisted with adding models Rick-Anderson (2022)
    public class DealModel
    {
        //this code was modified by Troelsen & Japikse (2017) and Rick-Anderson (2022)
        public string? id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }

        //this code was modified by Troelsen & Japikse (2017)
        public DealModel()
        {

        }

        //this code was modified by Troelsen & Japikse (2017)
        public DealModel(string title, string description)
        {
            this.Title = title;
            this.Description = description;
        }
    }
}
