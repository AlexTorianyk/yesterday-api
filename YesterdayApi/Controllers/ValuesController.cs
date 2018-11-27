using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace YesterdayApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ValuesController : ControllerBase
  {
    // GET api/values
    [HttpGet]
    public ActionResult<IEnumerable<string>> Get()
    {
      return new[] { "value1", "value2" };
    }

    // GET api/values/5
    [HttpGet("{id}")]
    public ActionResult<string> Get(int id)
    {
      return Ok(id);
    }

    // POST api/values
    [HttpPost]
    public void Post()
    {
    }

    // PUT api/values/5
    [HttpPut("{id}")]
    public void Put()
    {
    }

    // DELETE api/values/5
    [HttpDelete("{id}")]
    public void Delete()
    {
    }
  }
}