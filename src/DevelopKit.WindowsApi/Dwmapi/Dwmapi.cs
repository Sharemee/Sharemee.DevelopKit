using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Sharemee.DevelopKit.WindowsApi
{
    public partial class Dwmapi
    {
        protected const string LibraryName = "dwmapi.dll";

        /// <summary>
		/// Obtains a value that indicates whether Desktop Window Manager (DWM) composition is enabled.
		/// Applications can listen for composition state changes by handling the WM_DWMCOMPOSITIONCHANGED notification.
		/// </summary>
		/// <param name="pfEnabled">
		/// A pointer to a value that, when this function returns successfully, receives TRUE if DWM composition is enabled; otherwise FALSE.
		/// </param>
		/// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
        [DllImport(LibraryName, EntryPoint = "DwmIsCompositionEnabled", SetLastError = true, PreserveSig = true)]
        private static extern int DwmIsCompositionEnabled(out bool pfEnabled);
    }
}
