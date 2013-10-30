using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using TheBoyKnowsClass.Common.UI.WPF.Modern.ViewModels;

namespace TheBoyKnowsClass.Common.UI.WPF.Modern.Controls
{
    /// <summary>
    /// Follow steps 1a or 1b and then 2 to use this custom control in a XAML file.
    ///
    /// Step 1a) Using this custom control in a XAML file that exists in the current project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:TheBoyKnowsClass.Common.UI.WPF.Modern"
    ///
    ///
    /// Step 1b) Using this custom control in a XAML file that exists in a different project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:TheBoyKnowsClass.Common.UI.WPF.Modern;assembly=TheBoyKnowsClass.Common.UI.WPF.Modern"
    ///
    /// You will also need to add a project reference from the project where the XAML file lives
    /// to this project and Rebuild to avoid compilation errors:
    ///
    ///     Right click on the target project in the Solution Explorer and
    ///     "Add Reference"->"Projects"->[Select this project]
    ///
    ///
    /// Step 2)
    /// Go ahead and use your control in the XAML file.
    ///
    ///     <MyNamespace:CustomControl1/>
    ///
    /// </summary>
    public class ModernWindow : Window
    {

        private ContentControl _logoContentControl;
        private Frame _frame;   

        static ModernWindow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ModernWindow), new FrameworkPropertyMetadata(typeof(ModernWindow)));
        }

        public ModernWindow()
        {
            if(Application.Current.Resources.Contains("AppearanceManager"))
            {
                var appearanceManagerViewModel = Application.Current.Resources["AppearanceManager"];
            }

            CommandBindings.Add(new CommandBinding(SystemCommands.CloseWindowCommand, OnCloseWindow));
            CommandBindings.Add(new CommandBinding(SystemCommands.MaximizeWindowCommand, OnMaximizeWindow, OnCanResizeWindow));
            CommandBindings.Add(new CommandBinding(SystemCommands.MinimizeWindowCommand, OnMinimizeWindow));
            CommandBindings.Add(new CommandBinding(SystemCommands.RestoreWindowCommand, OnRestoreWindow, OnCanResizeWindow));

            Loaded += OnLoaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            _logoContentControl = Template.FindName("LogoControl", this) as ContentControl;
            _frame = Template.FindName("MainContentFrame", this) as Frame;

            if (_frame != null)
            {
                NavigationManagerViewModel.Instance.RegisterNavigationFrame(_frame);

                if (Source != null)
                {
                    NavigationManagerViewModel.Instance.NavigateCommand.Execute(Source);
                }

            }

            SetIcon();
        }

        #region Dependency Properties

        public static readonly DependencyProperty LogoProperty = DependencyProperty.Register("Logo", typeof(Object), typeof(ModernWindow), new PropertyMetadata(new Object(), OnLogoPropertyChanged));

        private static void OnLogoPropertyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
        {
            var window = dependencyObject as ModernWindow;
            if (window != null)
            {
                window.SetIcon();
            }
        }

        public Object Logo
        {
            get { return (Object)GetValue(LogoProperty); }
            set { SetValue(LogoProperty, value); } 
        }


        public static readonly DependencyProperty SourceProperty = DependencyProperty.Register("Source", typeof(Uri), typeof(ModernWindow), new PropertyMetadata(null, OnSourcePropertyChanged));

        private static void OnSourcePropertyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
        {
            var window = dependencyObject as ModernWindow;
            var uri = dependencyPropertyChangedEventArgs.NewValue as Uri;

            if (window != null  && uri != null)
            {
                NavigationManagerViewModel.Instance.NavigateCommand.Execute(uri);
            }
        }

        public Uri Source
        {
            get { return (Uri)GetValue(SourceProperty); }
            set
            {
                SetValue(SourceProperty, value);   
            }
        }

        #endregion

        private readonly MessageHandlerViewModel _messageHandler = MessageHandlerViewModel.Instance;

        public MessageHandlerViewModel MessageHandler
        {
            get { return _messageHandler; }
        }

        protected void OnRestoreWindow(object sender, ExecutedRoutedEventArgs e)
        {
            SystemCommands.RestoreWindow(this);
        }

        protected void OnMinimizeWindow(object sender, ExecutedRoutedEventArgs e)
        {
            SystemCommands.MinimizeWindow(this);
        }

        protected void OnCanResizeWindow(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = ResizeMode == ResizeMode.CanResize || ResizeMode == ResizeMode.CanResizeWithGrip;
        }

        protected void OnMaximizeWindow(object sender, ExecutedRoutedEventArgs e)
        {
            SystemCommands.MaximizeWindow(this);
        }

        protected void OnCloseWindow(object sender, ExecutedRoutedEventArgs e)
        {
            SystemCommands.CloseWindow(this);
        }

        internal void SetIcon()
        {
            if (_logoContentControl != null)
            {
                Rect bounds = VisualTreeHelper.GetDescendantBounds(_logoContentControl);

                _logoContentControl.UpdateLayout();
                var rtb = new RenderTargetBitmap(
                    (int) bounds.Width, //width 
                    (int) bounds.Height, //height 
                    96, //dpi x 
                    96, //dpi y 
                    PixelFormats.Pbgra32 // pixelformat 
                    );



                var drawingVisual = new DrawingVisual
                {
                    Effect = new DropShadowEffect
                    {
                        Color = Colors.Black,
                        Direction = 315,
                        ShadowDepth = 4,
                        Opacity = 1
                    }
                };

                using (DrawingContext ctx = drawingVisual.RenderOpen())
                {
                    var visualBrush = new VisualBrush(_logoContentControl);
                    ctx.DrawRectangle(visualBrush, null, new Rect(new Point(), bounds.Size));
                }


                rtb.Render(drawingVisual);
                Icon = rtb;
            }
        }
    }
}
