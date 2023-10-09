public class Manufacturer 
{
    public long ManufacturerId{get;set;}
    public string Name{get;set;}
    public List<GraphicsCard> GraphicsCards{get;}=new();
    public List<Case> Cases{get;}=new();
    public List<Cooler> Coolers{get;}=new();
    public List<Headset> Headsets{get;}=new();
    public List<Keyboard> Keyboards{get;}=new();
    public List<Monitor> Monitors{get;}=new();
    public List<Motherboard> Motherboards{get;}=new();
    public List<Mouse> Mouses{get;}=new();
    public List<PowerSupply> PowerSupplies{get;}=new();
    public List<Processor> Processors{get;}=new();
    public List<Ram> Rams{get;}=new();
}