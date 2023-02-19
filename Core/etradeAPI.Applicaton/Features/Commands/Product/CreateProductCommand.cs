
using etradeAPI.Domain.Entites;
using MediatR;

namespace etradeAPI.Applicaton.Features.Commands.Product;

public class CreateProductCommand : IRequest<List<Domain.Entites.Product>>
{
    public string Name { get; set; }
    public int Stock { get; set; }
    public float Price { get; set; }
}