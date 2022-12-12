using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace NavigationExample.Helpers
{
    public class NavigationHelper
    {
        public static string GetNavigateTo(ListBoxItem item) => (string)item.GetValue(NavigateToProperty);

        public static void SetNavigateTo(ListBoxItem item, string value) => item.SetValue(NavigateToProperty, value);

        public static readonly DependencyProperty NavigateToProperty =
            DependencyProperty.RegisterAttached("NavigateTo", typeof(string), typeof(NavigationHelper), new PropertyMetadata(null));

    }
}
