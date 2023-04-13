using FluentValidator;
using SilvioStore.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using SilvioStore.Domain.StoreContext.Commands.CustomerCommands.Outputs;
using SilvioStore.Domain.StoreContext.Entities;
using SilvioStore.Domain.StoreContext.Repositories;
using SilvioStore.Domain.StoreContext.Services;
using SilvioStore.Domain.StoreContext.ValueObjects;
using SilvioStore.Shared.Commands;
using ICommand = System.Windows.Input.ICommand;

namespace SilvioStore.Domain.StoreContext.Handlers;

public class CustomerHandler : Notifiable, 
                               ICommandHandler<CreateCustomerCommand>,
                               ICommandHandler<AddAddressCommand>
{
    private readonly ICustomerRepository _repository;
    private readonly IEmailService _emailService;

    public CustomerHandler(ICustomerRepository repository, IEmailService emailsService)
    {
        _repository = repository;
        _emailService = emailsService;
    }
    
    
    public ICommandResult Handle(CreateCustomerCommand command)
    {
        // Verificar se o CPF ja esta na base
        if (_repository.CheckDocument(command.Document))
            AddNotification("Document", "Este CPF ja existe !!!");
        
        // verificar se o email ja existe na base
        if (_repository.CheckEmail(command.Email))
            AddNotification("Email", "Este CPF ja está em uso  !!!");
        
        // Criar VOs
        var name = new Name(command.FirstName, command.LastName);
        var document = new Document(command.Document);
        var email = new Email(command.Email);
        
        // Criar entidade
        var customer = new Customer(name, document, email, command.Phone);
        
        // Validar entidades
        AddNotifications(name.Notifications);
        AddNotifications(document.Notifications);
        AddNotifications(email.Notifications);
        AddNotifications(customer.Notifications);

        if (Invalid)
            new CommandResult(false, "por favor corrija os campos abaixo", Notifications);
        
        // Persistir  o cliente
        _repository.Save(customer);
        
        // Enviar email de boas vindas
        _emailService.Send(email.Address, "cressoni.silvio@gmail.com", "Bem-vindo !!!","Seja bem vindo ao Silvio Store!!!");
        
        // Retornar o resultado para tela

        return new CommandResult(true, "Bem vindo ao Silvio Store", new
        {
            Id = customer.Id,
            Name = name.ToString(),
            Email = email.Address
        });
    }
    
    public ICommandResult Handle(AddAddressCommand command)
    {
        throw new System.NotImplementedException();
    }
}