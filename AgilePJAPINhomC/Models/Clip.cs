using System.ComponentModel.DataAnnotations;

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

        public int ChanelId { get; set; }
        public virtual Channel Channel { get; set; }
        
    }
}
