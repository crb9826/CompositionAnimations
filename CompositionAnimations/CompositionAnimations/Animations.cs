using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Composition;
using Windows.UI.Xaml.Hosting;
using Windows.UI.Xaml;
using System.Numerics;
namespace CompositionAnimations
{
    /// <summary>
    /// Create composition animations using this class
    /// </summary>
    public static class Animations
    {

        public static void Animate(this UIElement element, string propertyPath, float value, TimeSpan duration, TimeSpan delay, Vector2 bezierControlPoint1, Vector2 bezierControlPoint2)
        {
            // Animate the UIElement's underlying visual
            Animate(ElementCompositionPreview.GetElementVisual(element), propertyPath, value, duration, delay, bezierControlPoint1, bezierControlPoint2);
        }

        public static void Animate(CompositionObject compObject, string propertyPath, float value, TimeSpan duration, TimeSpan delay)
        {
            Animate(compObject, propertyPath, value, duration, delay, compObject.Compositor.CreateLinearEasingFunction());
        }

        public static void Animate(CompositionObject compObject, string propertyPath, float value, TimeSpan duration, TimeSpan delay, Vector2 bezierControlPoint1, Vector2 bezierControlPoint2)
        {
            Animate(compObject, propertyPath, value, duration, delay, compObject.Compositor.CreateCubicBezierEasingFunction(bezierControlPoint1, bezierControlPoint2));
        }

        public static void Animate(CompositionObject compObject, string propertyPath, float value, TimeSpan duration, TimeSpan delay, CompositionEasingFunction ease)
        {
            // Create a float animation, set its properties based on the provided arguments
            var scalarAni = compObject.Compositor.CreateScalarKeyFrameAnimation();
            scalarAni.Duration = duration;
            scalarAni.DelayTime = delay;
            if (ease != null)
            {
                scalarAni.InsertKeyFrame(1, value, ease);
            }
            else
            {
                scalarAni.InsertKeyFrame(1, value);
            }
            compObject.StartAnimation(propertyPath, scalarAni);
        }
    }
}
