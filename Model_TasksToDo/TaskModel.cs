namespace Model_TasksToDo;

public class TaskModel
{
    public required string Name { get; set; }
    public bool IsCompleted { get; set; }

    public override string ToString()
    {
        return $"Название: {Name} Статус: {GetStatus(IsCompleted)}";
    }

    public string GetStatus(bool IsCompleted)
    {
        if (IsCompleted)
        {
            return "Выполнено";
        }

        return "Не выполнено";
    }
}