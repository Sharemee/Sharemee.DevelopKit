using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharemee.DevelopKit.WindowsApi
{
    public enum GetWindowLong : int
    {
        /// <summary>
        /// Retrieves the extended window styles.
        /// </summary>
        /// <remarks>
        /// 检索扩展窗口样式。
        /// </remarks>
        GWL_EXSTYLE = -20,

        /// <summary>
        /// Retrieves a handle to the application instance.
        /// </summary>
        /// <remarks>
        /// 检索应用程序实例的句柄。
        /// </remarks>
        GWLP_HINSTANCE = -6,

        /// <summary>
        /// Retrieves a handle to the parent window, if there is one.
        /// </summary>
        /// <remarks>
        /// 检索父窗口的句柄（如果有）。
        /// </remarks>
        GWLP_HWNDPARENT = -8,

        /// <summary>
        /// Retrieves the identifier of the window.
        /// </summary>
        /// <remarks>
        /// 检索窗口的标识符。
        /// </remarks>
        GWLP_ID = -12,

        /// <summary>
        /// Retrieves the window styles.
        /// </summary>
        /// <remarks>
        /// 检索 窗口样式。
        /// </remarks>
        GWL_STYLE = -16,

        /// <summary>
        /// Retrieves the user data associated with the window.
        /// This data is intended for use by the application that created the window.
        /// Its value is initially zero.
        /// </summary>
        /// <remarks>
        /// 检索与窗口关联的用户数据。
        /// 此数据供创建窗口的应用程序使用。
        /// 其值最初为零。
        /// </remarks>
        GWLP_USERDATA = -21,

        /// <summary>
        /// Retrieves the pointer to the window procedure, or a handle representing the pointer to the window procedure.
        /// You must use the <see cref="CallWindowProc"/> function to call the window procedure.
        /// </summary>
        /// <remarks>
        /// 检索指向窗口过程的指针，或表示指向窗口过程的指针的句柄。
        /// 必须使用 CallWindowProc 函数调用窗口过程。
        /// </remarks>
        GWLP_WNDPROC = -4,
    }
}
