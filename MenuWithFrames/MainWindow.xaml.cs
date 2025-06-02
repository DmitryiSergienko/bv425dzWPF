using MenuWithFrames.Pages;
using System.Windows;

namespace MenuWithFrames;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private readonly HomePage homePage = new();
    private readonly ContactPage contactPage = new();
    private readonly AboutPage aboutPage = new();

    public MainWindow()
    {
        InitializeComponent();
    }

    private void ContactPage_Click(object sender, RoutedEventArgs e)
    {
        MyFrame.Navigate(contactPage);
    }

    private void AboutPage_Click(object sender, RoutedEventArgs e)
    {
        MyFrame.Navigate(aboutPage);
    }

    private void HomePage_Click(object sender, RoutedEventArgs e)
    {
        MyFrame.Navigate(homePage);
    }
}