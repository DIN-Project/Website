using Microsoft.AspNetCore.Mvc;


namespace Din.Controllers;

[ApiController]
[Route("[controller]")]
public class  ComputerController: ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private Din3Context _Din3Context;
    private IConfiguration _config;
    public ComputerController(ILogger<UserController> logger, Din3Context din3Context, IConfiguration config)
    {
        _logger = logger;
        _Din3Context = din3Context;
        _config = config;
    }

[HttpGet]
[Route("/Computers")]
public ActionResult ReadAll()
{
var all = _Din3Context.Computers;
return Ok(all);
}

[HttpGet]
[Route("/Computer/{id}")]
public async Task<ActionResult> Read(long id)
{
var computer = await _Din3Context.Computers.FindAsync(id);
return Ok(computer);
}

[HttpPost]
[Route("/Computer")]
public async Task<ActionResult> Create(Computer computer)
{
var _case = await _Din3Context.Cases.FindAsync(computer.Case.CaseId);
var cooler = await _Din3Context.Coolers.FindAsync(computer.Cooler.CoolerId);
var graphicsCard = await _Din3Context.GraphicsCards.FindAsync(computer.GraphicsCard.GraphicsCardId);
var motherboard = await _Din3Context.Motherboards.FindAsync(computer.Motherboard.MotherboardId);
var powerSuppy = await _Din3Context.PowerSupplies.FindAsync(computer.PowerSupply.PowerSupplyId);
var processor = await _Din3Context.Processors.FindAsync(computer.Processor.ProcessorId);
var ram = await _Din3Context.Rams.FindAsync(computer.Ram.RamId);

if(_case == null || cooler == null || graphicsCard == null || motherboard == null || powerSuppy == null || processor == null || ram == null)
{
    return BadRequest();
}
var newComputer = new Computer();
newComputer.Case = _case;
newComputer.Cooler = cooler;
newComputer.GraphicsCard = graphicsCard;
newComputer.Motherboard = motherboard;
newComputer.PowerSupply = powerSuppy;
newComputer.Processor = processor;
newComputer.Ram = ram;
newComputer.Description = computer.Description;
newComputer.Name = computer.Name;

_Din3Context.Computers.Add(newComputer);
_Din3Context.SaveChanges();
return Ok(computer);
}

[HttpPut]
[Route("/Computer")]
public async Task<ActionResult> Update(Case _case)
{

{
    return BadRequest();
}

}

[HttpDelete]
[Route("/Computer/{id}")]
public async Task<ActionResult> Delete(long id)
{

{
    return BadRequest();
}

}
}