using System.Windows;
using System.Windows.Controls;
using TestsInDifferentWindows.Classes;

namespace TestsInDifferentWindows.Pages;

/// <summary>
/// Логика взаимодействия для Question1.xaml
/// </summary>
public partial class Question1 : Page
{
    private readonly Question2 question2;

    private List<ResultTest> _resultTests;

    public Question1(List<ResultTest> resultTests)
    {
        InitializeComponent();

        _resultTests = resultTests;
        question2 = new Question2(_resultTests);
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
            NavigationService.Navigate(question2);
        }
    }

    private void CheckResult()
    {
        var selected = answers.Children.OfType<RadioButton>().FirstOrDefault(rb => rb.IsChecked == true);
        if (selected == null)
        {
            _resultTests.Add(new ResultTest(false));
        }
        else if (answers.Children.IndexOf(selected) == 1)
        {
            _resultTests.Add(new ResultTest(true));
        }
        else
        {
            _resultTests.Add(new ResultTest(false));
        }
    }
}