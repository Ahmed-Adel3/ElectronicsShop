using DataAccessLayer.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ElectronicsShop.Models
{
    public class HomeViewModel
    {
        public List<ProductCardViewModel> ProductCards { get; set; }
        public int CurrentPageNumber { get; set; }
        public int TotalPagesNumber { get; set; }
        public bool IsFirstPage { get; set; }
        public bool IsLastPage { get; set; }

        public HomeViewModel(List<ProductCardViewModel> productCards, int currentPageNumber, bool isFirstPage, bool isLastPage)
        {
            ProductCards = productCards;
            CurrentPageNumber = currentPageNumber;
            IsFirstPage = isFirstPage;
            IsLastPage = isLastPage;

        }
    }

    public class ProductCardViewModel
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string TypeName { get; set; }
        public string Description { get; set; }
        public int QuantityInStock { get; set; }
        public double Price { get; set; }
        public double FinalPrice { get; set; }
        public int Discount { get; set; }
        public int DiscountOfTwo { get; set; }

        public ProductCardViewModel(Product product, string culture)
        {
            ProductId = product.ProductId;
            Name = (culture == "ar-EG") ? product.NameAr : product.NameEn;
            Description = (culture == "ar-EG") ? product.DescriptionAr : product.DescriptionEn;
            TypeName = (culture == "ar-EG") ? product.ProductType.TypeNameAr : product.ProductType.TypeNameEn;
            Discount = product.Discount;
            DiscountOfTwo = product.DiscountOfTwo;
            QuantityInStock = product.QuantityInStock;
            Price = product.OriginalPrice;
            FinalPrice = product.OriginalPrice - (product.OriginalPrice * product.Discount) / 100;
        }
    }

    public class AddOrderViewModel
    {
        public int ProductId { get; set; }

        [Required(ErrorMessage = "RequiredQuantityNeeded")]
        [Display(Name = "QuantityNeededLbl")]
        [Range(1, 1000000, ErrorMessage = "NotValidQuantityNeeded")]
        [RegularExpression("([0-9]+)", ErrorMessage = "NotValidQuantityNeeded")]
        public int Quantity { get; set; }
    }
}
