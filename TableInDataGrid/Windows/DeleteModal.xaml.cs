using System.Windows;

namespace bv425dzWPF.ModalWindows;

/// <summary>
/// Логика взаимодействия для DeleteModal.xaml
/// </summary>
public partial class DeleteModal : Window
{
    private readonly MainWindow _mainWindow;
    public DeleteModal(MainWindow mainWindow)
    {
        InitializeComponent();

        _mainWindow = mainWindow;
    }

    private void yesButton_Click(object sender, RoutedEventArgs e)
    {
        _mainWindow.deleteProducts();
        Hide();
    }

    private void noButton_Click(object sender, RoutedEventArgs e)
    {
        Hide();
    }
}