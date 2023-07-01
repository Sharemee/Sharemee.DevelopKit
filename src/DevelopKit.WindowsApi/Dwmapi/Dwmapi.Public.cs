using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Sharemee.DevelopKit.WindowsApi
{
    public partial class Dwmapi
    {
        public static bool DwmIsCompositionEnabled()
        {
            int hResult = DwmIsCompositionEnabled(out bool pfEnabled);
            if (hResult != 0)
            {
                int errorcode = Marshal.GetLastWin32Error();
                throw new Win32Exception(errorcode);
            }
            return pfEnabled;
        }
    }
}
