using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SilvioStore.Domain.StoreContext.Entities;
using SilvioStore.Domain.StoreContext.ValueObjects;

namespace SilvioStore.Tests;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void TestMethod1()
    {
        var name = new Name("Silvio", "Cressoni");
        var document = new Document("1223345645");
        var email = new Email("cressoni.silvio@gmail.com");
        var c = new Customer(name, document, email, "1234535565");

        var mouse = new Product("Mouse", "Rato", "image.png", 59.90M, 10);
        var teclado = new Product("Teclado", "Teclado", "image.png", 159.90M, 10);
        var impressora = new Product("Impressora", "Impressora", "image.png", 359.90M, 10);
        var cadeira = new Product("Cadeira", "Cadeira", "image.png", 559.90M, 10);


        var order = new Order(c);
        // order.AddItem(new OrderItem(mouse, 5));
        // order.AddItem(new OrderItem(teclado, 5));
        // order.AddItem(new OrderItem(cadeira, 5));
        // order.AddItem(new OrderItem(impressora, 5));
        
        
        // Realizei o pedido
        order.Place();
        
        // Verificar se o pedido é valido
        var valid = order.IsValid;
        
        // Simular Pagamento
        order.Pay();
        
        // Simular envio
        order.Ship();
        
        // Simular cancelamento
        order.Cancel();
    }
}