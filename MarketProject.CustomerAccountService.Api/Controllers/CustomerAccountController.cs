using MarketProject.CustomerAccountService.Application.Interfaces;
using MarketProject.CustomerAccountService.Domain.Entities;
using MarketProject.CustomerAccountService.Domain.RequestModels;
using MarketProject.CustomerAccountService.Domain.ValueObjects;
using Microsoft.AspNetCore.Mvc;

namespace MarketProject.CustomerAccountService.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomerAccountController : ControllerBase
{
    private readonly ILogger<CustomerAccountController> _logger;
    private readonly ICustomerAccountApplication _customerAccountApplication;

    public CustomerAccountController(ILogger<CustomerAccountController> logger, ICustomerAccountApplication customerAccountApplication)
    {
        _logger = logger;
        _customerAccountApplication = customerAccountApplication;
    }

    [HttpGet("{id}")]
    public ActionResult<CustomerAccountResponseModel> Get(int id)
    {
        _logger.LogInformation("Getting customer account...");
        var customerAccount =  _customerAccountApplication.Get(id);

        _logger.LogInformation("Customer account found.");

        return Ok(customerAccount);
    }

    [HttpGet(Name = nameof(GetAll))]
    public ActionResult<IEnumerable<CustomerAccountResponseModel>> GetAll()
    {
        _logger.LogInformation("Getting all customers accounts...");
        var customersAccounts = _customerAccountApplication.Get();

        _logger.LogInformation("{0} Customers account found!", customersAccounts.Count().ToString());

        return Ok(customersAccounts);
    }

    [HttpPost]
    public ActionResult<CustomerAccountResponseModel> Create(CreateCustomerAccountRequestModel request)
    {
        _logger.LogInformation("Creating customer account...");      

        var createdCustomerAccount = _customerAccountApplication.CreateAndReturn(request);

        _logger.LogInformation("Customer account created!");

        return Created(string.Empty, createdCustomerAccount);
    }
}
