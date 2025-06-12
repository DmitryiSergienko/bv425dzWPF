namespace Model;

public class RepositoryProduct
{
    public List<Product> GetAll()
    {
        var products = new List<Product>();
        products.Add(new Product
        {
            Id = 1,
            Name = "Продукт1",
            Description = "Хороший продукт",
            Price = 100,
            PathImage = "/WpfControlLibrary;component/Images/1.jpg",
            LableImage = "Картинка1"
        });
        products.Add(new Product
        {
            Id = 2,
            Name = "Продукт2",
            Description = "Классный продукт",
            Price = 200,
            PathImage = "/WpfControlLibrary;component/Images/2.jpg",
            LableImage = "Картинка2"
        });
        products.Add(new Product
        {
            Id = 3,
            Name = "Продукт3",
            Description = "Супер продукт",
            Price = 300,
            PathImage = "/WpfControlLibrary;component/Images/3.jpg",
            LableImage = "Картинка3"
        });
        
        return products;
    }

    public List<Product> GetNewData()
    {
        var products = new List<Product>();
        products.Add(new Product
        {
            Id = 1,
            Name = "Продукт1",
            Description = "Хороший продукт",
            Price = 100,
            PathImage = "/WpfControlLibrary;component/Images/1.jpg",
            LableImage = "Картинка1"
        });
        products.Add(new Product
        {
            Id = 2,
            Name = "Продукт2",
            Description = "Классный продукт",
            Price = 200,
            PathImage = "/WpfControlLibrary;component/Images/2.jpg",
            LableImage = "Картинка2"
        });
        products.Add(new Product
        {
            Id = 3,
            Name = "Продукт3",
            Description = "Супер продукт",
            Price = 300,
            PathImage = "/WpfControlLibrary;component/Images/3.jpg",
            LableImage = "Картинка3"
        });
        products.Add(new Product
        {
            Id = 4,
            Name = "Продукт4",
            Description = "Хороший продукт",
            Price = 400,
            PathImage = "/WpfControlLibrary;component/Images/4.jpg",
            LableImage = "Картинка4"
        });
        products.Add(new Product
        {
            Id = 5,
            Name = "Продукт5",
            Description = "Классный продукт",
            Price = 500,
            PathImage = "/WpfControlLibrary;component/Images/5.jpg",
            LableImage = "Картинка5"
        });
        products.Add(new Product
        {
            Id = 6,
            Name = "Продукт6",
            Description = "Супер продукт",
            Price = 600,
            PathImage = "/WpfControlLibrary;component/Images/6.jpg",
            LableImage = "Картинка6"
        });

        return products;
    }
}