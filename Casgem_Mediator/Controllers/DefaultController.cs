using Casgem_Mediator.MediatorPattern.Commands;
using Casgem_Mediator.MediatorPattern.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Casgem_Mediator.Controllers
{
    public class DefaultController : Controller
    {
        private readonly IMediator _mediator;
        public DefaultController(IMediator meditor)
        {
            _mediator = meditor;
        }
        public async Task<IActionResult> Index()
        {
            var values = await _mediator.Send(new GetProductQuery());
            return View(values);
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(CreateProductCommand command)
        {
            await _mediator.Send(command);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _mediator.Send(new RemoveProductCommand(id));
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateProduct(int id)
        {
            var value = await _mediator.Send(new GetProductUpdateByIdQuery(id));
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductCommand command)
        {
            var value = await _mediator.Send(command);
            return RedirectToAction("Index");
        }
    }
}