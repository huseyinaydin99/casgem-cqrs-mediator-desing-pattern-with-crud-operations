using Casgem_Mediator.MediatorPattern.Results;
using MediatR;

namespace Casgem_Mediator.MediatorPattern.Queries
{
    public class GetProductUpdateByIdQuery : IRequest<GetProductUpdateByIdQueryResult>
    {
        public int Id { get; set; }

        public GetProductUpdateByIdQuery(int id)
        {
            Id = id;
        }
    }
}