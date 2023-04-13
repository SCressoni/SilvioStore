using Microsoft.VisualStudio.TestTools.UnitTesting;
using SilvioStore.Domain.StoreContext.Commands.CustomerCommands.Inputs;

namespace SilvioStore.Tests.Commands;

[TestClass]
public class CreateCustomerCommandTests
{
    [TestMethod]
    public void ShoudvalidateWhenCommandIsValid()
    {
        var command = new CreateCustomerCommand();
        command.FirstName = "Silvio";
        command.LastName = "Cressoni";
        command.Document = "33647488292";
        command.Email = "cressoni.silvio@gmail.com";
        command.Phone = "910355059";
        
        Assert.AreEqual(true, command.Valid());
    }
}