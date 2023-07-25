using Casgem_Mediator.MediatorPattern.Commands;
using Casgem_Mediator.MediatorPattern.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Casgem_Mediator.Controllers
{
    public class DefaultController : Controller
    {
        private readonly IMediator _meditor;
        public DefaultController(IMediator meditor)
        {
            _meditor = meditor;
        }
        public async Task<IActionResult> Index()
        {
            var values = await _meditor.Send(new GetProductQuery());
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
            await _meditor.Send(command);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _meditor.Send(new RemoveProductCommand(id));
            return RedirectToAction("Index");
        }
    }
}