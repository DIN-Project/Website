using Microsoft.AspNetCore.Mvc;


namespace Din.Controllers;

[ApiController]
[Route("[controller]")]
public class  ProcessorController: ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private Din3Context _Din3Context;
    private IConfiguration _config;
    public ProcessorController(ILogger<UserController> logger, Din3Context din3Context, IConfiguration config)
    {
        _logger = logger;
        _Din3Context = din3Context;
        _config = config;
    }

[HttpGet]
[Route("/Processors")]
public ActionResult ReadAll()
{
var all = _Din3Context.Processors;
return Ok(all);
}

[HttpGet]
[Route("/Processor/{id}")]
public async Task<ActionResult> Read(long id)
{
var Processor = await _Din3Context.Processors.FindAsync(id);
return Ok(Processor);
}

[HttpPost]
[Route("/Processor")]
public async Task<ActionResult> Create(Processor processor)
{
var manufacturer = await _Din3Context.Manufacturers.FindAsync(processor.Manufacturer.ManufacturerId);
if(manufacturer == null){
    return BadRequest();
}
processor.Manufacturer = manufacturer;
var result = await _Din3Context.Processors.AddAsync(processor);
manufacturer.Processors.Add (result.Entity);
_Din3Context.SaveChanges();
return Ok(processor.GetProcessorDTO());
}

[HttpPost]
[Route("/Processor/UploadImage/{id}")]
public async Task<ActionResult> UploadImage(long id, IFormFile image)
{
    var cpu = await _Din3Context.Processors.FindAsync(id);

    if (cpu == null)
    {
        return BadRequest("Processor not found.");
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

        cpu.ImagePath = uniqueFileName;
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
[Route("/Processor")]
public async Task<ActionResult> Update(Processor processor)
{
var find = await _Din3Context.Processors.FindAsync(processor.ProcessorId);
if(find == null)
{
    return BadRequest();
}
find.Name = processor.Name;
find.Updated = DateTime.UtcNow;
find.Description = processor.Description;
find.Price = processor.Price;
_Din3Context.SaveChanges();
return Ok(find);
}

[HttpDelete]
[Route("/Processor/{id}")]
public async Task<ActionResult> Delete(long id)
{
var find = await _Din3Context.Processors.FindAsync(id);
if (find == null)
{
    return BadRequest();
}
var deletus = _Din3Context.Processors.Remove(find);
_Din3Context.SaveChanges();
return Ok(deletus.Entity);
}
}