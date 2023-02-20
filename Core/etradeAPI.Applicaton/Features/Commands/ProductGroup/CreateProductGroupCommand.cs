using MediatR;

namespace etradeAPI.Applicaton.Features.Commands.ProductGroup;

public class CreateProductGroupCommand : IRequest<List<Domain.Entites.ProductGroup>>
{
    public string Name { get; set; }
}