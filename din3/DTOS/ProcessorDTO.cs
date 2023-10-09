public record ProcessorDTO
{
    public long ProcessorId{get;set;}
    public string Name{get;set;}
    public string Description{get;set;}
    public long Price{get;set;}
    public DateTime Created{get;set;}
    public DateTime Updated{get;set;}
public ProcessorDTO(Processor processor)
{
    ProcessorId = processor.ProcessorId;
    Name = processor.Name;
    Price = processor.Price;
    Description = processor.Description;
    Created = processor.Created;
    Updated = processor.Updated;
}
}