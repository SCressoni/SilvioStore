using FluentValidator;
using SilvioStore.Shared.Entities;

namespace SilvioStore.Domain.StoreContext.Entities;

public class OrderItem : Entity
{
    public OrderItem(Product product, decimal quantity)
    {
        Product = product;
        Quantity = quantity;
        Price = Product.Price;

        if (product.QuantityOnHand < quantity)
            //Notifications.Add("Quantidade", "Produto fora de estoque");
            AddNotification("Quantity", "Produto fora de estoque");
        
        product.DecreaseQuantity(quantity);
        
    }
    
    public Product Product { get; private set; }
    public decimal Quantity { get; private set; }
    public decimal Price { get; private set; }
    
    //public IDictionary<string, string> Notifications { get; set; }

}