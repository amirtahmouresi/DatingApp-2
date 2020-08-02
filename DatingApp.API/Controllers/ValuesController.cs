using System.Linq;
using System.Threading.Tasks;
using DatingApp.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ValuesController : ControllerBase
  {
    private readonly DataContext _Context;
    public ValuesController(DataContext context)
    {
      _Context = context;

    }

    [HttpGet]
    public async Task<IActionResult> GetValues()
    {
        var values = await _Context.Values.ToListAsync();
        return Ok(values);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetValue(int id){
        var value = await _Context.Values.FirstOrDefaultAsync(x => x.Id == id);
        return Ok(value);
    }
  }
}