using MediatR;

namespace Casgem_Mediator.MediatorPattern.Commands
{
    public class UpdateProductCommand : IRequest
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public int Stock { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
    }
}