using Model_TasksToDo;
using System.Collections.ObjectModel;
using System.ComponentModel;

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
        SaveTasksToFileCommand = new(SaveTasksToFile);
    }

    public void ToggleTaskCompletion(object? parameter)
    {
        if (parameter is TaskViewModel taskViewModel)
        {
            taskViewModel.IsCompleted = !taskViewModel.IsCompleted;
        }
    }

    public RelayCommand SaveTasksToFileCommand { get; set; }
    public RelayCommand ToggleTaskCompletionCommand { get; set; }
    public RelayCommand AddTaskCommand { get; set; }

    private void SaveTasksToFile(object? parameter)
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

        new TaskManager(tasksModel).Write();
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