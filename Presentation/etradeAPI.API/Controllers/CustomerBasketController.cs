using etradeAPI.Applicaton.Repositories;
using etradeAPI.Domain.Entites;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using etradeAPI.Applicaton.ViewModels.CustomerBasket;

namespace etradeAPI.API.Controllers;

[Route("api/[controller]")]
[ApiController]

public class CustomerBasketController : ControllerBase
{
    readonly private ICustomerBasketReadRepository _customerBasketReadRepository;
    readonly private ICustomerBasketWriteRepository _customerBasketWriteRepository;

    public CustomerBasketController(ICustomerBasketReadRepository customerBasketReadRepository,
        ICustomerBasketWriteRepository customerBasketWriteRepository)
    {
        _customerBasketReadRepository = customerBasketReadRepository;
        _customerBasketWriteRepository = customerBasketWriteRepository;
        
    }
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(_customerBasketReadRepository.GetAll());
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