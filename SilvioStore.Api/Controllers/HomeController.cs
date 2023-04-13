using Microsoft.AspNetCore.Mvc;

namespace SilvioStore.Api.Controllers;

public class HomeController : Controller
{
    [Route("")]
    public object GetMessage()
    {
        return new {version = "Version 0.0.1"};
    }
    
}