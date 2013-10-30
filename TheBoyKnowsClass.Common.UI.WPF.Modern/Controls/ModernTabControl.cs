using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

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
    ///     <MyNamespace:ModernTabControl/>
    ///
    /// </summary>
    public class ModernTabControl : TabControl
    {
        private int _lastSelectedIndex;

        private Canvas _transitions;
        private ContentPresenter _contentPresenter;


        static ModernTabControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ModernTabControl), new FrameworkPropertyMetadata(typeof(ModernTabControl)));
        }


        public ModernTabControl()
        {
            SelectionChanged += ModernTabControlSelectionChanged;
            Loaded += OnLoaded;

        }

        private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            ApplyTemplate();
            _transitions = Template.FindName("PART_Transitions", this) as Canvas;
            _contentPresenter = Template.FindName("PART_Content", this) as ContentPresenter;
        }

        void ModernTabControlSelectionChanged(object sender, SelectionChangedEventArgs selectionChangedEventArgs)
        {
            TabItem lastPage = null;
            VisualBrush lastPageBrush = null;

            if (selectionChangedEventArgs.RemovedItems.Count > 0)
            {
                lastPage = selectionChangedEventArgs.RemovedItems[0] as TabItem;
            }

            if (lastPage != null)
            {
                var lastPageContent = lastPage.Content as FrameworkElement;

                if (lastPageContent != null)
                {
                    lastPageBrush = new VisualBrush(lastPageContent)
                    {
                        Viewbox = new Rect(0, 0, lastPageContent.ActualWidth, lastPageContent.ActualHeight),
                        ViewboxUnits = BrushMappingMode.Absolute,
                        Stretch = Stretch.None
                    };
                }
            }

            //TabItem currentPage = null;
            //VisualBrush currentPageBrush;

            //if (selectionChangedEventArgs.AddedItems.Count > 0)
            //{
            //    currentPage = selectionChangedEventArgs.AddedItems[0] as TabItem;
            //}

            //if (currentPage != null)
            //{
            //    var currentPageContent = currentPage.Content as FrameworkElement;

            //    if (currentPageContent != null)
            //    {
            //        currentPageBrush = new VisualBrush(currentPageContent)
            //        {
            //            Viewbox = new Rect(0, 0, currentPageContent.ActualWidth, currentPageContent.ActualHeight),
            //            ViewboxUnits = BrushMappingMode.Absolute,
            //            Stretch = Stretch.None
            //        };
            //    }
            //}
            //else
            //{
            //    currentPageBrush = null;
            //}

            if (lastPageBrush != null)
            {
                var newContentTransform = new TranslateTransform();
                var oldContentTransform = new TranslateTransform();

                _transitions.Background = lastPageBrush;
                _transitions.RenderTransform = oldContentTransform;
                _contentPresenter.RenderTransform = newContentTransform;
                _transitions.Visibility = Visibility.Visible;

                if (_lastSelectedIndex < SelectedIndex)
                {
                    newContentTransform.BeginAnimation(TranslateTransform.XProperty, CreateAnimation(ActualWidth, 0));
                    oldContentTransform.BeginAnimation(TranslateTransform.XProperty, CreateAnimation(0, -ActualWidth, (s, e) => _transitions.Visibility = Visibility.Hidden));
                }
                else
                {
                    newContentTransform.BeginAnimation(TranslateTransform.XProperty, CreateAnimation(-ActualWidth, 0));
                    oldContentTransform.BeginAnimation(TranslateTransform.XProperty, CreateAnimation(0, ActualWidth, (s, e) => _transitions.Visibility = Visibility.Hidden));
                }
            }

            if (Equals(selectionChangedEventArgs.OriginalSource, this))
            {
                _lastSelectedIndex = SelectedIndex;
            }

        }

        /// <summary>
        /// Creates the animation that moves content in or out of view.
        /// </summary>
        /// <param name="from">The starting value of the animation.</param>
        /// <param name="to">The end value of the animation.</param>
        /// <param name="whenDone">(optional)
        ///   A callback that will be called when the animation has completed.</param>
        private AnimationTimeline CreateAnimation(double from, double to, EventHandler whenDone = null)
        {
            IEasingFunction easingFunction = new BackEase { Amplitude = 0.1, EasingMode = EasingMode.EaseInOut };
            var duration = new Duration(TimeSpan.FromSeconds(0.5));
            var animation = new DoubleAnimation(from, to, duration) { EasingFunction = easingFunction };
            if (whenDone != null)
            {
                animation.Completed += whenDone;
            }
            animation.Freeze();
            return animation;
        }   
    }
}
