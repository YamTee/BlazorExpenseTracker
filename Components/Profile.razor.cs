namespace BlazorExpenseTracker.Components;

public partial class Profile
{
    [Parameter]
    public string? Name { get; set; }

    [Parameter]
    public string? Initials { get; set; }

    [Parameter]
    public string? Email { get; set; }

    [Inject]
    private ILocalStorageService LocalStorage { get; set; } = default!;

    [Inject]
    private NavigationManager Navigation { get; set; } = default!;

    private async Task LogOutSystem()
    {
        await LocalStorage.RemoveItemAsync(LocalStorageKey.ApiKey.GetDescription()!);

        Navigation.NavigateTo("login");
    }

    private void NavigateToSettings()
    {
        Navigation.NavigateTo("settings");
    }
}
