using System.Net;
using etradeAPI.Applicaton.Features.Commands.ProductGroup;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace etradeAPI.API.Controllers;


[Route("api/[controller]")]
[ApiController]

public class ProductGroupController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductGroupController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost()]
    public async Task<IActionResult> Post(CreateProductGroupCommand createProductGroupCommand)
    {
        var response =  await _mediator.Send(createProductGroupCommand);
        return StatusCode((int)HttpStatusCode.Created);
    }
    
}