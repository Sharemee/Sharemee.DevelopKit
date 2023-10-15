using System.Runtime.InteropServices;

namespace Sharemee.DevelopKit.WindowsApi;

public partial class User32
{
    internal const string LibraryName = "user32.dll";

    /// <summary>
    /// 将创建指定窗口的线程引入前台并激活窗口。
    /// 键盘输入将定向到窗口，并为用户更改各种视觉提示。
    /// 系统为创建前台窗口的线程分配的优先级略高于其他线程的优先级。
    /// </summary>
    /// <param name="hWnd">应激活并带到前台的窗口的句柄。</param>
    /// <returns>
    /// 如果将窗口带到前台，则返回值为非零值。
    /// 如果未将窗口带到前台，则返回值为零。
    /// </returns>
    /// <remarks>
    /// 系统限制哪些进程可以设置前台窗口。 仅当以下项时，进程才能通过调用 SetForegroundWindow 来设置前台窗口： 
    /// 以下所有条件都为 true：
    /// 调用进程属于桌面应用程序，而不是为 Windows 8 或 8.1 设计的 UWP 应用或 Windows 应用商店应用。
    /// 前台进程尚未禁用对 LockSetForegroundWindow 函数的先前调用对 SetForegroundWindow 的 调用。
    /// 前台锁超时已过期， (在 SystemParametersInfo) 中看到SPI_GETFOREGROUNDLOCKTIMEOUT。
    /// 没有菜单处于活动状态。
    /// 此外，至少满足以下条件之一：
    /// 调用进程是前台进程。
    /// 调用进程由前台进程启动。
    /// 当前没有前台窗口，因此没有前台进程。
    /// 调用进程收到了最后一个输入事件。
    /// 正在调试前台进程或调用进程。
    /// 即使进程满足这些条件，也有可能被剥夺设置前台窗口的权利。
    /// 当用户使用另一个窗口时，应用程序无法将窗口强制到前台。 相反，Windows 会闪烁窗口的任务栏按钮以通知用户。
    /// 可以设置前台窗口的进程可以通过调用 AllowSetForegroundWindow 函数使另一个进程能够设置前台窗口。 由 allowSetForegroundWindow 的 dwProcessId 参数指定的进程将无法在用户下次生成输入时设置前台窗口，除非输入定向到该进程，或下一次进程调用 AllowSetForegroundWindow 时，除非指定的进程与上次对 AllowSetForegroundWindow 的调用相同。
    /// 前台进程可以通过调用 LockSetForegroundWindow 函数来禁用对 SetForegroundWindow 的 调用。
    /// https://learn.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-setforegroundwindow?redirectedfrom=MSDN
    /// </remarks>
    [DllImport(LibraryName, EntryPoint = "SetForegroundWindow", ExactSpelling = true, CharSet = CharSet.Auto)]
    private static extern bool SetForegroundWindowPrivate(IntPtr hWnd);
}
