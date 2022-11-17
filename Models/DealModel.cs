using Microsoft.Build.Framework;

namespace XBCAD_WebApp.Models
{
    public class DealModel
    {
        public string? id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public string Image { get; set; }

        public DealModel()
        {

        }

        public DealModel(string title, string description, string image)
        {
            this.Title = title;
            this.Description = description;
            this.Image = image;
        }
    }
}
