namespace Sharemee.DevelopKit.WindowsApi;

public partial class User32
{
    /// <summary>
    /// 将指定的消息发送到一个或多个窗口。SendMessage 函数调用指定窗口的窗口过程，在窗口过程处理消息之前不会返回。
    /// </summary>
    /// <param name="hWnd">
    /// 窗口的句柄，其窗口过程将接收消息。如果此参数 HWND_BROADCAST ((HWND)0xffff)，则消息将发送到系统中的所有顶级窗口，包括禁用或不可见的无所有者窗口、重叠窗口和弹出窗口;但消息不会发送到子窗口。
    /// 消息发送受 UIPI 约束。进程的线程只能将消息发送到完整性级别较低或相等的进程中的线程的消息队列。</param>
    /// <param name="Msg">
    /// 要发送的消息。
    /// 有关系统提供的消息的列表，请参阅 系统定义的消息。
    /// https://learn.microsoft.com/zh-cn/windows/desktop/winmsg/about-messages-and-message-queues</param>
    /// <param name="wParam">其他的消息特定信息。</param>
    /// <param name="lParam">其他的消息特定信息。</param>
    /// <returns>返回值指定消息处理的结果;这取决于发送的消息。</returns>
    /// <![CDATA[https://learn.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-sendmessage]]>
    /// <remarks>
    /// 当 UIPI 阻止消息时，使用 GetLastError 检索到的最后一个错误设置为 5， (拒绝访问) 。
    /// 需要使用 HWND_BROADCAST 进行通信的应用程序应使用 RegisterWindowMessage 函数获取应用程序间通信的唯一消息。
    /// 系统仅对系统消息执行封送处理， (范围为 0 到(WM_USER-1) ) 。 若要将其他消息(那些 >= WM_USER) 发送到另一个进程，必须执行自定义封送处理。
    /// 如果指定的窗口是由调用线程创建的，则窗口过程将立即作为子例程调用。 如果指定的窗口是由其他线程创建的，则系统会切换到该线程并调用相应的窗口过程。 仅当接收线程执行消息检索代码时，才会处理线程之间发送的消息。 在接收线程处理消息之前，将阻止发送线程。 但是，发送线程将在等待处理其消息时处理传入的非排队消息。 若要防止出现这种情况，请使用具有SMTO_BLOCK集的 SendMessageTimeout 。 有关非排队消息的详细信息，请参阅 非排队消息。
    /// 辅助功能应用程序可以使用 SendMessage 将 WM_APPCOMMAND 消息发送到 shell 以启动应用程序。 不保证此功能适用于其他类型的应用程序。
    /// </remarks>
    [DescriptionUri("https://learn.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-sendmessage")]
    [DllImport(LibraryName, EntryPoint = "SendMessage", ExactSpelling = true, CharSet = CharSet.Auto)]
    public static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);
}
