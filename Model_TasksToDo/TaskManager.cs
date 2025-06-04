namespace Model_TasksToDo;

public class TaskManager
{
    private readonly List<TaskModel> _tasks;
    public TaskManager(List<TaskModel> tasks)
    {
        _tasks = tasks;
    }

    public void Write()
    {
        foreach (var task in _tasks)
        {
            // Файл будет лежать в тойже директории что и папка проекта
            File.AppendAllText(@"../../../../tasks.txt", $"{task}\n"); 
        }
    }
}