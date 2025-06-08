using Microsoft.Win32;
using System.IO;
using System.Windows;
using ViewModel_TasksToDo;

namespace View_TasksToDo;

/// <summary>
/// Логика взаимодействия для ToDo.xaml
/// </summary>
public partial class ToDo : Window
{
    private readonly ToDoViewModel toDoViewModel = new();
    public ToDo()
    {
        InitializeComponent();
        DataContext = toDoViewModel;
    }

    private void SaveTasks(object sender, RoutedEventArgs e)
    {
        var saveFileDialog = new SaveFileDialog();
        saveFileDialog.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";

        if (saveFileDialog.ShowDialog() == true)
        {
            toDoViewModel.SaveTasksToFile(saveFileDialog.FileName);
        }
    }

    private void LoadTasks(object sender, RoutedEventArgs e)
    {
        var openFileDialog = new OpenFileDialog();
        openFileDialog.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";

        if (openFileDialog.ShowDialog() == true)
        {
            toDoViewModel.LoadTasksFromFile(openFileDialog.FileName);
        }
    }
}