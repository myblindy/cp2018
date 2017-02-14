using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;

namespace cp2018.Adorners
{
    class DesignAdorner : Adorner
    {
        public DesignAdorner(UIElement element)
            : base(element)
        {
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            var rect = new Rect(AdornedElement.RenderSize);

            // Some arbitrary drawing implements.
            var brush = new SolidColorBrush(Colors.Green) { Opacity = .2 };
            var pen = new Pen(new SolidColorBrush(Colors.Navy), 1.5);
            const double radius = 5.0;

            // Draw a circle at each corner.
            drawingContext.DrawEllipse(brush, pen, rect.BottomLeft, radius, radius);
            drawingContext.DrawEllipse(brush, pen, rect.BottomRight, radius, radius);
        }
    }
}
