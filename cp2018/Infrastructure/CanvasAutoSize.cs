using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace cp2018.Infrastructure
{
    class CanvasAutoSize : Canvas
    {
        protected override Size MeasureOverride(Size constraint)
        {
            base.MeasureOverride(constraint);

            double maxw = 0, maxh = 0;

            foreach (UIElement element in InternalChildren)
            {
                var w = element.DesiredSize.Width + (double)element.GetValue(LeftProperty);
                var h = element.DesiredSize.Height + (double)element.GetValue(TopProperty);

                if (maxw < w) maxw = w;
                if (maxh < h) maxh = h;
            }

            return new Size(maxw, maxh);
        }
    }
}
