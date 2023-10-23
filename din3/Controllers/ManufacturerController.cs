using Microsoft.AspNetCore.Mvc;


namespace Din.Controllers;

[ApiController]
[Route("[controller]")]
public class  ManufacturerController: ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private Din3Context _Din3Context;
    private IConfiguration _config;
    public ManufacturerController(ILogger<UserController> logger, Din3Context din3Context, IConfiguration config)
    {
        _logger = logger;
        _Din3Context = din3Context;
        _config = config;
    }

[HttpGet]
[Route("/Manufacturers")]
public ActionResult ReadAll()
{
var all = _Din3Context.Manufacturers;
return Ok(all);
}

[HttpGet]
[Route("/Manufacturer/{id}")]
public async Task<ActionResult> Read(long id)
{
var manufacturer = await _Din3Context.Manufacturers.FindAsync(id);
return Ok(manufacturer);
}

[HttpPost]
[Route("/Manufacturer")]
public async Task<ActionResult> Create(Manufacturer manufacturer)
{
var result = await _Din3Context.Manufacturers.AddAsync(manufacturer);
_Din3Context.SaveChanges();
return Ok(result.Entity);
}

[HttpPut]
[Route("/Manufacturer")]
public async Task<ActionResult> Update(Manufacturer manufacturer)
{
var find = await _Din3Context.Manufacturers.FindAsync(manufacturer.ManufacturerId);
find.Name = manufacturer.Name;
_Din3Context.SaveChanges();
return Ok(manufacturer);
}

[HttpDelete]
[Route("/Manufacturer/{id}")]
public async Task<ActionResult> Delete(long id)
{
var find = await _Din3Context.Manufacturers.FindAsync(id);
if (find == null){
    return BadRequest();
}
var deletus = _Din3Context.Manufacturers.Remove(find);
_Din3Context.SaveChanges();
return Ok(deletus.Entity);
}
}