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
using ProductMarketEditor.Data;
using ProductMarketEditor.Models;
using ProductMarketEditor.ViewModels;

namespace ProductStoreEditor.Controllers
{
    public class ProductListController : Controller
    {
        private ProductMarketDBContext context;
        private readonly IConfiguration configuration;
        private IWebHostEnvironment hostEnvironment;

        public ProductListController(ProductMarketDBContext context, IConfiguration configuration, IWebHostEnvironment hostEnvironment)
        {
            this.context = context;
            this.configuration = configuration;
            this.hostEnvironment = hostEnvironment;

        }
    
        public ActionResult Index()
        {
            
            List<Product> products = context.Products.Include(a=>a.ProductChange)
                  .Include(c => c.Supplier).ToList();
            return View(products);
        }

    


        public ActionResult Details(int id)
        {
            Product product = context.Products
                 .Include(a => a.Supplier).Include(a=>a.ProductChange)
                .FirstOrDefault(a => a.ProductId == id);
           
            return View(product);


        }

        [Authorize]
        public IActionResult Create()
        {
            CreateProductViewModel createProductViewModel = new CreateProductViewModel();
            createProductViewModel.Suppliers = GetSuppliers();
          
            return View(createProductViewModel);
        }


        [HttpPost]
        public IActionResult Create(CreateProductViewModel model, IFormFile photo)
        {
            ProductChange changeLog = new ProductChange();
            changeLog.CreatedBy = this.HttpContext.User.Identity.Name;
            changeLog.CreatedOn = DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss tt");
            changeLog.EditedBy = changeLog.CreatedBy;
            changeLog.EditedOn = changeLog.CreatedOn;
            context.ProductChanges.Add(changeLog);
            context.SaveChanges();
            model.ProductChangeId = context.ProductChanges.First(a => a.CreatedOn == changeLog.CreatedOn).ProductChangeId;



            Product product = new Product();
            product.ProductName = model.ProductName;
            product.ProductChangeId = model.ProductChangeId;
            model.Suppliers = GetSuppliers();
            product.SupplierId = model.SelectedSupplierId;
            context.Products.Add(product);
            context.SaveChanges();


            if (photo != null)
            {
                model.ErrorMessageVisible = false;
                string wwwRootPath = hostEnvironment.WebRootPath;
                string imagesPath = configuration.GetValue<string>("ProductPhotosLocation");

                string directoryPath = Path.Combine(imagesPath, product.ProductId.ToString());
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }

                string fileName = string.Format("{0}.jpg", Path.GetFileNameWithoutExtension(Path.GetRandomFileName()));
                context.Products.FirstOrDefault(a => a == product).ImageFileName = fileName;
                string filePath = Path.Combine(directoryPath, fileName);
                using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    photo.CopyTo(fileStream);
                }
               

                context.SaveChanges();
                return RedirectToAction("Index");
               
            }
            else
            {
                context.SaveChanges();
                return RedirectToAction("Index");
            }
           
        }


        [Authorize]
        public IActionResult Edit(int id)
        {
            CultureInfo cultureInfo = CultureInfo.CurrentCulture;
            Product product = context.Products.Include(a => a.Supplier).Include(a=>a.ProductChange)
                .First(a => a.ProductId == id);
           
            ProductListEditViewModel viewModel = new ProductListEditViewModel();
            viewModel.ProductToBeEdited = product;
            viewModel.Suppliers = GetSuppliers();

            
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
                originalProduct.ImageFileName = editedProduct.ImageFileName;
                originalProduct.SupplierId = editedProduct.SupplierId;

                ProductChange editing = context.ProductChanges.FirstOrDefault(a=>a.ProductChangeId == originalProduct.ProductChangeId);
                editing.EditedBy = this.HttpContext.User.Identity.Name;
                editing.EditedOn = DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss tt");



                viewModel.SuccessMessageVisible = true;
                context.SaveChanges();
            }
            return View(viewModel);
        }
        [Authorize]

        public ActionResult Delete(int id)
        {
            Product product = context.Products
                .Include(a => a.Supplier).Include(a=>a.ProductChange)
               .FirstOrDefault(a => a.ProductId == id);

            return View(product);


        }


        [HttpPost]
        public ActionResult Delete(Product product)
        {
            string imagesPath = configuration.GetValue<string>("ProductPhotosLocation");
          
            string directoryPath = Path.Combine(imagesPath, product.ProductId.ToString());
                if (Directory.Exists(directoryPath))
                {
                var files = Directory.GetFiles(directoryPath);
                foreach(var file in files)
                {
                    System.IO.File.Delete(file);
                }
                    Directory.Delete(directoryPath);
                }
           
            context.Products.Remove(product);
            context.SaveChanges();

            return RedirectToAction("Index");

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


