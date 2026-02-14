using System;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace BasicIconProvider
{
    /// <summary>
    /// SHGetFileInfo を使用した最小限のアイコン取得クラス。
    /// 非同期・キャッシュなしの同期版。
    /// </summary>
    public static class BasicIconProvider
    {
        /// <summary>
        /// 指定パスのアイコンを取得します（Small / Large のみ）。
        /// </summary>
        public static ImageSource? GetIcon(string path, IconSize size = IconSize.Small)
        {
            // SHGetFileInfo に渡すフラグ
            uint flags = ShellInterop.SHGFI_ICON | ShellInterop.SHGFI_USEFILEATTRIBUTES;

            // Small / Large の切り替え
            flags |= size == IconSize.Small
                ? ShellInterop.SHGFI_SMALLICON
                : ShellInterop.SHGFI_LARGEICON;

            ShellInterop.SHFILEINFO shinfo = new ShellInterop.SHFILEINFO();

            // SHGetFileInfo 呼び出し（同期）
            IntPtr result = ShellInterop.SHGetFileInfo(
                path,
                ShellInterop.FILE_ATTRIBUTE_NORMAL,
                out shinfo,
                (uint)System.Runtime.InteropServices.Marshal.SizeOf(shinfo),
                flags);

            if (shinfo.hIcon == IntPtr.Zero)
                return null;

            // HICON → ImageSource に変換
            var image = Imaging.CreateBitmapSourceFromHIcon(
                shinfo.hIcon,
                Int32Rect.Empty,
                BitmapSizeOptions.FromEmptyOptions());

            // HICON の破棄（リーク防止）
            ShellInterop.DestroyIcon(shinfo.hIcon);

            return image;
        }
    }
}
