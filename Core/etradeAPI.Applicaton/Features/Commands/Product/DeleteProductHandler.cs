using etradeAPI.Applicaton.Repositories;
using MediatR;

namespace etradeAPI.Applicaton.Features.Commands.Product;

public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, List<Domain.Entites.Product>>
{
    readonly IProductWriteRepository _productWriteRepository;

    public DeleteProductHandler(IProductWriteRepository productWriteRepository)
    {
        _productWriteRepository = productWriteRepository;
    }

    public async Task<List<Domain.Entites.Product>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
       var items = await _productWriteRepository.RemoveAsync(request.Id);
        await _productWriteRepository.SaveAsync();
        return new();
    }
}