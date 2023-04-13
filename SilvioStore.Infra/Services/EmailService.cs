using SilvioStore.Domain.StoreContext.Services;

namespace SilvioStore.Infra.Services;

public class EmailService : IEmailService
{
    public void Send(string to, string @from, string subject, string body)
    {
        // TO DO
    }
}