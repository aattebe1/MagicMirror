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
        public static System.Drawing.Bitmap[] WeatherImages()
        {
            System.Reflection.Assembly weatherAssembly = System.Reflection.Assembly.GetExecutingAssembly();
            System.Drawing.Bitmap[] images = new System.Drawing.Bitmap[19];

            images[0] = new System.Drawing.Bitmap(weatherAssembly.GetManifestResourceStream("MagicMirror.Images.default.gif"));
            images[1] = new System.Drawing.Bitmap(weatherAssembly.GetManifestResourceStream("MagicMirror.Images.01d.gif"));
            images[2] = new System.Drawing.Bitmap(weatherAssembly.GetManifestResourceStream("MagicMirror.Images.01n.gif"));
            images[3] = new System.Drawing.Bitmap(weatherAssembly.GetManifestResourceStream("MagicMirror.Images.02d.gif"));
            images[4] = new System.Drawing.Bitmap(weatherAssembly.GetManifestResourceStream("MagicMirror.Images.02n.gif"));
            images[5] = new System.Drawing.Bitmap(weatherAssembly.GetManifestResourceStream("MagicMirror.Images.03d.gif"));
            images[6] = new System.Drawing.Bitmap(weatherAssembly.GetManifestResourceStream("MagicMirror.Images.03n.gif"));
            images[7] = new System.Drawing.Bitmap(weatherAssembly.GetManifestResourceStream("MagicMirror.Images.04d.gif"));
            images[8] = new System.Drawing.Bitmap(weatherAssembly.GetManifestResourceStream("MagicMirror.Images.04n.gif"));
            images[9] = new System.Drawing.Bitmap(weatherAssembly.GetManifestResourceStream("MagicMirror.Images.09d.gif"));
            images[10] = new System.Drawing.Bitmap(weatherAssembly.GetManifestResourceStream("MagicMirror.Images.09n.gif"));
            images[11] = new System.Drawing.Bitmap(weatherAssembly.GetManifestResourceStream("MagicMirror.Images.10d.gif"));
            images[12] = new System.Drawing.Bitmap(weatherAssembly.GetManifestResourceStream("MagicMirror.Images.10n.gif"));
            images[13] = new System.Drawing.Bitmap(weatherAssembly.GetManifestResourceStream("MagicMirror.Images.11d.gif"));
            images[14] = new System.Drawing.Bitmap(weatherAssembly.GetManifestResourceStream("MagicMirror.Images.11n.gif"));
            images[15] = new System.Drawing.Bitmap(weatherAssembly.GetManifestResourceStream("MagicMirror.Images.13d.gif"));
            images[16] = new System.Drawing.Bitmap(weatherAssembly.GetManifestResourceStream("MagicMirror.Images.13n.gif"));
            images[17] = new System.Drawing.Bitmap(weatherAssembly.GetManifestResourceStream("MagicMirror.Images.50d.gif"));
            images[18] = new System.Drawing.Bitmap(weatherAssembly.GetManifestResourceStream("MagicMirror.Images.50n.gif"));

            return images;
        }
    }
}