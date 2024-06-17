namespace BlazorExpenseTracker.AuthLogics;

public class CustomAuthenticationStateProvider(ILocalStorageService _localStorage) : AuthenticationStateProvider
{
    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var apiKey = await _localStorage.GetItemAsync<string?>(LocalStorageKey.ApiKey.GetDescription()!);

        ClaimsIdentity identity;

        if (!string.IsNullOrEmpty(apiKey))
        {
            identity = new ClaimsIdentity(
            [new Claim(ClaimTypes.Name, "ApiUser")],
            "apiauth");
        }
        else
        {
            identity = new ClaimsIdentity(); // Unauthenticated state
        }

        var user = new ClaimsPrincipal(identity);
        return await Task.FromResult(new AuthenticationState(user));
    }

    public void NotifyUserAuthentication()
    {
        var authState = GetAuthenticationStateAsync();
        NotifyAuthenticationStateChanged(authState);
    }

    public void NotifyUserLogout()
    {
        var authState = Task.FromResult(new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity())));
        NotifyAuthenticationStateChanged(authState);
    }
}