using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FibonacciRestApi.Controllers
{
    [ApiController]
    [Route("controlhub/api/[controller]")]
    public class fibonacciController : ControllerBase
    {
        [HttpGet("[action]")]
        public IActionResult calc(int index)
        {
            try
            {
                List<int> serie = getFibonacciSerie(index);
                int value = serie[index];

                return Ok(new {serie,index,value});
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        private List<int> getFibonacciSerie(int index)
        {

            int n = index<= 8 ? 8 : 8 + index;

            int a = 0; 
            int b = 1;

            List<int> serie = new List<int>();
            for (int i = 0; i < n; i++)
            {
                serie.Add(a);
                int temp = a;
                a = b;
                b = temp + b;
            }

            return serie;
        }

    }
}
