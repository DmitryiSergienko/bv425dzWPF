using bv425dzWPF.Classes;
using bv425dzWPF.ModalWindows;
using System.Collections.ObjectModel;
using System.Media;
using System.Windows;
using System.Windows.Controls;

namespace bv425dzWPF;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private ObservableCollection<Products> _products = [
            new("Lipton", "Чай черный", 100, 20),
            new("Pringles", "Вкусные чипсы", 400, 10),
            new("Nutella", "Ореховая паста", 1000, 3)
        ];

    public MainWindow()
    {
        InitializeComponent();

        tableData.ItemsSource = _products;
    }

    private void tableData_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var selectedCount = tableData.SelectedItems.Count;

        if (selectedCount == 1)
        {
            editButton.IsEnabled = true;
            delButton.IsEnabled = true;
        }
        else if (selectedCount > 1)
        {
            editButton.IsEnabled = false;
            delButton.IsEnabled = true;
        }
        else
        {
            editButton.IsEnabled = false;
            delButton.IsEnabled = false;
        }

        var selectedProduct = tableData.SelectedItem as Products;
        if (selectedProduct != null)
        {
            summaryInput.Text = selectedProduct.Summary;
            descriptionInput.Text = selectedProduct.Description;
            priceInput.Text = selectedProduct.Price.ToString();
            quantityInput.Text = selectedProduct.Quantity.ToString();
        }

        if (formProduct.Visibility == Visibility.Visible)
        {
            editButton.IsEnabled = false;
        }
    }

    private void addButton_Click(object sender, RoutedEventArgs e)
    {
        clearFormAndCollapsed();
        tableData.IsEnabled = false;
        formProduct.Visibility = Visibility.Visible;
        addButton.IsEnabled = false;
    }

    private void editButton_Click(object sender, RoutedEventArgs e)
    {
        tableData.Focus();
        sendButton.Visibility = Visibility.Collapsed;
        sendChangeButton.Visibility = Visibility.Visible;
        formProduct.Visibility = Visibility.Visible;
        editButton.IsEnabled = false;
    }

    private void delButton_Click(object sender, RoutedEventArgs e)
    {
        var deleteModal = new DeleteModal(this);
        deleteModal.Owner = this;
        deleteModal.ShowDialog();
    }

    public void deleteProducts()
    {
        var selectedItems = tableData.SelectedItems;
        var itemsToRemove = new List<Products>();

        foreach (var item in selectedItems)
        {
            if (item is Products product)
            {
                itemsToRemove.Add(product);
            }
        }

        foreach (var product in itemsToRemove)
        {
            _products.Remove(product);
        }
    }

    private void sendButton_Click(object sender, RoutedEventArgs e)
    {
        var newProduct = tryCreateOrEditProductInForm();
        if (newProduct == null)
        {
            return;
        }
        _products.Add(newProduct);

        clearFormAndCollapsed();
    }

    private Products? tryCreateOrEditProductInForm()
    {
        if (!decimal.TryParse(priceInput.Text, out decimal price))
        {
            SystemSounds.Exclamation.Play();
            MessageBox.Show("Цена должна быть числом!");
            return null;
        }

        if (!int.TryParse(quantityInput.Text, out int quantity))
        {
            SystemSounds.Hand.Play();
            MessageBox.Show("Количество должно быть числом!");
            return null;
        }

        var newProduct = new Products(
            summaryInput.Text,
            descriptionInput.Text,
            decimal.Parse(priceInput.Text),
            int.Parse(quantityInput.Text)
            );

        return newProduct;
    }

    private void clearFormAndCollapsed()
    {
        tableData.SelectedItem = null;
        tableData.IsEnabled = true;

        formProduct.Visibility = Visibility.Collapsed;

        summaryInput.Clear();
        descriptionInput.Clear();
        priceInput.Clear();
        quantityInput.Clear();

        addButton.IsEnabled = true;
        sendButton.Visibility = Visibility.Visible;
        sendChangeButton.Visibility = Visibility.Collapsed;
    }

    private void cancelButton_Click(object sender, RoutedEventArgs e)
    {
        clearFormAndCollapsed();
    }

    private void allInputInFormProduct_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (!(string.IsNullOrWhiteSpace(summaryInput.Text)
            || string.IsNullOrWhiteSpace(descriptionInput.Text)
            || string.IsNullOrWhiteSpace(priceInput.Text)
            || string.IsNullOrWhiteSpace(quantityInput.Text)))
        {
            sendButton.IsEnabled = true;
            sendChangeButton.IsEnabled = true;
        }
        else
        {
            sendButton.IsEnabled = false;
            sendChangeButton.IsEnabled = false;
        }
    }

    private void sendChangeButton_Click(object sender, RoutedEventArgs e)
    {
        var editModal = new EditModal(this);
        editModal.Owner = this;
        editModal.ShowDialog();
    }

    public void editProducts()
    {
        var selectedProduct = tableData.SelectedItem as Products;
        int index;
        if (selectedProduct != null)
        {
            index = _products.IndexOf(selectedProduct);
        }
        else
        {
            index = -1;
        }

        var newProduct = tryCreateOrEditProductInForm();
        if (newProduct == null)
        {
            return;
        }
        _products.RemoveAt(index);
        _products.Insert(index, newProduct);

        clearFormAndCollapsed();
    }
}