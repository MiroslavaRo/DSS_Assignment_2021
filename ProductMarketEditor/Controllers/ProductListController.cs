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
            
            List<Product> products = context.Products.Include(a=>a.ProductChanges.FirstOrDefault(b=>b.ProductId==a.ProductId))
                  .Include(c => c.Supplier).ToList();

            List<ProductChange> changeLog = context.ProductChanges.Include(a => a.Product).ToList();
           
            /*
            DisplayProductViewModel display = new DisplayProductViewModel():
            Mapping mapping = new Mapping();

            for(var i = 0; i < products.Count; i++)
            {
                mapping.product = context.Products.Include(a => a.Supplier.Company).FirstOrDefault(a=>a.ProductId==i);
                mapping.changeLog = context.Products.FirstOrDefault(a => a.ProductId == i);
                display.Display.Add(mapping);
            }
            */
            return View(display);
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
        public IActionResult Create(CreateProductViewModel model, IFormFile photo)
        {
            Product product = new Product();
            product.ProductName = model.ProductName;

            model.Suppliers = GetSuppliers();
            product.SupplierId = model.SelectedSupplierId;

         

            ProductChange changeLog = new ProductChange();
            changeLog.CreatedBy = changeLog.EditedBy = this.HttpContext.User.Identity.Name;
            changeLog.CreatedOn = changeLog.EditedOn = DateTime.Now.ToString("yyyy/MM/dd hh:mm");



            if (photo != null)
            {

                model.ErrorMessageVisible = false;
                string wwwRootPath = hostEnvironment.WebRootPath;
                string imagesPath = Path.Combine(wwwRootPath, "wwwroot", "Images","ProductPhotos");
                //wwwRootPath + "/Images/ProductPhotos/";

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

                    ProductPhoto image = new ProductPhoto();
                    image.ProductId = product.ProductId;
                    product.ImageFileName=  image.FileName = fileName;

                    context.ProductPhotos.Add(image);
                    context.ProductChanges.Add(changeLog);
                    context.Products.Add(product);
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch
                {
                    //rollback
                    return RedirectToAction("Error", "Home");
                }
             
            }
            else
            {
                model.ErrorMessageVisible = true;
                return View(model);
            }
            

            #region
            /*   if (model.ImageFile!=null)
               {

                   model.ErrorMessageVisible = false;
                   string wwwRootPath = hostEnvironment.WebRootPath;
                   string fileName = Path.GetFileNameWithoutExtension(model.ImageFile.FileName);
                   string extension = Path.GetExtension(model.ImageFile.FileName);

                   string imagesPath = wwwRootPath + "/Images/ProductPhotos/";


                   string directoryPath = Path.Combine(imagesPath, product.ProductId.ToString());
                   if (!Directory.Exists(directoryPath))
                   {
                       Directory.CreateDirectory(directoryPath);
                   }

                   fileName = fileName + extension;
                   model.ImageFileName=product.ImageFileName = fileName + extension;

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
           */
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


                ProductChange editing = context.ProductChanges.FirstOrDefault(a=>a.ProductId ==editedProduct.ProductId);
                editing.EditedBy = this.HttpContext.User.Identity.Name;
                editing.EditedOn = DateTime.Now.ToString("yyyy/MM/dd hh:mm");



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

            if (product.ImageFileName != null)
            {
                var photo = context.ProductPhotos.First(a=>a.ProductId==product.ProductId);
                context.ProductPhotos.Remove(photo);

                string wwwRootPath = hostEnvironment.WebRootPath;
                string imagesPath = Path.Combine(wwwRootPath, "wwwroot", "Images", "ProductPhotos", product.ProductId.ToString());
                string filePath = Path.Combine(imagesPath, product.ImageFileName);


                  if (System.IO.File.Exists(filePath))
                  {
                      System.IO.File.Delete(filePath);
                  }
            }
            var deleting = context.ProductChanges.First(a=>a.ProductId==product.ProductId);
            context.ProductChanges.Remove(deleting);

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
*/

