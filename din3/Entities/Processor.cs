public class Processor
{
    public long ProcessorId{get;set;}
    public string Name{get;set;}
    public string Description{get;set;}
    public string ImagePath {get;set;}
    public long Price{get;set;}
    public DateTime Created{get;set;}
    public DateTime Updated{get;set;}
    public Manufacturer Manufacturer {get;set;}
       public ProcessorDTO GetProcessorDTO()
    {
        return new ProcessorDTO(this);
    }
}