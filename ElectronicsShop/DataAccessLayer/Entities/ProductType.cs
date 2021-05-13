using System.Collections.Generic;

namespace DataAccessLayer.Entities
{
    public class ProductType
    {
        public int ProductTypeId { get; set; }
        public string TypeNameAr { get; set; }
        public string TypeNameEn { get; set; }
        public virtual ICollection<Product> Products { get;set; }
    }
}