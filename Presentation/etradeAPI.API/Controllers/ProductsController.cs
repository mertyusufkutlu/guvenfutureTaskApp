using etradeAPI.Applicaton.Repositories;
using etradeAPI.Domain.Entites;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using etradeAPI.Applicaton.Features.Commands.Product;
using etradeAPI.Applicaton.Features.Queries.GetAllProduct;
using MediatR;

namespace etradeAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        readonly private IProductWriteRepository _productWriteRepository;
        readonly private IProductReadRepository _productReadRepository;
        
        readonly IMediator _mediator;



        public ProductsController(IProductWriteRepository productWriteRepository,
            IProductReadRepository productReadRepository, IMediator mediator)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
            _mediator = mediator;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
         var response =  await _mediator.Send(new GetAllProductQueryRequest());
         return Ok(response);
         
        }
        [HttpPost]
        public async Task<IActionResult> Post(CreateProductCommand createProductCommand)
        {
            var response =  await _mediator.Send(createProductCommand);
            return StatusCode((int)HttpStatusCode.Created);
        }
        [HttpPut]
        public async Task<IActionResult> Put()
        {
            return Ok();
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var response =  await _mediator.Send(new DeleteProductCommand{ Id = id});
            return Ok();
        }
        
        


    }
}
