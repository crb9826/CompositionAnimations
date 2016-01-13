using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Composition;
using System.Numerics;
using Windows.UI.Xaml.Hosting;
using Windows.UI.Xaml;

namespace Windows.UI.Composition
{
    public static class Extensions
    {
        public static Visual GetVisual(this UIElement element)
        {
            return ElementCompositionPreview.GetElementVisual(element);
        }
    }
}
