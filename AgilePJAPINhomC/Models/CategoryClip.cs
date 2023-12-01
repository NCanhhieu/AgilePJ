using System.ComponentModel.DataAnnotations;

namespace AgilePJAPINhomC.Models
{
    public class CategoryClip
    {
        [Key]
        public int CaclipId { get; set; }

        public virtual Category CategoryId { get; set; }

        public virtual Clip ClipId { get; set; }

    }
}
