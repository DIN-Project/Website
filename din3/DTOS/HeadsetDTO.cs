public record HeadsetDTO
{
    public long HeadsetId{get;set;}
    public string Name{get;set;}
    public string Description{get;set;}
    public long Price{get;set;}
    public DateTime Created{get;set;}
    public DateTime Updated{get;set;}
public HeadsetDTO(Headset headset)
{
    HeadsetId = headset.HeadsetId;
    Name = headset.Name;
    Price = headset.Price;
    Description = headset.Description;
    Created = headset.Created;
    Updated = headset.Updated;
}
}