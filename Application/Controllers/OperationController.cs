using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationController : ControllerBase
    {

        [HttpGet]
        public decimal Get(decimal a, decimal b)
        {
            return a + b;
        }

        [HttpPost]
        public decimal Add(Numbers numbers, [FromHeader] string host,
            [FromHeader(Name = "Content-Length")] string contentLength,
            [FromHeader(Name = "X-Some")] string some)
        {
            Console.WriteLine(host);
            Console.WriteLine(contentLength);
            Console.WriteLine(some);
            return numbers.A - numbers.B;
        }
        
        [HttpPut]
        public decimal Div(Numbers numbers)
        {
            return numbers.A / numbers.B;
        }
        
        [HttpDelete]
        public decimal Mul(decimal a, decimal b)
        {
            return a * b;
        }

        public class Numbers
        {
            public decimal A { get; set; }
            public decimal B { get; set; }
        }
   
    }
    
}

