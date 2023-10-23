using Microsoft.AspNetCore.Mvc;


namespace Din.Controllers;

[ApiController]
[Route("[controller]")]
public class  CaseController: ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private Din3Context _Din3Context;
    private IConfiguration _config;
    public CaseController(ILogger<UserController> logger, Din3Context din3Context, IConfiguration config)
    {
        _logger = logger;
        _Din3Context = din3Context;
        _config = config;
    }

[HttpGet]
[Route("/Cases")]
public ActionResult ReadAll()
{
var all = _Din3Context.Cases;
return Ok(all);
}

[HttpGet]
[Route("/Case/{id}")]
public async Task<ActionResult> Read(long id)
{
var Case = await _Din3Context.Cases.FindAsync(id);
return Ok(Case);
}

[HttpPost]
[Route("/Case")]
public async Task<ActionResult> Create(Case _case)
{
var manufacturer = await _Din3Context.Manufacturers.FindAsync(_case.Manufacturer.ManufacturerId);
if(manufacturer == null){
    return BadRequest();
}
_case.Manufacturer = manufacturer;
var result = await _Din3Context.Cases.AddAsync(_case);
manufacturer.Cases.Add (result.Entity);
_Din3Context.SaveChanges();
return Ok(_case.GetCaseDTO());
}

[HttpPut]
[Route("/Case")]
public async Task<ActionResult> Update(Case _case)
{
var find = await _Din3Context.Cases.FindAsync(_case.CaseId);
if(find == null)
{
    return BadRequest();
}
find.Name = _case.Name;
find.Updated = DateTime.UtcNow;
find.Description = _case.Description;
find.Price = _case.Price;
_Din3Context.SaveChanges();
return Ok(find);
}

[HttpDelete]
[Route("/Case/{id}")]
public async Task<ActionResult> Delete(long id)
{
var find = await _Din3Context.Cases.FindAsync(id);
if (find == null)
{
    return BadRequest();
}
var deletus = _Din3Context.Cases.Remove(find);
_Din3Context.SaveChanges();
return Ok(deletus.Entity);
}
}