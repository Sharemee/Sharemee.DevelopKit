namespace Sharemee.DevelopKit.WindowsApi;

public partial class User32
{
    [Flags]
    public enum LAYERED_WINDOW_ATTRIBUTES_FLAGS : uint
    {
        /// <summary>
        /// 使用 bAlpha 确定分层窗口的不透明度。
        /// </summary>
        LWA_ALPHA = 0x00000002,

        /// <summary>
        /// 使用 crKey 作为透明度颜色。
        /// </summary>
        LWA_COLORKEY = 0x00000001,
    }

    /// <summary>
    /// 设置分层窗口的不透明度和透明度颜色键。
    /// </summary>
    /// <param name="hwnd"></param>
    /// <param name="crKey"></param>
    /// <param name="bAlpha"></param>
    /// <param name="dwFlags"></param>
    /// <returns></returns>
    [DescriptionUri("https://learn.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-setlayeredwindowattributes")]
    [DllImport(LibraryName, EntryPoint = "SetLayeredWindowAttributes", ExactSpelling = true, CharSet = CharSet.Auto)]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    //[SupportedOSPlatform("windows")]
    public static extern bool SetLayeredWindowAttributes(IntPtr hwnd, uint crKey, byte bAlpha, LAYERED_WINDOW_ATTRIBUTES_FLAGS dwFlags);
}
