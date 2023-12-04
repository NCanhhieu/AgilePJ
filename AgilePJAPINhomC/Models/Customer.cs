using System.ComponentModel.DataAnnotations;

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

        public int userid { get; set; }
        public virtual Userweb Userweb { get; set;}
    }
}
