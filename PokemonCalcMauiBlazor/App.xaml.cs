using System.Runtime.InteropServices;

namespace PkmnCalcMauiBlazor;

public partial class App : Application
{
    public App()
	{
		InitializeComponent();
        Microsoft.Maui.Handlers.WindowHandler.Mapper.AppendToMapping(nameof(IWindow), (handler, view) =>
        {
#if WINDOWS
            var nativeWindow = handler.PlatformView;
            nativeWindow.Activate();
            IntPtr windowHandle = WinRT.Interop.WindowNative.GetWindowHandle(nativeWindow);
            ShowWindow(windowHandle, 3);
#endif
        });
        MainPage = new MainPage();
	}

    [DllImport("user32.dll")]
    public static extern bool ShowWindow(IntPtr hWnd, int cmdShow);
}
