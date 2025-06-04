using System.Windows;
using ViewModel_TasksToDo;

namespace View_TasksToDo;

/// <summary>
/// Логика взаимодействия для ToDo.xaml
/// </summary>
public partial class ToDo : Window
{
    private ToDoViewModel toDoViewModel = new();
    public ToDo()
    {
        InitializeComponent();
        DataContext = toDoViewModel;
    }
}