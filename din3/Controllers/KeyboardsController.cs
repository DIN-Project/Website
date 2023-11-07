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

[HttpGet]
[Route("/Keyboard/Images/{id}")]
public IActionResult GetImage(long id)
{
    var keyboard = _Din3Context.Keyboards.FirstOrDefault(m => m.KeyboardId == id);

    if (keyboard == null || string.IsNullOrWhiteSpace(keyboard.ImagePath))
    {
        return NotFound();
    }

    var directoryPath = "products/images"; 
    var imagePath = Path.Combine(Directory.GetCurrentDirectory(), directoryPath, keyboard.ImagePath);

    if (!System.IO.File.Exists(imagePath))
    {
        return NotFound();
    }

    var imageBytes = System.IO.File.ReadAllBytes(imagePath);
    return File(imageBytes, "image/jpeg"); 
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

[HttpPost]
[Route("/Keyboard/UploadImage/{id}")]
public async Task<ActionResult> UploadImage(long id, IFormFile image)
{
    var keyboard = await _Din3Context.Keyboards.FindAsync(id);

    if (keyboard == null)
    {
        return BadRequest("Keyboard not found.");
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

        keyboard.ImagePath = uniqueFileName;
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