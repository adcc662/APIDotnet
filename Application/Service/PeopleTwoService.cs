using WebApplication2.Controllers;
namespace WebApplication2.Service
{

    public class PeopleTwoService : IPeopleService
    {
        public bool Validate(People people)
        {
            if (!string.IsNullOrEmpty(people.Name) ||
                people.Name.Length > 100 || people.Name.Length < 3)
            {
                return false;
            }

            return true;
        }

    }
}