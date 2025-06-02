namespace bv425dzWPF.Classes;

public class Products
{
    public string Summary { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }

    public Products(string summary, string description, decimal price, int quantity)
    {
        Summary = summary;
        Description = description;
        Price = price;
        Quantity = quantity;
    }
}