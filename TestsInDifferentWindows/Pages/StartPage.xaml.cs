using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using TestsInDifferentWindows.Classes;

namespace TestsInDifferentWindows.Pages;

/// <summary>
/// Логика взаимодействия для StartPage.xaml
/// </summary>
public partial class StartPage : Page
{
    private readonly Question1 question1;

    private List<ResultTest> _resultTests;

    public StartPage(List<ResultTest> resultTests)
    {
        InitializeComponent();

        _resultTests = resultTests;
        question1 = new Question1(_resultTests);
    }

    private void startTest_Click(object sender, RoutedEventArgs e)
    {
        NavigationService.Navigate(question1);
    }
}