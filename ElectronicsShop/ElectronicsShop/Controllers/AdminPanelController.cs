using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using ElectronicsShop.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace ElectronicsShop.Controllers
{
    public class AdminPanelController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public AdminPanelController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View("~/Views/AdminPanel/AdminPanel.cshtml");
        }
        public IActionResult GetGridData(int pageNum, int typeId)
        {
            var data = _unitOfWork.ProductRepository.GetProductsWithPaging(pageNum, 10,typeId);
            var culture = Request.Cookies[".AspNetCore.Culture"];
            var productsRowViewModel = data.Select(a => new ProductRowViewModel(a, culture)).ToList();
            var totalCount = _unitOfWork.ProductRepository.GetGridCount(typeId);
            var pagesCount = Math.Ceiling(totalCount/10d);
            var isLastPage = pageNum * 10 >= totalCount && (pageNum - 1) * 10 < totalCount;
            var gridViewModel = new ProductGridViewModel(productsRowViewModel, pageNum, pageNum == 1, isLastPage , pagesCount);
            return new JsonResult(gridViewModel);
        }
        public IActionResult GetProductTypes()
        {
            var culture = Request.Cookies[".AspNetCore.Culture"];
            var types = _unitOfWork.ProductTypeRepository.All.Select(a => new ProductTypeViewModel(a, culture)).ToList();
            return new JsonResult(types);
        }           

        [HttpGet]
        public IActionResult AddNewProduct()
        {
            return View("~/Views/AdminPanel/AddNewProduct.cshtml");;
        }

        [HttpPost]
        public IActionResult AddNewProduct(AddProductViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var newProduct = new Product
            {
                NameAr = model.NameAr,
                NameEn = model.NameEn,
                DescriptionAr = model.DescriptionAr,
                DescriptionEn = model.DescriptionEn,
                OriginalPrice = model.OriginalPrice,
                QuantityInStock = model.QuantityInStock,
                Discount = model.Discount is null ? 0 : model.Discount.Value,
                DiscountOfTwo = model.DiscountOfTwo is null ? 0 : model.DiscountOfTwo.Value,
                ProductType = _unitOfWork.ProductTypeRepository.FindBy(a=>a.ProductTypeId == model.TypeId).FirstOrDefault(),
            };
            _unitOfWork.ProductRepository.Add(newProduct);
            _unitOfWork.SaveChanges();
            return RedirectToAction("Index", "AdminPanel");
        }
    }
}
