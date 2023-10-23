public record RamDTO
{
    public long RamId{get;set;}
    public string Name{get;set;}
    public string Description{get;set;}
    public long Price{get;set;}
    public DateTime Created{get;set;}
    public DateTime Updated{get;set;}
public RamDTO(Ram ram)
{
    RamId = ram.RamId;
    Name = ram.Name;
    Price = ram.Price;
    Description = ram.Description;
    Created = ram.Created;
    Updated = ram.Updated;
}
}