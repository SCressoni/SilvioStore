using System;
using System.Collections.Generic;
using SilvioStore.Domain.StoreContext.Entities;
using SilvioStore.Domain.StoreContext.Queries;
using SilvioStore.Domain.StoreContext.Repositories;

namespace SilvioStore.Tests.Fakes_Mocks;

public class FakeCustomerRepository : ICustomerRepository
{
    public bool CheckDocument(string document)
    {
        return false;
    }

    public bool CheckEmail(string email)
    {
        return false;
    }

    public void Save(Customer customer)
    {
        
    }

    public CustomerOrdersCountResult GetCustomerOrdersCount(string document)
    {
        throw new System.NotImplementedException();
    }

    public IEnumerable<ListCustomerQueryResult> Get()
    {
        throw new NotImplementedException();
    }

    public GetCustomerQueryResult Get(Guid id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<ListCustomerOrdersQueryResult> GetOrders(Guid id)
    {
        throw new NotImplementedException();
    }
}