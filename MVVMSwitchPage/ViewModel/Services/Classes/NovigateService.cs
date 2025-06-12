using Model;
using ViewModel.Core;
using ViewModel.Factories;
using ViewModel.Services.Interfaces;

namespace ViewModel.Services.Classes;

public class NovigateService(CookieFile cookieFile, FactoryPageViewModel factoryPageViewModel) : ObservableObject, INovigationService
{
    private BasePageViewModel? basePageViewModel;
    public BasePageViewModel? BasePageViewModel
    {
        get => basePageViewModel; 
        set
        {
            basePageViewModel = value;
            OnPropertyChanged();
        }
    }

    public void NovigateTo<T>() where T : BasePageViewModel
    {
        if (basePageViewModel is not T)
        {
            cookieFile.Write(typeof(T).Name);
            BasePageViewModel = factoryPageViewModel.Create(typeof(T));
        }
    }

    public void SetPageViewModel(BasePageViewModel pageViewModel)
    {
        BasePageViewModel = pageViewModel;
    }
}