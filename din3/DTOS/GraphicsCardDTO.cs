public record GraphicsCardDTO
{
    public long GraphicsCardId{get;set;}
    public string Name{get;set;}
    public string Description{get;set;}
    public long Price{get;set;}
    public DateTime Created{get;set;}
    public DateTime Updated{get;set;}
public GraphicsCardDTO(GraphicsCard graphicsCard)
{
    GraphicsCardId = graphicsCard.GraphicsCardId;
    Name = graphicsCard.Name;
    Price = graphicsCard.Price;
    Description = graphicsCard.Description;
    Created = graphicsCard.Created;
    Updated = graphicsCard.Updated;
}
}