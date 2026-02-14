using System;
using System.Runtime.InteropServices;

namespace BasicIconProvider
{
    internal static class ShellInterop
    {
        [DllImport("Shell32.dll", CharSet = CharSet.Unicode)]
        internal static extern IntPtr SHGetFileInfo(
            string pszPath,
            uint dwFileAttributes,
            out SHFILEINFO psfi,
            uint cbFileInfo,
            uint uFlags);

        internal const uint SHGFI_ICON = 0x000000100;
        internal const uint SHGFI_SMALLICON = 0x000000001;
        internal const uint SHGFI_LARGEICON = 0x000000000;
        internal const uint SHGFI_USEFILEATTRIBUTES = 0x000000010;

        internal const uint FILE_ATTRIBUTE_NORMAL = 0x80;

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        internal struct SHFILEINFO
        {
            public IntPtr hIcon;
            public int iIcon;
            public uint dwAttributes;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            public string szDisplayName;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
            public string szTypeName;
        }

        [DllImport("User32.dll")]
        internal static extern bool DestroyIcon(IntPtr hIcon);
    }
}