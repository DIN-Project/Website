public record CoolerDTO
{
    public long CoolerId{get;set;}
    public string Name{get;set;}
    public string Description{get;set;}
    public long Price{get;set;}
    public DateTime Created{get;set;}
    public DateTime Updated{get;set;}
public CoolerDTO(Cooler cooler)
{
    CoolerId = cooler.CoolerId;
    Name = cooler.Name;
    Price = cooler.Price;
    Description = cooler.Description;
    Created = cooler.Created;
    Updated = cooler.Updated;
}
}