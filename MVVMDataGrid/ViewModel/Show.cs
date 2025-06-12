using Model;
using System.Collections.ObjectModel;

namespace ViewModel;

public class Show
{
    private readonly RepositoryProduct repositoryProduct = new();

    public ObservableCollection<Product> Products { get; set; } = [];

    public RelayCommand LoadProducts { get; set; }

    public Show()
    {
        var products = repositoryProduct.GetAll();

        for (int i = 0;  i < products.Count; i++)
        {
            Products.Add(products[i]);
        }

        LoadProducts = new(LoadProd);
    }

    private void LoadProd(object param)
    {
        Products.Clear();
        var products = repositoryProduct.GetNewData();

        for (int i = 0; i < products.Count; i++)
        {
            Products.Add(products[i]);
        }
    }
}