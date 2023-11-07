using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Din.Controllers;

[ApiController]
[Route("[controller]")]
public class  MotherboardController: ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private Din3Context _Din3Context;
    private IConfiguration _config;
    public MotherboardController(ILogger<UserController> logger, Din3Context din3Context, IConfiguration config)
    {
        _logger = logger;
        _Din3Context = din3Context;
        _config = config;
    }

[HttpGet]
[Route("/Motherboards")]
public ActionResult ReadAll()
{
var all = _Din3Context.Motherboards;
return Ok(all);
}

[HttpGet]
[Route("/Motherboard/{id}")]
public async Task<ActionResult> Read(long id)
{
var Motherboard = await _Din3Context.Motherboards.FindAsync(id);
return Ok(Motherboard);
}

[HttpGet]
[Route("/Motherboard/Images/{id}")]
public IActionResult GetImage(long id)
{
    var motherboard = _Din3Context.Motherboards.FirstOrDefault(m => m.MotherboardId == id);

    if (motherboard == null || string.IsNullOrWhiteSpace(motherboard.ImagePath))
    {
        return NotFound();
    }

    var directoryPath = "products/images"; 
    var imagePath = Path.Combine(Directory.GetCurrentDirectory(), directoryPath, motherboard.ImagePath);

    if (!System.IO.File.Exists(imagePath))
    {
        return NotFound();
    }

    var imageBytes = System.IO.File.ReadAllBytes(imagePath);
    return File(imageBytes, "image/jpeg"); 
}

[HttpPost]
[Route("/Motherboard/UploadImage/{id}")]
public async Task<ActionResult> UploadImage(long id, IFormFile image)
{
    var motherboard = await _Din3Context.Motherboards.FindAsync(id);

    if (motherboard == null)
    {
        return BadRequest("Motherboard not found.");
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

        motherboard.ImagePath = uniqueFileName;
        _Din3Context.SaveChanges();

        Console.WriteLine("Image uploaded to: " + imagePath);

        return Ok("Image uploaded successfully.");
    }
    else
    {
        return BadRequest("Image upload failed.");
    }
}

[HttpPost]
[Route("/Motherboard")]
public async Task<ActionResult> Create(Motherboard motherboard)
{
var manufacturer = await _Din3Context.Manufacturers.FindAsync(motherboard.Manufacturer.ManufacturerId);
if(manufacturer == null){
    return BadRequest();
}
motherboard.Manufacturer = manufacturer;
var result = await _Din3Context.Motherboards.AddAsync(motherboard);
manufacturer.Motherboards.Add (result.Entity);
_Din3Context.SaveChanges();
return Ok(motherboard.GetMotherboardDTO());
}


[HttpPut]
[Route("/Motherboard")]
public async Task<ActionResult> Update(Motherboard motherboard)
{
var find = await _Din3Context.Motherboards.FindAsync(motherboard.MotherboardId);
if(find == null)
{
    return BadRequest();
}
find.Name = motherboard.Name;
find.Updated = DateTime.UtcNow;
find.Description = motherboard.Description;
find.Price = motherboard.Price;
_Din3Context.SaveChanges();
return Ok(find);
}

[HttpDelete]
[Route("/Motherboard/{id}")]
public async Task<ActionResult> Delete(long id)
{
var find = await _Din3Context.Motherboards.FindAsync(id);
if (find == null)
{
    return BadRequest();
}
var deletus = _Din3Context.Motherboards.Remove(find);
_Din3Context.SaveChanges();
return Ok(deletus.Entity);
}
}