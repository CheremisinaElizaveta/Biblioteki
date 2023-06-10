using System;
using System.Windows;

namespace ThemeLibrary
{
    public static class ThemeManager
    {
        public static void ApplyLightTheme()
        {
            Application.Current.Resources.MergedDictionaries.Clear();
            var uri = new Uri("pack://application:,,,/ThemeLibrary;component/LightTheme.xaml", UriKind.RelativeOrAbsolute);
            Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary() { Source = uri });
        }

        public static void ApplyDarkTheme()
        {
            Application.Current.Resources.MergedDictionaries.Clear();
            var uri = new Uri("pack://application:,,,/ThemeLibrary;component/DarkTheme.xaml", UriKind.RelativeOrAbsolute);
            Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary() { Source = uri });
        }
    }

}
