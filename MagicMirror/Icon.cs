/* 
 * Icon.cs
 * 
 * Author: Austin Atteberry
 * 
 * Description: Initializes the embedded
 *              icon resource
 * 
 */

namespace MagicMirror
{
    public static class Icon
    {
        public static System.Drawing.Icon MainIcon()
        {
            System.Reflection.Assembly IconAssembly = System.Reflection.Assembly.GetExecutingAssembly();
            return new System.Drawing.Icon(IconAssembly.GetManifestResourceStream("MagicMirror.Icon.1.ico"));
        }
    }
}