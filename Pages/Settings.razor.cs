
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

    #region Theme Settings
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
    #endregion


    public List<Categories>? Categories { get; set; } = [];

    GridSort<Categories> sortByName = GridSort<Categories>
        .ByAscending(p => p.Name)
        .ThenAscending(p => p.Name);

    GridSort<Categories> sortByDescription = GridSort<Categories>
        .ByAscending(p => p.Description)
        .ThenAscending(p => p.Description);

    protected override async Task OnInitializedAsync()
    {
        await Task.Delay(5000);

        Categories = [
            new(){ CategoryId = Guid.NewGuid().ToString(), Name = "Category 1", Description= "desc 1"},
            new(){ CategoryId = Guid.NewGuid().ToString(), Name = "Category 2", Description= "desc 2"}
        ];

        await base.OnInitializedAsync();
    }
}
