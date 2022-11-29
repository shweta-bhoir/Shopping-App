using System.ComponentModel.DataAnnotations;

namespace Shopping_App.Models
{
    public class OrderDetails
    {
        [Key]
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public string ItemName { get; set; }
        public int Qty { get; set; }
        public int ItemAmount { get; set; }
        public int DiscountAmount { get; set; }
        public int FinalAmount { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
