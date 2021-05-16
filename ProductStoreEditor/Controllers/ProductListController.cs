using ProductStoreEditor.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Globalization;
using Microsoft.AspNetCore.Authorization;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using ProductStoreEditor.ViewModels;


namespace ProductStoreEditor.Controllers
{
    public class ProductListController : Controller
    {
        private ProductStoreDataBaseContext context;
        private readonly IConfiguration configuration;
        private IWebHostEnvironment hostEnvironment;

        public ProductListController(ProductStoreDataBaseContext context, IConfiguration configuration, IWebHostEnvironment hostEnvironment)
        {
            this.context = context;
            this.configuration = configuration;
            this.hostEnvironment = hostEnvironment;
        }


        public ActionResult Index()
        {
            List<Product> products = context.Products
                .Include(a => a.Supplier).ToList();
            foreach(var p in products)
            {
                if (p.PhotoFileName == null)
                {
                    p.PhotoFileName = "NotFound.png";
                }
            }

            return View(products);
        }


        public ActionResult Details(int id)
        {
            Product product = context.Products
                 .Include(a => a.Supplier)
                .FirstOrDefault(a => a.ProductId == id);

            if (product.PhotoFileName == null)
            {
                product.PhotoFileName = "NotFound.png";
            }
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
            supplier.SupplierId = (int)model.SupplierId;
            product.SupplierId = supplier.SupplierId;

            if (photo != null)
            {
                
                string fileName = product.ProductId+".jpg";
                string filePath = Path.Combine(hostEnvironment.WebRootPath + "/Images/ProductPhotos/",  fileName);
                product.PhotoFileName = fileName;

                using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    photo.CopyTo(fileStream);

                }

                context.Products.Add(product);
                context.SaveChanges();

            }

            return RedirectToAction("Index");
        }


        public IActionResult Edit(int id)
        {
            CultureInfo cultureInfo = CultureInfo.CurrentCulture;
            Product product = context.Products.Include(a => a.Supplier)
                .First(a => a.ProductId == id);
           
            ProductListEditViewModel viewModel = new ProductListEditViewModel();
            viewModel.ProductToBeEdited = product;
            viewModel.Suppliers = GetSuppliers();
            if (product.PhotoFileName == null)
            {
                viewModel.ProductToBeEdited.PhotoFileName = "NotFound.png";
            }

            return View(viewModel);
        }


        [HttpPost]
        public IActionResult Edit(ProductListEditViewModel viewModel)
        {
            
            viewModel.Suppliers = GetSuppliers();
            if (!base.ModelState.IsValid)
            {
                viewModel.ErrorMessageVisible = true;
            }
            else
            {
               
                Product editedProduct = viewModel.ProductToBeEdited;

                Product originalProduct = context.Products.FirstOrDefault(a => a.ProductId == editedProduct.ProductId);

                originalProduct.ProductName = editedProduct.ProductName;
                originalProduct.PhotoFileName = editedProduct.PhotoFileName;
                originalProduct.SupplierId = editedProduct.SupplierId;
                originalProduct.Supplier = editedProduct.Supplier;


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
            return View();

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


