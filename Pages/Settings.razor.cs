namespace BlazorExpenseTracker.Pages;

public partial class Settings
{
    #region Accordion

    const string activeId = "accordion-1";

    FluentAccordionItem? changed;

    private void HandleOnAccordionItemChange(FluentAccordionItem item)
    {
        changed = item;
    }

    #endregion

    [Inject]
    private ILogger<Settings> Logger { get; set; } = default!;

    [Inject]
    private ILocalStorageService LocalStorage { get; set; } = default!;

    public DesignThemeModes Mode { get; set; }

    public OfficeColor? OfficeColor { get; set; }

    private void OnLoaded(LoadedEventArgs e)
    {
        Logger.LogInformation("Loaded: {SystemTheme} {Theme}",
            e.Mode == DesignThemeModes.System ? "System" : "",
            e.IsDark ? "Dark" : "Light");
    }

    private void OnLuminanceChanged(LuminanceChangedEventArgs e)
    {
        Logger.LogInformation("Changed: {SystemTheme} {Theme}",
            e.Mode == DesignThemeModes.System ? "System" : "",
            e.IsDark ? "Dark" : "Light");
    }
}
