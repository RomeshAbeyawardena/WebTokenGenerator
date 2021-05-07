using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebTokenGenerator.Shared.Components;

namespace WebTokenGenerator.WinApp.Components
{
    public class GradientComponent<TControl>
        where TControl : Control, IGradientComponent
    {
        private readonly Func<Rectangle, Color, Color, float, bool, LinearGradientBrush> linearGradientBrush;

        public GradientComponent(TControl control,
            Func<Rectangle, Color, Color, float, bool, LinearGradientBrush> linearGradientBrush = default)
        {
            BaseControl = control;
            this.linearGradientBrush = linearGradientBrush;
        }

        public LinearGradientBrush GetLinearGradientBrush(Rectangle clipRectangle,
            Color backgroundColour1, Color backgroundColour2, float angle, bool isScalable)
        {
            return linearGradientBrush?.Invoke(clipRectangle, backgroundColour1, backgroundColour2, angle, isScalable) 
                ?? new LinearGradientBrush(clipRectangle, backgroundColour1, 
                backgroundColour2, angle, isScalable);
        }

        public Pen GetBorderPen(Color color)
        {
            return new Pen(color);
        }

        public void PaintGradientComponent(PaintEventArgs pevent)
        {
            var clipRectangle = pevent.ClipRectangle;
            var linearGradientBrush = GetLinearGradientBrush(clipRectangle,
                BaseControl.BackgroundColour1, BaseControl.BackgroundColour2, 
                BaseControl.Angle, true);

            pevent.Graphics.FillRectangle(linearGradientBrush, clipRectangle);

            var rect = new Rectangle(clipRectangle.Location, new Size(clipRectangle.Width - 1, clipRectangle.Height - 1));

            pevent.Graphics
                .DrawRectangle(GetBorderPen(BaseControl.BorderColour), rect) ;

            TextRenderer.DrawText(pevent.Graphics, BaseControl.Text, BaseControl.Font, clipRectangle, 
                BaseControl.ForeColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }

        public void UpdateProperty<T>(ref T backingProperty, T newValue)
        {
            backingProperty = newValue;
            BaseControl.Refresh();
        }

        public TControl BaseControl { get; }
    }
}
