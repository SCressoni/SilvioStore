using Microsoft.VisualStudio.TestTools.UnitTesting;
using SilvioStore.Domain.StoreContext.Entities;
using SilvioStore.Domain.StoreContext.Entities.Enums;
using SilvioStore.Domain.StoreContext.ValueObjects;

namespace SilvioStore.Tests.Entities;

[TestClass]
public class OrderTests
{
    private Product _mouse;

    private Product _keyboard;
    
    private Product _chair;
    
    private Product _monitor;
    
    private Customer _customer;

    private Order _order;
    
    public OrderTests()
    {
        var name = new Name("Silvio", "Cressoni");
        var document = new Document("3334553556");
        var email = new Email("cressoni.silvio@gmail.com");
        _customer = new Customer(name, document, email, "351910355324");
        _order = new Order(_customer);

        _mouse = new Product("Mouse gamer", "Mouse gamer", "mouse.jpg", 100M, 10);
        _keyboard = new Product("Teclado gamer", "Teclado gamer", "teclado.jpg", 100M, 10);
        _chair = new Product("Cadeira gamer", "Cadeira gamer", "cadeira.jpg", 100M, 10);
        _monitor = new Product("Monitor gamer", "Monitor gamer", "monitor.jpg", 100M, 10);
    }

    /*public Order CreateOrder(Customer customer)
    {
        var name = new Name("Silvio", "Cressoni");
        var document = new Document("3334553556");
        var email = new Email("cressoni.silvio@gmail.com");
        _customer = new Customer(name, document, email, "351910355324");
        _order = new Order(_customer);

        _mouse = new Product("Mouse gamer", "Mouse gamer", "mouse.jpg", 100M, 10);
        _keyboard = new Product("Teclado gamer", "Teclado gamer", "teclado.jpg", 100M, 10);
        _chair = new Product("Cadeira gamer", "Cadeira gamer", "cadeira.jpg", 100M, 10);
        _monitor = new Product("Monitor gamer", "Monitor gamer", "monitor.jpg", 100M, 10);
    }*/

    // consigo criar um novo pedido
    [TestMethod]
    public void ShouldReturnWhenValid()
    {
        Assert.AreEqual(true, _order.IsValid);
    }

    // Ao criar um novo pedido, o status deve ser created
    [TestMethod]
    public void StatusShouldBeCreatedWhenOrderCreated()
    {
        Assert.AreEqual(EOrderStatus.Created, _order.Status);
    }
    
    // Ao adicionar um novo item, a quantidade deve mudar
    [TestMethod]
    public void ShouldReturnTwoWhenAddedTwoValidItems()
    {
       _order.AddItem(_monitor, 5);
       _order.AddItem(_mouse, 5);
       Assert.AreEqual(2, _order.Items.Count);
    }
    
    // Ao adicionar um novo item, deve subtrair a quantidade do produto
    [TestMethod]
    public void ShouldReturnFiveWhenAddedPurchasedFiveItem()
    {
        _order.AddItem(_mouse, 5);
        Assert.AreEqual(_mouse.QuantityOnHand, 5);
    }
    
    // Ao confirmar o pedido, deve gerar um numero
    [TestMethod]
    public void ShouldReturnNumberWhenOrderPlaced()
    {
        _order.Place();
        Assert.AreNotEqual("", _order.Number);
    }
    
    // Ao pagar um pedido, o status deve ser PAGO
    [TestMethod]
    public void ShouldReturnPaidWhenOrderPaid()
    {
        _order.Pay();
        Assert.AreEqual(EOrderStatus.Paid, _order.Status);
    }
    
    // Dados mais 10 produtos, devem haver duas entregas
    [TestMethod]
    public void ShouldTwoWhenPurchasedTenProducts()
    {
        _order.AddItem(_mouse, 1);
        _order.AddItem(_mouse, 1);
        _order.AddItem(_mouse, 1);
        _order.AddItem(_mouse, 1);
        _order.AddItem(_mouse, 1);
        _order.AddItem(_mouse, 1);
        _order.AddItem(_mouse, 1);
        _order.AddItem(_mouse, 1);
        _order.AddItem(_mouse, 1);
        _order.AddItem(_mouse, 1);
        _order.Ship();
        
        Assert.AreEqual(2, _order.Deliveries.Count);
    }
    
    // Ao cancelar o pedido, o status deve ser cancelado
    [TestMethod]
    public void StatusShouldBeCanceledWhenOrderCanceled()
    {
        _order.Cancel();
        Assert.AreEqual(EOrderStatus.Canceled, _order.Status);
    }
    
    
    // Ao cancelar o pedido, deve cancelar as entregas
    [TestMethod]
    public void ShouldCancelShippingsWhenOrderCanceled()
    {
        _order.AddItem(_mouse, 1);
        _order.AddItem(_mouse, 1);
        _order.AddItem(_mouse, 1);
        _order.AddItem(_mouse, 1);
        _order.AddItem(_mouse, 1);
        _order.AddItem(_mouse, 1);
        _order.AddItem(_mouse, 1);
        _order.AddItem(_mouse, 1);
        _order.AddItem(_mouse, 1);
        _order.AddItem(_mouse, 1);
        _order.Ship();
        
        _order.Cancel();

        foreach (var x in _order.Deliveries)
        {
            Assert.AreEqual(EDeliveryStatus.Canceled, x.Status);
        }
    }

    public void CreateCustomer()
    {
        // Verifica se o CPF ja existe
        
        // Verifica se o E-mail ja existe

        // Criar os V.Os

        // Criar a entidade
        
        // Validar entidades e VOs

        // Inserir cliente no banco

        // Envia convite para o slack

        // Envia E-mail de boas vindas
    }
}