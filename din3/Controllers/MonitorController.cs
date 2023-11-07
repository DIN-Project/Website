using Microsoft.AspNetCore.Mvc;


namespace Din.Controllers;

[ApiController]
[Route("[controller]")]
public class  MonitorController: ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private Din3Context _Din3Context;
    private IConfiguration _config;
    public MonitorController(ILogger<UserController> logger, Din3Context din3Context, IConfiguration config)
    {
        _logger = logger;
        _Din3Context = din3Context;
        _config = config;
    }

[HttpGet]
[Route("/Monitors")]
public ActionResult ReadAll()
{
var all = _Din3Context.Monitors;
return Ok(all);
}

[HttpGet]
[Route("/Monitor/{id}")]
public async Task<ActionResult> Read(long id)
{
var Monitor = await _Din3Context.Monitors.FindAsync(id);
return Ok(Monitor);
}

[HttpGet]
[Route("/Monitor/Images/{id}")]
public IActionResult GetImage(long id)
{
    var monitor = _Din3Context.Monitors.FirstOrDefault(m => m.MonitorId == id);

    if (monitor == null || string.IsNullOrWhiteSpace(monitor.ImagePath))
    {
        return NotFound();
    }

    var directoryPath = "products/images"; 
    var imagePath = Path.Combine(Directory.GetCurrentDirectory(), directoryPath, monitor.ImagePath);

    if (!System.IO.File.Exists(imagePath))
    {
        return NotFound();
    }

    var imageBytes = System.IO.File.ReadAllBytes(imagePath);
    return File(imageBytes, "image/jpeg"); 
}


[HttpPost]
[Route("/Monitor")]
public async Task<ActionResult> Create(Monitor monitor)
{
var manufacturer = await _Din3Context.Manufacturers.FindAsync(monitor.Manufacturer.ManufacturerId);
if(manufacturer == null){
    return BadRequest();
}
monitor.Manufacturer = manufacturer;
var result = await _Din3Context.Monitors.AddAsync(monitor);
manufacturer.Monitors.Add (result.Entity);
_Din3Context.SaveChanges();
return Ok(monitor.GetMonitorDTO());
}

[HttpPost]
[Route("/Monitor/UploadImage/{id}")]
public async Task<ActionResult> UploadImage(long id, IFormFile image)
{
    var monitor = await _Din3Context.Monitors.FindAsync(id);

    if (monitor == null)
    {
        return BadRequest("Monitor not found.");
    }

    if (image != null && image.Length > 0)
    {
        var directoryPath = "products/images";
        var uniqueFileName = Guid.NewGuid().ToString() + "_" + image.FileName;
        var imagePath = Path.Combine(directoryPath, uniqueFileName);

        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }

        using (var stream = new FileStream(imagePath, FileMode.Create))
        {
            await image.CopyToAsync(stream);
        }

        monitor.ImagePath = uniqueFileName;
        _Din3Context.SaveChanges();

        Console.WriteLine("Image uploaded to: " + imagePath);

        return Ok("Image uploaded successfully.");
    }
    else
    {
        return BadRequest("Image upload failed.");
    }
}

[HttpPut]
[Route("/Monitor")]
public async Task<ActionResult> Update(Monitor monitor)
{
var find = await _Din3Context.Monitors.FindAsync(monitor.MonitorId);
if(find == null)
{
    return BadRequest();
}
find.Name = monitor.Name;
find.Updated = DateTime.UtcNow;
find.Description = monitor.Description;
find.Price = monitor.Price;
_Din3Context.SaveChanges();
return Ok(find);
}

[HttpDelete]
[Route("/Monitor/{id}")]
public async Task<ActionResult> Delete(long id)
{
var find = await _Din3Context.Monitors.FindAsync(id);
if (find == null)
{
    return BadRequest();
}
var deletus = _Din3Context.Monitors.Remove(find);
_Din3Context.SaveChanges();
return Ok(deletus.Entity);
}
}