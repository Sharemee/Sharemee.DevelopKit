using System.Runtime.InteropServices;
using System.Runtime.Versioning;

namespace Sharemee.DevelopKit.WindowsApi
{
    public static partial  class Kernel32
    {
        private const string LibraryName = "kernel32.dll";

        [DllImport(LibraryName, SetLastError = true)]
        [SupportedOSPlatformGuard("Windows")]
        static extern IntPtr GetStdHandle(int nStdHandle);
    }
}
