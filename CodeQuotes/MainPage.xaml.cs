﻿using MaterialColorUtilities;
using System.Threading.Tasks;

namespace CodeQuotes
{

    public partial class MainPage : ContentPage
    {


        List<string> quotes =
            new List<string>();


        private readonly Random random = new();

        public MainPage()
        {
            InitializeComponent();
            LoadMauiAsset();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await LoadMauiAsset();

        }
        async Task LoadMauiAsset()
        {
            using var stream = await FileSystem.OpenAppPackageFileAsync("quotes.txt");
            using var reader = new StreamReader(stream);

            while (reader.Peek() != -1)
            {
                quotes.Add(reader.ReadLine());
            }
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

            int index = random.Next(quotes.Count);
            quote.Text = quotes[index];
            Console.WriteLine($"Neues Zitat: {quotes[index]}");
        }
    }
}
