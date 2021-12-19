using DAL;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using ProductCrud.Services;

namespace ProductCrud.Controllers
{
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _context;
        private readonly IBlobStorageService _blobStorageService;
        private readonly IConfiguration _configuration;
        public ProductController(IUnitOfWork context, IBlobStorageService blobStorageService, IConfiguration configuration)
        {
            _context = context;
            _blobStorageService = blobStorageService;
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var productModel = _context.ProductRepo.GetAll();
            return View(productModel);
        }

        [HttpGet]
        public IActionResult GetById(int id)
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductModel productModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            string fileName = Path.GetFileName(productModel.file.FileName);

            BlobStorageService blobService = new BlobStorageService(_configuration);
            productModel.ImageName = fileName;
            productModel.ImagePath = blobService.UploadFileToBlobAsync(productModel.file.FileName, productModel.file.OpenReadStream(), productModel.file.ContentType).Result;

            _context.ProductRepo.Add(productModel);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int Id)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var product = _context.ProductRepo.GetById(Id);
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Update(ProductModel productModel)
        {
            if (ModelState.IsValid)
            {
                var product = _context.ProductRepo.GetById(productModel.Id);
                BlobStorageService objBlob = new BlobStorageService(_configuration);
                await objBlob.DeleteBlobData(product.ImagePath);

                productModel.ImagePath = objBlob.UploadFileToBlobAsync(productModel.file.FileName, productModel.file.OpenReadStream(), productModel.file.ContentType).Result;
                _context.ProductRepo.DetachEntity(product);
                var model = new ProductModel()
                {
                    Id = productModel.Id,
                    ProductName = productModel.ProductName,
                    Price = productModel.Price,
                    ImageName = productModel.ImageName,
                    ImagePath = productModel.ImagePath,
                    Category = productModel.Category,
                    Quantity = productModel.Quantity,
                    Description = productModel.Description,
                    CreatedDate = productModel.CreatedDate,
                    UpdatedDate = DateTime.Now,
                };
                _context.ProductRepo.Modify(model);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int Id)
        {
            var product = _context.ProductRepo.GetById(Id);
            BlobStorageService objBlob = new BlobStorageService(_configuration);
            await objBlob.DeleteBlobData(product.ImagePath);
            _context.ProductRepo.Delete(product);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
