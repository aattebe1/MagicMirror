/* 
 * Cursor.cs
 * 
 * Author: Austin Atteberry
 * 
 * Description: Initializes the embedded
 *              cursor resource
 * 
 */

namespace MagicMirror
{
	public static class Cursor
    {
		public static System.Windows.Forms.Cursor None()
        {
            System.Reflection.Assembly CursorAssembly = System.Reflection.Assembly.GetExecutingAssembly();
            return new System.Windows.Forms.Cursor(CursorAssembly.GetManifestResourceStream("MagicMirror.Cursor.None.cur"));
        }
    }
}