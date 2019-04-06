/* 
 * Program.cs
 * 
 * Author: Austin Atteberry
 * 
 * Description: Provides the entry point for
 *              the MagicMirror program
 * 
 */

namespace MagicMirror
{
    public class Program
    {
        /* Creates a Program object */
        public Program(string[] args)
        {
            Gtk.Application.Init();                     // Initialize GTK functions

            ProgWindow mWindow = new ProgWindow();      // Create a MagicWindow object

            Gtk.Application.Run();                      // Launch application
        }

        /* Application's main entry point */
        [System.STAThread]
        public static void Main(string[] args)
        {
            new Program(args);
        }
    }
}
