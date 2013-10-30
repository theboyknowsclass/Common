using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interactivity;
using TheBoyKnowsClass.Common.UI.Interfaces;

namespace TheBoyKnowsClass.Common.UI.WPF.Behaviours
{
    public class DragBehavior : Behavior<FrameworkElement>
    {
        private Point? _dragStartPoint;
        private Adorner _draggedAdorner;

        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.PreviewMouseLeftButtonDown -= AssociatedObjectPreviewMouseLeftButtonDown;
            AssociatedObject.PreviewMouseMove -= AssociatedObjectPreviewMouseMove;
            AssociatedObject.PreviewMouseUp -= AssociatedObjectPreviewMouseUp;
        }

        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.AllowDrop = true;
            AssociatedObject.PreviewMouseLeftButtonDown += AssociatedObjectPreviewMouseLeftButtonDown;
            AssociatedObject.PreviewMouseMove += AssociatedObjectPreviewMouseMove;
            AssociatedObject.PreviewMouseUp += AssociatedObjectPreviewMouseUp;
        }

        #region Dependency Properties

        public static readonly DependencyProperty DragEffectsProperty = DependencyProperty.Register("DragEffects", typeof(DragDropEffects), typeof(DragBehavior), new FrameworkPropertyMetadata(DragDropEffects.All));

        public DragDropEffects DragEffects
        {
            get { return (DragDropEffects)GetValue(DragEffectsProperty); }
            set { SetValue(DragEffectsProperty, value); }
        }

        public static readonly DependencyProperty DragTemplateProperty = DependencyProperty.RegisterAttached("DragTemplate", typeof(DataTemplate), typeof(DragBehavior), new UIPropertyMetadata(null));

        public DataTemplate DragTemplate
        {
            get { return (DataTemplate)GetValue(DragTemplateProperty); }
            set { SetValue(DragTemplateProperty, value); }
        }

        #endregion

        private void AssociatedObjectPreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _dragStartPoint = e.GetPosition(null);
        }

        private void AssociatedObjectPreviewMouseMove(object sender, MouseEventArgs e)
        {
            if (_dragStartPoint.HasValue)
            {
                bool horizontalGesture = Math.Abs(e.GetPosition(null).X - _dragStartPoint.Value.X) > SystemParameters.MinimumHorizontalDragDistance;
                bool verticalGesture = Math.Abs(e.GetPosition(null).Y - _dragStartPoint.Value.Y) > SystemParameters.MinimumVerticalDragDistance;

                if (horizontalGesture || verticalGesture)
                {
                    //Mouse.Capture(AssociatedObject);

                    var dragObject = AssociatedObject.DataContext as IDragable;
                    if (dragObject != null)
                    {
                        Debug.WriteLine("Drag started for item {0}", AssociatedObject.DataContext);



                        IsDragging = true;
                        var data = new DataObject();
                        data.SetData(dragObject.DataType, dragObject);
                        DragDrop.DoDragDrop(AssociatedObject, data, DragEffects);
                        IsDragging = false;

                        //if (_adorner == null)
                        //{
                        //    var adornerLayer = AdornerLayer.GetAdornerLayer(AssociatedObject);
                        //    _adorner = new DragDropPreviewAdorner(AssociatedObject, data, DragDropTemplate, adornerLayer);
                        //}

                        //advisor.FinishDrag(_draggedElement, effects);
                        //// Clean up
                        //RemovePreviewAdorner();

                    }

                    //Mouse.Capture(null);
                } 
            }
        }

        protected bool IsDragging
        {
            get; set;
        }

        private void AssociatedObjectPreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            _dragStartPoint = null;
            //Mouse.Capture(null);
        }

        private void ShowDraggedAdorner(Point currentPosition)
        {
            //if (_draggedAdorner == null)
            //{
            //    var adornerLayer = AdornerLayer.GetAdornerLayer(AssociatedObject);
            //    _draggedAdorner = new DraggedAdorner(draggedData, GetDragDropTemplate(sourceItemsControl), sourceItemContainer, adornerLayer);
            //}
            //_draggedAdorner.SetPosition(currentPosition.X - _dragStartPoint.Value.X + _dragStartPoint.Value.X, currentPosition.Y - _dragStartPoint.Value.Y + _dragStartPoint.Value.Y);
        }

        private void RemoveDraggedAdorner()
        {
            //if (_draggedAdorner != null)
            //{
            //    _draggedAdorner.Detach();
            //    _draggedAdorner = null;
            //}
        }
    }
}
