using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace News.ViewModels
{
    public class NewsViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "HeaderRequired")]
        public string Header { get; set; }
        [Required(ErrorMessage = "SubtitleRequired")]
        public string Subtitle { get; set; }
        [Required(ErrorMessage = "TextRequired")]
        public string Text { get; set; }
        [Required(ErrorMessage = "ImageRequired")]
        public string Image { get; set; }
    }
}
