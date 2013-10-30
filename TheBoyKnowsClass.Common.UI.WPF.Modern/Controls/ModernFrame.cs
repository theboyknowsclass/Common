using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using TheBoyKnowsClass.Common.UI.WPF.Modern.Enumerations;
using TheBoyKnowsClass.Common.UI.WPF.Modern.Interfaces;

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
    ///     <MyNamespace:ModernFrame/>
    ///
    /// </summary>
    public class ModernFrame : Frame
    {
        private VisualBrush _lastPageBrush;
        private Canvas _transitions;
        private ContentPresenter _frame;
        private SlideDirection _slideDirection;

        static ModernFrame()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ModernFrame), new FrameworkPropertyMetadata(typeof(ModernFrame)));
        }

        public ModernFrame()
        {
            Navigated += OnNavigated;
            Navigating += OnNavigating;
            Loaded += OnLoaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            _transitions = Template.FindName("PART_Transitions", this) as Canvas;
            _frame = Template.FindName("PART_FrameCP", this) as ContentPresenter;
        }

        private void OnNavigated(object sender, NavigationEventArgs navigationEventArgs)
        {
            var slideDirection = (SlideDirection?)navigationEventArgs.ExtraData;

            _slideDirection = slideDirection ?? SlideDirection.LeftToRight;

            if (_lastPageBrush != null)
            {
                BeginAnimateContentReplacement();
            }
        }

        private void OnNavigating(object sender, NavigatingCancelEventArgs navigatingCancelEventArgs)
        {
            var page = Content as IModernPage;

            if (page != null)
            {
                page.OnNavigating(navigatingCancelEventArgs);
            }

            var lastPage = Content as FrameworkElement;

            if (lastPage != null)
            {
                _lastPageBrush = new VisualBrush(lastPage)
                {
                    Viewbox = new Rect(0, 0, lastPage.ActualWidth, lastPage.ActualHeight),
                    ViewboxUnits = BrushMappingMode.Absolute,
                    Stretch = Stretch.None
                };
            }
            else
            {
                _lastPageBrush = null;
            }
        }

        private void BeginAnimateContentReplacement()
        {
            var newContentTransform = new TranslateTransform();
            var oldContentTransform = new TranslateTransform();

            _transitions.Background = _lastPageBrush;
            _transitions.RenderTransform = oldContentTransform;
            _frame.RenderTransform = newContentTransform;
            _transitions.Visibility = Visibility.Visible;

            if (_slideDirection == SlideDirection.RightToLeft)
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
