/* 
 * Icon.cs
 * 
 * Author: Austin Atteberry
 * 
 * Description: Initializes the embedded
 *              icon resource
 * 
 */

namespace MagicMirror3
{
    public static class Icon
    {
        public static System.Drawing.Icon MainIcon()
        {
            System.Reflection.Assembly IconAssembly = System.Reflection.Assembly.GetExecutingAssembly();
            return new System.Drawing.Icon(IconAssembly.GetManifestResourceStream("MagicMirror3.Icon.1.ico"));
        }
    }
}