using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string DescriptionAr { get; set; }
        public string DescriptionEn { get; set; }
        public int QuantityInStock { get; set; }
        public int Discount { get; set; }
        public int DiscountOfTwo { get; set; }
        public virtual ProductType ProductType { get; set; }
        public virtual ICollection<ProductOrder> ProductOrders { get; set; }
    }
}
