using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Sharemee.DevelopKit.WindowsApi
{
    public partial class User32
    {
        /// <summary>
        /// 获得指定窗口的信息
        /// </summary>
        /// <param name="hWnd">指定窗口的句柄</param>
        /// <param name="nIndex">
        /// 要检索的值的从零开始的偏移量。
        /// 有效值的范围为零到额外窗口内存的字节数，减去 LONG_PTR的大小。
        /// 若要检索任何其他值，请使用<see cref="GetWindowLong"/>。</param>
        /// <remarks>若要编写与 32 位和 64 位版本的 Windows 兼容的代码，请使用 GetWindowLongPtr。</remarks> 
        /// <returns>类型：LONG_PTR。如果函数失败，则返回值为零。</returns>
        [DllImport(LibraryName, EntryPoint = "GetWindowLongPtr", ExactSpelling = false, CharSet = CharSet.Auto)]
        public static extern IntPtr GetWindowLongPtr(IntPtr hWnd, int nIndex);
    }
}
