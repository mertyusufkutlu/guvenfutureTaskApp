using etradeAPI.Applicaton.Repositories;
using etradeAPI.Domain.Entites;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using etradeAPI.Applicaton.Features.Queries.CustomerBasket;
using etradeAPI.Applicaton.ViewModels.CustomerBasket;
using MediatR;

namespace etradeAPI.API.Controllers;

[Route("api/[controller]")]
[ApiController]

public class CustomerBasketController : ControllerBase
{
    readonly private ICustomerBasketReadRepository _customerBasketReadRepository;
    readonly private ICustomerBasketWriteRepository _customerBasketWriteRepository;
    readonly private IMediator _mediator;

    public CustomerBasketController(ICustomerBasketReadRepository customerBasketReadRepository,
        ICustomerBasketWriteRepository customerBasketWriteRepository, IMediator mediator)
    {
        _customerBasketReadRepository = customerBasketReadRepository;
        _customerBasketWriteRepository = customerBasketWriteRepository;
        _mediator = mediator;
    }
    [HttpGet("{userId}")]
    public async Task<IActionResult> GetById(Guid userId)
    {
        var response = await _mediator.Send(new GetCustomerBasketByIdQueryRequest { UserId = userId });
        return Ok(response);
    }
    
    [HttpPost]
    public async Task<IActionResult> Post(VM_CustomerBasket model)
    {
        await _customerBasketWriteRepository.AddAsync(new()
        {
            ProductId = model.ProductId,
            UserId = model.UserId
        });
        await _customerBasketWriteRepository.SaveAsync();
        return StatusCode((int)HttpStatusCode.Created);
    }
    
    [HttpPut]
    public async Task<IActionResult> Put()
    {
        return Ok();
    }

    
}