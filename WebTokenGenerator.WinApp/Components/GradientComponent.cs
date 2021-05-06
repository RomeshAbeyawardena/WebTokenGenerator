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
        public GradientComponent(TControl control)
        {
            BaseControl = control;
        }

        private float linearGradientAngle = 90;
        private Color borderColour = SystemColors.ButtonShadow;
        private Color backgroundColour1 = SystemColors.Control;
        private Color backgroundColour2 = SystemColors.Window;

        public Color BorderColour
        {
            get => borderColour;
            set => UpdateProperty(ref borderColour, value);
        }

        public float Angle
        {
            get => linearGradientAngle;
            set => UpdateProperty(ref linearGradientAngle, value);
        }

        public Color BackgroundColour1
        {
            get => backgroundColour1;
            set => UpdateProperty(ref backgroundColour1, value);
        }

        public Color BackgroundColour2
        {
            get => backgroundColour2;
            set => UpdateProperty(ref backgroundColour2, value);
        }

        public LinearGradientBrush GetLinearGradientBrush(Rectangle clipRectangle,
            Color backgroundColour1, Color backgroundColour2, float angle, bool isScalable)
        {
            return new LinearGradientBrush(clipRectangle, backgroundColour1, 
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
                BackgroundColour1, BackgroundColour2, Angle, true);

            pevent.Graphics.FillRectangle(linearGradientBrush, clipRectangle);

            var rect = new Rectangle(clipRectangle.Location, new Size(clipRectangle.Width - 1, clipRectangle.Height - 1));

            pevent.Graphics
                .DrawRectangle(GetBorderPen(BorderColour), rect) ;

            TextRenderer.DrawText(pevent.Graphics, BaseControl.Text, BaseControl.Font, clipRectangle, BaseControl.ForeColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }

        public void UpdateProperty<T>(ref T backingProperty, T newValue)
        {
            backingProperty = newValue;
            BaseControl.Refresh();
        }

        public TControl BaseControl { get; }
    }
}
