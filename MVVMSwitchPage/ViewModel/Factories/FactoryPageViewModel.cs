using ViewModel.Core;
using ViewModel.PagesViewModel;

namespace ViewModel.Factories;

public class FactoryPageViewModel
{
    private readonly Dictionary<Type, Func<BasePageViewModel>> pageViewModelByType = [];
    private readonly Dictionary<string, Func<BasePageViewModel>> pageViewModelByNameType = [];

    public FactoryPageViewModel()
    {
        pageViewModelByType.Add(typeof(AboutPageViewModel), () => new AboutPageViewModel());
        pageViewModelByType.Add(typeof(HomePageViewModel), () => new HomePageViewModel());

        pageViewModelByNameType.Add(nameof(AboutPageViewModel), () => new AboutPageViewModel());
        pageViewModelByNameType.Add(nameof(HomePageViewModel), () => new HomePageViewModel());
    }
    public BasePageViewModel Create(Type type)
    {
        return pageViewModelByType[type].Invoke();
    }

    public BasePageViewModel Create(string nameType)
    {
        return pageViewModelByNameType[nameType].Invoke();
    }
}