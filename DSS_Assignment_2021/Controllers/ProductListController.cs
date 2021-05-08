using DSS_Assignment_2021.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DSS_Assignment_2021.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Globalization;
using Microsoft.AspNetCore.Authorization;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace DSS_Assignment_2021.Controllers
{
    public class ProductListController : Controller
    {
        private ProductSroreDBContext context;
        private readonly IConfiguration configuration;
        private readonly string notFoundImageLocation;

        public ProductListController(ProductSroreDBContext context, IConfiguration configuration, IWebHostEnvironment environment)
        {
            this.context = context;
            this.configuration = configuration;
            this.notFoundImageLocation = Path.Combine(environment.WebRootPath, "wwwroot", "Images", "NotFound.png");
        }

        public IActionResult Get(int productId, string fileName)
        {
            string imagesLocation = configuration.GetValue<string>("ProductPhotos");
            string imagePath = Path.Combine(imagesLocation, productId.ToString(), fileName);

            FileStream image;
            if (System.IO.File.Exists(imagePath))
            {
                image = System.IO.File.OpenRead(imagePath);
            }
            else
            {
                image = System.IO.File.OpenRead(notFoundImageLocation);

            }

            return File(image, "image/jpeg");
        }

        public ActionResult Index()
        {       
            List<Product> products = context.Products
                .Include(a => a.ProductType)
                 .Include(a => a.Supplier)
                 .ToList();

            return View(products);
        }
                

        public ActionResult Details(int id)
        {
            Product product = context.Products.FirstOrDefault(a => a.ProductId == id);
            return View(product);
        }


        public IActionResult Create()
        {
             Product newproduct = new Product();
             newproduct.ProductType = (ProductType)context.ProductTypes.ToList().Select(a=> new SelectListItem() { Text = a.ProductTypeName, Value = a.ProductTypeId.ToString() });
             newproduct.Supplier = (Supplier)context.Suppliers.ToList().Select(a => new SelectListItem() { Text = a.SupplierName, Value = a.SupplierId.ToString() });


            return View(newproduct);
        }


        [HttpPost]
        public IActionResult Create(Product model, IFormFile photo)
        {
            Product product = new Product();
            product.ProductName = model.ProductName;

            ProductType type = new ProductType();
            type.ProductTypeId = model.ProductTypeId;
            product.ProductTypeId= type;

            Supplier supplier = new Supplier();
            supplier.SupplierId = model.SupplierId;
            product.SupplierId = (int)supplier;

            if (photo != null)
            {
                string imagesPath = configuration.GetValue<string>("ProductPhotos");


                string directoryPath = Path.Combine(imagesPath, product.ProductId.ToString());
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }

                string fileName = string.Format("{0}.jpg", Path.GetFileNameWithoutExtension(Path.GetRandomFileName()));
                string filePath = Path.Combine(directoryPath, fileName);

                try
                {
                    using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        photo.CopyTo(fileStream);
                    }

                    product.PhotoFileName = fileName;

                    context.Products.Add(product);
                    context.SaveChanges();

                }
                catch
                {
                    RedirectToAction("Error", "Home");
                }
            }

            return RedirectToAction("Index");
        }


        public IActionResult Edit(int id)
        {
            CultureInfo cultureInfo = CultureInfo.CurrentCulture;
            Product product = context.Products.Include(a => a.Supplier)
         .Include(a => a.ProductType).FirstOrDefault(a => a.ProductId == id);

            ProductEditViewModel viewModel = new ProductEditViewModel();
            viewModel.ProductToBeEdited = product;
            viewModel.Suppliers = GetSuppliers();
            viewModel.ProductType = GetProductType();

            return View(viewModel);
        }


        [HttpPost]
        public IActionResult Edit(ProductEditViewModel viewModel)
        {
            viewModel.Suppliers = GetSuppliers();
            viewModel.ProductType = GetProductType();
            if (!base.ModelState.IsValid)
            {
                viewModel.ErrorMessageVisible = true;
            }
            else
            {
                Product editedProduct = viewModel.ProductToBeEdited;
                Product originalProduct = context.Products.First(a => a.ProductId == editedProduct.ProductId);

                originalProduct.ProductName = editedProduct.ProductName;
                originalProduct.PhotoFileName = editedProduct.PhotoFileName;
                viewModel.SuccessMessageVisible = true;
                context.SaveChanges();
            }
            return View(viewModel);
        }


        public ActionResult Delete(int id)
        {
            return View();
        }


        [HttpPost]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        private List<SelectListItem> GetSuppliers()
        {
            List<SelectListItem> suppliersSelectList = new List<SelectListItem>();

            List<Supplier> suppliers = context.Suppliers.ToList();
            foreach (Supplier s in suppliers)
            {
                SelectListItem selectListItem = new SelectListItem();
                selectListItem.Value = s.SupplierId.ToString();
                selectListItem.Text = s.SupplierName;
                suppliersSelectList.Add(selectListItem);
            }
            return suppliersSelectList;
        }
        private List<SelectListItem> GetProductType()
        {
            List<SelectListItem> productTypesSelectList = new List<SelectListItem>();

            List<ProductType> type = context.ProductTypes.ToList();
            foreach (ProductType t in type)
            {
                SelectListItem selectListItem = new SelectListItem();
                selectListItem.Value = t.ProductTypeId.ToString();
                selectListItem.Text = t.ProductTypeName;
                productTypesSelectList.Add(selectListItem);
            }
            return productTypesSelectList;
        }
    }
}
