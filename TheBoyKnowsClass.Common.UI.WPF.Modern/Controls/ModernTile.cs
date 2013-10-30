using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace TheBoyKnowsClass.Common.UI.WPF.Modern.Controls
{
    /// <summary>
    /// Follow steps 1a or 1b and then 2 to use this custom control in a XAML file.
    ///
    /// Step 1a) Using this custom control in a XAML file that exists in the current project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:TheBoyKnowsClass.Common.UI.WPF.Modern.Controls"
    ///
    ///
    /// Step 1b) Using this custom control in a XAML file that exists in a different project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:TheBoyKnowsClass.Common.UI.WPF.Modern.Controls;assembly=TheBoyKnowsClass.Common.UI.WPF.Modern.Controls"
    ///
    /// You will also need to add a project reference from the project where the XAML file lives
    /// to this project and Rebuild to avoid compilation errors:
    ///
    ///     Right click on the target project in the Solution Explorer and
    ///     "Add Reference"->"Projects"->[Browse to and select this project]
    ///
    ///
    /// Step 2)
    /// Go ahead and use your control in the XAML file.
    ///
    ///     <MyNamespace:ModernTile/>
    ///
    /// </summary>
    public class ModernTile : Button
    {
        static ModernTile()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ModernTile), new FrameworkPropertyMetadata(typeof(ModernTile)));
        }

        public ModernTile()
        {
            MouseDown += OnMouseDown;
        }

        private void OnMouseDown(object sender, MouseButtonEventArgs mouseButtonEventArgs)
        {
            Point clickPoint = mouseButtonEventArgs.GetPosition(this);
        }


        public new static readonly DependencyProperty ContentProperty = DependencyProperty.Register("Title", typeof(object), typeof(ModernTile), new PropertyMetadata(null, ContentPropertyChangedCallback));

        public new object Content
        {
            get { return GetValue(ContentProperty); }
            set { SetValue(ContentProperty, value); }
        }

        private static void ContentPropertyChangedCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
        {
            var tile = dependencyObject as ModernTile;

            if (tile != null)
            {
                ((Button) tile).Content = dependencyPropertyChangedEventArgs.NewValue;
            }
        }

        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register("Title", typeof(string), typeof(ModernTile), new PropertyMetadata(default(string)));

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public static readonly DependencyProperty CountProperty = DependencyProperty.Register("Count", typeof(string), typeof(ModernTile), new PropertyMetadata(default(string)));

        public string Count
        {
            get { return (string)GetValue(CountProperty); }
            set { SetValue(CountProperty, value); }
        }

        public static readonly DependencyProperty KeepDraggingProperty = DependencyProperty.Register("KeepDragging", typeof(bool), typeof(ModernTile), new PropertyMetadata(true));

        public bool KeepDragging
        {
            get { return (bool)GetValue(KeepDraggingProperty); }
            set { SetValue(KeepDraggingProperty, value); }
        }

        public static readonly DependencyProperty TiltFactorProperty =
            DependencyProperty.Register("TiltFactor", typeof(int), typeof(ModernTile), new PropertyMetadata(5));

        public int TiltFactor
        {
            get { return (Int32)GetValue(TiltFactorProperty); }
            set { SetValue(TiltFactorProperty, value); }
        }
    }
}
