using Microsoft.Win32;
using Model_TasksToDo;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Threading.Tasks;
using System.Windows;

namespace ViewModel_TasksToDo;

public class ToDoViewModel : INotifyPropertyChanged
{
    public ObservableCollection<TaskViewModel> Tasks { get; set; }

    private string textTask;    
    public string TextTask 
    {
        get => textTask;
        set 
        {
            textTask = value;
            OnPropertyChanged(nameof(TextTask));
        }
    }

    public ToDoViewModel() 
    {
        Tasks =
            [
                new()
                {
                    Name = "Задание #1",
                    IsCompleted = false
                },
                new()
                {
                    Name = "Задание #2",
                    IsCompleted = true
                }
            ];

        AddTaskCommand = new(AddTask);
        ToggleTaskCompletionCommand = new(ToggleTaskCompletion);
    }

    public void ToggleTaskCompletion(object? parameter)
    {
        if (parameter is TaskViewModel task)
    {
        task.IsCompleted = !task.IsCompleted;
    }
    }
    public RelayCommand ToggleTaskCompletionCommand { get; set; }
    public RelayCommand AddTaskCommand { get; set; }

    public void SaveTasksToFile(string filePath)
    {
        var tasksModel = new List<TaskModel>();

        foreach (var task in Tasks)
        {
            var taskModel = new TaskModel
            {
                Name = task.Name,
                IsCompleted = task.IsCompleted
            };

            tasksModel.Add(taskModel);
        }

        new TaskManager().Write(tasksModel, filePath);
    }
    public void LoadTasksFromFile(string filePath)
    {
        var loadedTasks = new TaskManager().Read(filePath);

        if (loadedTasks != null && loadedTasks.Count > 0)
        {
            Tasks.Clear();

            foreach (var taskModel in loadedTasks)
            {
                Tasks.Add(new TaskViewModel
                {
                    Name = taskModel.Name,
                    IsCompleted = taskModel.IsCompleted
                });
            }
        }
    }

    private void AddTask(object? parameter)
    {
        var taskViewModel = new TaskViewModel
        {
            Name = TextTask
        };

        TextTask = string.Empty;
        Tasks.Add(taskViewModel);
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    public void OnPropertyChanged(string propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}