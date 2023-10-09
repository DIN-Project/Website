public class Computer 
{
    public long ComputerId{get;set;}
    public string Name{get;set;}
    public string Description{get;set;}
    public DateTime Created{get;set;}
    public DateTime Updated{get;set;}
    public Case Case {get;set;}
    public Cooler Cooler {get;set;}
    public GraphicsCard GraphicsCard {get;set;}
    public Motherboard Motherboard {get;set;}
    public PowerSupply PowerSupply {get;set;}
    public Processor Processor {get;set;}
    public Ram Ram {get;set;}
}