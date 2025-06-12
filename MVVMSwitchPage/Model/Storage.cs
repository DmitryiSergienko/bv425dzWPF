namespace Model;

public class Storage
{
    public string Read()
    {
        var data = File.ReadAllText("..\\..\\..\\..\\data.txt");
        return data;
    }
    public void Write(string data)
    {
        File.WriteAllText("..\\..\\..\\..\\data.txt", $"{data}"); // Корень проекта [bv425dzWPF/MVVMSwitchPage/]
    }
}