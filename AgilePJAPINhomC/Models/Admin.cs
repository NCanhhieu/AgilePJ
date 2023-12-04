using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgilePJAPINhomC.Models
{
    public class Admin
    {
        [Key]
        public int adminid { get; set; }

        public string? adminname { get; set; }

        public string? admintel { get; set; }

        [ForeignKey("userid")]
        [Required]
        //public int userid { get; set; }
        public virtual Userweb Userweb { get; set; }
    }
}
