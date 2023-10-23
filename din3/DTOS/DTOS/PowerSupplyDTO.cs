public record PowerSupplyDTO
{
    public long PowerSupplyId{get;set;}
    public string Name{get;set;}
    public string Description{get;set;}
    public long Price{get;set;}
    public DateTime Created{get;set;}
    public DateTime Updated{get;set;}
public PowerSupplyDTO(PowerSupply powerSupply)
{
    PowerSupplyId = powerSupply.PowerSupplyId;
    Name = powerSupply.Name;
    Price = powerSupply.Price;
    Description = powerSupply.Description;
    Created = powerSupply.Created;
    Updated = powerSupply.Updated;
}
}