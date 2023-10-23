using Microsoft.AspNetCore.Mvc;


namespace Din.Controllers;

[ApiController]
[Route("[controller]")]
public class  KeyboardController: ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private Din3Context _Din3Context;
    private IConfiguration _config;
    public KeyboardController(ILogger<UserController> logger, Din3Context din3Context, IConfiguration config)
    {
        _logger = logger;
        _Din3Context = din3Context;
        _config = config;
    }

[HttpGet]
[Route("/Keyboards")]
public ActionResult ReadAll()
{
var all = _Din3Context.Keyboards;
return Ok(all);
}

[HttpGet]
[Route("/Keyboard/{id}")]
public async Task<ActionResult> Read(long id)
{
var Keyboard = await _Din3Context.Keyboards.FindAsync(id);
return Ok(Keyboard);
}

[HttpPost]
[Route("/Keyboard")]
public async Task<ActionResult> Create(Keyboard keyboard)
{
var manufacturer = await _Din3Context.Manufacturers.FindAsync(keyboard.Manufacturer.ManufacturerId);
if(manufacturer == null){
    return BadRequest();
}
keyboard.Manufacturer = manufacturer;
var result = await _Din3Context.Keyboards.AddAsync(keyboard);
manufacturer.Keyboards.Add (result.Entity);
_Din3Context.SaveChanges();
return Ok(keyboard.GetKeyboardDTO());
}

[HttpPut]
[Route("/Keyboard")]
public async Task<ActionResult> Update(Keyboard keyboard)
{
var find = await _Din3Context.Keyboards.FindAsync(keyboard.KeyboardId);
if(find == null)
{
    return BadRequest();
}
find.Name = keyboard.Name;
find.Updated = DateTime.UtcNow;
find.Description = keyboard.Description;
find.Price = keyboard.Price;
_Din3Context.SaveChanges();
return Ok(find);
}

[HttpDelete]
[Route("/Keyboard/{id}")]
public async Task<ActionResult> Delete(long id)
{
var find = await _Din3Context.Keyboards.FindAsync(id);
if (find == null)
{
    return BadRequest();
}
var deletus = _Din3Context.Keyboards.Remove(find);
_Din3Context.SaveChanges();
return Ok(deletus.Entity);
}
}