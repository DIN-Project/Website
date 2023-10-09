public class Order 
{
    public long OrderId{get;set;}
    public User User{get;set;}
    public List<OrderItem> OrderItems{get;set;}=new();
}