using Microsoft.AspNetCore.Mvc;


namespace Din.Controllers;

[ApiController]
[Route("[controller]")]
public class  HeadsetController: ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private Din3Context _Din3Context;
    private IConfiguration _config;
    public HeadsetController(ILogger<UserController> logger, Din3Context din3Context, IConfiguration config)
    {
        _logger = logger;
        _Din3Context = din3Context;
        _config = config;
    }

[HttpGet]
[Route("/Headsets")]
public ActionResult ReadAll()
{
var all = _Din3Context.Headsets;
return Ok(all);
}

[HttpGet]
[Route("/Headset/{id}")]
public async Task<ActionResult> Read(long id)
{
var headset = await _Din3Context.Headsets.FindAsync(id);
return Ok(headset);
}

[HttpPost]
[Route("/Headset")]
public async Task<ActionResult> Create(Headset headset)
{
var manufacturer = await _Din3Context.Manufacturers.FindAsync(headset.Manufacturer.ManufacturerId);
if(manufacturer == null){
    return BadRequest();
}
headset.Manufacturer = manufacturer;
var result = await _Din3Context.Headsets.AddAsync(headset);
manufacturer.Headsets.Add (result.Entity);
_Din3Context.SaveChanges();
return Ok(headset.GetHeadsetDTO());
}

[HttpPut]
[Route("/Headset")]
public async Task<ActionResult> Update(Headset headset)
{
var find = await _Din3Context.Headsets.FindAsync(headset.HeadsetId);
if(find == null)
{
    return BadRequest();
}
find.Name = headset.Name;
find.Updated = DateTime.UtcNow;
find.Description = headset.Description;
find.Price = headset.Price;
_Din3Context.SaveChanges();
return Ok(find);
}

[HttpDelete]
[Route("/Headset/{id}")]
public async Task<ActionResult> Delete(long id)
{
var find = await _Din3Context.Headsets.FindAsync(id);
if (find == null)
{
    return BadRequest();
}
var deletus = _Din3Context.Headsets.Remove(find);
_Din3Context.SaveChanges();
return Ok(deletus.Entity);
}
}