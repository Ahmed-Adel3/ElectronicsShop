using DataAccessLayer.Entities;
using System.Collections.Generic;

namespace ElectronicsShop.Models
{
    public class HomeViewModel
    {
        public List<ProductCardViewModel> ProductCards { get; set; }
        public int CurrentPageNumber { get; set; }
        public bool IsFirstPage { get; set; }
        public bool IsLastPage { get; set; }

        public HomeViewModel(List<ProductCardViewModel>productCards, int currentPageNumber, bool isFirstPage, bool isLastPage)
        {
            ProductCards = productCards;
            CurrentPageNumber = currentPageNumber;
            IsFirstPage = isFirstPage;
            IsLastPage = isLastPage;
        }
    }   

    public class ProductRowViewModel
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string TypeName { get; set; }
        public double OriginalPrice { get; set; }
        public double FinalPrice { get; set; }
        public int QuantityInStock { get; set; }
        public int Discount { get; set; }
        public int DiscountOfTwo { get; set; }

        public ProductRowViewModel(Product product, string culture)
        {
            ProductId = product.ProductId;
            Name = (culture == "ar-EG") ? product.NameAr : product.NameEn;
            TypeName = (culture == "ar-EG") ? product.ProductType.TypeNameAr : product.ProductType.TypeNameEn;
            OriginalPrice = product.OriginalPrice;
            FinalPrice = product.OriginalPrice - (product.OriginalPrice * product.Discount) / 100;
            Discount = product.Discount;
            DiscountOfTwo = product.DiscountOfTwo;
            QuantityInStock = product.QuantityInStock;
        }
    }

    public class ProductTypesViewModel
    {
        public int ProductTypeId { get; set; }
        public string Name{ get; set; }
        public ProductTypesViewModel(ProductType type, string culture)
        {
            ProductTypeId = type.ProductTypeId;
            Name = (culture == "ar-EG") ? type.TypeNameAr : type.TypeNameEn;
        }
    }

}
