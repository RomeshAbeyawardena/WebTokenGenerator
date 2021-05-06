using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebTokenGenerator.WinApp.Components
{
    public class GradientButton : Button
    {
        private float linearGradientAngle = 90;
        private Color borderColour = SystemColors.ButtonShadow;
        private Color backgroundColour1 = SystemColors.Control;
        private Color backgroundColour2 = SystemColors.Window;
        private bool mouseDown = false;
        public GradientButton()
        {

        }

        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            mouseDown = true;
            base.OnMouseDown(mevent);
        }

        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            mouseDown = false;
            base.OnMouseUp(mevent);
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            var clipRectangle = pevent.ClipRectangle;
            var linearGradientBrush = new LinearGradientBrush(clipRectangle, BackgroundColour1, BackgroundColour2, mouseDown ? -Angle : Angle, true);
            pevent.Graphics.FillRectangle(linearGradientBrush, clipRectangle);
            
            pevent.Graphics.DrawRectangle(new Pen(Focused ? SystemColors.ActiveBorder : BorderColour), new Rectangle(clipRectangle.Location, new Size(clipRectangle.Width - 1, clipRectangle.Height - 1)));
            TextRenderer.DrawText(pevent.Graphics, Text, Font, clipRectangle, Enabled ? ForeColor : SystemColors.InactiveCaption, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }

        public Color BorderColour { 
            get => borderColour;
            set => UpdateProperty(ref borderColour, value);
        }

        public float Angle { 
            get => linearGradientAngle;
            set => UpdateProperty(ref linearGradientAngle, value); 
        }

        public Color BackgroundColour1 { 
            get => backgroundColour1; 
            set => UpdateProperty(ref backgroundColour1, value); 
        }
        public Color BackgroundColour2 { 
            get => backgroundColour2; 
            set => UpdateProperty(ref backgroundColour2, value); 
        }

        private void UpdateProperty<T>(ref T backingProperty, T newValue)
        {
            backingProperty = newValue;
            Refresh();
        }
    }
}
