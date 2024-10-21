using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;

namespace Messanger.Settings.Utilities
{
    internal static class ThemeConfigurator
    {
        // Путь до светлой темы
        const string LIGHT_THEME = "pack://application:,,,/UI;component/Styles/Themes/LightTheme.xaml";
        // Путь до тёмной темы
        const string DARK_THEME = "pack://application:,,,/UI;component/Styles/Themes/DarkTheme.xaml";
        private static string SetResources(string theme)
        {
            // Директории 
            var labelStyles = new ResourceDictionary() { Source = new Uri("pack://application:,,,/UI;component/Styles/Controls/Label.xaml") };
            var textBoxStyles = new ResourceDictionary() { Source = new Uri("pack://application:,,,/UI;component/Styles/Controls/TextBox.xaml") };
            var buttonStyles = new ResourceDictionary() { Source = new Uri("pack://application:,,,/UI;component/Styles/Controls/Button.xaml") };
            var listViewStyles = new ResourceDictionary() { Source = new Uri("pack://application:,,,/UI;component/Styles/Controls/ListView.xaml") };
            var statusesStyles = new ResourceDictionary() { Source = new Uri("pack://application:,,,/UI;component/Styles/Themes/Statuses.xaml") };
            // Очистка текущих ресурсов
            Application.Current.Resources.Clear();
            // Загрузка новых
            Application.Current.Resources.MergedDictionaries.Add(labelStyles);
            Application.Current.Resources.MergedDictionaries.Add(textBoxStyles);
            Application.Current.Resources.MergedDictionaries.Add(buttonStyles);
            Application.Current.Resources.MergedDictionaries.Add(listViewStyles);
            Application.Current.Resources.MergedDictionaries.Add(statusesStyles);
            // Исходя из параметра Theme в App.config выбираем тему
            switch (theme.ToLower())
            {
                case "light":
                    Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary() { Source = new Uri(LIGHT_THEME) });
                    break;
                case "dark":
                    Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary() { Source = new Uri(DARK_THEME) });
                    break;
            }
            return theme;
        }
        internal static void LoadTheme()
        {
            var theme = ConfigurationManager.AppSettings.Get("Theme")!;
            var result = SetResources(theme);
            Debug.WriteLine($"Установлена тема: {result}");
        }
        internal static void ChangeTheme()
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var theme = config.AppSettings.Settings["Theme"].Value;
            Debug.WriteLine($"Текущая тема: {theme}");
            theme = config.AppSettings.Settings["Theme"].Value = theme == "Dark" ? "Light" : "Dark" ;
            config.Save();
            ConfigurationManager.RefreshSection("appSettings");
            var result = SetResources(theme);
            Debug.WriteLine($"Установлена тема: {result}");
        }

    }
}
