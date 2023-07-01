using Sharemee.DevelopKit.WindowsApi.Enums;

namespace Sharemee.DevelopKit.WindowsApi
{
    public partial class User32
    {
        public delegate IntPtr WndProc(IntPtr hwnd, WindowMessage uMsg, IntPtr wParam, IntPtr lParam);

        public static bool SetForegroundWindow(IntPtr hWnd) => SetForegroundWindowPrivate(hWnd);

        public static IntPtr GetWindowLongPtr(IntPtr hWnd, GetWindowLong nIndex) => GetWindowLongPtr(hWnd, (int)nIndex);

        public static IntPtr SetWindowLongPtr(IntPtr hWnd, GetWindowLong nIndex, IntPtr dwNewLong) => SetWindowLongPtr(hWnd, (int)nIndex, dwNewLong);
    }
}
