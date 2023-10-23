public record KeyboardDTO
{
    public long KeyboardId{get;set;}
    public string Name{get;set;}
    public string Description{get;set;}
    public long Price{get;set;}
    public DateTime Created{get;set;}
    public DateTime Updated{get;set;}
public KeyboardDTO(Keyboard keyboard)
{
    KeyboardId = keyboard.KeyboardId;
    Name = keyboard.Name;
    Price = keyboard.Price;
    Description = keyboard.Description;
    Created = keyboard.Created;
    Updated = keyboard.Updated;
}
}