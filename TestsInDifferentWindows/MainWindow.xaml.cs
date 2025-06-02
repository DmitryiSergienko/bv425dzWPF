using System.Windows;
using TestsInDifferentWindows.Classes;
using TestsInDifferentWindows.Pages;

namespace TestsInDifferentWindows;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private List<ResultTest> _resultTests = new();

    private readonly StartPage startPage;

    public MainWindow()
    {
        InitializeComponent();

        startPage = new StartPage(_resultTests);
        myFrame.Navigate(startPage);
    }
}