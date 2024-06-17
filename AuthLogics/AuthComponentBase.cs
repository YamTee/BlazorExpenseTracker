namespace BlazorExpenseTracker.AuthLogics;

public class AuthComponentBase : ComponentBase
{
    [Inject]
    protected AuthenticationStateProvider AuthenticationStateProvider { get; set; } = default!;

    [Inject]
    protected NavigationManager Navigation { get; set; } = default!;

    protected override async Task OnInitializedAsync()
    {
        var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();

        if (!(authState.User.Identity?.IsAuthenticated ?? true))
        {
            Navigation.NavigateTo("login");
        }
    }
}