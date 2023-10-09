public record MouseDTO
{
    public long MouseId{get;set;}
    public string Name{get;set;}
    public string Description{get;set;}
    public long Price{get;set;}
    public DateTime Created{get;set;}
    public DateTime Updated{get;set;}
public MouseDTO(Mouse mouse)
{
    MouseId = mouse.MouseId;
    Name = mouse.Name;
    Price = mouse.Price;
    Description = mouse.Description;
    Created = mouse.Created;
    Updated = mouse.Updated;
}
}