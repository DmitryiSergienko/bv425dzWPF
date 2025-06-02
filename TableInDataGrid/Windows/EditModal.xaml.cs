using System.Windows;

namespace bv425dzWPF.ModalWindows
{
    /// <summary>
    /// Логика взаимодействия для EditModal.xaml
    /// </summary>
    public partial class EditModal : Window
    {
        private readonly MainWindow _mainWindow;
        public EditModal(MainWindow mainWindow)
        {
            InitializeComponent();

            _mainWindow = mainWindow;
        }

        private void yesButton_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow.editProducts();
            Hide();
        }

        private void noButton_Click(object sender, RoutedEventArgs e)
        {
            Hide();
        }
    }
}