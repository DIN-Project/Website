using Microsoft.EntityFrameworkCore;
public class Din3Context:DbContext
{ 
    public DbSet<Case> Cases{get;set;}
    public DbSet<Cooler> Coolers{get;set;}
    public DbSet<GraphicsCard> GraphicsCards{get;set;}
    public DbSet<Headset> Headsets{get;set;}
    public DbSet<Keyboard> Keyboards{get;set;}
    public DbSet<Manufacturer> Manufacturers{get;set;}
    public DbSet<Monitor> Monitors{get;set;}
    public DbSet<Motherboard> Motherboards{get;set;}
    public DbSet<Mouse> Mouses{get;set;}
    public DbSet<PowerSupply> PowerSupplies{get;set;}
    public DbSet<Processor> Processors{get;set;}
    public DbSet<Ram> Rams{get;set;}
    public DbSet<User> Users{get;set;}
    public DbSet<Computer> Computers{get;set;}
    public DbSet<Order> Orders{get;set;}
    public DbSet<OrderItem> OrderItems{get;set;}

public Din3Context(DbContextOptions<Din3Context> options) : base(options)
    {

    }
}