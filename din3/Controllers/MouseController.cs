using Microsoft.AspNetCore.Mvc;


namespace Din.Controllers;

[ApiController]
[Route("[controller]")]
public class  MouseController: ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private Din3Context _Din3Context;
    private IConfiguration _config;
    public MouseController(ILogger<UserController> logger, Din3Context din3Context, IConfiguration config)
    {
        _logger = logger;
        _Din3Context = din3Context;
        _config = config;
    }

[HttpGet]
[Route("/Mouses")]
public ActionResult ReadAll()
{
var all = _Din3Context.Mouses;
return Ok(all);
}

[HttpGet]
[Route("/Mouse/{id}")]
public async Task<ActionResult> Read(long id)
{
var Mouse = await _Din3Context.Mouses.FindAsync(id);
return Ok(Mouse);
}

[HttpPost]
[Route("/Mouse")]
public async Task<ActionResult> Create(Mouse mouse)
{
var manufacturer = await _Din3Context.Manufacturers.FindAsync(mouse.Manufacturer.ManufacturerId);
if(manufacturer == null){
    return BadRequest();
}
mouse.Manufacturer = manufacturer;
var result = await _Din3Context.Mouses.AddAsync(mouse);
manufacturer.Mouses.Add (result.Entity);
_Din3Context.SaveChanges();
return Ok(mouse.GetMouseDTO());
}

[HttpPost]
[Route("/Mouse/UploadImage/{id}")]
public async Task<ActionResult> UploadImage(long id, IFormFile image)
{
    var mouse = await _Din3Context.Mouses.FindAsync(id);

    if (mouse == null)
    {
        return BadRequest("Mouse not found.");
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

        mouse.ImagePath = uniqueFileName;
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
[Route("/Mouse")]
public async Task<ActionResult> Update(Mouse mouse)
{
var find = await _Din3Context.Mouses.FindAsync(mouse.MouseId);
if(find == null)
{
    return BadRequest();
}
find.Name = mouse.Name;
find.Updated = DateTime.UtcNow;
find.Description = mouse.Description;
find.Price = mouse.Price;
_Din3Context.SaveChanges();
return Ok(find);
}

[HttpDelete]
[Route("/Mouse/{id}")]
public async Task<ActionResult> Delete(long id)
{
var find = await _Din3Context.Mouses.FindAsync(id);
if (find == null)
{
    return BadRequest();
}
var deletus = _Din3Context.Mouses.Remove(find);
_Din3Context.SaveChanges();
return Ok(deletus.Entity);
}
}