using MaterialColorUtilities;

namespace CodeQuotes
{
    public partial class MainPage : ContentPage
    {
        private readonly Random random = new();

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object? sender, EventArgs e)
        {
        }

        private void btnGenerateQoute_Clicked(object sender, EventArgs e)
        {
            var startColor = new Color(
                                 (float)random.NextDouble(),
                                 (float)random.NextDouble(),
                                 (float)random.NextDouble());

            var endColor = new Color(
                                (float)random.NextDouble(),
                                (float)random.NextDouble(),
                                (float)random.NextDouble());


            var colors = ColorControls.GetColorGradient(startColor, endColor, 6);



            float stopOffset = .0f;
            var stops = new GradientStopCollection();

            foreach (var c in colors)
            {
                stops.Add(new GradientStop(c, stopOffset));
                stopOffset += .2f;
            }

            var gradient =
                new LinearGradientBrush(stops,
                new Point(0, 0),
                new Point(1, 1));

            background.Background = gradient;
        }
    }
}
