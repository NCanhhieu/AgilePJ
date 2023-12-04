using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgilePJAPINhomC.Models
{
    public class Clip
    {
        [Key]
        public int ClipId { get; set; }

        public string? ClipName { get; set; }

        public string? ClipDesc { get; set;}

        public string? Thumbnail { get; set;}

        public DateTime DateUpload { get; set; }

        public int Filesize { get; set; } 

        public string? Filepath { get; set; }
        public int ClipStatus { get; set; }
        [ForeignKey("ChannelId")]
        [Required]        
        public int ChannelId { get; set; }
        [Required]
        public virtual Channel Channel { get; set; }
        
    }
}
