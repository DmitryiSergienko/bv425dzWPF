using ViewModel.Core;

namespace ViewModel.Services.Interfaces;

interface INovigationService
{
    BasePageViewModel? BasePageViewModel { get; }
    void NovigateTo<T>() where T : BasePageViewModel;
}