using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace TheBoyKnowsClass.Common.UI.WPF.Helpers
{
    public static class WPFHelper
    {
        public static T GetVisualChild<T>(DependencyObject parent) where T : Visual
        {
            T child = default(T);

            int numVisuals = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < numVisuals; i++)
            {
                var v = (Visual)VisualTreeHelper.GetChild(parent, i);

                child = v as T ?? GetVisualChild<T>(v);

                if (child != null)
                {
                    break;
                }
            }
            return child;
        }

        public static UIElement FindCanvasChild(DependencyObject parent, Canvas canvas)
        {
            DependencyObject dependencyObject = parent;

            while (dependencyObject != null)
            {
                // If the current object is a UIElement which is a child of the
                // Canvas, exit the loop and return it.
                var elem = dependencyObject as UIElement;
                if (elem != null && canvas.Children.Contains(elem))
                {
                    break;
                }

                // VisualTreeHelper works with objects of type Visual or Visual3D.
                // If the current object is not derived from Visual or Visual3D,
                // then use the LogicalTreeHelper to find the parent element.
                if (dependencyObject is Visual || dependencyObject is Visual3D)
                {
                    dependencyObject = VisualTreeHelper.GetParent(dependencyObject);
                }
                else
                {
                    dependencyObject = LogicalTreeHelper.GetParent(dependencyObject);
                }
            }
            return dependencyObject as UIElement;
        }
    }

}
