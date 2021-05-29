using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProductMarketEditor.Data;
using ProductMarketEditor.Models;
using ProductMarketEditor.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ProductMarketEditor.Controllers
{
    public class SupplierController : Controller
    {
        private ProductMarketDBContext context;
        private readonly IConfiguration configuration;
        private IWebHostEnvironment hostEnvironment;

        public SupplierController(ProductMarketDBContext context, IConfiguration configuration, IWebHostEnvironment hostEnvironment)
        {
            this.context = context;
            this.configuration = configuration;
            this.hostEnvironment = hostEnvironment;
        }

            public ActionResult Index()
        {
            List<Supplier> suppliers = context.Suppliers.Include(a => a.ProductType).Include(a => a.SupplierChange).ToList();
            return View(suppliers);
        }


        public ActionResult Details(int id)
        {
            Supplier supplier = context.Suppliers.Include(a => a.ProductType).Include(a => a.SupplierChange).FirstOrDefault(a=>a.SupplierId==id);
            return View(supplier);
        }

        [Authorize]
        public IActionResult Create()
        {
            CreateSupplierViewModel createSupplierViewModel = new CreateSupplierViewModel();
            createSupplierViewModel.ProductTypes = GetTypes();

            return View(createSupplierViewModel);
        }
        [HttpPost]
        public IActionResult Create(CreateSupplierViewModel model, IFormFile photo)
        {
            SupplierChange changelog = new SupplierChange();
            changelog.CreatedBy = this.HttpContext.User.Identity.Name;
            changelog.CreatedOn = DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss tt");
            changelog.EditedBy = changelog.CreatedBy;
            changelog.EditedOn = changelog.CreatedOn;
            context.SupplierChanges.Add(changelog);
            context.SaveChanges();
            model.SupplierChangeId = context.SupplierChanges.First(a => a.CreatedOn == changelog.CreatedOn).ProductChangeId;



            Supplier supplier = new Supplier();
            supplier.Company = model.Company;
            supplier.ProductTypeId = model.SelectedTypeId;
            supplier.ProductType = context.ProductTypes.FirstOrDefault(a => a.ProductTypeId == model.SelectedTypeId);
            supplier.SupplierChangeId= model.SupplierChangeId;
            context.Suppliers.Add(supplier);
            context.SaveChanges();

            if (photo != null)
            {
                model.ErrorMessageVisible = false;
                string wwwRootPath = hostEnvironment.WebRootPath;
                string imagesPath = configuration.GetValue<string>("LogosLocation");

                string directoryPath = Path.Combine(imagesPath, supplier.SupplierId.ToString());
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }

                string fileName = string.Format("{0}.jpg", Path.GetFileNameWithoutExtension(Path.GetRandomFileName()));
                context.Suppliers.FirstOrDefault(a => a == supplier).ImageFile = fileName;
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
            Supplier supplier = context.Suppliers.Include(a => a.ProductType).Include(a => a.SupplierChange).First(a => a.SupplierId == id);

            SupplierEditViewModel viewModel = new SupplierEditViewModel();
            viewModel.SupplierToBeEdited = supplier;
            viewModel.ProductTypes = GetTypes();


            return View(viewModel);
        }


        [HttpPost]
        public IActionResult Edit(SupplierEditViewModel viewModel)
        {
            viewModel.ProductTypes = GetTypes();
            if (!base.ModelState.IsValid)
            {
                viewModel.ErrorMessageVisible = true;
            }
            else
            {

                Supplier editedSupplier = viewModel.SupplierToBeEdited;

                Supplier originalSupplier = context.Suppliers.FirstOrDefault(a => a.SupplierId == editedSupplier.SupplierId);
                originalSupplier.Company = editedSupplier.Company;
                originalSupplier.ProductTypeId = editedSupplier.ProductTypeId;

                /*
                SupplierChange editing = context.SupplierChanges.FirstOrDefault(b=>b.SupplierChangeId == originalSupplier.SupplierChangeId);
                editing.EditedBy = this.HttpContext.User.Identity.Name;
                editing.EditedOn = DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss tt"); 
                */
                viewModel.SuccessMessageVisible = true;
                context.SaveChanges();
            }
            return View(viewModel);
        }
        private List<SelectListItem> GetTypes()
        {
            List<SelectListItem> suppliersSelectList = new List<SelectListItem>();

            List<ProductType> types = context.ProductTypes.ToList();
            foreach (ProductType s in types)
            {
                SelectListItem selectListItem = new SelectListItem();
                selectListItem.Value = s.ProductTypeId.ToString();
                selectListItem.Text = s.ProductTypeName;
                suppliersSelectList.Add(selectListItem);
            }
            return suppliersSelectList;
        }
    }
}
