using Model;
using ViewModel.Core;
using ViewModel.Factories;
using ViewModel.Services.Classes;

namespace ViewModel.PagesViewModel;

public class MainViewModel
{
    public NovigateService NovigateService { get; }

    public RelayCommand NovigateToAboutCommand { get; }
    public RelayCommand NovigateToHomeCommand { get; }

    private readonly FactoryPageViewModel factoryPageViewModel = new();
    private readonly CookieFile cookieFile = new();
    private readonly Storage storage = new();
    public MainViewModel()
    {
        NovigateService = new(cookieFile, factoryPageViewModel);
        NovigateToAboutCommand = new(obj => NovigateService.NovigateTo<AboutPageViewModel>());
        NovigateToHomeCommand = new(obj => NovigateService.NovigateTo<HomePageViewModel>());
    }

    public void SaveDataPage()
    {
        if (NovigateService.BasePageViewModel == null)
        {
            return;
        }
        if (NovigateService.BasePageViewModel.Text == null)
        {
            return;
        }

        storage.Write(NovigateService.BasePageViewModel.Text);
    }
    public void RestoreDataPage()
    {
        var nameTypeLastPage = cookieFile.GetLastPage();
        var pageViewModel = factoryPageViewModel.Create(nameTypeLastPage);
        NovigateService.SetPageViewModel(pageViewModel);

        if (NovigateService.BasePageViewModel == null)
        {
            return;
        }

        NovigateService.BasePageViewModel.Text = storage.Read();
    }
}