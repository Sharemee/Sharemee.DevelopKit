namespace Sharemee.DevelopKit.WindowsApi;

public partial class User32
{
    /// <summary>
    /// 更改指定窗口的属性。该函数还会在额外窗口内存中的指定偏移量设置值。
    /// </summary>
    /// <param name="hWnd"></param>
    /// <param name="nIndex">要设置的值的从零开始的偏移量。 有效值的范围是零到额外窗口内存的字节数，减去 LONG_PTR的大小。</param>
    /// <param name="dwNewLong"></param>
    /// <returns>如果函数成功，则返回值为指定偏移量的上一个值，否则返回零。</returns>
    [DescriptionUri("https://learn.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-setwindowlongptrw")]
    [DllImport(LibraryName, ExactSpelling = true, CharSet = CharSet.Auto)]
    public static extern IntPtr SetWindowLongPtr(IntPtr hWnd, int nIndex, IntPtr dwNewLong);
}
