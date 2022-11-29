using System.ComponentModel.DataAnnotations;

namespace Shopping_App.Models
{
    public class Orders
    {
        [Key]
        public int OrderId { get; set; }

        public int UserId { get; set; }

        public int OrderTotal { get; set; }

        public DateTime OrderDate { get; set; }
        public string OrderBy { get; set; }
    }
}
