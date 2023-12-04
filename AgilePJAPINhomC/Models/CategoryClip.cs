using System.ComponentModel.DataAnnotations;

namespace AgilePJAPINhomC.Models
{
    public class CategoryClip
    {
        [Key]
        public int CaclipId { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public int ClipId { get; set; }
        public virtual Clip Clip { get; set; }

    }
}
