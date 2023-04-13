using FluentValidator;
using SilvioStore.Domain.StoreContext.ValueObjects;
using SilvioStore.Shared.Entities;

namespace SilvioStore.Domain.StoreContext.Entities;

public class Customer : Entity
{
    private readonly IList<Address> _addresses;
    public Customer(Name name, Document document, Email email, string phone)
    {
        Name = name;
        Document = document;
        Email = email;
        Phone = phone;
        _addresses = new List<Address>();
    }
    
    public Name Name { get; private set; }
    public Document Document { get; private set; }
    public Email Email { get; private set; }
    public string Phone { get; private set; }

    public IReadOnlyCollection<Address> Addresses => _addresses.ToArray();
    //{
    //    get { return _addresses.ToArray(); }
    //}

    public void AddAdress(Address address)
    {
        // validar
        // adicinar
        _addresses.Add(address);
    }
    
    
    public string BillingAdress { get; private set; }


    public override string ToString()
    {
        return Name.ToString();
    }
}