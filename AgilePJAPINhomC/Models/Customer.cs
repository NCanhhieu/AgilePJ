using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgilePJAPINhomC.Models
{
    public class Customer
    {
        [Key]
        public int customid { get; set; }

        public string customname { get; set; }

        public string customtel { get; set; }

        public string custaddress { get; set; }

        public DateTime custbirthday { get; set; }

        [ForeignKey("userid")]
        [Required]
        //public int userid { get; set; }
        public virtual Userweb Userweb { get; set; }

    }
}
