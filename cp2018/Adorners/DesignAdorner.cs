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

            //BottomLeftThumb.DragDelta+=(_, e)=>
        }

        private void AddThumbCorner(ref Thumb thumb, Cursor cursor) =>
            VisualCollection.Add(thumb = new Thumb
            {
                Cursor = cursor,
                Height = 10,
                Width = 10,
            });

        protected override Size ArrangeOverride(Size finalSize)
        {
            var adornedwidth = AdornedElement.DesiredSize.Width;
            var adornedheight = AdornedElement.DesiredSize.Height;

            var adornerwidth = DesiredSize.Width;
            var adornerheight = DesiredSize.Height;

            BottomLeftThumb.Arrange(new Rect(0, adornerheight - BottomLeftThumb.Height, 
                BottomLeftThumb.Width, BottomLeftThumb.Height));
            BottomRightThumb.Arrange(new Rect(adornerwidth - BottomRightThumb.Width, adornerheight - BottomRightThumb.Height,
                BottomRightThumb.Width, BottomRightThumb.Height));

            return finalSize;
        }

        protected override int VisualChildrenCount => VisualCollection.Count;

        protected override Visual GetVisualChild(int index) => VisualCollection[index];
    }
}
