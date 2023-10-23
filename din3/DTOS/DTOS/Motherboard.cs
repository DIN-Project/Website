public record MotherboardDTO
{
    public long MotherboardId{get;set;}
    public string Name{get;set;}
    public string Description{get;set;}
    public long Price{get;set;}
    public DateTime Created{get;set;}
    public DateTime Updated{get;set;}
public MotherboardDTO(Motherboard motherboard)
{
    MotherboardId = motherboard.MotherboardId;
    Name = motherboard.Name;
    Price = motherboard.Price;
    Description = motherboard.Description;
    Created = motherboard.Created;
    Updated = motherboard.Updated;
}
}