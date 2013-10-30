using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Interactivity;
using TheBoyKnowsClass.Common.UI.Interfaces;
using DragDropEffects = System.Windows.DragDropEffects;
using DragEventArgs = System.Windows.DragEventArgs;

namespace TheBoyKnowsClass.Common.UI.WPF.Behaviours
{
    public class DropBehavior : Behavior<FrameworkElement>
    {
        //private Adorner _adorner;

        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.AllowDrop = true;
            AssociatedObject.PreviewDrop += AssociatedObjectPreviewDrop;
            AssociatedObject.PreviewDragEnter += AssociatedObjectPreviewDragEnter;
            AssociatedObject.PreviewDragOver += AssociatedObjectPreviewDragOver;
            AssociatedObject.PreviewDragLeave += AssociatedObjectPreviewDragLeave;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.AllowDrop = false;
            AssociatedObject.PreviewDrop -= AssociatedObjectPreviewDrop;
            AssociatedObject.PreviewDragEnter -= AssociatedObjectPreviewDragEnter;
            AssociatedObject.PreviewDragOver -= AssociatedObjectPreviewDragOver;
            AssociatedObject.PreviewDragLeave -= AssociatedObjectPreviewDragLeave;
        }

        #region Dependency Properties

        public static readonly DependencyProperty DropTypeProperty = DependencyProperty.Register("DropType", typeof(Type), typeof(DropBehavior), new PropertyMetadata(typeof(object)));

        public Type DropType
        {
            get { return (Type)GetValue(DropTypeProperty); }
            set { SetValue(DropTypeProperty, value); }
        }

        public static readonly DependencyProperty DropEffectsProperty = DependencyProperty.Register("DropEffects", typeof(DragDropEffects), typeof(DropBehavior), new FrameworkPropertyMetadata(DragDropEffects.All));

        public DragDropEffects DropEffects
        {
            get { return (DragDropEffects)GetValue(DropEffectsProperty); }
            set { SetValue(DropEffectsProperty, value); }
        }

        public static readonly DependencyProperty DropTemplateProperty = DependencyProperty.RegisterAttached("DropTemplate", typeof(DataTemplate), typeof(DropBehavior), new UIPropertyMetadata(null));

        public DataTemplate DropTemplate
        {
            get { return (DataTemplate)GetValue(DropTemplateProperty); }
            set { SetValue(DropTemplateProperty, value); }
        }

        #endregion

        private static void AssociatedObjectPreviewDragLeave(object sender, DragEventArgs e)
        {
            // TODO remove adorner

            e.Handled = false;
        }

        private void AssociatedObjectPreviewDragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DropType.FullName))
            {
                //give mouse effect
                e.Effects = DropEffects;
                e.Handled = true;
                // TODO add adorner
            }
            else
            {
                e.Effects = DragDropEffects.None;
                e.Handled = false;
            }
        }

        private void AssociatedObjectPreviewDragEnter(object sender, DragEventArgs e)
        {
            e.Handled = false;
        }

        private void AssociatedObjectPreviewDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DropType))
            {
                Debug.WriteLine("Drop started for item {0} to item {1}", e.Data.GetData(DropType), AssociatedObject.DataContext);

                var dropEndPoint = e.GetPosition(AssociatedObject);

                //drop the data
                var target = AssociatedObject.DataContext as IDropTarget;
                if (target != null)
                {
                    target.Drop(e.Data.GetData(DropType), null, dropEndPoint.X / AssociatedObject.ActualWidth, dropEndPoint.Y / AssociatedObject.ActualHeight);
                }

                //remove the data from the source is applicable
                var source = e.Data.GetData(DropType) as IDragMoveSource;
                if (source != null) source.Remove(e.Data.GetData(DropType)); 
            }

            //if (_adorner != null)
            //{
            //    // _adorner.Remove(); 
            //}
        }
    }
}
