using CQRS.Presentation.CQRSPattern.Commands;
using CQRS.Presentation.CQRSPattern.Handlers;
using CQRS.Presentation.CQRSPattern.Queries;
using Microsoft.AspNetCore.Mvc;
using GetProductByIdQueryHandler = CQRS.Presentation.CQRSPattern.Handlers.GetProductByIdQueryHandler;

namespace CQRS.Presentation.Controllers
{
    public class DefaultController : Controller
    {
        private readonly GetProductQueryHandler _getProductQueryHandler;
        private readonly CreateProductCommandHandler _createProductCommandHandler;
        private readonly DeleteProductCommandHandler _deleteProductCommandHandler;
        private readonly GetProductByIdQueryHandler _getProductByIdQueryHandler;
        private readonly GetProductUpdateByIdQueryHandler _getProductUpdateByIdQueryHandler;
        private readonly UpdateProductCommandHandler _updateProductCommandHandler;
        public DefaultController(GetProductQueryHandler getProductQueryHandler, CreateProductCommandHandler createProductCommandHandler, DeleteProductCommandHandler deleteProductCommandHandler, GetProductByIdQueryHandler getProductByIdQueryHandler, GetProductUpdateByIdQueryHandler getProductUpdateByIdQueryHandler, UpdateProductCommandHandler updateProductCommandHandler)
        {
            _getProductQueryHandler = getProductQueryHandler;
            _createProductCommandHandler = createProductCommandHandler;
            _deleteProductCommandHandler = deleteProductCommandHandler;
            _getProductByIdQueryHandler = getProductByIdQueryHandler;
            _getProductUpdateByIdQueryHandler = getProductUpdateByIdQueryHandler;
            _updateProductCommandHandler = updateProductCommandHandler;
        }

        public IActionResult Index()
        {
            var results = _getProductQueryHandler.Handle();

            return View(results);
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(CreateProductCommand createProductCommand)
        {
            _createProductCommandHandler.Handle(createProductCommand);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult DeleteProduct(DeleteProductCommand deleteProductCommand)
        {
            _deleteProductCommandHandler.Handle(deleteProductCommand);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult GetProductById(GetProductByIdQuery getProductByIdQuery)
        {
            var result = _getProductByIdQueryHandler.Handle(getProductByIdQuery);

            return View(result);
        }

        [HttpGet]
        public IActionResult UpdateProduct(int id)
        {
            var result = _getProductUpdateByIdQueryHandler.Handle(new GetProductUpdateByIdQuery(id));

            return View(result);
        }

        [HttpPost]
        public IActionResult UpdateProduct(UpdateProductCommand updateProductCommand)
        {
            _updateProductCommandHandler.Handle(updateProductCommand);

            return RedirectToAction("Index");
        }
    }
}