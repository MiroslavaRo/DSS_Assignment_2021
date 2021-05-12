using ProductStoreEditor.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
//using DSS_Assignment_2021.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Globalization;
using Microsoft.AspNetCore.Authorization;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using ProductStoreEditor.ViewModels;

namespace ProductStoreEditor.Controllers { 
        public class ProductsController : Controller
        {
            private ProductStoreDbContext context;
            private readonly IConfiguration configuration;
            private readonly string notFoundImageLocation;

            public ProductsController(ProductStoreDbContext context, IConfiguration configuration, IWebHostEnvironment environment)
            {
                this.context = context;
                this.configuration = configuration;
                this.notFoundImageLocation = Path.Combine(environment.WebRootPath, "wwwroot", "Images", "NotFound.png");
            }
        

            public ActionResult Index()
            {
                List<Product> products = context.Products
                     .Include(a => a.Supplier)
                     .ToList();
            foreach (var p in products)
            {
                if (p.PhotoFileName == null)
                {
                    p.PhotoFileName= notFoundImageLocation;
                }
            }

                /*           
                foreach(var p in products)
                {
                    string imagesLocation = configuration.GetValue<string>("ProductPhotos");
                    string imagePath = Path.Combine(imagesLocation, p.ProductId.ToString(), p.PhotoFileName);

                    FileStream image;
                    if (System.IO.File.Exists(imagePath))
                    {
                        image = System.IO.File.OpenRead(imagePath);
                    }
                    else
                    {
                        image = System.IO.File.OpenRead(notFoundImageLocation);

                    }

                    File(image, "image/jpeg");
                }
              */

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
                newproduct.Supplier = (Supplier)context.Suppliers.ToList().Select(a => new SelectListItem() { Text = a.Company, Value = a.SupplierId.ToString() });


                return View(newproduct);
            }


            [HttpPost]
        public IActionResult Create(Product model, IFormFile photo)
            {
                Product product = new Product();
                product.ProductName = model.ProductName;

                Supplier supplier = new Supplier();
                supplier.SupplierId = model.SupplierId;
                product.SupplierId = supplier;

                if (photo != null)
                {

                string imagesPath = configuration.GetValue<string>("ProductPhotos");


                    string directoryPath = Path.Combine(imagesPath, product.ProductId.ToString());
                    if (!Directory.Exists(directoryPath))
                    {
                        Directory.CreateDirectory(directoryPath);
                    }

                //  string fileName = string.Format("{0}.jpg", Path.GetFileNameWithoutExtension(Path.GetRandomFileName()));

                string fileName = string.Format("img"+DateTime.Now.ToString("yymmssfff"));
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
             .FirstOrDefault(a => a.ProductId == id);

                ProductEditViewModel viewModel = new ProductEditViewModel();
                viewModel.ProductToBeEdited = product;
                viewModel.Suppliers = GetSuppliers();

                return View(viewModel);
            }


            [HttpPost]
            public IActionResult Edit(ProductEditViewModel viewModel)
            {
                viewModel.Suppliers = GetSuppliers();
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
                    selectListItem.Text = s.Company;
                    suppliersSelectList.Add(selectListItem);
                }
                return suppliersSelectList;
            }
        }
    
}
