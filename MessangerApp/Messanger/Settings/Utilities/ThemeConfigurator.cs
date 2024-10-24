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
            var styles = new List<ResourceDictionary>()
            { 
                // Директории 
                new ResourceDictionary() { Source = new Uri("pack://application:,,,/UI;component/Styles/FullStyles.xaml") }
            };
            // Очистка текущих ресурсов
            Application.Current.Resources.Clear();
            // Загрузка новых
            foreach (var style in styles) 
            {
                Application.Current.Resources.MergedDictionaries.Add(style);
            }
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
