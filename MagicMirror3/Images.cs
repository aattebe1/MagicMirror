/* 
 * Images.cs
 * 
 * Author: Austin Atteberry
 * 
 * Description: Initializes the embedded
 *              image resources
 * 
 */

namespace GUI
{
	public static class Images
    {
        public static System.Drawing.Bitmap[] WeatherImages = new System.Drawing.Bitmap[]
        {
            new System.Drawing.Bitmap(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("MagicMirror3.Images.default.gif")),
            new System.Drawing.Bitmap(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("MagicMirror3.Images.01d.gif")),
            new System.Drawing.Bitmap(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("MagicMirror3.Images.01n.gif")),
            new System.Drawing.Bitmap(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("MagicMirror3.Images.02d.gif")),
            new System.Drawing.Bitmap(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("MagicMirror3.Images.02n.gif")),
            new System.Drawing.Bitmap(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("MagicMirror3.Images.03d.gif")),
            new System.Drawing.Bitmap(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("MagicMirror3.Images.03n.gif")),
            new System.Drawing.Bitmap(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("MagicMirror3.Images.04d.gif")),
            new System.Drawing.Bitmap(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("MagicMirror3.Images.04n.gif")),
            new System.Drawing.Bitmap(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("MagicMirror3.Images.09d.gif")),
            new System.Drawing.Bitmap(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("MagicMirror3.Images.09n.gif")),
            new System.Drawing.Bitmap(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("MagicMirror3.Images.10d.gif")),
            new System.Drawing.Bitmap(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("MagicMirror3.Images.10n.gif")),
            new System.Drawing.Bitmap(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("MagicMirror3.Images.11d.gif")),
            new System.Drawing.Bitmap(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("MagicMirror3.Images.11n.gif")),
            new System.Drawing.Bitmap(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("MagicMirror3.Images.13d.gif")),
            new System.Drawing.Bitmap(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("MagicMirror3.Images.13n.gif")),
            new System.Drawing.Bitmap(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("MagicMirror3.Images.50d.gif")),
            new System.Drawing.Bitmap(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("MagicMirror3.Images.50n.gif"))
        };

        public static System.Drawing.Bitmap[] SensorImages = new System.Drawing.Bitmap[]
        {
            new System.Drawing.Bitmap(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("MagicMirror3.Images.door1.gif")),
            new System.Drawing.Bitmap(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("MagicMirror3.Images.door2.gif")),
            new System.Drawing.Bitmap(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("MagicMirror3.Images.window1.gif")),
            new System.Drawing.Bitmap(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("MagicMirror3.Images.window2.gif")),
            new System.Drawing.Bitmap(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("MagicMirror3.Images.motion1.gif")),
            new System.Drawing.Bitmap(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("MagicMirror3.Images.motion2.gif")),
            new System.Drawing.Bitmap(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("MagicMirror3.Images.fire1.gif")),
            new System.Drawing.Bitmap(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("MagicMirror3.Images.fire2.gif"))
        };
    }
}