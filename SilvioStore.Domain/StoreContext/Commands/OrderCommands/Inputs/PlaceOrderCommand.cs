using FluentValidator;
using FluentValidator.Validation;
using SilvioStore.Shared.Commands;

namespace SilvioStore.Domain.StoreContext.Commands.OrderCommands.Inputs;

public class PlaceOrderCommand : Notifiable, ICommand
{

    public PlaceOrderCommand()
    {
        OrderItems = new List<OrderItemCommand>();
    }
    
    public Guid Customer { get; set; }

    // public Dictionary<Guid, decimal> OrderItems { get; set; }
    // Tenho a opção de criar um dicionario ou, criar uma lista como abaixo
    // a apção abaixo (lista) é melhor em termos de mapeamento
    public IList<OrderItemCommand> OrderItems { get; set; }
    public bool Valid()
    {
        AddNotifications(new ValidationContract()
            .Requires()
            .HasLen(Customer.ToString(), 36, "Customer", "Identificador do cliente invalido")
            .IsGreaterThan(OrderItems.Count(), 0, "Items", "Nenhum item do pedido foi encontrado")
        );

        return IsValid;
    }
}

public class OrderItemCommand
{
    public Guid Product { get; set; }

    public decimal Quantity { get; set; }
}