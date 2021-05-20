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
using ProductMarketEditor.ViewModels.ChageLog;

namespace ProductStoreEditor.Controllers
{
    public class ProductListController : Controller
    {
        private ProductMarketDBContext context;
        private readonly IConfiguration configuration;
        private IWebHostEnvironment hostEnvironment;
        private List<ProductChanges> ChangeLog;

        public ProductListController(ProductMarketDBContext context, IConfiguration configuration, IWebHostEnvironment hostEnvironment, List<ProductChanges> ChangeLog)
        {
            this.context = context;
            this.configuration = configuration;
            this.hostEnvironment = hostEnvironment;
            this.ChangeLog = ChangeLog;

        }
        public void DefaultChangeLog()
        {
            List<Product> products = context.Products.ToList();
            foreach (var product in products)
            {
                ProductChanges data = new ProductChanges();
                User admin = context.Users.FirstOrDefault(a => a.Role.RoleName == "Admin");
                data.CreatedBy = admin.UserName;
                data.CreatedOn = DateTime.Today;
                data.EditedBy = admin.UserName;
                data.EditedOn = DateTime.Today;
                data.ProductId = product.ProductId;
                ChangeLog.Add(data);
            }
        }

        public ActionResult Index()
        {
            List<Product> products = context.Products
                  .Include(a => a.Supplier).ToList();

            DefaultChangeLog();
            List<ProductChanges> changeLogs = ChangeLog;

            DisplayProductViewModel display = new DisplayProductViewModel();
            for(var i = 0; i < products.Count; i++)
            {
               // display.Display.Add(products[i], changeLogs[i]);
            }
            

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

            /*
            Supplier supplier = new Supplier();
            supplier.SupplierId = model.SelectedSupplierId;*/

            model.Suppliers = GetSuppliers();
            product.SupplierId = model.SelectedSupplierId;


            /*
            ProductChanges creating = new ProductChanges();
            creating.CreatedBy = creating.EditedBy = this.HttpContext.User.Identity.Name;
            creating.CreatedOn = creating.EditedOn = DateTime.Now;
            ChangeLog.Add(creating);
            */

            #region

            if (ModelState.IsValid)
            {
                model.ErrorMessageVisible = false;
                string wwwRootPath = hostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(model.ImageFile.FileName);
                string extension = Path.GetExtension(model.ImageFile.FileName);
                
                string imagesPath = wwwRootPath + "/Images/ProductPhotos/";
                
                fileName = product.ProductId.ToString() + extension;
                product.ImageFileName = product.ProductId.ToString() + extension;

                string filePath = Path.Combine(imagesPath, fileName);
                using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.ImageFile.CopyTo(fileStream);
                }

                context.Products.Add(product);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                model.ErrorMessageVisible = true;
                return View(model);
            }
        
            #endregion
            
        }




       // [Authorize(Roles = "Admin")]
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

                /*
                var edit = ChangeLog.Find(a => a.ProductId == originalProduct.ProductId);
                edit.EditedBy = this.HttpContext.User.Identity.Name;
                edit.EditedOn = DateTime.Now;
                */

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
            ProductChanges deleting = ChangeLog.Find(a => a.ProductId == product.ProductId);
            ChangeLog.Remove(deleting);


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


