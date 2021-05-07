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
    public class GradientButton : Button, IGradientComponent
    {
        private float linearGradientAngle = 90;
        private Color borderColour = SystemColors.ButtonShadow;
        private Color backgroundColour1 = SystemColors.Control;
        private Color backgroundColour2 = SystemColors.Window;
        private bool mouseDown = false;
        private GradientComponent<GradientButton> gradientComponent;

        public GradientButton()
            : this(null)
        {

        }

        public GradientButton(GradientComponent<GradientButton> gradientComponent = default)
        {
            this.gradientComponent = gradientComponent 
                ?? new GradientComponent<GradientButton>(this, GetLinearGradient);
        }

        private LinearGradientBrush GetLinearGradient(Rectangle clipRectangle, Color backgroundColour1, 
            Color backgroundColour2, float angle, bool arg5)
        {
            return new LinearGradientBrush(clipRectangle, backgroundColour1, backgroundColour2, 
                mouseDown ? -angle : angle, true);
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

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            gradientComponent
                .PaintGradientComponent(pevent);

            TextRenderer.DrawText(pevent.Graphics, Text, Font, pevent.ClipRectangle,
                ForeColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }

        public Color BorderColour { 
            get => borderColour;
            set => gradientComponent
                .UpdateProperty(ref borderColour, value);
        }

        public float Angle { 
            get => linearGradientAngle;
            set => gradientComponent.
                UpdateProperty(ref linearGradientAngle, value); 
        }

        public Color BackgroundColour1 { 
            get => backgroundColour1; 
            set => gradientComponent.
                UpdateProperty(ref backgroundColour1, value); 
        }
        public Color BackgroundColour2 { 
            get => backgroundColour2; 
            set => gradientComponent.
                UpdateProperty(ref backgroundColour2, value); 
        }
    }
}
