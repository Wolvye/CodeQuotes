using Microsoft.Maui.Graphics;

namespace MaterialColorUtilities
{
    public static class ColorControls
    {
        public static List<Color> GetColorGradient(Color start, Color end, int steps)
        {
            var gradient = new List<Color>();
            for (int i = 0; i < steps; i++)
            {
                float ratio = (float)i / (steps - 1);
                float r = start.Red + (end.Red - start.Red) * ratio;
                float g = start.Green + (end.Green - start.Green) * ratio;
                float b = start.Blue + (end.Blue - start.Blue) * ratio;
                gradient.Add(new Color(r, g, b));
            }
            return gradient;
        }

    }
}
