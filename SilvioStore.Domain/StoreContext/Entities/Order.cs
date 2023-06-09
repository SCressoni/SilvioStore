using FluentValidator;
using SilvioStore.Domain.StoreContext.Entities.Enums;
using SilvioStore.Shared.Entities;

namespace SilvioStore.Domain.StoreContext.Entities;

public class Order : Entity
{
    private readonly IList<OrderItem> _items;
    private readonly IList<Delivery> _deliveries;
    
    public Order(Customer customer)
    {
        Customer = customer;
        CreatedDate = DateTime.Now;
        Status = EOrderStatus.Created;
        _items = new List<OrderItem>();
        _deliveries = new List<Delivery>();
    }
    
    public Customer Customer { get; private set; }
    public string Number { get; private set; }
    public DateTime CreatedDate { get; private set; }
    public EOrderStatus Status { get; private set; }
    
    public IReadOnlyCollection<OrderItem> Items => _items.ToArray();
    
    public IReadOnlyCollection<Delivery> Deliveries => _deliveries.ToArray();

    
    public void AddItem(Product product, decimal quantity)
    {
        if (quantity > product.QuantityOnHand)
            AddNotification("OrderItem", $"Produto {product.Title} não tem {quantity} itens em estoque");
        

        var item = new OrderItem(product, quantity);
        _items.Add(item);
    }
    
    public void AddDelivery(Delivery delivery)
    {
        _deliveries.Add(delivery);
    }

    // To place An Order
    public void Place()
    {
        //Gera numero do pedido
        Number = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 8).ToUpper();

        // Validar
        if (_items.Count == 0)
            AddNotification("Order", "Este pedido não possui itens");
    }
    
    // pagar um pedido
    public void Pay()
    {
        Status = EOrderStatus.Paid; 
        
    }
    
    // Enviar um pedido
    public void Ship()
    {
        // A cada 5 produtos é uma entrega
        var deliveries = new List<Delivery>();
    //    deliveries.Add(new Delivery(DateTime.Now.AddDays(5)));
        var count = 1;
        
        // Quebra entregas
        foreach (var item in _items)
        {
            if (count == 5)
            {
                count = 1;
                deliveries.Add(new Delivery(DateTime.Now.AddDays(5)));
            }
            
            count++;
        }
        
        // Envia todas as etregas 
        deliveries.ForEach(x => x.Ship());
        
        // Adiciona todas as entregas
        deliveries.ForEach(x => _deliveries.Add(x));
        
    }
    
    // cancelar um pedido
    public void Cancel()
    {
        // Se o pedido ja foi entregue não pode cancelar
        Status = EOrderStatus.Canceled;
        _deliveries.ToList().ForEach(x => x.Cancel());
    }
}