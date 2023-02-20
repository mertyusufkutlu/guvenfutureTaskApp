using etradeAPI.Applicaton.Repositories;
using MediatR;

namespace etradeAPI.Applicaton.Features.Commands.ProductGroup;

public class CreateProductGroupHandler : IRequestHandler<CreateProductGroupCommand, List<Domain.Entites.ProductGroup>>
{
    private readonly IProductGroupWriteRepository _productGroupWriteRepository;

    public CreateProductGroupHandler(IProductGroupWriteRepository productGroupWriteRepository)
    {
        _productGroupWriteRepository = productGroupWriteRepository;
    }

    public async Task<List<Domain.Entites.ProductGroup>> Handle(CreateProductGroupCommand request,
        CancellationToken cancellationToken)
    {
        var items = await _productGroupWriteRepository.AddAsync(new()
        {
            Name = request.Name
        });
        await _productGroupWriteRepository.SaveAsync();
        return new();
    }
}