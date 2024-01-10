using WebApplication2.Controllers;

namespace WebApplication2.Service;

public interface IPeopleService
{
    bool Validate(People people);
    
}