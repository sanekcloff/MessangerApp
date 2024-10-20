using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;

namespace Messanger.Settings
{
    internal class AppTheme
    {
        const string LIGHT_THEME = "pack://application:,,,/UI;component/Styles/Themes/LightTheme.xaml";
        const string DARK_THEME = "pack://application:,,,/UI;component/Styles/Themes/DarkTheme.xaml";
        private static void SetResources()
        {
            var labelStyles = new ResourceDictionary() { Source = new Uri("pack://application:,,,/UI;component/Styles/Controls/Label.xaml") };
            var textBoxStyles = new ResourceDictionary() { Source = new Uri("pack://application:,,,/UI;component/Styles/Controls/TextBox.xaml") };
            var buttonStyles = new ResourceDictionary() { Source = new Uri("pack://application:,,,/UI;component/Styles/Controls/Button.xaml") };
            
            App.Current.Resources.Clear();
            App.Current.Resources.MergedDictionaries.Add(labelStyles);
            App.Current.Resources.MergedDictionaries.Add(textBoxStyles);
            App.Current.Resources.MergedDictionaries.Add(buttonStyles);
        }
        public static void LoadTheme()
        {

        }

    }
}
