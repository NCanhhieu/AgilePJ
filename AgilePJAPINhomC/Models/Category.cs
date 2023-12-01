using System.ComponentModel.DataAnnotations;

namespace AgilePJAPINhomC.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        public string? CategoryName { get; set; }

        public int CateStatus { get; set; }

    }
}
