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

[HttpGet]
[Route("/Headset/Images/{id}")]
public IActionResult GetImage(long id)
{
    var headset = _Din3Context.Headsets.FirstOrDefault(m => m.HeadsetId == id);

    if (headset == null || string.IsNullOrWhiteSpace(headset.ImagePath))
    {
        return NotFound();
    }

    var directoryPath = "products/images"; 
    var imagePath = Path.Combine(Directory.GetCurrentDirectory(), directoryPath, headset.ImagePath);

    if (!System.IO.File.Exists(imagePath))
    {
        return NotFound();
    }

    var imageBytes = System.IO.File.ReadAllBytes(imagePath);
    return File(imageBytes, "image/jpeg"); 
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

[HttpPost]
[Route("/Headset/UploadImage/{id}")]
public async Task<ActionResult> UploadImage(long id, IFormFile image)
{
    var headset = await _Din3Context.Headsets.FindAsync(id);

    if (headset == null)
    {
        return BadRequest("Headset not found.");
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

        headset.ImagePath = uniqueFileName;
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