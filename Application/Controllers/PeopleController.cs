using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;
using WebApplication2.Service;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private IPeopleService _peopleService;

        public PeopleController()
        {
            _peopleService = new PeopleService();
        }
        
        [HttpGet("all")]
        public List<People> GetPeople() => Repository.People;

        [HttpGet("{id}")]
        public ActionResult<People> GetId(int id)
        {
            var people = Repository.People.FirstOrDefault(p => p.Id == id);
            if (people == null)
            {
                return NotFound();
            }

            return Ok(people);
        }

        [HttpGet("search/{search}")]
        public List<People> Get(string search) =>
            Repository.People.Where(p => p.Name.ToUpper().Contains(search.ToUpper())).ToList();

        [HttpPost]
        public IActionResult Add(People people)
        {
            if (_peopleService.Validate(people))
            {
                return BadRequest();
            }
            Repository.People.Add(people);
            return NoContent();
        }
            

    }

    public class Repository
    {
        public static List<People> People = new List<People>
        {
            new People()
            {
                Id = 1,
                Name = "David",
                BirthDate = new DateTime(1997, 12, 3)

            },
            new People()
            {
                Id = 2,
                Name = "Monica",
                BirthDate = new DateTime(1992, 2, 3)

            },

            new People()
            {
                Id = 3,
                Name = "Karen",
                BirthDate = new DateTime(1995, 6, 2)

            },

            new People()
            {
                Id = 4,
                Name = "Mario",
                BirthDate = new DateTime(1990, 2, 9)

            },
        };

    }

    public class People
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
    }
    
}



