using System.ComponentModel.DataAnnotations;

namespace AgilePJAPINhomC.Models
{
    public class Userweb
    {
        [Key]
        public int userid { get; set; }

        public string username { get; set; }

        public string userpass { get; set; }

        public string usermail { get; set; }

        public string userimg { get; set; }

        public string role { get; set; }

        public int status { get; set; }
    }
}
