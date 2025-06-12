
namespace Model;

public class CookieFile
{
    public void Write(string page)
    {
        File.AppendAllText("..\\..\\..\\..\\cookie.txt", $"Страница: {page}\n"); // Корень проекта [bv425dzWPF/MVVMSwitchPage/]
    }
    public string GetLastPage()
    {
        var prefixPages = File.ReadAllLines("..\\..\\..\\..\\cookie.txt");
        var lastPrefixPage = prefixPages.Last();
        var elementsPrefixPage = lastPrefixPage.Split(' ');
        return elementsPrefixPage.Last();
    }
}