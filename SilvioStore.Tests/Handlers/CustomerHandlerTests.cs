using Microsoft.VisualStudio.TestTools.UnitTesting;
using SilvioStore.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using SilvioStore.Domain.StoreContext.Handlers;
using SilvioStore.Tests.Fakes_Mocks;

namespace SilvioStore.Tests.Handlers;

[TestClass]
public class CustomerHandlerTests
{

    [TestMethod]
    public void ShouldRegisterCustomerWhenCommandIsValid()
    {
        var command = new CreateCustomerCommand();
        command.FirstName = "Silvio";
        command.LastName = "Cressoni";
        command.Document = "28659170377";
        command.Email = "cressoni.silvio@gmail.com";
        command.Phone = "11999999997";
        
        var handler = new CustomerHandler(new FakeCustomerRepository(), new FakeEmailService());
        var result = handler.Handle(command);
        
        Assert.AreNotEqual(null, result);
        Assert.AreEqual(true, handler.IsValid);
    }


}