using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using TestsInDifferentWindows.Classes;

namespace TestsInDifferentWindows.Pages;

/// <summary>
/// Логика взаимодействия для Question3.xaml
/// </summary>
public partial class Question3 : Page
{
    private List<ResultTest> _resultTests;

    public Question3(List<ResultTest> resultTests)
    {
        InitializeComponent();

        _resultTests = resultTests;
    }

    private void backTest_Click(object sender, RoutedEventArgs e)
    {
        _resultTests.RemoveAt(_resultTests.Count - 1);
        NavigationService.GoBack();
    }

    private void nextTest_Click(object sender, RoutedEventArgs e)
    {
        CheckResult();
        if (NavigationService.CanGoForward)
        {
            NavigationService.GoForward();
        }
        else
        {
            var results = new Results(_resultTests);
            NavigationService.Navigate(results);
        }
    }

    private void CheckResult()
    {
        var selected = answers.Children.OfType<RadioButton>().FirstOrDefault(rb => rb.IsChecked == true);
        if (selected == null)
        {
            _resultTests.Add(new ResultTest(false));
        }
        else if (answers.Children.IndexOf(selected) == 3)
        {
            _resultTests.Add(new ResultTest(true));
        }
        else
        {
            _resultTests.Add(new ResultTest(false));
        }
    }
}