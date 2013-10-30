using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interactivity;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace TheBoyKnowsClass.Common.UI.WPF.Behaviours
{
    public class DragElementCanvasBehavior : Behavior<Canvas>
    {
        private bool _isDragInProgress;
        private Point _dragStartPoint;
        private UIElement _elementBeingDragged;
        private double _origHorizOffset;
        private double _origVertOffset;
        private bool _modifyLeftOffset;
        private bool _modifyTopOffset;


        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.AllowDrop = true;
            AssociatedObject.PreviewMouseLeftButtonDown += AssociatedObjectPreviewMouseLeftButtonDown;
            AssociatedObject.PreviewMouseMove += AssociatedObjectPreviewMouseMove;
            AssociatedObject.PreviewMouseUp += AssociatedObjectPreviewMouseUp;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.PreviewMouseLeftButtonDown -= AssociatedObjectPreviewMouseLeftButtonDown;
            AssociatedObject.PreviewMouseMove -= AssociatedObjectPreviewMouseMove;
            AssociatedObject.PreviewMouseUp -= AssociatedObjectPreviewMouseUp;
        }

        #region Dependency Properties

        public static readonly DependencyProperty OffsetProperty = DependencyProperty.Register("Offset", typeof(Thickness), typeof(DragElementCanvasBehavior), new FrameworkPropertyMetadata(null));

        public Thickness Offset
        {
            get { return (Thickness)GetValue(OffsetProperty); }
            set { SetValue(OffsetProperty, value); }
        }

        #endregion


        private void AssociatedObjectPreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            // Reset the field whether the left or right mouse button was 
            // released, in case a context menu was opened on the drag element.
            _elementBeingDragged = null;
        }

        private void AssociatedObjectPreviewMouseMove(object sender, MouseEventArgs e)
        {
            // If no element is being dragged, there is nothing to do.
            if (_elementBeingDragged == null || !_isDragInProgress)
            {
                return;
            }

            // Get the position of the mouse cursor, relative to the Canvas.
            Point cursorLocation = e.GetPosition(AssociatedObject);

            // These values will store the new offsets of the drag element.
            double newHorizontalOffset, newVerticalOffset;

            #region Calculate Offsets

            // Determine the horizontal offset.
            if (_modifyLeftOffset)
            {
                newHorizontalOffset = _origHorizOffset + (cursorLocation.X - _dragStartPoint.X);
            }
            else
            {
                newHorizontalOffset = _origHorizOffset - (cursorLocation.X - _dragStartPoint.X);
            }

            // Determine the vertical offset.
            if (_modifyTopOffset)
            {
                newVerticalOffset = _origVertOffset + (cursorLocation.Y - _dragStartPoint.Y);
            }
            else
            {
                newVerticalOffset = _origVertOffset - (cursorLocation.Y - _dragStartPoint.Y);
            }

            #endregion // Calculate Offsets

            #region Verify Drag Element Location

            // Get the bounding rect of the drag element.
            Rect elemRect = CalculateDragElementRect(newHorizontalOffset, newVerticalOffset);

            //
            // If the element is being dragged out of the viewable area, 
            // determine the ideal rect location, so that the element is 
            // within the edge(s) of the canvas.
            //
            bool leftAlign = elemRect.Left < 0 + Offset.Left;
            bool rightAlign = elemRect.Right > AssociatedObject.ActualWidth + Offset.Right;

            if (leftAlign)
            {
                newHorizontalOffset = _modifyLeftOffset ? 0 + Offset.Left : AssociatedObject.ActualWidth + Offset.Left - elemRect.Width;
            }
            else if (rightAlign)
            {
                newHorizontalOffset = _modifyLeftOffset ? AssociatedObject.ActualWidth + Offset.Right - elemRect.Width : 0 + Offset.Right;
            }

            bool topAlign = elemRect.Top < Offset.Top;
            bool bottomAlign = elemRect.Bottom > AssociatedObject.ActualHeight + Offset.Bottom;

            if (topAlign)
                newVerticalOffset = _modifyTopOffset ? 0 + Offset.Top : AssociatedObject.ActualHeight + Offset.Top - elemRect.Height;
            else if (bottomAlign)
                newVerticalOffset = _modifyTopOffset ? AssociatedObject.ActualHeight + Offset.Bottom - elemRect.Height : 0 + Offset.Bottom;

            #endregion // Verify Drag Element Location
            

            #region Move Drag Element

            if (_modifyLeftOffset)
            {
                Canvas.SetLeft(_elementBeingDragged, newHorizontalOffset);
            }
            else
            {
                Canvas.SetRight(_elementBeingDragged, newHorizontalOffset);
            }

            if (_modifyTopOffset)
            {
                Canvas.SetTop(_elementBeingDragged, newVerticalOffset);
            }
            else
            {
                Canvas.SetBottom(_elementBeingDragged, newVerticalOffset);
            }

            #endregion // Move Drag Element
        }

        private void AssociatedObjectPreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _isDragInProgress = false;

            // Cache the mouse cursor location.
            _dragStartPoint = e.GetPosition(AssociatedObject);

            // Walk up the visual tree from the element that was clicked, 
            // looking for an element that is a direct child of the Canvas.
            _elementBeingDragged = FindCanvasChild(e.Source as DependencyObject);
            if (_elementBeingDragged == null)
            {
                return;
            }

            // Get the element's offsets from the four sides of the Canvas.
            double left = Canvas.GetLeft(_elementBeingDragged);
            double right = Canvas.GetRight(_elementBeingDragged);
            double top = Canvas.GetTop(_elementBeingDragged);
            double bottom = Canvas.GetBottom(_elementBeingDragged);

            // Calculate the offset deltas and determine for which sides
            // of the Canvas to adjust the offsets.
            _origHorizOffset = ResolveOffset(left, right, out _modifyLeftOffset);
            _origVertOffset = ResolveOffset(top, bottom, out _modifyTopOffset);

            // Set the Handled flag so that a control being dragged 
            // does not react to the mouse input.
            //e.Handled = false;

            _isDragInProgress = true;
        }

        private UIElement FindCanvasChild(DependencyObject depObj)
        {
            while (depObj != null)
            {
                // If the current object is a UIElement which is a child of the
                // Canvas, exit the loop and return it.
                var elem = depObj as UIElement;
                if (elem != null && AssociatedObject.Children.Contains(elem))
                {
                    break;
                }

                // VisualTreeHelper works with objects of type Visual or Visual3D.
                // If the current object is not derived from Visual or Visual3D,
                // then use the LogicalTreeHelper to find the parent element.
                if (depObj is Visual || depObj is Visual3D)
                {
                    depObj = VisualTreeHelper.GetParent(depObj);
                }
                else
                {
                    depObj = LogicalTreeHelper.GetParent(depObj);
                }
            }
            return depObj as UIElement;
        }

        private static double ResolveOffset(double side1, double side2, out bool useSide1)
        {
            useSide1 = true;
            double result;

            if (Double.IsNaN(side1))
            {
                if (Double.IsNaN(side2))
                {
                    result = 0;
                }
                else
                {
                    result = side2;
                    useSide1 = false;
                }
            }
            else
            {
                result = side1;
            }

            return result;
        }

        /// <summary>
        /// Returns a Rect which describes the bounds of the element being dragged.
        /// </summary>
        private Rect CalculateDragElementRect(double newHorizOffset, double newVertOffset)
        {
            if (_elementBeingDragged == null)
            {
                throw new InvalidOperationException("ElementBeingDragged is null.");
            }

            Size size = _elementBeingDragged.RenderSize;

            double x, y;

            if (_modifyLeftOffset)
            {
                x = newHorizOffset;
            }
            else
            {
                x = AssociatedObject.ActualWidth - newHorizOffset - size.Width;
            }

            if (_modifyTopOffset)
            {
                y = newVertOffset;
            }
            else
            {
                y = AssociatedObject.ActualHeight - newVertOffset - size.Height;
            }

            var elemLoc = new Point(x, y);
            return new Rect(elemLoc, size);
        }

    }
}
