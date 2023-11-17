using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Sharemee.DevelopKit.Wpf;

public static class DependencyObjectExtension
{
    public static T? FindParent<T>(this DependencyObject dependencyObject) where T : DependencyObject
    {
        if (dependencyObject is null) return null;

        DependencyObject? obj = VisualTreeHelper.GetParent(dependencyObject);
        if (obj is null) return null;

        if(obj is T t)
        {
            return t;
        }
        else
        {
            return FindParent<T>(obj);
        }
    }
}
