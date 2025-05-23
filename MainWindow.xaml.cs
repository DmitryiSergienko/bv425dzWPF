using System.Windows;

namespace bv425dzWPF;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void addButton_Click(object sender, RoutedEventArgs e)
    {
        var text = itemsText.Text;
        if (!string.IsNullOrWhiteSpace(text))
        {
            listBox.Items.Add(itemsText.Text);
        }
        else 
        {
            System.Media.SystemSounds.Hand.Play();
            MessageBox.Show("Поле не должно быть пустым или состоящим из пробелов!", "Ошибка!");
        }

        if (listBox.Items.Count > 0)
        {
            listBox.Visibility = Visibility.Visible;
        }

        itemsText.Clear();
    }

    private void deleteButton_Click(object sender, RoutedEventArgs e)
    {
        if (listBox.SelectedItem == null)
        {
            System.Media.SystemSounds.Hand.Play();
            MessageBox.Show("Вы ничего не выбрали!", "Ошибка!");
        }
        else
        {
            listBox.Items.Remove(listBox.SelectedItem);
        }

        if (listBox.Items.Count == 0)
        {
            listBox.Visibility = Visibility.Hidden;
        }
    }
}