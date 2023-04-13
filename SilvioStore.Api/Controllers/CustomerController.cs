using Microsoft.AspNetCore.Mvc;
using SilvioStore.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using SilvioStore.Domain.StoreContext.Commands.CustomerCommands.Outputs;
using SilvioStore.Domain.StoreContext.Entities;
using SilvioStore.Domain.StoreContext.Handlers;
using SilvioStore.Domain.StoreContext.Queries;
using SilvioStore.Domain.StoreContext.Repositories;
using SilvioStore.Domain.StoreContext.ValueObjects;
using SilvioStore.Shared.Commands;

namespace SilvioStore.Api.Controllers;

public class CustomerController : Controller
{
    private readonly ICustomerRepository _repository;

    private readonly CustomerHandler _handler;
    
    public CustomerController(ICustomerRepository repository, CustomerHandler customerHandler)
    {
        _repository = repository;
        _handler = customerHandler;
    }
    
    [HttpGet]
    [Route("customers")]
    [ResponseCache(Duration = 60)]
    public IEnumerable<ListCustomerQueryResult> Get()
    {
        return _repository.Get();
    }
    
    [HttpGet]
    [Route("v1/customers/{id}")]
    public GetCustomerQueryResult GetById(Guid id)
    {
        return _repository.Get(id);
    }
    
    [HttpGet]
    [Route("v1/customers/{id}/orders")]
    public List<Order> GetOrders(Guid id)
    {
        var name = new Name("Silvio", "Cressoni");
        var document = new Document("123456789");
        var email = new Email("cressoni.silvio@gmail.com");
        var customer = new Customer(name, document, email, "910355879");
        var order = new Order(customer);

        var mouse = new Product("Mouse Gamer", "Mouse Gamer", "mouse.jpg", 100M, 10);
        var keyboard = new Product("Teclado Gamer", "Teclado Gamer", "Teclado.jpg", 100M, 10);
        var chair = new Product("Cadeira Gamer", "Cadeira Gamer", "cadeira.jpg", 100M, 10);
        
        order.AddItem(mouse, 5);
        order.AddItem(keyboard, 5);

        var orders = new List<Order>();
        orders.Add(order);

        return orders;
    }
    
    [HttpPost]
    [Route("v1/customers")]
    public ICommandResult Post([FromBody]CreateCustomerCommand command)
    {
        var result = (CreateCustomerCommandResult)_handler.Handle(command);
    
        return result;
    }
    
}