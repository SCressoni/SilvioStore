using SilvioStore.Domain.StoreContext.Services;

namespace SilvioStore.Tests.Fakes_Mocks;

public class FakeEmailService : IEmailService
{
    public void Send(string to, string from, string subject, string body)
    {
    }
}