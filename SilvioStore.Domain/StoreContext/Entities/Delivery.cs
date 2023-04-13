using SilvioStore.Domain.StoreContext.Entities.Enums;
using SilvioStore.Shared.Entities;

namespace SilvioStore.Domain.StoreContext.Entities;

public class Delivery : Entity
{
    public Delivery(DateTime estimatedDeliveryDate)
    {
        CreateDate = DateTime.Now;
        EstimatedDate = estimatedDeliveryDate;
        Status = EDeliveryStatus.Waiting;
    }
    public DateTime CreateDate { get; private set; }
    public DateTime EstimatedDate { get; private set; }
    public EDeliveryStatus Status { get; private set; }

    public void Ship()
    {
        Status = EDeliveryStatus.Shipped;
    }

    public void Cancel()
    {
        Status = EDeliveryStatus.Canceled;
    }
}