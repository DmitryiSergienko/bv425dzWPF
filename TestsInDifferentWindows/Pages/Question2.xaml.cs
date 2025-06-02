using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using TestsInDifferentWindows.Classes;

namespace TestsInDifferentWindows.Pages;

/// <summary>
/// Логика взаимодействия для Question2.xaml
/// </summary>
public partial class Question2 : Page
{
    private readonly Question3 question3;

    private List<ResultTest> _resultTests;

    public Question2(List<ResultTest> resultTests)
    {
        InitializeComponent();

        _resultTests = resultTests;
        question3 = new Question3(_resultTests);
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
            NavigationService.Navigate(question3);
        }
    }

    private void CheckResult()
    {
        
        var selectedAnswers = answers.Children.OfType<CheckBox>().Where(cb => cb.IsChecked == true).ToList();

        if (selectedAnswers.Count == 0)
        {
            _resultTests.Add(new ResultTest(false));
            return;
        }

        var correctIndices = new List<int> { 0, 3 };
        var selectedIndices = selectedAnswers.Select(cb => answers.Children.IndexOf(cb)).ToList();
        
        bool check = true;
        for (int i = 0; i < selectedIndices.Count; i++)
        {
            if (correctIndices[i] != selectedIndices[i])
            {
                check = false; 
                break;
            }
        }

        _resultTests.Add(new ResultTest(check));
    }
}