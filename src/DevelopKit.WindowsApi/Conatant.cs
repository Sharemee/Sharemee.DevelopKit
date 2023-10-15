using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharemee.DevelopKit.WindowsApi
{
    public class Conatant
    {
        /// <summary>
        /// 设置新的 扩展窗口样式。
        /// </summary>
        public const int GWL_EXSTYLE = -20;
        /// <summary>
        /// 设置新的应用程序实例句柄。
        /// </summary>
        public const int GWLP_HINSTANCE = -6;
        /// <summary>
        /// 设置子窗口的新标识符。 该窗口不能是顶级窗口。
        /// </summary>
        public const int GWLP_ID = -12;
        /// <summary>
        /// 设置新 窗口样式。
        /// </summary>
        public const int GWL_STYLE = -16;
        /// <summary>
        /// 设置与窗口关联的用户数据。 此数据供创建窗口的应用程序使用。 其值最初为零。
        /// </summary>
        public const int GWLP_USERDATA = -21;
        /// <summary>
        /// 设置窗口过程的新地址。
        /// </summary>
        public const int GWLP_WNDPROC = -4;


    }
}
