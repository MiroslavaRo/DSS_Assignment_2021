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
            List<Product> products = context.Products
                .Include(a => a.Supplier).ToList();
           
            return View(products);
        }


        public ActionResult Details(int id)
        {
            Product product = context.Products
                 .Include(a => a.Supplier)
                .FirstOrDefault(a => a.ProductId == id);
           
            return View(product);


        }


        public IActionResult Create()
        {
            CreateProductViewModel createProductViewModel = new CreateProductViewModel();
            createProductViewModel.Suppliers = GetSuppliers();

            return View(createProductViewModel);
        }


        [HttpPost]
        public IActionResult Create(CreateProductViewModel model)
        {      

            Product product = new Product();
            product.ProductName = model.ProductName;


            Supplier supplier = new Supplier();
            supplier.SupplierId = model.SelectedSupplierId;
            product.SupplierId = supplier.SupplierId;
            #region 
            /*
            if (photo != null)
            {/*
                string fileName = product.ProductName+".jpg";
                string filePath = Path.Combine(hostEnvironment.WebRootPath, "wwwroot", "Images", "ProductPhotos", fileName);
                product.PhotoFileName = fileName;
                using (FileStream fileStream = System.IO.File.Create(filePath))
                {
                    photo.CopyTo(fileStream);
                }
                // context.Products.Add(product);
                //  context.SaveChanges();
                string imagesPath = configuration.GetValue<string>("ProductPhotosLocation");


                string directoryPath = Path.Combine(imagesPath, product.ProductId.ToString());
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }

                string fileName = string.Format("{0}.jpg", Path.GetFileNameWithoutExtension(Path.GetRandomFileName()));
                string filePath = Path.Combine(directoryPath, fileName);
                /*
                try
                {
                    using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        photo.CopyTo(fileStream);
                    }
                    product.PhotoFileName = fileName;
                }
                catch
                {
                    //rollback
                    RedirectToAction("Error", "Home");
                }
                using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    photo.CopyTo(fileStream);
                }
                product.PhotoFileName = fileName;
            }
        */
            #endregion

            #region

            if (ModelState.IsValid)
            {
                string wwwRootPath = hostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(model.ImageFile.FileName);
                string extension = Path.GetExtension(model.ImageFile.FileName);
                
                string imagesPath = wwwRootPath + "/Images/ProductPhotos/";
               /* string directoryPath = Path.Combine(imagesPath, product.ProductId.ToString());
                
                string imagesPath = wwwRootPath + "/Images/ProductPhotos/"+ product.ProductId.ToString();
                if (!Directory.Exists(imagesPath))
                {
                    Directory.CreateDirectory(imagesPath);
                }
                */
              //  string imagesPath = "D:/VUM STUDY/1 year 2 semester/DDS/Assignment/DSS_Assignment_2021/ProductStoreEditor/wwwroot/Images/ProductPhotos/";

                fileName = product.ProductId.ToString() + extension;
                product.ImageFileName = product.ProductId.ToString() + extension;

                string filePath = Path.Combine(imagesPath, fileName);
                using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.ImageFile.CopyTo(fileStream);
                }
                context.Products.Add(product);
                context.SaveChanges();
            }
        
            #endregion

           // context.Products.Add(product);
            //context.SaveChanges();
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
                originalProduct.Supplier = editedProduct.Supplier;
                               

                viewModel.SuccessMessageVisible = true;
                context.SaveChanges();
            }
            return View(viewModel);
        }


        public ActionResult Delete(int id)
        {
            Product product = context.Products
                .Include(a => a.Supplier)
               .FirstOrDefault(a => a.ProductId == id);

            return View(product);


        }


        [HttpPost]
        public ActionResult Delete(Product product)
        {
            #region
            
            if (product.ImageFileName != null)
            {
                string wwwRootPath = hostEnvironment.WebRootPath;
                string imagesPath = wwwRootPath + "/Images/ProductPhotos/";
                string filePath = Path.Combine(imagesPath, product.ImageFileName);


                  if (System.IO.File.Exists(filePath))
                  {
                      System.IO.File.Delete(filePath);
                  }
            }
#endregion
            context.Products.Remove(product);
            context.SaveChanges();

            return RedirectToAction(nameof(Index));

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


