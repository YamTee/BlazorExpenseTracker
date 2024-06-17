namespace BlazorExpenseTracker.Components;

public partial class ThemePanel
{
    [Inject]
    private ILogger<ThemePanel> Logger { get; set; } = default!;

    [Inject]
    private ILocalStorageService LocalStorage { get; set; } = default!;

    [Inject]
    private NavigationManager Navigation { get; set; } = default!;

    [Parameter]
    public ThemePanelParams Content { get; set; } = default!;

    private DesignThemeModes _mode = default!;
    private OfficeColor? _officeColor = default!;

    protected override void OnInitialized()
    {
        _mode = Content.Mode!;
        _officeColor = Content.OfficeColor;
    }

    private void OnLoaded(LoadedEventArgs e)
    {
        Logger.LogInformation("Loaded: {SystemTheme} {Theme}",
            (e.Mode == DesignThemeModes.System ? "System" : ""),
            (e.IsDark ? "Dark" : "Light"));
    }

    private void OnLuminanceChanged(LuminanceChangedEventArgs e)
    {
        Logger.LogInformation("Changed: {SystemTheme} {Theme}",
            (e.Mode == DesignThemeModes.System ? "System" : ""),
            (e.IsDark ? "Dark" : "Light"));
    }

    private async Task LogOutSystem()
    {
        await LocalStorage.RemoveItemAsync(LocalStorageKey.ApiKey.GetDescription()!);

        Navigation.NavigateTo("login");
    }
}