using MediatR;

namespace etradeAPI.Applicaton.Features.Commands.Product;

public class DeleteProductCommand : IRequest<List<Domain.Entites.Product>>
{
    public string Id { get; set; }
}