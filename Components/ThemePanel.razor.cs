namespace BlazorExpenseTracker.Components;

public partial class ThemePanel
{
    [Inject]
    private ILocalStorageService LocalStorage { get; set; } = default!;

    [Inject]
    private NavigationManager Navigation { get; set; } = default!;

    [Parameter]
    public ThemePanelParams Content { get; set; } = default!;

    private async Task LogOutSystem()
    {
        await LocalStorage.RemoveItemAsync(LocalStorageKey.ApiKey.GetDescription()!);

        Navigation.NavigateTo("login");
    }
}