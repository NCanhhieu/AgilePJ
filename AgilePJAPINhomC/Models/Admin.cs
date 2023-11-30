using System.ComponentModel.DataAnnotations;

namespace AgilePJAPINhomC.Models
{
    public class Admin
    {
        [Key]
        public int adminid { get; set; }

        public string? adminname { get; set; }

        public string? admintel { get; set; }

        public virtual Userweb userid { get; set; }
    }
}
