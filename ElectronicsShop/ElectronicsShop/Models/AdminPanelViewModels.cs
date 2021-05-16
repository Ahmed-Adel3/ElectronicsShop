using DataAccessLayer.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ElectronicsShop.Models
{
    public class ProductGridViewModel
    {
        public List<ProductRowViewModel> ProductRows { get; set; }
        public int CurrentPageNumber { get; set; }
        public bool IsFirstPage { get; set; }
        public bool IsLastPage { get; set; }
        public double TotalPagesNumber { get; set; }

        public ProductGridViewModel(List<ProductRowViewModel> productRows, int currentPageNumber, bool isFirstPage, bool isLastPage, double totalPagesNumber)
        {
            ProductRows = productRows;
            CurrentPageNumber = currentPageNumber;
            IsFirstPage = isFirstPage;
            IsLastPage = isLastPage;
            TotalPagesNumber = totalPagesNumber;
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

    public class ProductTypeViewModel
    {
        public int ProductTypeId { get; set; }
        public string Name{ get; set; }
        public ProductTypeViewModel(ProductType type, string culture)
        {
            ProductTypeId = type.ProductTypeId;
            Name = (culture == "ar-EG") ? type.TypeNameAr : type.TypeNameEn;
        }
    }

    public class AddProductViewModel
    {
        [Required(ErrorMessage = "RequiredNameAr")]
        [Display(Name = "NameArLbl")]
        public string NameAr { get; set; }
        [Required(ErrorMessage = "RequiredNameEn")]
        [Display(Name = "NameEnLbl")]
        public string NameEn { get; set; }
        [Required(ErrorMessage = "RequiredDescriptionAr")]
        [Display(Name = "DescriptionArLbl")]
        public string DescriptionAr { get; set; }
        [Required(ErrorMessage = "RequiredDescriptionEn")]
        [Display(Name = "DescriptionEnLbl")]
        public string DescriptionEn { get; set; }
        [Required(ErrorMessage = "RequiredType")]
        [Display(Name = "TypeLbl")]
        public int TypeId { get; set; }
        [Required(ErrorMessage = "RequiredOriginalPrice")]
        [Display(Name = "OriginalPriceLbl")]
        [Range(1,1000000,ErrorMessage = "NotValidOriginalPrice")]
        public double OriginalPrice { get; set; }

        [Required(ErrorMessage = "RequiredQuantityInStock")]
        [Display(Name = "QuantityInStockLbl")]
        [Range(1, 1000000, ErrorMessage = "NotValidQuantityInStock")]
        [RegularExpression("([0-9]+)", ErrorMessage = "NotValidQuantityInStock")]
        public int QuantityInStock { get; set; }

        //[Required(ErrorMessage = "RequiredDiscount")]
        [Display(Name = "DiscountLbl")]
        [Range(0, 100, ErrorMessage = "NotValidDiscount")]
        [RegularExpression("([0-9]+)", ErrorMessage = "NotValidDiscount")]
        public int? Discount { get; set; }

        //[Required(ErrorMessage = "RequiredDiscountOfTwo")]
        [Display(Name = "DiscountOfTwoLbl")]
        [Range(0, 100, ErrorMessage = "NotValidDiscountOfTwo")]
        [RegularExpression("([0-9]+)", ErrorMessage = "NotValidDiscountOfTwo")]
        public int? DiscountOfTwo { get; set; }
    }
}
