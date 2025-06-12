namespace Model;

public class Product
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required decimal Price { get; set; } = decimal.Zero;
    public required string LableImage { get; set; }
    public required string PathImage { get; set; }
}