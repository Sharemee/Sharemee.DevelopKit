using System.Windows;
using System.Windows.Media;

namespace Sharemee.DevelopKit.Wpf;

public static class DependencyObjectExtension
{
    /// <summary>
    /// Find first visual tree parent object
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="dependencyObject"></param>
    /// <returns></returns>
    public static T? FindParent<T>(this DependencyObject dependencyObject) where T : DependencyObject
    {
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

    /// <summary>
    /// Find first visual tree child object.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="dependencyObject"></param>
    /// <returns></returns>
    public static T? FindChild<T>(this DependencyObject dependencyObject) where T : DependencyObject
    {
        int count = VisualTreeHelper.GetChildrenCount(dependencyObject);
        for (int i = 0; i < count; i++)
        {
            DependencyObject obj = VisualTreeHelper.GetChild(dependencyObject, i);
            if (obj is T t)
            {
                return t;
            }
        }
        return null;
    }

    public static Window GetWindow(this DependencyObject dependencyObject) => Window.GetWindow(dependencyObject);

}
