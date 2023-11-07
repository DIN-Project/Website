public record MonitorDTO
{
    public long MonitorId{get;set;}
    public string Name{get;set;}
    public string Description{get;set;}
    public string ImagePath {get; set;}
    public long Price{get;set;}
    public DateTime Created{get;set;}
    public DateTime Updated{get;set;}
public MonitorDTO(Monitor monitor)
{
    MonitorId = monitor.MonitorId;
    Name = monitor.Name;
    Price = monitor.Price;
    Description = monitor.Description;
    ImagePath = monitor.ImagePath;
    Created = monitor.Created;
    Updated = monitor.Updated;
}
}