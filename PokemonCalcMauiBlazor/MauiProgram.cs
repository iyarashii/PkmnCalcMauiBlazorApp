// Copyright (c) 2022 iyarashii @ https://github.com/iyarashii 
// Licensed under the GNU General Public License v3.0.

using Microsoft.AspNetCore.Components.WebView.Maui;
using MudBlazor.Services;

namespace PkmnCalcMauiBlazor;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
			});

		builder.Services.AddMauiBlazorWebView();
#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
#endif
        builder.Services.AddMudServices(config => 
        {
            config.SnackbarConfiguration.PreventDuplicates = false;
            config.SnackbarConfiguration.ClearAfterNavigation = true;
        });

        // TODO investigate how to handle context menus here Configure BlazorWebView options
        //builder.Services.Configure<BlazorWebView>(options =>
        //{
        //    options. = false; // Set this as needed
        //});

        return builder.Build();
	}
}
