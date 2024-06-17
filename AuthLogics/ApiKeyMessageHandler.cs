namespace BlazorExpenseTracker.AuthLogics;

public class ApiKeyMessageHandler(
    ILocalStorageService _localStorage,
    ILogger<ApiKeyMessageHandler> _logger,
    NavigationManager _navigation) : DelegatingHandler
{
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var apiKey = await _localStorage.GetItemAsync<string?>(
            key: LocalStorageKey.ApiKey.GetDescription()!,
            cancellationToken: cancellationToken);

        if (string.IsNullOrEmpty(apiKey))
        {
            _logger.LogWarning("API key is missing!");

            _navigation.NavigateTo("login");
        }

        request.Headers.Add("Authorization", $"Api-Key {apiKey}");

        return await base.SendAsync(request, cancellationToken);
    }
}