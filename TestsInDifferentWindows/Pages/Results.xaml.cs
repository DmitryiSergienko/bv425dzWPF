using System.Windows.Controls;
using TestsInDifferentWindows.Classes;

namespace TestsInDifferentWindows.Pages;

/// <summary>
/// Логика взаимодействия для Results.xaml
/// </summary>
public partial class Results : Page
{
    private List<ResultTest> _resultTests;

    public Results(List<ResultTest> resultTests)
    {
        InitializeComponent();

        _resultTests = resultTests;
        ShowResults();
    }

    private void ShowResults()
    {
        if (_resultTests.Count > 0) addResult(_resultTests[0].Result, answer0);
        if (_resultTests.Count > 1) addResult(_resultTests[1].Result, answer1);
        if (_resultTests.Count > 2) addResult(_resultTests[2].Result, answer2);
    }

    private void addResult(bool rusult, TextBlock text)
    {
        if (rusult)
        {
            text.Text = "Правильный";
        }
        else
        {
            text.Text = "Не правильный";
        }
    }
}