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

    private void SumNumbers(object sender, RoutedEventArgs e)
    {
        double xValue;
        double yValue;
        if (string.IsNullOrEmpty(firstValue.Text) || string.IsNullOrEmpty(secondValue.Text))
        {
            disPlay.Text = "Заполните поля!";
        }
        else if (double.TryParse(firstValue.Text, out xValue) && double.TryParse(secondValue.Text, out yValue))
        { 
            disPlay.Text = $"{xValue} + {yValue} = {xValue + yValue}";
        }
        else
        {
            disPlay.Text = "Не корректный ввод!";
        }
        disPlay.ToolTip = disPlay.Text;
    }
}