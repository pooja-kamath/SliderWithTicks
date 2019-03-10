using System;
using CoreGraphics;
using SliderWithTicks;
using SliderWithTicks.iOS;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomSlider), typeof(CustomSliderRenderer))]
namespace SliderWithTicks.iOS
{
    public class CustomSliderRenderer:SliderRenderer
    {
        public CustomSliderRenderer()
        {
        }
        protected override void OnElementChanged(ElementChangedEventArgs<Slider> e)
        {
            base.OnElementChanged(e);
           // Control.SetThumbImage(new UIImage("ic_arrow_drop_down_circle.png"),UIControlState.Normal);
        }


    }

   
}
