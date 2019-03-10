using System;
using System.Linq;
using System.Runtime.Remoting.Channels;
using Xamarin.Forms;

namespace SliderWithTicks
{
    public partial class AboutPage : ContentPage
    {
        private readonly int SliderMaxValue = 150;
        private readonly int SliderMinValue = 0;
        private readonly int SliderStepSize = 5;
        private readonly int SliderTickWidth = 2;
        private readonly int SliderTickHeight = 2;

        public AboutPage()
        {
            InitializeComponent();

            slider.Maximum = SliderMaxValue;
            slider.Minimum = SliderMinValue;

            stack.Orientation = StackOrientation.Horizontal;

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            AddTickMarksForSlider(stack);
            slider.ValueChanged += (sender, e) =>
            {
                double StepValue = SliderStepSize;

                var newStep = Math.Round(e.NewValue / StepValue);

                slider.Value = newStep * StepValue;
            };

        }

        public void PlusButtonClicked(object sender, EventArgs args)
        {
            slider.Value = slider.Value + SliderStepSize;
        }

        public void MinusButtonClicked(object sender, EventArgs args)
        {
            slider.Value = slider.Value - SliderStepSize;
        }
        public void AddTickMarksForSlider(StackLayout view)
        {
            int ticksDivider = SliderStepSize;
            int ticks = (int)slider.Maximum / ticksDivider;

            view.BackgroundColor = Color.Transparent;

            // make a UIImageView with tick for each tick in the slider
            for (int i = 0; i <= ticks; i++)
            {

                Label tick = new Label();
                tick.WidthRequest = SliderTickWidth;
                tick.HeightRequest = SliderTickHeight;

                view.Padding = new Thickness(15, 0, 14, 0);

                tick.Margin = new Thickness(GetOffsetFor(i), 0, 0, 0);

                tick.BackgroundColor = Color.Red;

                view.Children.Add(tick);

            }
        }

        private double GetOffsetFor(int index)
        {
            if (index == 0)
                return 0.0;
            else if (GetSeries().Contains(index))
                return 3.5;
            else
                return 2.5;
        }

        private int[] GetSeries()
        {
            int[] series = new int[13];
            int[] buffer = new[] { 0, 0, 1, 1, 1, 2, 2, 1, 2, 3, 3, 3, 3 };
            for (int i = 0; i <= 12; i++)
            {
                series[i] = 2 * i + buffer[i];
            }

            return series;
        }

    }
}
