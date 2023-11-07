using Microsoft.AspNetCore.Mvc;


namespace Din.Controllers;

[ApiController]
[Route("[controller]")]
public class  GraphicsCardController: ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private Din3Context _Din3Context;
    private IConfiguration _config;
    public GraphicsCardController(ILogger<UserController> logger, Din3Context din3Context, IConfiguration config)
    {
        _logger = logger;
        _Din3Context = din3Context;
        _config = config;
    }

[HttpGet]
[Route("/GraphicsCards")]
public ActionResult ReadAll()
{
var all = _Din3Context.GraphicsCards;
return Ok(all);
}

[HttpGet]
[Route("/GraphicsCard/{id}")]
public async Task<ActionResult> Read(long id)
{
var GraphicsCard = await _Din3Context.GraphicsCards.FindAsync(id);
return Ok(GraphicsCard);
}

[HttpGet]
[Route("/GraphicsCard/Images/{id}")]
public IActionResult GetImage(long id)
{
    var gpu = _Din3Context.GraphicsCards.FirstOrDefault(m => m.GraphicsCardId == id);

    if (gpu == null || string.IsNullOrWhiteSpace(gpu.ImagePath))
    {
        return NotFound();
    }

    var directoryPath = "products/images"; 
    var imagePath = Path.Combine(Directory.GetCurrentDirectory(), directoryPath, gpu.ImagePath);

    if (!System.IO.File.Exists(imagePath))
    {
        return NotFound();
    }

    var imageBytes = System.IO.File.ReadAllBytes(imagePath);
    return File(imageBytes, "image/jpeg"); 
}


[HttpPost]
[Route("/GraphicsCard")]
public async Task<ActionResult> Create(GraphicsCard graphicsCard)
{
var manufacturer = await _Din3Context.Manufacturers.FindAsync(graphicsCard.Manufacturer.ManufacturerId);
if(manufacturer == null){
    return BadRequest();
}
graphicsCard.Manufacturer = manufacturer;
var result = await _Din3Context.GraphicsCards.AddAsync(graphicsCard);
manufacturer.GraphicsCards.Add (result.Entity);
_Din3Context.SaveChanges();
return Ok(graphicsCard.GetGraphicsCardDTO());
}
[HttpPost]
[Route("/GraphicsCard/UploadImage/{id}")]
public async Task<ActionResult> UploadImage(long id, IFormFile image)
{
    var gpu = await _Din3Context.GraphicsCards.FindAsync(id);

    if (gpu == null)
    {
        return BadRequest("Graphics Card not found.");
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

        gpu.ImagePath = uniqueFileName;
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
[Route("/GraphicsCard")]
public async Task<ActionResult> Update(GraphicsCard graphicsCard)
{
var find = await _Din3Context.GraphicsCards.FindAsync(graphicsCard.GraphicsCardId);
if(find == null)
{
    return BadRequest();
}
find.Name = graphicsCard.Name;
find.Updated = DateTime.UtcNow;
find.Description = graphicsCard.Description;
find.Price = graphicsCard.Price;
_Din3Context.SaveChanges();
return Ok(find);
}

[HttpDelete]
[Route("/GraphicsCard/{id}")]
public async Task<ActionResult> Delete(long id)
{
var find = await _Din3Context.GraphicsCards.FindAsync(id);
if (find == null)
{
    return BadRequest();
}
var deletus = _Din3Context.GraphicsCards.Remove(find);
_Din3Context.SaveChanges();
return Ok(deletus.Entity);
}
}