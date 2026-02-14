using System;
using System.IO;
using System.Linq;
using System.Windows;
using BasicIconProvider;

namespace BasicIconProviderSample
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadSampleFiles();
        }

        // ボタン押下でアイコン取得
        private void OnGetIcon(object sender, RoutedEventArgs e)
        {
            var path = PathBox.Text;

            // Large アイコンを取得
            var icon = BasicIconProvider.BasicIconProvider.GetIcon(path, IconSize.Large);
            IconImage.Source = icon;
        }

        // サンプルとして C:\Windows のファイルを一覧表示
        private void LoadSampleFiles()
        {
            var folder = @"C:\Windows";

            if (!Directory.Exists(folder))
                return;

            var items = Directory.GetFiles(folder)
                .Take(50) // サンプルなので 50 件だけ
                .Select(f => new SampleFileItem
                {
                    Name = System.IO.Path.GetFileName(f),
                    Icon = BasicIconProvider.BasicIconProvider.GetIcon(f, IconSize.Small)
                })
                .ToList();

            FileList.ItemsSource = items;
        }
    }
}