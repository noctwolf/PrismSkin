using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace PrismSkin.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!(sender is Button button)) return;
            Application.Current.Resources.MergedDictionaries.Clear();
            AppDomain.CurrentDomain.GetAssemblies().Where(f => !f.GlobalAssemblyCache && !f.IsDynamic).ToList().ForEach(f =>
            {
                try
                {
                    Uri uri = new Uri($"/{f.GetName()};component/Themes/Themes{button.Content}/Dictionary.xaml", UriKind.Relative);
                    _ = Application.GetResourceStream(uri);//如果资源不存在，跳过下面的行
                    Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary { Source = uri });
                }
                catch (IOException ex) when (new StackTrace(ex).GetFrames().Reverse().Skip(1).First().GetMethod().Name == nameof(Application.GetResourceStream))
                {
                    // ignored
                }
            });
        }
    }
}
