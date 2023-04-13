using SilvioStore.Domain.StoreContext.Entities;
using SilvioStore.Domain.StoreContext.Queries;

namespace SilvioStore.Domain.StoreContext.Repositories;

public interface ICustomerRepository
{
    bool CheckDocument(string document);
    bool CheckEmail(string email);
    void Save(Customer customer);
    CustomerOrdersCountResult GetCustomerOrdersCount(string document);
    IEnumerable<ListCustomerQueryResult> Get();
    GetCustomerQueryResult Get(Guid id);
    IEnumerable<ListCustomerOrdersQueryResult> GetOrders(Guid id);

}