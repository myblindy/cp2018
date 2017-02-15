using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

namespace cp2018.Adorners
{
    class DesignAdorner : Adorner
    {
        private Thumb BottomLeftThumb, BottomRightThumb;
        private VisualCollection VisualCollection;

        public DesignAdorner(UIElement element)
            : base(element)
        {
            VisualCollection = new VisualCollection(this);
            AddThumbCorner(ref BottomLeftThumb, Cursors.SizeNESW);
            AddThumbCorner(ref BottomRightThumb, Cursors.SizeNWSE);
        }

        private void AddThumbCorner(ref Thumb thumb, Cursor cursor) =>
            VisualCollection.Add(new Thumb
            {
                Cursor = cursor,
                Height = 10,
                Width = 10,
                Opacity = .4,
                Background = Brushes.White
            });

        protected override Size ArrangeOverride(Size finalSize)
        {
            return base.ArrangeOverride(finalSize);
        }

        //protected override void OnRender(DrawingContext drawingContext)
        //{
        //    var rect = new Rect(AdornedElement.RenderSize);

        //    // Some arbitrary drawing implements.
        //    var brush = new SolidColorBrush(Colors.Green) { Opacity = .2 };
        //    var pen = new Pen(new SolidColorBrush(Colors.Navy), 1.5);
        //    const double radius = 5.0;

        //    // Draw a circle at each corner.
        //    drawingContext.DrawEllipse(brush, pen, rect.BottomLeft, radius, radius);
        //    drawingContext.DrawEllipse(brush, pen, rect.BottomRight, radius, radius);
        //}
    }
}
