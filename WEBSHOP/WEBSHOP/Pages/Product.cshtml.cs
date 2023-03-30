using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using WEBSHOP.DAL.Repositories.Interfaces;
using WEBSHOP.Domain.Helpers;
using WEBSHOP.Domain.ViewModels;

namespace WEBSHOP.Pages
{
    public class ProductModel : PageModel
    {
        public List<ProductViewModel> ProductList { get; set; }
        public string str { get; set; }

        public ProductViewModel Product { get; set; }

        private readonly IProductInterface _repo;

        public ProductModel(IProductInterface repo)
        {
            _repo = repo;
        }

        public async Task OnGetAsync()
        {
            ProductList = (List<ProductViewModel>)await _repo.GetAll();
        }
        public async Task OnGetByType(int type_id)
        {
            ProductList = (List<ProductViewModel>)await _repo.GetAllByType(type_id);
        }
        public IActionResult OnGetDelete(int Id)
        {
            if (_repo.Delete(new ProductViewModel { Id = Id}))
                return RedirectToPage("Product");
            else return BadRequest();
        }
        public IActionResult OnPostCreate(ProductCUViewModel _product)
        {
            if (ModelState.IsValid)
            {
                if (_repo.Create(new ProductViewModel 
                {
                    Title = _product.Title,
                    Cost = _product.Cost,
                    Quantity = _product.Quantity,
                    PicturePath = _product.PicturePath,
                    ProductManufactorer = _product.ProductManufactorer,
                    ProductType = _product.ProductType,
                    ProductUnit = _product.ProductUnit
                }))
                    return new PartialViewResult
                    {
                        ViewName = "_ProductCreate",
                        ViewData = new ViewDataDictionary<ProductCUViewModel>(ViewData, _product)
                    };
                else
                    return BadRequest();
            }
            ProductList = (List<ProductViewModel>)_repo.GetAll().Result;
            List<TypesViewModel> types = new();
            List<ManufactorerViewModel> mnfs = new();
            List<UnitViewModel> units = new();

            _repo.GetDataForCU(ref types, ref units, ref mnfs);

            var productToCreate = new ProductCUViewModel
            {
                Title = _product.Title,
                Cost = _product.Cost,
                Quantity = _product.Quantity,
                PicturePath = _product.PicturePath,
                selectMnf = new SelectList(mnfs, "Title", "Title",_product.ProductManufactorer),
                selectType = new SelectList(types, "Title", "Title", _product.ProductType),
                selectUnit = new SelectList(units, "Title", "Title", _product.ProductUnit)
            };
            return new PartialViewResult
            {
                ViewName = "_ProductCreate",
                ViewData = new ViewDataDictionary<ProductCUViewModel>(ViewData, productToCreate)
            };
        }
        public IActionResult OnPostEdit(ProductViewModel product)
        {
            if (_repo.Edit(product))
                return RedirectToPage("Product");
            else
                return BadRequest();
        }
        public IActionResult OnGetToEdit(ProductViewModel product)
        {
            return RedirectToPage("_ProductEdit",product);
        }
        public IActionResult OnGetToDelete(int Id)
        {
            var prod = _repo.GetById(Id).Result;
            Dictionary<string, string> FieldAndValue = DictionaryFromModel.GetDictionaryFromModel(typeof(ProductViewModel), prod);
            return Partial("_DeleteConfirmation",new DeleteViewModel {ObjName = "Product", ObjInfo = FieldAndValue });
        }
        public async Task<IActionResult> OnGetShowOrderProdList(int OrderId)
        {
            List<ProductViewModel> orderProdList = (List<ProductViewModel>)await _repo.GetAllByOrderId(OrderId);
            
            return Partial("_OrderProdList", new OrdersViewModel 
            {
                Id = OrderId,
                ProductsIn = orderProdList
                
            });
        }

        public IActionResult OnGetDataToCreatePartial()
        {
            List<TypesViewModel> types = new();
            List<ManufactorerViewModel> mnfs = new();
            List<UnitViewModel> units = new();

            _repo.GetDataForCU(ref types, ref units, ref mnfs);

            var productToCreate = new ProductCUViewModel
            {
                Title = "",
                selectMnf = new SelectList(mnfs, "Title", "Title"),
                selectType = new SelectList(types, "Title", "Title"),
                selectUnit = new SelectList(units, "Title", "Title")
            };

            return Partial("_ProductCreate", productToCreate);

        }

        public async Task<IActionResult> OnGetDataToEditPartial(ProductViewModel product)
        {
            List<TypesViewModel> types = new();
            List<ManufactorerViewModel> mnfs = new();
            List<UnitViewModel> units = new();

            _repo.GetDataForCU(ref types, ref units, ref mnfs);

            var prod = await _repo.GetById(product.Id);

            var productToEdit = new ProductCUViewModel
            {
                Id = prod.Id,
                Title = prod.Title,
                Cost = prod.Cost,
                Quantity = prod.Quantity,
                ProductManufactorer = prod.ProductManufactorer,
                ProductType = prod.ProductType,
                ProductUnit = prod.ProductUnit,
                PicturePath = prod.PicturePath,
                selectMnf = new SelectList(mnfs, "Title", "Title", prod.ProductManufactorer),
                selectType = new SelectList(types, "Title", "Title", prod.ProductType),
                selectUnit = new SelectList(units, "Title", "Title", prod.ProductUnit)
            };

            return Partial("_ProductEdit", productToEdit);
        }
    }
}
