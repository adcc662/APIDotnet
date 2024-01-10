using WebApplication2.Controllers;

namespace WebApplication2.Service;

public class PeopleService : IPeopleService
{
    public bool Validate(People people)
    {
        if (!string.IsNullOrEmpty(people.Name) || 
            people.Name.Length > 100)
        {
            return false;
        }

        return true;
    }
}