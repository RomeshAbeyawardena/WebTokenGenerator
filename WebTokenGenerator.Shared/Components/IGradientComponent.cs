using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebTokenGenerator.Shared.Components
{
    public interface IGradientComponent
    {
        float Angle { get; set; }
        Color BackgroundColour1 { get; set; }
        Color BackgroundColour2 { get; set; }
        Color BorderColour { get; set; }
    }
}
