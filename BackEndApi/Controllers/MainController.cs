using BackEndApi.Brain;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEndApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        // GET: api/<MainController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<MainController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<MainController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<MainController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MainController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        // GET api/<MainController>/5
        [HttpGet("GetValueTest")]
        public string GetValueTest()
        {
            BubbleMain.Instance.Test();
            return "value";
        }

        
        // GET api/<MainController>/5
        [HttpGet("StartCreationPdf")]
        public string StartCreationPdf()
        {
            BubbleMain.Instance.CreationPdf();
            return "value";
        }

        // GET api/<MainController>/5
        [HttpGet("StartCreationPicture")]
        public string StartCreationPicture()
        {
            BubbleMain.Instance.CreationPicture();
            return "value";
        }
    }
}
