using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgilePJAPINhomC.Models
{
    public class CategoryClip
    {
        [Key]
        public int CaclipId { get; set; }

        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        [ForeignKey("ClipId")]
        [Required]       
        public int ClipId { get; set; }
        public virtual Clip Clip { get; set; }

    }
}
