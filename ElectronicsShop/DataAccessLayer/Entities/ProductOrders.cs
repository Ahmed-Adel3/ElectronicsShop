namespace DataAccessLayer.Entities
{
    public class ProductOrder
    {
        public int ProductOrderId { get; set; }
        public virtual ApplicationUser Client {get;set;}
        public virtual Product Product { get; set; }
        public int QuantityOrdered { get; set; }
    }
}