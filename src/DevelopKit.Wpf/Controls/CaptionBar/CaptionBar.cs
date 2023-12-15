using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using Brush = System.Windows.Media.Brush;
using Point = System.Windows.Point;

namespace Sharemee.DevelopKit.Wpf.Controls;

public class CaptionBar : ContentControl
{
    #region IconSourceProperty

    public ImageSource IconSource
    {
        get => (ImageSource)GetValue(IconSourceProperty);
        set => SetValue(IconSourceProperty, value);
    }

    public static readonly DependencyProperty IconSourceProperty = DependencyProperty.Register(
        nameof(IconSource), typeof(ImageSource), typeof(CaptionBar), new UIPropertyMetadata(default(ImageSource), OnIconSourcePropertyChanged));

    private static void OnIconSourcePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {

    }

    #endregion

    #region CornerRadiusProperty

    public CornerRadius CornerRadius
    {
        get { return (CornerRadius)GetValue(CornerRadiusProperty); }
        set { SetValue(CornerRadiusProperty, value); }
    }

    public static readonly DependencyProperty CornerRadiusProperty =
        DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(CaptionBar), new PropertyMetadata(new CornerRadius(0), OnCornerRadiusPropertyChanged));

    private static void OnCornerRadiusPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (e.NewValue is CornerRadius cr)
        {
            Window? window = d.GetWindow();
            if (window != null)
            {
                var winChrome = WindowChrome.GetWindowChrome(window);
                if (winChrome is null)
                {
                    winChrome = new WindowChrome() { CornerRadius = cr };
                    WindowChrome.SetWindowChrome(window, winChrome);
                }
                else
                {
                    winChrome.CornerRadius = cr;
                }
            }
        }
    }

    #endregion

    #region HeightProperty

    public new double Height
    {
        get { return (double)GetValue(HeightProperty); }
        set { SetValue(HeightProperty, value); }
    }

    public static new readonly DependencyProperty HeightProperty =
        DependencyProperty.Register("Height", typeof(double), typeof(CaptionBar), new PropertyMetadata(32d));

    //private static void OnHeightPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    //{
    //    if (d is CaptionBar captionBar && e.NewValue is double value && !double.IsNaN(value))
    //    {
    //        //captionBar.CaptionHeight = value;
    //    }
    //}

    #endregion

    #region BackgroundProperty

    public new Brush Background
    {
        get { return (Brush)GetValue(BackgroundProperty); }
        set { SetValue(BackgroundProperty, value); }
    }

    /// <summary>
    /// 覆盖默认背景颜色, 设置默认颜色为透明(如此标题栏则可拖动)
    /// </summary>
    public static new readonly DependencyProperty BackgroundProperty =
        DependencyProperty.Register("Background", typeof(Brush), typeof(CaptionBar), new PropertyMetadata(new SolidColorBrush(Colors.Transparent)));

    #endregion

    #region ActionStateProperty

    public static WindowState? GetActionState(DependencyObject obj) => (WindowState?)obj.GetValue(ActionStateProperty);

    public static void SetActionState(DependencyObject obj, WindowState? value) => obj.SetValue(ActionStateProperty, value);

    public static readonly DependencyProperty ActionStateProperty =
        DependencyProperty.RegisterAttached("ActionState", typeof(WindowState?), typeof(CaptionBar), new PropertyMetadata(null, OnActionStateChanged));

    private static void OnActionStateChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (d is Button button)
        {
            if (e.OldValue is WindowState)
            {
                button.Click -= ControlButtonClick;
            }
            if (e.NewValue is WindowState)
            {
                button.Click -= ControlButtonClick;
                button.Click += ControlButtonClick;
            }
        }
    }

    private static void ControlButtonClick(object sender, RoutedEventArgs e)
    {
        DependencyObject button = (DependencyObject)sender;
        Window window = button.GetWindow();
        WindowState? state = GetActionState(button);
        if (window is not null && state.HasValue)
        {
            window.WindowState = state.Value;
        }
    }

    #endregion

    #region IsCloseActionProperty

    public static bool GetIsCloseAction(DependencyObject obj) => (bool)obj.GetValue(IsCloseActionProperty);

    public static void SetIsCloseAction(DependencyObject obj, bool value) => obj.SetValue(IsCloseActionProperty, value);

    public static readonly DependencyProperty IsCloseActionProperty =
        DependencyProperty.RegisterAttached("IsCloseAction", typeof(bool), typeof(CaptionBar), new PropertyMetadata(false, OnIsCloseActionChanged));

    private static void OnIsCloseActionChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (d is Button button)
        {
            if (e.OldValue is true)
            {
                button.Click -= CloseActionClick;
            }
            if (e.NewValue is true)
            {
                button.Click -= CloseActionClick;
                button.Click += CloseActionClick;
            }
        }
    }

    private static void CloseActionClick(object sender, RoutedEventArgs e)
    {
        if (sender is DependencyObject dependencyObject)
        {
            dependencyObject.GetWindow()?.Close();
        }
    }

    #endregion

    #region IsCaptionBarContainerProperty

    public static bool GetIsCaptionBarContainer(DependencyObject obj) => (bool)obj.GetValue(IsCaptionBarContainerProperty);

    public static void SetIsCaptionBarContainer(DependencyObject obj, bool value) => obj.SetValue(IsCaptionBarContainerProperty, value);

    public static readonly DependencyProperty IsCaptionBarContainerProperty =
        DependencyProperty.RegisterAttached("IsCaptionBarContainer", typeof(bool), typeof(CaptionBar), new PropertyMetadata(false, OnIsCapitonBarContainerChanged));

    private static void OnIsCapitonBarContainerChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (d is UIElement element)
        {
            if (e.OldValue is true)
            {
                element.MouseLeftButtonDown -= OnMouseDoubleClick;

                element.MouseMove -= OnMouseMove;
            }
            if (e.NewValue is true)
            {
                element.MouseLeftButtonDown -= OnMouseDoubleClick;
                element.MouseLeftButtonDown += OnMouseDoubleClick;

                element.MouseMove -= OnMouseMove;
                element.MouseMove += OnMouseMove;
            }
        }
    }

    private static void OnMouseMove(object sender, MouseEventArgs e)
    {
        Window window = (sender as DependencyObject)!.GetWindow()!;
        if (e.LeftButton == MouseButtonState.Pressed)
        {
            if (window.WindowState == WindowState.Maximized)
            {
                Point innerPoint = e.GetPosition(window);
                var globalPoint = window.PointToScreen(innerPoint);
                var xr = innerPoint.X / window.ActualWidth;

                window.WindowState = WindowState.Normal;

                var newX = window.Width * xr;
                window.Left = innerPoint.X - newX;
                window.Top = globalPoint.Y + 7 - innerPoint.Y;
            }
            window.DragMove();
        }
    }

    private static void OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        if (sender is UIElement element)
        {
            Window? window = element.GetWindow();
            if (window is not null)
            {
                if (e.ClickCount == 2)
                {
                    if (window.WindowState == WindowState.Normal)
                    {
                        element.ReleaseMouseCapture();
                        window.WindowState = WindowState.Maximized;
                    }
                    else if (window.WindowState == WindowState.Maximized)
                    {
                        element.ReleaseMouseCapture();
                        window.WindowState = WindowState.Normal;
                    }
                }
            }
        }
    }

    #endregion

    public override void OnApplyTemplate()
    {
        base.OnApplyTemplate();

        Window? window = this.GetWindow();
        if (window is not null)
        {
            WindowChrome? winChrome = WindowChrome.GetWindowChrome(window);
            if (winChrome is null)
            {
                winChrome = new()
                {
                    CaptionHeight = 0,
                    CornerRadius = this.CornerRadius,
                    GlassFrameThickness = new Thickness(0d),
                    NonClientFrameEdges = NonClientFrameEdges.None,
                    ResizeBorderThickness = new Thickness(4),
                    UseAeroCaptionButtons = false,
                };
                WindowChrome.SetWindowChrome(window, winChrome);
            }
            else
            {
                winChrome.CaptionHeight = 0;
                winChrome.CornerRadius = this.CornerRadius;
                winChrome.GlassFrameThickness = new Thickness(0d);
                winChrome.NonClientFrameEdges = NonClientFrameEdges.None;
                winChrome.ResizeBorderThickness = new Thickness(4);
                winChrome.UseAeroCaptionButtons = false;
            }

            // 设置标题绑定窗口
            if (GetTemplateChild("PART_TextBlock_Caption") is TextBlock caption)
            {
                Binding captionBinding = new("Title")
                {
                    Source = window,
                    Mode = BindingMode.TwoWay,
                };
                caption.SetBinding(TextBlock.TextProperty, captionBinding);
            }
        }
    }
}
