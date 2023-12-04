using System.ComponentModel.DataAnnotations;

namespace AgilePJAPINhomC.Models
{
    public class Channel
    {
        [Key]
        public int ChannelId { get; set; }

        public string? ChannelName { get; set; }

        public int? Channelstatus { get; set; }

        public int customId { get; set; }
        public virtual Customer customer { get; set; }



    }
}
