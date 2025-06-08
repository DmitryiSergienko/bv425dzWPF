using System.Collections.Generic;
using System.Runtime.Serialization.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace Model_TasksToDo;

public class TaskManager
{
    public void Write(List<TaskModel> tasks, string filePath)
    {
        //Сериализовать и сохранить в файл
        var options = new JsonSerializerOptions { WriteIndented = true };
        string json = JsonSerializer.Serialize(tasks, options);
        File.WriteAllText(filePath, json);
    }

    public List<TaskModel> Read(string filePath)
    {
        //Десериализовать и читать с файла
        if (!File.Exists(filePath))
        {
            return [];
        }

        string json = File.ReadAllText(filePath);
        return JsonSerializer.Deserialize<List<TaskModel>>(json) ?? [];
    }
}