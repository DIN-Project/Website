
public class Cooler 
{
    public long CoolerId{get;set;}
    public string Name{get;set;}
    public string Description{get;set;}
    public string ImagePath {get;set;}
    public long Price{get;set;}
    public DateTime Created{get;set;}
    public DateTime Updated{get;set;}
    public Manufacturer Manufacturer {get;set;}
     public CoolerDTO GetCoolerDTO()
    {
        return new CoolerDTO(this);
    }
}