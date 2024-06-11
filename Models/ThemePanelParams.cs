using Microsoft.FluentUI.AspNetCore.Components;

namespace BlazorExpenseTracker.Models;

public class ThemePanelParams
{
    public DesignThemeModes Mode { get; set; }

    public OfficeColor? OfficeColor { get; set; }
}