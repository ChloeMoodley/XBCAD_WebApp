using Microsoft.Build.Framework;
using System.Drawing;

namespace XBCAD_WebApp.Models
{
    public class DealModel
    {
        public string? id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }

        public DealModel()
        {

        }

        public DealModel(string title, string description)
        {
            this.Title = title;
            this.Description = description;
        }
    }
}
