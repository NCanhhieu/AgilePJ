using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgilePJAPINhomC.Models
{
    public class Channel
    {
        [Key]
        public int ChannelId { get; set; }

        public string? ChannelName { get; set; }

        public int? Channelstatus { get; set; }

        [ForeignKey("customid")]
        [Required]
        //public int customid { get; set; }
        public virtual Customer customer { get; set; }
        
    }
}
