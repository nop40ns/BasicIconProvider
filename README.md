[English README is here → README.en.md](README.en.md)
# BasicIconProvider
![NuGet](https://img.shields.io/nuget/v/Nop40ns.BasicIconProvider)
![Downloads](https://img.shields.io/nuget/dt/Nop40ns.BasicIconProvider)


**BasicIconProvider** は、WPF アプリケーションで  
**ファイルやフォルダのアイコンを取得するための「最小限の学習用ライブラリ」** です。

Windows の `SHGetFileInfo` を使用した **同期・低機能・シンプル** な実装で、  
WPF でアイコンを扱う最初のステップとして最適です。

---

## 🚀 特徴

- Windows の SHGetFileInfo を使った **最低限のアイコン取得**
- **Small / Large** の 2 サイズに対応
- **同期処理のみ**
- **キャッシュなし**
- **例外処理も最小限**
- **WPF (.NET 8)** 対応

学習用としてシンプルに保つため、  
実用レベルの機能はあえて含めていません。

---

## 📦 プロジェクト構成
```
/src /BasicIconProvider BasicIconProvider.cs IconSize.cs ShellInterop.cs
/BasicIconProviderSample MainWindow.xaml MainWindow.xaml.cs SampleFileItem.cs
```
- **BasicIconProvider**  
  → ライブラリ本体（DLL）

- **BasicIconProviderSample**  
  → 使い方のサンプル（WPF アプリ）

---

## 🧩 使い方（サンプル）
csharp
```
using BasicIconProvider;

var icon = BasicIconProvider.GetIcon(@"C:\Windows\explorer.exe", IconSize.Large);
```
## 🖼 Sample Application

![Sample Screenshot](images/sample.png)


## 📄 License

This project is licensed under the MIT License.  
See the LICENSE file for details.
