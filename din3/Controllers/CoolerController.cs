using Microsoft.AspNetCore.Mvc;


namespace Din.Controllers;

[ApiController]
[Route("[controller]")]
public class  CoolerController: ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private Din3Context _Din3Context;
    private IConfiguration _config;
    public CoolerController(ILogger<UserController> logger, Din3Context din3Context, IConfiguration config)
    {
        _logger = logger;
        _Din3Context = din3Context;
        _config = config;
    }

[HttpGet]
[Route("/Coolers")]
public ActionResult ReadAll()
{
var all = _Din3Context.Coolers;
return Ok(all);
}

[HttpGet]
[Route("/Cooler/{id}")]
public async Task<ActionResult> Read(long id)
{
var Cooler = await _Din3Context.Coolers.FindAsync(id);
return Ok(Cooler);
}

[HttpPost]
[Route("/Cooler")]
public async Task<ActionResult> Create(Cooler cooler)
{
var manufacturer = await _Din3Context.Manufacturers.FindAsync(cooler.Manufacturer.ManufacturerId);
if(manufacturer == null)
{
    return BadRequest();
}
cooler.Manufacturer = manufacturer;
var result = await _Din3Context.Coolers.AddAsync(cooler);
manufacturer.Coolers.Add (result.Entity);
_Din3Context.SaveChanges();
return Ok(cooler.GetCoolerDTO());
}

[HttpPost]
[Route("/Cooler/UploadImage/{id}")]
public async Task<ActionResult> UploadImage(long id, IFormFile image)
{
    var cooler = await _Din3Context.Coolers.FindAsync(id);

    if (cooler == null)
    {
        return BadRequest("Cooler not found.");
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

        cooler.ImagePath = uniqueFileName;
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
[Route("/Cooler")]
public async Task<ActionResult> Update(Cooler cooler)
{
var find = await _Din3Context.Coolers.FindAsync(cooler.CoolerId);
if(find == null)
{
    return BadRequest();
}
find.Name = cooler.Name;
find.Updated = DateTime.UtcNow;
find.Description = cooler.Description;
find.Price = cooler.Price;
_Din3Context.SaveChanges();
return Ok(find);
}

[HttpDelete]
[Route("/Cooler/{id}")]
public async Task<ActionResult> Delete(long id)
{
var find = await _Din3Context.Coolers.FindAsync(id);
if (find == null)
{
    return BadRequest();
}
var deletus = _Din3Context.Coolers.Remove(find);
_Din3Context.SaveChanges();
return Ok(deletus.Entity);
}
}